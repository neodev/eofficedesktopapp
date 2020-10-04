<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.scrnsvr = New System.Windows.Forms.Timer(Me.components)
        Me.actvprcs = New System.Windows.Forms.Timer(Me.components)
        Me.txtTextToSend = New System.Windows.Forms.TextBox()
        Me.ButSendText = New System.Windows.Forms.Button()
        Me.ButGetAllPorccess = New System.Windows.Forms.Button()
        Me.lstboxhandels = New System.Windows.Forms.ListBox()
        Me.LstBoxHWNDCaptions = New System.Windows.Forms.ListBox()
        Me.actvwndw = New System.Windows.Forms.Timer(Me.components)
        Me.lvwFGWindow = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.traffic = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(157, 288)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(47, 119)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 13)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(48, 194)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(218, 13)
        Me.TextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(43, 246)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(135, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Remember login details"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(41, 183)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(227, 38)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(41, 108)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(227, 38)
        Me.TextBox4.TabIndex = 7
        '
        'Timer1
        '
        Me.Timer1.Interval = 6000
        '
        'scrnsvr
        '
        Me.scrnsvr.Enabled = True
        Me.scrnsvr.Interval = 1000
        '
        'actvprcs
        '
        Me.actvprcs.Enabled = True
        Me.actvprcs.Interval = 1000
        '
        'txtTextToSend
        '
        Me.txtTextToSend.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtTextToSend.Location = New System.Drawing.Point(48, 404)
        Me.txtTextToSend.Name = "txtTextToSend"
        Me.txtTextToSend.Size = New System.Drawing.Size(352, 20)
        Me.txtTextToSend.TabIndex = 12
        Me.txtTextToSend.Text = "TEXT TO SEND"
        '
        'ButSendText
        '
        Me.ButSendText.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.ButSendText.Location = New System.Drawing.Point(48, 366)
        Me.ButSendText.Name = "ButSendText"
        Me.ButSendText.Size = New System.Drawing.Size(120, 32)
        Me.ButSendText.TabIndex = 11
        Me.ButSendText.Text = "Send Text To Selected Application"
        '
        'ButGetAllPorccess
        '
        Me.ButGetAllPorccess.Location = New System.Drawing.Point(272, 365)
        Me.ButGetAllPorccess.Name = "ButGetAllPorccess"
        Me.ButGetAllPorccess.Size = New System.Drawing.Size(128, 32)
        Me.ButGetAllPorccess.TabIndex = 10
        Me.ButGetAllPorccess.Text = "Show Proccesses On This PC"
        '
        'lstboxhandels
        '
        Me.lstboxhandels.Enabled = False
        Me.lstboxhandels.Location = New System.Drawing.Point(41, 91)
        Me.lstboxhandels.Name = "lstboxhandels"
        Me.lstboxhandels.Size = New System.Drawing.Size(144, 238)
        Me.lstboxhandels.TabIndex = 9
        '
        'LstBoxHWNDCaptions
        '
        Me.LstBoxHWNDCaptions.Location = New System.Drawing.Point(358, 87)
        Me.LstBoxHWNDCaptions.Name = "LstBoxHWNDCaptions"
        Me.LstBoxHWNDCaptions.Size = New System.Drawing.Size(224, 238)
        Me.LstBoxHWNDCaptions.TabIndex = 8
        '
        'actvwndw
        '
        Me.actvwndw.Enabled = True
        Me.actvwndw.Interval = 1000
        '
        'lvwFGWindow
        '
        Me.lvwFGWindow.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.lvwFGWindow.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwFGWindow.GridLines = True
        Me.lvwFGWindow.HideSelection = False
        Me.lvwFGWindow.Location = New System.Drawing.Point(358, 34)
        Me.lvwFGWindow.Name = "lvwFGWindow"
        Me.lvwFGWindow.Size = New System.Drawing.Size(574, 315)
        Me.lvwFGWindow.TabIndex = 13
        Me.lvwFGWindow.UseCompatibleStateImageBehavior = False
        Me.lvwFGWindow.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Window"
        '
        'traffic
        '
        Me.traffic.Enabled = True
        Me.traffic.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Label4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 471)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvwFGWindow)
        Me.Controls.Add(Me.txtTextToSend)
        Me.Controls.Add(Me.ButSendText)
        Me.Controls.Add(Me.ButGetAllPorccess)
        Me.Controls.Add(Me.lstboxhandels)
        Me.Controls.Add(Me.LstBoxHWNDCaptions)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Name = "Form1"
        Me.Text = "E Office"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents scrnsvr As Timer
    Friend WithEvents actvprcs As Timer
    Friend WithEvents txtTextToSend As TextBox
    Friend WithEvents ButSendText As Button
    Friend WithEvents ButGetAllPorccess As Button
    Friend WithEvents lstboxhandels As ListBox
    Friend WithEvents LstBoxHWNDCaptions As ListBox
    Friend WithEvents actvwndw As Timer
    Friend WithEvents lvwFGWindow As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents traffic As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
