﻿

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
        Me.autostart = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.autoselproject = New System.Windows.Forms.CheckBox()
        Me.taskdetailslink = New System.Windows.Forms.LinkLabel()
        Me.beforelogin = New System.Windows.Forms.Panel()
        Me.autologin = New System.Windows.Forms.CheckBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.afterlogin.SuspendLayout()
        Me.beforelogin.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(195, 293)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 37)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(31, 55)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(295, 15)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "test@test.com"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(31, 153)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(291, 16)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(21, 220)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(178, 21)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Remember login details"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(21, 140)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(318, 43)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(23, 46)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(317, 43)
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
        Me.lvwFGWindow.Location = New System.Drawing.Point(17, 47)
        Me.lvwFGWindow.Margin = New System.Windows.Forms.Padding(4)
        Me.lvwFGWindow.Name = "lvwFGWindow"
        Me.lvwFGWindow.Size = New System.Drawing.Size(1209, 171)
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
        Me.Label3.Location = New System.Drawing.Point(13, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Active Window"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 231)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "All Process"
        '
        'lstboxhandels
        '
        Me.lstboxhandels.HorizontalScrollbar = True
        Me.lstboxhandels.ItemHeight = 16
        Me.lstboxhandels.Location = New System.Drawing.Point(17, 258)
        Me.lstboxhandels.Margin = New System.Windows.Forms.Padding(4)
        Me.lstboxhandels.Name = "lstboxhandels"
        Me.lstboxhandels.Size = New System.Drawing.Size(1209, 164)
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
        Me.inactivitylogs.ItemHeight = 16
        Me.inactivitylogs.Location = New System.Drawing.Point(912, 464)
        Me.inactivitylogs.Margin = New System.Windows.Forms.Padding(4)
        Me.inactivitylogs.Name = "inactivitylogs"
        Me.inactivitylogs.Size = New System.Drawing.Size(315, 164)
        Me.inactivitylogs.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(909, 444)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Inactivity Logs"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(17, 518)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(871, 110)
        Me.RichTextBox1.TabIndex = 18
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(224, 26)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 36)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'authkey
        '
        Me.authkey.Location = New System.Drawing.Point(17, 464)
        Me.authkey.Margin = New System.Windows.Forms.Padding(4)
        Me.authkey.Name = "authkey"
        Me.authkey.Size = New System.Drawing.Size(871, 22)
        Me.authkey.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(979, 18)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(101, 21)
        Me.CheckBox2.TabIndex = 22
        Me.CheckBox2.Text = "Full Screnn"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(1111, 18)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(110, 21)
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
        Me.project.ItemHeight = 18
        Me.project.Location = New System.Drawing.Point(17, 112)
        Me.project.Margin = New System.Windows.Forms.Padding(4)
        Me.project.Name = "project"
        Me.project.Size = New System.Drawing.Size(321, 26)
        Me.project.TabIndex = 26
        '
        'task
        '
        Me.task.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.task.FormattingEnabled = True
        Me.task.Location = New System.Drawing.Point(17, 196)
        Me.task.Margin = New System.Windows.Forms.Padding(4)
        Me.task.Name = "task"
        Me.task.Size = New System.Drawing.Size(321, 26)
        Me.task.TabIndex = 27
        '
        'Projects
        '
        Me.Projects.AutoSize = True
        Me.Projects.Location = New System.Drawing.Point(16, 89)
        Me.Projects.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Projects.Name = "Projects"
        Me.Projects.Size = New System.Drawing.Size(59, 17)
        Me.Projects.TabIndex = 28
        Me.Projects.Text = "Projects"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 170)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 17)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Tasks"
        '
        'syncact
        '
        Me.syncact.Interval = 5000
        '
        'autostart
        '
        Me.autostart.AutoSize = True
        Me.autostart.Location = New System.Drawing.Point(21, 261)
        Me.autostart.Margin = New System.Windows.Forms.Padding(4)
        Me.autostart.Name = "autostart"
        Me.autostart.Size = New System.Drawing.Size(93, 21)
        Me.autostart.TabIndex = 32
        Me.autostart.Text = "Auto Start"
        Me.autostart.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(414, 28)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripSeparator6, Me.ToolStripMenuItem2, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(170, 26)
        Me.ToolStripMenuItem3.Text = "My Account"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(167, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(170, 26)
        Me.ToolStripMenuItem2.Text = "Close"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(167, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(170, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator4, Me.AboutToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem1, Me.ToolStripSeparator2, Me.AboutEOfficeDesktopToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(248, 26)
        Me.ToolStripMenuItem1.Text = "Keyboard Shortcuts"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(245, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.AboutToolStripMenuItem.Text = "Give Feddback"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(245, 6)
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(248, 26)
        Me.AboutToolStripMenuItem1.Text = "Conatct Support"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(245, 6)
        '
        'AboutEOfficeDesktopToolStripMenuItem
        '
        Me.AboutEOfficeDesktopToolStripMenuItem.Name = "AboutEOfficeDesktopToolStripMenuItem"
        Me.AboutEOfficeDesktopToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.AboutEOfficeDesktopToolStripMenuItem.Text = "About E Office Desktop"
        '
        'logout
        '
        Me.logout.Location = New System.Drawing.Point(20, 323)
        Me.logout.Margin = New System.Windows.Forms.Padding(4)
        Me.logout.Name = "logout"
        Me.logout.Size = New System.Drawing.Size(145, 36)
        Me.logout.TabIndex = 34
        Me.logout.Text = "Logout"
        Me.logout.UseVisualStyleBackColor = True
        '
        'afterlogin
        '
        Me.afterlogin.Controls.Add(Me.autoselproject)
        Me.afterlogin.Controls.Add(Me.taskdetailslink)
        Me.afterlogin.Controls.Add(Me.project)
        Me.afterlogin.Controls.Add(Me.logout)
        Me.afterlogin.Controls.Add(Me.task)
        Me.afterlogin.Controls.Add(Me.Projects)
        Me.afterlogin.Controls.Add(Me.Label6)
        Me.afterlogin.Controls.Add(Me.Button2)
        Me.afterlogin.Location = New System.Drawing.Point(29, 477)
        Me.afterlogin.Margin = New System.Windows.Forms.Padding(4)
        Me.afterlogin.Name = "afterlogin"
        Me.afterlogin.Size = New System.Drawing.Size(353, 362)
        Me.afterlogin.TabIndex = 35
        '
        'autoselproject
        '
        Me.autoselproject.AutoSize = True
        Me.autoselproject.Location = New System.Drawing.Point(20, 274)
        Me.autoselproject.Name = "autoselproject"
        Me.autoselproject.Size = New System.Drawing.Size(207, 21)
        Me.autoselproject.TabIndex = 38
        Me.autoselproject.Text = "Autoselect Project and Task"
        Me.autoselproject.UseVisualStyleBackColor = True
        '
        'taskdetailslink
        '
        Me.taskdetailslink.AutoSize = True
        Me.taskdetailslink.Location = New System.Drawing.Point(221, 233)
        Me.taskdetailslink.Name = "taskdetailslink"
        Me.taskdetailslink.Size = New System.Drawing.Size(119, 17)
        Me.taskdetailslink.TabIndex = 40
        Me.taskdetailslink.TabStop = True
        Me.taskdetailslink.Text = "View Task Details"
        Me.taskdetailslink.Visible = False
        '
        'beforelogin
        '
        Me.beforelogin.Controls.Add(Me.autologin)
        Me.beforelogin.Controls.Add(Me.LinkLabel2)
        Me.beforelogin.Controls.Add(Me.LinkLabel1)
        Me.beforelogin.Controls.Add(Me.TextBox2)
        Me.beforelogin.Controls.Add(Me.autostart)
        Me.beforelogin.Controls.Add(Me.TextBox3)
        Me.beforelogin.Controls.Add(Me.TextBox1)
        Me.beforelogin.Controls.Add(Me.Label1)
        Me.beforelogin.Controls.Add(Me.Label2)
        Me.beforelogin.Controls.Add(Me.Button1)
        Me.beforelogin.Controls.Add(Me.CheckBox1)
        Me.beforelogin.Controls.Add(Me.TextBox4)
        Me.beforelogin.Location = New System.Drawing.Point(29, 46)
        Me.beforelogin.Margin = New System.Windows.Forms.Padding(4)
        Me.beforelogin.Name = "beforelogin"
        Me.beforelogin.Size = New System.Drawing.Size(353, 423)
        Me.beforelogin.TabIndex = 36
        '
        'autologin
        '
        Me.autologin.AutoSize = True
        Me.autologin.Location = New System.Drawing.Point(20, 302)
        Me.autologin.Name = "autologin"
        Me.autologin.Size = New System.Drawing.Size(98, 21)
        Me.autologin.TabIndex = 41
        Me.autologin.Text = "Auto Login"
        Me.autologin.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 385)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(319, 17)
        Me.LinkLabel2.TabIndex = 39
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Don't have an account? Register for new account"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(221, 118)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(122, 17)
        Me.LinkLabel1.TabIndex = 38
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Forgot Password?"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lvwFGWindow)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.lstboxhandels)
        Me.Panel1.Controls.Add(Me.authkey)
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.inactivitylogs)
        Me.Panel1.Location = New System.Drawing.Point(573, 48)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1281, 671)
        Me.Panel1.TabIndex = 37
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 875)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.beforelogin)
        Me.Controls.Add(Me.afterlogin)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "E Office"
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
    Friend WithEvents autostart As CheckBox
    Friend WithEvents Timer1 As Timer
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
End Class
