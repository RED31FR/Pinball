<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlSwitch
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ButtonSwitch = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonSwitch
        '
        Me.ButtonSwitch.Location = New System.Drawing.Point(0, 0)
        Me.ButtonSwitch.Name = "ButtonSwitch"
        Me.ButtonSwitch.Size = New System.Drawing.Size(30, 30)
        Me.ButtonSwitch.TabIndex = 0
        Me.ButtonSwitch.UseVisualStyleBackColor = True
        '
        'UserControlSwitch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonSwitch)
        Me.Name = "UserControlSwitch"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonSwitch As Button
End Class
