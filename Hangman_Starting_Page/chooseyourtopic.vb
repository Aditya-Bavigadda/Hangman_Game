Public Class chooseyourtopic
    Dim number1 As SByte = 0 'this is used for timer 1
    Dim number2 As SByte = 0 'this is used for timer 2
    Private Sub chooseyourtopic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fade_in() 'fades in the screen
        Me.MaximizeBox = False
        Me.MinimizeBox = False 'prevents resizing of form, as buttons do not scale with form in winforms
        Timer1.Start() 'starts timer and blah blah blah
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'handles the choose your topic
        PictureBox1.Location = New Point(PictureBox1.Location.X + 0, PictureBox1.Location.Y + 5)
        number1 += 1
        If (number1 = 16) Then
            Timer1.Stop()
            Timer2.Start()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick 'handles button animations
        PictureBox2.Location = New Point(PictureBox2.Location.X + 50, PictureBox2.Location.Y + 0) 'handles geography button animation
        PictureBox3.Location = New Point(PictureBox3.Location.X - 50, PictureBox3.Location.Y + 0) 'handles ?? button animation
        PictureBox4.Location = New Point(PictureBox4.Location.X + 50, PictureBox4.Location.Y + 0) ' handles ?? button animation
        PictureBox5.Location = New Point(PictureBox5.Location.X + 0, PictureBox5.Location.Y + 10) 'handles back arrow animation
        number2 += 1
        If (number2 = 27) Then
            Timer2.Stop()
        End If
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click 'handles the go back to startpage thing
        Me.Dispose()
        StartingPage.Show()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click 'handles the going to the geography page
        Me.Dispose()
        Geographychooseyourcharacter.Show()
    End Sub

End Class