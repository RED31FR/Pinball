<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlCPinball
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.UserControlDMDInfo = New Pinball.UserControlDMD()
        Me.UserControlDMDScore = New Pinball.UserControlDMD()
        Me.SuspendLayout()
        '
        'UserControlDMDInfo
        '
        Me.UserControlDMDInfo.DMD = Nothing
        Me.UserControlDMDInfo.Interval = 100
        Me.UserControlDMDInfo.Location = New System.Drawing.Point(0, 106)
        Me.UserControlDMDInfo.Name = "UserControlDMDInfo"
        Me.UserControlDMDInfo.Size = New System.Drawing.Size(150, 58)
        Me.UserControlDMDInfo.TabIndex = 1
        '
        'UserControlDMDScore
        '
        Me.UserControlDMDScore.DMD = Nothing
        Me.UserControlDMDScore.Interval = 100
        Me.UserControlDMDScore.Location = New System.Drawing.Point(0, 0)
        Me.UserControlDMDScore.Name = "UserControlDMDScore"
        Me.UserControlDMDScore.Size = New System.Drawing.Size(150, 71)
        Me.UserControlDMDScore.TabIndex = 0
        '
        'UserControlCPinball
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UserControlDMDInfo)
        Me.Controls.Add(Me.UserControlDMDScore)
        Me.Name = "UserControlCPinball"
        Me.Size = New System.Drawing.Size(164, 191)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserControlDMDScore As UserControlDMD
    Friend WithEvents UserControlDMDInfo As UserControlDMD
End Class
