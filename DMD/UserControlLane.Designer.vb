<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlLane
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlLane))
        Me.Switch = New System.Windows.Forms.Button()
        Me.UserControlLamp1 = New Pinball.UserControlLamp()
        Me.SuspendLayout()
        '
        'Switch
        '
        Me.Switch.BackgroundImage = CType(resources.GetObject("Switch.BackgroundImage"), System.Drawing.Image)
        Me.Switch.Location = New System.Drawing.Point(0, 44)
        Me.Switch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Switch.Name = "Switch"
        Me.Switch.Size = New System.Drawing.Size(30, 80)
        Me.Switch.TabIndex = 1
        Me.Switch.UseVisualStyleBackColor = True
        '
        'UserControlLamp1
        '
        Me.UserControlLamp1.Lamp = Nothing
        Me.UserControlLamp1.Location = New System.Drawing.Point(0, 0)
        Me.UserControlLamp1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.UserControlLamp1.Name = "UserControlLamp1"
        Me.UserControlLamp1.Size = New System.Drawing.Size(30, 30)
        Me.UserControlLamp1.TabIndex = 2
        '
        'UserControlLane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UserControlLamp1)
        Me.Controls.Add(Me.Switch)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UserControlLane"
        Me.Size = New System.Drawing.Size(43, 142)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Switch As Button
    Friend WithEvents UserControlLamp1 As UserControlLamp
End Class
