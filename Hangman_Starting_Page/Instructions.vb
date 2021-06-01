Public Class Instructions
    Private Sub help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fade_in() 'fades in the screen
        Me.MaximizeBox = False
        Me.MinimizeBox = False 'prevents resizing of form, as buttons do not scale with form in winforms
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