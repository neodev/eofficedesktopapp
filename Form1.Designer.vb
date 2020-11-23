

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
        Me.savelogin = New System.Windows.Forms.CheckBox()
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
        Me.autostart = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutEOfficeDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.logout = New System.Windows.Forms.Button()
        Me.afterlogin = New System.Windows.Forms.Panel()
        Me.taskdetailslink = New System.Windows.Forms.LinkLabel()
        Me.autoselproject = New System.Windows.Forms.CheckBox()
        Me.beforelogin = New System.Windows.Forms.Panel()
        Me.desktopshortcut = New System.Windows.Forms.CheckBox()
        Me.autologin = New System.Windows.Forms.CheckBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.initializer = New System.Windows.Forms.Timer(Me.components)
        Me.animate = New System.Windows.Forms.Timer(Me.components)
        Me.internetchkr = New System.Windows.Forms.Timer(Me.components)
        Me.async = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.afterlogin.SuspendLayout()
        Me.beforelogin.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(225, 305)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 46)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(39, 74)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(332, 19)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(37, 194)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(327, 19)
        Me.TextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Email ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 148)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'savelogin
        '
        Me.savelogin.AutoSize = True
        Me.savelogin.Location = New System.Drawing.Point(186, 260)
        Me.savelogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.savelogin.Name = "savelogin"
        Me.savelogin.Size = New System.Drawing.Size(201, 24)
        Me.savelogin.TabIndex = 3
        Me.savelogin.Text = "Remember login details"
        Me.savelogin.UseVisualStyleBackColor = True
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
        Me.lvwFGWindow.Location = New System.Drawing.Point(19, 59)
        Me.lvwFGWindow.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvwFGWindow.Name = "lvwFGWindow"
        Me.lvwFGWindow.Size = New System.Drawing.Size(1085, 213)
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
        Me.ColumnHeader5.Text = "DBID"
        Me.ColumnHeader5.Width = 112
        '
        'tmrGetFgWindow
        '
        Me.tmrGetFgWindow.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Active Window"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 289)
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
        Me.lstboxhandels.Location = New System.Drawing.Point(19, 314)
        Me.lstboxhandels.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstboxhandels.Name = "lstboxhandels"
        Me.lstboxhandels.Size = New System.Drawing.Size(1085, 204)
        Me.lstboxhandels.TabIndex = 11
        '
        'allprocess
        '
        Me.allprocess.Interval = 5000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "My Time Tracker"
        Me.NotifyIcon1.Visible = True
        '
        'InactivityTimer
        '
        Me.InactivityTimer.Enabled = True
        Me.InactivityTimer.Interval = 1000
        '
        'inactivitylogs
        '
        Me.inactivitylogs.FormattingEnabled = True
        Me.inactivitylogs.ItemHeight = 20
        Me.inactivitylogs.Location = New System.Drawing.Point(18, 565)
        Me.inactivitylogs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inactivitylogs.Name = "inactivitylogs"
        Me.inactivitylogs.Size = New System.Drawing.Size(1087, 144)
        Me.inactivitylogs.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 539)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Inactivity Logs"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 782)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(1084, 136)
        Me.RichTextBox1.TabIndex = 18
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(225, 38)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 45)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'authkey
        '
        Me.authkey.Location = New System.Drawing.Point(18, 731)
        Me.authkey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.authkey.Name = "authkey"
        Me.authkey.Size = New System.Drawing.Size(1083, 26)
        Me.authkey.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(829, 21)
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
        Me.CheckBox3.Location = New System.Drawing.Point(978, 21)
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
        Me.project.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.project.FormattingEnabled = True
        Me.project.IntegralHeight = False
        Me.project.ItemHeight = 22
        Me.project.Location = New System.Drawing.Point(19, 140)
        Me.project.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.project.Name = "project"
        Me.project.Size = New System.Drawing.Size(361, 30)
        Me.project.TabIndex = 26
        '
        'task
        '
        Me.task.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.task.FormattingEnabled = True
        Me.task.Location = New System.Drawing.Point(19, 245)
        Me.task.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.task.Name = "task"
        Me.task.Size = New System.Drawing.Size(361, 30)
        Me.task.TabIndex = 27
        '
        'Projects
        '
        Me.Projects.AutoSize = True
        Me.Projects.Location = New System.Drawing.Point(15, 111)
        Me.Projects.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Projects.Name = "Projects"
        Me.Projects.Size = New System.Drawing.Size(66, 20)
        Me.Projects.TabIndex = 28
        Me.Projects.Text = "Projects"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 212)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Tasks"
        '
        'autostart
        '
        Me.autostart.AutoSize = True
        Me.autostart.Location = New System.Drawing.Point(24, 315)
        Me.autostart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.autostart.Name = "autostart"
        Me.autostart.Size = New System.Drawing.Size(108, 24)
        Me.autostart.TabIndex = 32
        Me.autostart.Text = "Auto Start"
        Me.autostart.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(1767, 31)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripSeparator6, Me.ToolStripMenuItem2, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(209, 34)
        Me.ToolStripMenuItem3.Text = "My Account"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(206, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(209, 34)
        Me.ToolStripMenuItem2.Text = "Close"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(206, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(209, 34)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator4, Me.AboutToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem1, Me.ToolStripSeparator2, Me.AboutEOfficeDesktopToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(65, 29)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(296, 34)
        Me.ToolStripMenuItem1.Text = "Keyboard Shortcuts"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(293, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(296, 34)
        Me.AboutToolStripMenuItem.Text = "Give Feedback"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(293, 6)
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(296, 34)
        Me.AboutToolStripMenuItem1.Text = "Contact Support"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(293, 6)
        '
        'AboutEOfficeDesktopToolStripMenuItem
        '
        Me.AboutEOfficeDesktopToolStripMenuItem.Name = "AboutEOfficeDesktopToolStripMenuItem"
        Me.AboutEOfficeDesktopToolStripMenuItem.Size = New System.Drawing.Size(296, 34)
        Me.AboutEOfficeDesktopToolStripMenuItem.Text = "About My Time Tracker"
        '
        'logout
        '
        Me.logout.Location = New System.Drawing.Point(19, 391)
        Me.logout.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.logout.Name = "logout"
        Me.logout.Size = New System.Drawing.Size(163, 45)
        Me.logout.TabIndex = 34
        Me.logout.Text = "Logout"
        Me.logout.UseVisualStyleBackColor = True
        '
        'afterlogin
        '
        Me.afterlogin.Controls.Add(Me.taskdetailslink)
        Me.afterlogin.Controls.Add(Me.autoselproject)
        Me.afterlogin.Controls.Add(Me.project)
        Me.afterlogin.Controls.Add(Me.logout)
        Me.afterlogin.Controls.Add(Me.task)
        Me.afterlogin.Controls.Add(Me.Projects)
        Me.afterlogin.Controls.Add(Me.Label6)
        Me.afterlogin.Controls.Add(Me.Button2)
        Me.afterlogin.Location = New System.Drawing.Point(33, 595)
        Me.afterlogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.afterlogin.Name = "afterlogin"
        Me.afterlogin.Size = New System.Drawing.Size(397, 499)
        Me.afterlogin.TabIndex = 35
        '
        'taskdetailslink
        '
        Me.taskdetailslink.AutoSize = True
        Me.taskdetailslink.Location = New System.Drawing.Point(297, 291)
        Me.taskdetailslink.Name = "taskdetailslink"
        Me.taskdetailslink.Size = New System.Drawing.Size(81, 20)
        Me.taskdetailslink.TabIndex = 40
        Me.taskdetailslink.TabStop = True
        Me.taskdetailslink.Text = "View Task"
        '
        'autoselproject
        '
        Me.autoselproject.AutoSize = True
        Me.autoselproject.Location = New System.Drawing.Point(22, 341)
        Me.autoselproject.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.autoselproject.Name = "autoselproject"
        Me.autoselproject.Size = New System.Drawing.Size(233, 24)
        Me.autoselproject.TabIndex = 38
        Me.autoselproject.Text = "Autoselect Project and Task"
        Me.autoselproject.UseVisualStyleBackColor = True
        '
        'beforelogin
        '
        Me.beforelogin.Controls.Add(Me.desktopshortcut)
        Me.beforelogin.Controls.Add(Me.autologin)
        Me.beforelogin.Controls.Add(Me.LinkLabel2)
        Me.beforelogin.Controls.Add(Me.LinkLabel1)
        Me.beforelogin.Controls.Add(Me.TextBox2)
        Me.beforelogin.Controls.Add(Me.autostart)
        Me.beforelogin.Controls.Add(Me.TextBox1)
        Me.beforelogin.Controls.Add(Me.Label1)
        Me.beforelogin.Controls.Add(Me.Label2)
        Me.beforelogin.Controls.Add(Me.Button1)
        Me.beforelogin.Controls.Add(Me.savelogin)
        Me.beforelogin.Controls.Add(Me.Label5)
        Me.beforelogin.Controls.Add(Me.Label8)
        Me.beforelogin.Location = New System.Drawing.Point(33, 59)
        Me.beforelogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.beforelogin.Name = "beforelogin"
        Me.beforelogin.Size = New System.Drawing.Size(397, 529)
        Me.beforelogin.TabIndex = 36
        '
        'desktopshortcut
        '
        Me.desktopshortcut.AutoSize = True
        Me.desktopshortcut.Location = New System.Drawing.Point(24, 394)
        Me.desktopshortcut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.desktopshortcut.Name = "desktopshortcut"
        Me.desktopshortcut.Size = New System.Drawing.Size(160, 24)
        Me.desktopshortcut.TabIndex = 38
        Me.desktopshortcut.Text = "Desktop Shortcut"
        Me.desktopshortcut.UseVisualStyleBackColor = True
        '
        'autologin
        '
        Me.autologin.AutoSize = True
        Me.autologin.Location = New System.Drawing.Point(24, 355)
        Me.autologin.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.autologin.Name = "autologin"
        Me.autologin.Size = New System.Drawing.Size(112, 24)
        Me.autologin.TabIndex = 41
        Me.autologin.Text = "Auto Login"
        Me.autologin.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(14, 481)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(358, 20)
        Me.LinkLabel2.TabIndex = 39
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Don't have an account? Register for new account"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(246, 148)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(138, 20)
        Me.LinkLabel1.TabIndex = 38
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Forgot Password?"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Window
        Me.Label5.Location = New System.Drawing.Point(26, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(360, 54)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = " USERMAAAEIIII"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(26, 178)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(360, 54)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = " USERMAAAEIIII"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lvwFGWindow)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.lstboxhandels)
        Me.Panel1.Controls.Add(Me.authkey)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.inactivitylogs)
        Me.Panel1.Location = New System.Drawing.Point(496, 59)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1151, 989)
        Me.Panel1.TabIndex = 37
        '
        'initializer
        '
        Me.initializer.Enabled = True
        Me.initializer.Interval = 2000
        '
        'animate
        '
        Me.animate.Interval = 150
        '
        'internetchkr
        '
        Me.internetchkr.Interval = 10000
        '
        'async
        '
        Me.async.Interval = 10000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1767, 1050)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.beforelogin)
        Me.Controls.Add(Me.afterlogin)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "My Time Tracker"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.afterlogin.ResumeLayout(False)
        Me.afterlogin.PerformLayout()
        Me.beforelogin.ResumeLayout(False)
        Me.beforelogin.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents savelogin As CheckBox
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
    Friend WithEvents autostart As CheckBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutEOfficeDesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents logout As Button
    Friend WithEvents afterlogin As Panel
    Friend WithEvents beforelogin As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents taskdetailslink As LinkLabel
    Friend WithEvents autologin As CheckBox
    Friend WithEvents autoselproject As CheckBox
    Friend WithEvents initializer As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents animate As Timer
    Friend WithEvents desktopshortcut As CheckBox
    Friend WithEvents internetchkr As Timer
    Friend WithEvents async As Timer
End Class
