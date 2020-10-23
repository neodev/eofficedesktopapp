

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.scrnsvr = New System.Windows.Forms.Timer(Me.components)
        Me.lvwFGWindow = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmrGetFgWindow = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstboxhandels = New System.Windows.Forms.ListBox()
        Me.allprocess = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.InactivityTimer = New System.Windows.Forms.Timer(Me.components)
        Me.inactivitylogs = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.authkey = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.project = New System.Windows.Forms.ComboBox()
        Me.task = New System.Windows.Forms.ComboBox()
        Me.Projects = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.syncact = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.autostart = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(236, 360)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 46)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(70, 102)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(327, 19)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "test@test.com"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(70, 223)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(327, 19)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(58, 294)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(201, 24)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Remember login details"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(60, 208)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(340, 53)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(62, 89)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(340, 53)
        Me.TextBox4.TabIndex = 7
        '
        'scrnsvr
        '
        Me.scrnsvr.Interval = 5000
        '
        'lvwFGWindow
        '
        Me.lvwFGWindow.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvwFGWindow.GridLines = True
        Me.lvwFGWindow.HideSelection = False
        Me.lvwFGWindow.Location = New System.Drawing.Point(444, 46)
        Me.lvwFGWindow.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvwFGWindow.Name = "lvwFGWindow"
        Me.lvwFGWindow.Size = New System.Drawing.Size(1360, 213)
        Me.lvwFGWindow.TabIndex = 8
        Me.lvwFGWindow.UseCompatibleStateImageBehavior = False
        Me.lvwFGWindow.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        Me.ColumnHeader1.Width = 97
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Handler"
        Me.ColumnHeader2.Width = 112
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Window Title"
        Me.ColumnHeader3.Width = 112
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Screenshot Name"
        Me.ColumnHeader4.Width = 112
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Description"
        Me.ColumnHeader5.Width = 112
        '
        'tmrGetFgWindow
        '
        Me.tmrGetFgWindow.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(440, 14)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Active Window"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(440, 302)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "All Process"
        '
        'lstboxhandels
        '
        Me.lstboxhandels.HorizontalScrollbar = True
        Me.lstboxhandels.ItemHeight = 20
        Me.lstboxhandels.Location = New System.Drawing.Point(444, 329)
        Me.lstboxhandels.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstboxhandels.Name = "lstboxhandels"
        Me.lstboxhandels.Size = New System.Drawing.Size(1360, 204)
        Me.lstboxhandels.TabIndex = 11
        '
        'allprocess
        '
        Me.allprocess.Interval = 60000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'InactivityTimer
        '
        Me.InactivityTimer.Enabled = True
        '
        'inactivitylogs
        '
        Me.inactivitylogs.FormattingEnabled = True
        Me.inactivitylogs.ItemHeight = 20
        Me.inactivitylogs.Location = New System.Drawing.Point(1450, 603)
        Me.inactivitylogs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inactivitylogs.Name = "inactivitylogs"
        Me.inactivitylogs.Size = New System.Drawing.Size(354, 164)
        Me.inactivitylogs.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1446, 578)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Inactivity Logs"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(58, 494)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(336, 81)
        Me.RichTextBox1.TabIndex = 18
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(285, 802)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 35)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Projects"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'authkey
        '
        Me.authkey.Location = New System.Drawing.Point(60, 454)
        Me.authkey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.authkey.Name = "authkey"
        Me.authkey.Size = New System.Drawing.Size(336, 26)
        Me.authkey.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(60, 365)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(115, 24)
        Me.CheckBox2.TabIndex = 22
        Me.CheckBox2.Text = "Full Screnn"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(62, 400)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(126, 24)
        Me.CheckBox3.TabIndex = 23
        Me.CheckBox3.Text = "Window Size"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'project
        '
        Me.project.DropDownHeight = 150
        Me.project.FormattingEnabled = True
        Me.project.IntegralHeight = False
        Me.project.ItemHeight = 20
        Me.project.Items.AddRange(New Object() {"Givemethevin.com", "PowerBuyer", "Anywebsite", "Eoffice Desktop App"})
        Me.project.Location = New System.Drawing.Point(58, 628)
        Me.project.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.project.Name = "project"
        Me.project.Size = New System.Drawing.Size(338, 28)
        Me.project.TabIndex = 26
        '
        'task
        '
        Me.task.FormattingEnabled = True
        Me.task.Location = New System.Drawing.Point(58, 705)
        Me.task.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.task.Name = "task"
        Me.task.Size = New System.Drawing.Size(338, 28)
        Me.task.TabIndex = 27
        '
        'Projects
        '
        Me.Projects.AutoSize = True
        Me.Projects.Location = New System.Drawing.Point(56, 603)
        Me.Projects.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Projects.Name = "Projects"
        Me.Projects.Size = New System.Drawing.Size(66, 20)
        Me.Projects.TabIndex = 28
        Me.Projects.Text = "Projects"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 680)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Tasks"
        '
        'syncact
        '
        Me.syncact.Interval = 5000
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(444, 603)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(979, 164)
        Me.ListBox1.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(440, 578)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 20)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Screenshots"
        '
        'autostart
        '
        Me.autostart.AutoSize = True
        Me.autostart.Location = New System.Drawing.Point(60, 329)
        Me.autostart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.autostart.Name = "autostart"
        Me.autostart.Size = New System.Drawing.Size(108, 24)
        Me.autostart.TabIndex = 32
        Me.autostart.Text = "Auto Start"
        Me.autostart.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1854, 903)
        Me.Controls.Add(Me.autostart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Projects)
        Me.Controls.Add(Me.task)
        Me.Controls.Add(Me.project)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.authkey)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.inactivitylogs)
        Me.Controls.Add(Me.lstboxhandels)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvwFGWindow)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "E Office"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
    Friend WithEvents scrnsvr As Timer
    Friend WithEvents lvwFGWindow As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents tmrGetFgWindow As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lstboxhandels As ListBox
    Friend WithEvents allprocess As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Private WithEvents InactivityTimer As Timer
    Friend WithEvents inactivitylogs As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents authkey As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents project As ComboBox
    Friend WithEvents task As ComboBox
    Friend WithEvents Projects As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents syncact As Timer
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents autostart As CheckBox
End Class
