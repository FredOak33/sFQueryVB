Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Linq
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq


Public Class frmMain
    Public indexU As Integer
    Private _dt As New DataTable
    Private _tbl2 As New DataTable

    Public Property Dt As DataTable
        Get
            Return _dt
        End Get
        Set(value As DataTable)
            _dt = value
        End Set
    End Property
    Public Property tbl2 As DataTable
        Get
            Return _tbl2
        End Get
        Set(value As DataTable)
            _tbl2 = value
        End Set
    End Property

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        SalesFile()

        Dt.Columns.Add("id", GetType(Integer))
        Dt.Columns.Add("uID", GetType(String))
        Dt.Columns.Add("YID", GetType(String))
        Dt.Columns.Add("User", GetType(String))
        Dt.Columns.Add("Status", GetType(String))
        Dt.Columns.Add("CC", GetType(String))
        Dt.Columns.Add("Level1", GetType(String))

    End Sub

    Public Sub AddPerson()

        Dt.Rows.Add(indexU, txtuID.Text, txtYID.Text, txtUser.Text, txtStatus.Text, txtCC.Text, txtLevel1.Text)

        txtUser.Text = ""
        txtuID.Text = ""
        txtYID.Text = ""
        txtStatus.Text = ""
        txtCC.Text = ""
        txtLevel1.Text = ""
    End Sub
    Private Sub btnGO_Click(sender As Object, e As EventArgs) Handles btnGO.Click
        Dim FILE_NAME As String = "C:\Users\y15645\Documents\Fusion\WriteLines2.txt"
        Dim user As String = ""
        Dim TextLine As String = ""


        indexU = 1
        Dim NLen As Integer = 0

        For Each line As String In File.ReadLines("C:\Users\y15645\Documents\Fusion\WriteLines2.txt")
            If line.Contains(Chr(34) & "url") Then
                txtuID.Text = Microsoft.VisualBasic.Mid(line, 65, 18)
            End If

            If line.Contains("Name") Then
                txtUser.Text = Microsoft.VisualBasic.Mid(line, 15, 55)
                NLen = Microsoft.VisualBasic.Len(txtUser.Text)
                txtUser.Text = Microsoft.VisualBasic.Mid(txtUser.Text, 1, NLen - 2)
            End If

            If line.Contains("YID__c") Then
                txtYID.Text = Microsoft.VisualBasic.Mid(line, 17, 6)
            End If

            If line.Contains("Status") Then
                line.Replace("""", "")
                txtStatus.Text = Microsoft.VisualBasic.Mid(line, 19, 10)
                If txtStatus.Text = Chr(34) & "Active" & Chr(34) Then
                    txtStatus.Text = "Active"
                End If
            End If

            If line.Contains("Cost_Center__c") Then
                txtCC.Text = Microsoft.VisualBasic.Mid(line, 25, 4)
            End If

            If line.Contains("Level_1_Supervisor_ID__c") Then
                txtLevel1.Text = Microsoft.VisualBasic.Mid(line, 35, 6)
            End If

            If txtuID.Text > "" And txtYID.Text > "" And txtUser.Text > "" And txtStatus.Text > "" And txtCC.Text > "" And txtLevel1.Text > "" Then
                AddPerson()
                indexU = indexU + 1
            End If
        Next

        'dgAPI.DataSource = Dt
        'Dt.Dispose()
        ConvertCSVToDataSet()
        CompareDataTables(Dt, tbl2)
    End Sub

    Public Function CreateClient() As SalesforceClient
        Return New SalesforceClient With {
            .Username = ConfigurationManager.AppSettings("username"),
            .Password = ConfigurationManager.AppSettings("password"),
            .Token = ConfigurationManager.AppSettings("token"),
            .ClientId = ConfigurationManager.AppSettings("clientId"),
            .ClientSecret = ConfigurationManager.AppSettings("clientSecret")
        }
    End Function

    Private Sub SalesFile()
        Dim client = CreateClient()

        client.Login()
        System.IO.File.WriteAllText("C:\Users\y15645\Documents\Fusion\WriteLines2.txt", "")

        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("C:\Users\y15645\Documents\Fusion\WriteLines2.txt", True)

            If True Then
                file.WriteLine(client.Query("SELECT Name, YID__c, Status__c,Cost_Center__c,Level_1_Supervisor_ID__c from FF__Key_Contact__c"))
            End If
        End Using

    End Sub

    Private Sub ConvertCSVToDataSet()
        Dim reader As StreamReader
        reader = New StreamReader("H:\Fusion_Employee_Key_Contacts.csv")
        'Dim tbl2 As DataTable = New DataTable
        Dim currentLine As String = ""
        Dim id As Integer = 1
        'currentLine = reader.ReadLine
        Dim firstLine As Boolean = True
        Dim regex As Object
        regex = CreateObject("vbscript.regexp")
        regex.IgnoreCase = True
        regex.Global = True
        Dim splitline2 As String()
        Dim reader2 As StreamReader = New StreamReader(File.OpenRead("H:\Fusion_Employee_Key_Contacts.csv"))
        Dim lineCount As Integer = 0

        While reader2.ReadLine() IsNot Nothing
            lineCount += 1
            If lineCount Mod 1000 = 0 Then Console.WriteLine(lineCount)
        End While

        regex.Pattern = ",(?=([^" & Chr(34) & "]*" & Chr(34) & "[^" & Chr(34) & "]*" & Chr(34) & ")*(?![^" & Chr(34) & "]*" & Chr(34) & "))"
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("H:\Fusion_Employee_Key_Contacts.csv")

            While id < lineCount
                If firstLine Then
                    firstLine = False
                    Dim cols = reader.ReadLine.Split(",")
                    For Each col In cols
                        tbl2.Columns.Add(New DataColumn(col, GetType(String)))
                    Next
                Else
                    splitline2 = Split(regex.Replace((reader.ReadLine), ";"), ";")
                    tbl2.Rows.Add(splitline2)
                    id = id + 1
                End If
            End While

            tbl2.Columns.Add("ID", GetType(String))
            tbl2.Columns("ID").DefaultValue = 0
            tbl2.Columns("ID").SetOrdinal(0)

            id = 2

            Dim i As Integer
            For i = 0 To tbl2.Rows.Count - 1 Step 1
                tbl2.Rows(i)("ID") = id
            Next

            'dgPeople.DataSource = tbl2
        End Using

    End Sub

    Private Sub CompareDataTables(ByVal dt1 As DataTable, ByVal dt2 As DataTable)
        Dim ChangesDataTable As New DataTable

        With ChangesDataTable
            .Columns.Add("YID")
            .Columns.Add("NAME")
            .Columns.Add("STATUS")
            .Columns.Add("CC")
            .Columns.Add("Level1")
        End With
        Dim rowArray As DataRow()
        Dim rowAdd As DataRow

        'If dt1 is the original
        For Each row In dt2.Rows
            rowArray = dt1.Select("YID = '" & Mid(row(1).ToString, 2, 6) & "'")

            If rowArray.Length > 0 Then
                'compare fields
                'if changes
                If Mid(row(6).ToString, 2, 10) = "Terminated" Then
                    rowAdd = ChangesDataTable.NewRow
                    rowAdd("YID") = Mid(row(1).ToString, 2, 6)
                    rowAdd("NAME") = row(5).ToString
                    rowAdd("STATUS") = Mid(row(6).ToString, 2, 10)
                    ChangesDataTable.Rows.Add(rowAdd)
                End If


                If Mid(row(15).ToString, 2, 4) <> rowArray(0).Item(5).ToString Then
                    rowAdd = ChangesDataTable.NewRow
                    rowAdd("YID") = Mid(row(1).ToString, 2, 6)
                    rowAdd("NAME") = row(5).ToString
                    rowAdd("STATUS") = Mid(row(6).ToString, 2, 10)
                    rowAdd("CC") = Mid(row(15).ToString, 2, 4)
                    ChangesDataTable.Rows.Add(rowAdd)
                End If

                If Mid(row(36).ToString, 2, 4) <> rowArray(0).Item(6).ToString Then
                    rowAdd = ChangesDataTable.NewRow
                    rowAdd("YID") = Mid(row(1).ToString, 2, 6)
                    rowAdd("NAME") = row(5).ToString
                    rowAdd("STATUS") = Mid(row(6).ToString, 2, 10)
                    rowAdd("LEVEL1") = Mid(row(36).ToString, 2, 6)
                    ChangesDataTable.Rows.Add(rowAdd)
                End If
            End If
        Next
        dgChange.DataSource = ChangesDataTable
    End Sub


End Class
