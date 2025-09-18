Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class cntrlFuzzySlider

    Private Const MAX As Double = 1.0
    Private Const MIN As Double = 0.0

    Private minThumbLeft As Long
    Private maxThmubLeft As Long

    Dim theValue As Double = (MIN + MAX) / 2
    Public Property Value As Double
        Get
            Return theValue
        End Get
        Set(ByVal newValue As Double)
            theValue = newValue
            setPosition()
        End Set
    End Property

    Public ReadOnly Property Minimum As Double
        Get
            Return MIN
        End Get
    End Property

    Public ReadOnly Property Maximum As Double
        Get
            Return MAX
        End Get
    End Property

    Public ReadOnly Property ValSet As Boolean
        Get
            Return lblThumb.Visible
        End Get
    End Property

    Private Sub cntrlFuzzySlider_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        Me.UpdateStyles()

        AttachHandlersRecursive(Me)
    End Sub

    Private Sub AttachHandlersRecursive(parent As Control)
        For Each ctrl As Control In parent.Controls
            AddHandler ctrl.MouseDown, AddressOf ForwardMouseX
            AddHandler ctrl.Click, AddressOf ForwardMouseX
            AddHandler ctrl.MouseMove, AddressOf ForwardMouseMove
            AttachHandlersRecursive(ctrl)
        Next
    End Sub

    Private Sub ForwardMouseX(sender As Object, e As MouseEventArgs)
        Dim screenPoint As Point = CType(sender, Control).PointToScreen(New Point(e.X, e.Y))
        Dim localPoint As Point = Me.PointToClient(screenPoint)
        setValueFromMouse(localPoint.X)
    End Sub

    Private Sub ForwardMouseMove(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ForwardMouseX(sender, e)
        End If
    End Sub

    Private Sub cntrlFuzzySlider_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lblMax.Left = Me.Width - (lblMin.Left + lblMax.Width)
        lblRightAnchor.Left = Me.Width - (lblRightAnchor.Width + (lblMin.Left - lblLeftAnchor.Left))
        lblMid.Left = (Me.Width - lblMid.Width) / 2
        lblTrack.Width = Me.Width - (lblTrack.Left * 2)

        minThumbLeft = lblMin.Left - (lblThumb.Width - lblMin.Width) / 2
        maxThmubLeft = lblMax.Left - (lblThumb.Width - lblMax.Width) / 2

        setPosition()
        CreateTickLabels(21 - 2)
    End Sub

    Private Sub setPosition()
        lblThumb.Left = theValue * (maxThmubLeft - minThumbLeft) + minThumbLeft
        lblVal.Text = Format(theValue, "0.00")
        lblVal.Left = lblThumb.Left + (lblThumb.Width - lblVal.Width) / 2
    End Sub

    Private Sub setValueFromMouse(X As Long)
        If X <= lblMin.Left Then
            Me.Value = MIN
        ElseIf X >= lblMax.Left + lblMax.Width Then
            Me.Value = MAX
        Else
            Me.Value = Math.Round((MAX - MIN) * (X - lblMin.Left) / (lblMax.Left + lblMax.Width - lblMin.Left) + MIN, 2)
        End If
        lblThumb.Visible = True
        lblVal.Visible = True
    End Sub

    Private Sub cntrlFuzzySlider_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        setValueFromMouse(e.X)
    End Sub

    Private Sub cntrlFuzzySlider_Click(sender As Object, e As MouseEventArgs) Handles Me.Click
        setValueFromMouse(e.X)
    End Sub

    Private Sub cntrlFuzzySlider_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            setValueFromMouse(e.X)
        End If
    End Sub

    Private tickLabels As New List(Of Label)

    Private Sub CreateTickLabels(n As Integer)
        ' Remove old tick labels (except lblMin and lblMax)
        For Each lbl In tickLabels
            Me.Controls.Remove(lbl)
            lbl.Dispose()
        Next
        tickLabels.Clear()

        ' Calculate positions
        Dim startX As Integer = lblMin.Left + lblMin.Width \ 2
        Dim endX As Integer = lblMax.Left + lblMax.Width \ 2
        Dim stepX As Double = (endX - startX) / (n + 1) ' n labels between min and max

        For i As Integer = 1 To n
            Dim lbl As New Label()
            ' Copy properties from lblMin
            lbl.AutoSize = lblMin.AutoSize
            lbl.Font = lblMin.Font
            lbl.ForeColor = lblMin.ForeColor
            lbl.BackColor = lblMin.BackColor
            lbl.Height = lblMin.Height
            lbl.Width = lblMin.Width
            lbl.TextAlign = lblMin.TextAlign
            lbl.Text = "" ' Set your own text if needed
            lbl.Top = lblMin.Top
            lbl.Left = CInt(startX + i * stepX - lbl.Width \ 2)
            Me.Controls.Add(lbl)
            tickLabels.Add(lbl)
            AttachHandlersRecursive(lblVal)
        Next

        lblThumb.BringToFront()
    End Sub

End Class
