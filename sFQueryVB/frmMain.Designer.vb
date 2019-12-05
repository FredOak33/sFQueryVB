<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnGO = New System.Windows.Forms.Button()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtuID = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtYID = New System.Windows.Forms.TextBox()
        Me.dgChange = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.txtLevel1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGO
        '
        Me.btnGO.Location = New System.Drawing.Point(12, 39)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(75, 23)
        Me.btnGO.TabIndex = 1
        Me.btnGO.Text = "GO"
        Me.btnGO.UseVisualStyleBackColor = True
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(12, 106)
        Me.txtUser.Multiline = True
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(51, 19)
        Me.txtUser.TabIndex = 2
        Me.txtUser.Visible = False
        '
        'txtuID
        '
        Me.txtuID.Location = New System.Drawing.Point(12, 68)
        Me.txtuID.Multiline = True
        Me.txtuID.Name = "txtuID"
        Me.txtuID.Size = New System.Drawing.Size(51, 19)
        Me.txtuID.TabIndex = 3
        Me.txtuID.Visible = False
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(12, 144)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(51, 19)
        Me.txtStatus.TabIndex = 4
        Me.txtStatus.Visible = False
        '
        'txtYID
        '
        Me.txtYID.Location = New System.Drawing.Point(12, 182)
        Me.txtYID.Multiline = True
        Me.txtYID.Name = "txtYID"
        Me.txtYID.Size = New System.Drawing.Size(51, 19)
        Me.txtYID.TabIndex = 5
        Me.txtYID.Visible = False
        '
        'dgChange
        '
        Me.dgChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgChange.Location = New System.Drawing.Point(79, 68)
        Me.dgChange.Name = "dgChange"
        Me.dgChange.Size = New System.Drawing.Size(939, 370)
        Me.dgChange.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "TERMINATED"
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(12, 216)
        Me.txtCC.Multiline = True
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(51, 19)
        Me.txtCC.TabIndex = 9
        Me.txtCC.Visible = False
        '
        'txtLevel1
        '
        Me.txtLevel1.Location = New System.Drawing.Point(12, 250)
        Me.txtLevel1.Multiline = True
        Me.txtLevel1.Name = "txtLevel1"
        Me.txtLevel1.Size = New System.Drawing.Size(51, 19)
        Me.txtLevel1.TabIndex = 10
        Me.txtLevel1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(421, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "CC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(495, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 25)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Level 1 Supervisor"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 444)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLevel1)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgChange)
        Me.Controls.Add(Me.txtYID)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtuID)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.btnGO)
        Me.Name = "frmMain"
        Me.Text = "SfQueryVB"
        CType(Me.dgChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGO As Button
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtuID As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtYID As TextBox
    Friend WithEvents dgChange As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCC As TextBox
    Friend WithEvents txtLevel1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
