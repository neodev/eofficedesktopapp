<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupForm
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
        Me.CancelFormButton = New System.Windows.Forms.Button()
        Me.CloseAppButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CancelFormButton
        '
        Me.CancelFormButton.Location = New System.Drawing.Point(22, 15)
        Me.CancelFormButton.Name = "CancelFormButton"
        Me.CancelFormButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelFormButton.TabIndex = 0
        Me.CancelFormButton.Text = "Cancel"
        Me.CancelFormButton.UseVisualStyleBackColor = True
        '
        'CloseAppButton
        '
        Me.CloseAppButton.Location = New System.Drawing.Point(134, 15)
        Me.CloseAppButton.Name = "CloseAppButton"
        Me.CloseAppButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseAppButton.TabIndex = 1
        Me.CloseAppButton.Text = "Close App"
        Me.CloseAppButton.UseVisualStyleBackColor = True
        '
        'PopupForm
        '
        Me.AcceptButton = Me.CancelFormButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 52)
        Me.Controls.Add(Me.CloseAppButton)
        Me.Controls.Add(Me.CancelFormButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PopupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tray Application Dialog"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CloseAppButton As System.Windows.Forms.Button
    Friend WithEvents CancelFormButton As System.Windows.Forms.Button
End Class
