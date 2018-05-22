<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlLanes
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
        Me.ButtonRight = New System.Windows.Forms.Button()
        Me.ButtonLeft = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonRight
        '
        Me.ButtonRight.Location = New System.Drawing.Point(134, 47)
        Me.ButtonRight.Name = "ButtonRight"
        Me.ButtonRight.Size = New System.Drawing.Size(13, 46)
        Me.ButtonRight.TabIndex = 0
        Me.ButtonRight.Text = ">"
        Me.ButtonRight.UseVisualStyleBackColor = True
        '
        'ButtonLeft
        '
        Me.ButtonLeft.Location = New System.Drawing.Point(3, 47)
        Me.ButtonLeft.Name = "ButtonLeft"
        Me.ButtonLeft.Size = New System.Drawing.Size(13, 46)
        Me.ButtonLeft.TabIndex = 1
        Me.ButtonLeft.Text = "<"
        Me.ButtonLeft.UseVisualStyleBackColor = True
        '
        'UserControlLanes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ButtonLeft)
        Me.Controls.Add(Me.ButtonRight)
        Me.Name = "UserControlLanes"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonRight As Button
    Friend WithEvents ButtonLeft As Button
End Class
