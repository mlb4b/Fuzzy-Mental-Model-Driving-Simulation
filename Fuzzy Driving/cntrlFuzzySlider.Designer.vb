<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cntrlFuzzySlider
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
        lblRightAnchor = New Label()
        lblVal = New Label()
        lblLeftAnchor = New Label()
        lblMid = New Label()
        lblTrack = New Label()
        lblThumb = New Label()
        lblMin = New Label()
        lblMax = New Label()
        SuspendLayout()
        ' 
        ' lblRightAnchor
        ' 
        lblRightAnchor.AutoSize = True
        lblRightAnchor.Location = New Point(845, 5)
        lblRightAnchor.Name = "lblRightAnchor"
        lblRightAnchor.Size = New Size(173, 32)
        lblRightAnchor.TabIndex = 4
        lblRightAnchor.Text = "Completely - 1"
        ' 
        ' lblVal
        ' 
        lblVal.AutoSize = True
        lblVal.Location = New Point(12, 107)
        lblVal.Name = "lblVal"
        lblVal.Size = New Size(27, 32)
        lblVal.TabIndex = 5
        lblVal.Text = "0"
        lblVal.TextAlign = ContentAlignment.TopCenter
        lblVal.Visible = False
        ' 
        ' lblLeftAnchor
        ' 
        lblLeftAnchor.AutoSize = True
        lblLeftAnchor.Location = New Point(12, 6)
        lblLeftAnchor.Name = "lblLeftAnchor"
        lblLeftAnchor.Size = New Size(155, 32)
        lblLeftAnchor.TabIndex = 6
        lblLeftAnchor.Text = "0 - Not At All"
        ' 
        ' lblMid
        ' 
        lblMid.BackColor = SystemColors.ControlDark
        lblMid.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMid.ForeColor = SystemColors.ControlDark
        lblMid.Location = New Point(514, 16)
        lblMid.Margin = New Padding(0)
        lblMid.Name = "lblMid"
        lblMid.Size = New Size(1, 38)
        lblMid.TabIndex = 6
        ' 
        ' lblTrack
        ' 
        lblTrack.BackColor = SystemColors.Control
        lblTrack.BorderStyle = BorderStyle.FixedSingle
        lblTrack.CausesValidation = False
        lblTrack.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTrack.ForeColor = SystemColors.ControlDarkDark
        lblTrack.Location = New Point(19, 72)
        lblTrack.Margin = New Padding(0)
        lblTrack.Name = "lblTrack"
        lblTrack.Size = New Size(989, 10)
        lblTrack.TabIndex = 7
        ' 
        ' lblThumb
        ' 
        lblThumb.BackColor = SystemColors.Highlight
        lblThumb.BorderStyle = BorderStyle.FixedSingle
        lblThumb.CausesValidation = False
        lblThumb.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblThumb.ForeColor = SystemColors.ControlDarkDark
        lblThumb.Location = New Point(19, 50)
        lblThumb.Margin = New Padding(0)
        lblThumb.Name = "lblThumb"
        lblThumb.Size = New Size(10, 53)
        lblThumb.TabIndex = 7
        lblThumb.Visible = False
        ' 
        ' lblMin
        ' 
        lblMin.BackColor = SystemColors.ControlDark
        lblMin.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMin.ForeColor = SystemColors.ControlDark
        lblMin.Location = New Point(24, 44)
        lblMin.Margin = New Padding(0)
        lblMin.Name = "lblMin"
        lblMin.Size = New Size(1, 10)
        lblMin.TabIndex = 8
        ' 
        ' lblMax
        ' 
        lblMax.BackColor = SystemColors.ControlDark
        lblMax.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMax.ForeColor = SystemColors.ControlDark
        lblMax.Location = New Point(1004, 44)
        lblMax.Margin = New Padding(0)
        lblMax.Name = "lblMax"
        lblMax.Size = New Size(1, 10)
        lblMax.TabIndex = 9
        ' 
        ' cntrlFuzzySlider
        ' 
        AutoScaleDimensions = New SizeF(13.0F, 32.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblThumb)
        Controls.Add(lblMax)
        Controls.Add(lblMin)
        Controls.Add(lblTrack)
        Controls.Add(lblRightAnchor)
        Controls.Add(lblVal)
        Controls.Add(lblMid)
        Controls.Add(lblLeftAnchor)
        Name = "cntrlFuzzySlider"
        Size = New Size(1032, 145)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRightAnchor As Label
    Friend WithEvents lblVal As Label
    Friend WithEvents lblLeftAnchor As Label
    Friend WithEvents lblMid As Label
    Friend WithEvents lblTrack As Label
    Friend WithEvents lblThumb As Label
    Friend WithEvents lblMin As Label
    Friend WithEvents lblMax As Label

End Class
