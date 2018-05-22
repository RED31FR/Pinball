<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlBumper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlBumper))
        Me.BumperPicture = New System.Windows.Forms.PictureBox()
        CType(Me.BumperPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BumperPicture
        '
        Me.BumperPicture.BackColor = System.Drawing.Color.Yellow
        Me.BumperPicture.BackgroundImage = CType(resources.GetObject("BumperPicture.BackgroundImage"), System.Drawing.Image)
        Me.BumperPicture.Location = New System.Drawing.Point(0, 0)
        Me.BumperPicture.Name = "BumperPicture"
        Me.BumperPicture.Size = New System.Drawing.Size(60, 60)
        Me.BumperPicture.TabIndex = 0
        Me.BumperPicture.TabStop = False
        '
        'UserControlBumper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BumperPicture)
        Me.Name = "UserControlBumper"
        CType(Me.BumperPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BumperPicture As PictureBox
End Class
