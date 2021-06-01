'couldn't do fading in of help button as visual studio did not allow me to
Public Class StartingPage
    Dim colourR As SByte = 1 'controls red colour for fade in
    Dim colourG As SByte = 1 'controls green colour for fade in
    Dim colourB As SByte = 1 'controls blue colour for fade in
    Dim ycount As SByte = 1 'controls timer for help button
    'would have used byte as there is no need for a signed number but SByte sounds cooler

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        fade_in() 'fades in the screen
        Timer1.Start() 'timer for the thing to go upwards
        Me.MaximizeBox = False
        Me.MinimizeBox = False 'prevents resizing of form, as buttons do not scale with form in winforms
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click 'takes user to instructions page
        Instructions.Show()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'does not handle timer1.tick, actually handles the upwards animation at the start
        PictureBox1.Location = New Point(PictureBox1.Location.X + 0, PictureBox1.Location.Y - 5)
        If (PictureBox1.Location = New Point(0, 0)) Then
            Timer1.Stop() 'stops the thing when it reaches the middle of the screen
            Timer2.Start() 'starts timer for the fading in of the start button
            Timer3.Start() 'controls help button
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click 'takes user to next page
        chooseyourtopic.Show()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click 'takes user to next page
        Me.Dispose()
        chooseyourtopic.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick 'handles  buttons appearing cooly
        Label1.Text = "----Start----" 'sets text
        'below this controls start button
        Label1.ForeColor = Color.FromArgb(Label1.ForeColor.A, Label1.ForeColor.R + colourR, Label1.ForeColor.G + colourG, Label1.ForeColor.B - colourB)
        'rest of the sub controls colours
        If (Label1.ForeColor.R = 252) Then
            colourR = 0
        End If
        If (Label1.ForeColor.G = 235) Then
            colourG = 0
        End If
        If (Label1.ForeColor.B = 220) Then
            colourB = 0
        End If
        If (Label1.ForeColor.R = 252 & Label1.ForeColor.G = 235 & Label1.ForeColor.B = 220) Then 'helps with ram (i think) as timer is not running anymore
            Timer2.Stop()
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick 'handles help button
        PictureBox2.Location = New Point(PictureBox2.Location.X, PictureBox2.Location.Y + 10)
        ycount += 1
        If (ycount = 10) Then
            Timer3.Stop()
        End If
    End Sub

    Public Sub fade_in() 'fades in the form 
        For FadeIn = 0.0 To 1.2 Step 0.15
            Me.Opacity = FadeIn
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
    End Sub

    'everything below handles fade out
    Public Sub fade_out()
        For FadeOut = 90 To 10 Step -30
            Me.Opacity = FadeOut / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        fade_out()
    End Sub

End Class
