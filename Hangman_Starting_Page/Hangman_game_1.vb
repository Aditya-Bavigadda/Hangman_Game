Public Class Hangman_game_1
    Dim r As New Random()
    Dim selectedword As SByte = r.Next(1, 11) 'gets random int between 1 and 10
    Dim word As String 'is the chosen word
    Dim result As Char 'recieves word given
    Dim usedcharacter As SByte 'tells you which character you used
    Dim position As SByte = 0 'gives position
    Dim string1 As String
    Dim tries As SByte = 0
    Dim wincheck As SByte = 0
    Dim int3 As SByte = 0

    Private Sub Hangman_game_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (geomanchoice = 1) Then 'changes character based on selection choice
            PictureBox2.Image = My.Resources.blankedoutgeohangman
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf (geomanchoice = 2) Then
            PictureBox2.Image = My.Resources.baldmanblank
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox2.Image = My.Resources.spikehairedmanblank
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        fade_in() 'fades in the screen
        Me.MaximizeBox = False
        Me.MinimizeBox = False 'prevents resizing of form, as buttons do not scale with form in winforms
        If (selectedword = 1) Then 'did not want to hardcode this, but i had no idea how to use enums
            word = "UAE"
            string1 = "_ _ _"
        ElseIf (selectedword = 2) Then
            word = "MAP"
            string1 = "_ _ _"
        ElseIf (selectedword = 3) Then
            word = "CHAD"
            string1 = "_ _ _ _"
        ElseIf (selectedword = 4) Then
            word = "CUBA"
            string1 = "_ _ _ _"
        ElseIf (selectedword = 5) Then
            word = "CHILE"
            string1 = "_ _ _ _ _"
        ElseIf (selectedword = 6) Then
            word = "CHINA"
            string1 = "_ _ _ _ _"
        ElseIf (selectedword = 7) Then
            word = "PRAGUE"
            string1 = "_ _ _ _ _ _"
        ElseIf (selectedword = 8) Then
            word = "FRANCE"
            string1 = "_ _ _ _ _ _"
        ElseIf (selectedword = 9) Then
            word = "DENMARK"
            string1 = "_ _ _ _ _ _ _"
        Else
            word = "GERMANY"
            string1 = "_ _ _ _ _ _ _"
        End If
        Label2.Text = string1 'is the displayed text
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

    'handles what happens when the letter is clicked
    Private Sub letter_Click(sender As Object, e As EventArgs) Handles lettera.Click, letterb.Click, letterc.Click, letterd.Click, lettere.Click, letterf.Click, letterg.Click, letterh.Click, letteri.Click, letterj.Click, letterk.Click, letterl.Click, letterm.Click, lettern.Click, lettero.Click, letterp.Click, letterq.Click, letterr.Click, letters.Click, lettert.Click, letteru.Click, letterv.Click, letterw.Click, letterx.Click, lettery.Click, letterz.Click
        Dim test = DirectCast(sender, PictureBox) 'collects which imagebox was sent
        test.Image = My.Resources.lettercover 'covers it
        CheckForWords(test) 'checks if underscored word is selected
        test.Enabled = False 'disables the image (used in detecting if word is chosen)
    End Sub

    Private Sub CheckForWords(lettersabcd As PictureBox)  'checks if underscored word is selected
        Dim i As SByte
        Dim lst As New List(Of Integer)
        Dim replacement As Char = lettersabcd.Tag.ToString() 'is the character that we want to check
        Dim sbString1 As New System.Text.StringBuilder(string1) 'using a stringbuilder allows me to manipulate certain characters
        For Each c In word 'checks which character number i need to select
            If c = lettersabcd.Tag.ToString() Then
                lst.Add(i) 'gets the character number
            End If
            i += 1 'checks the next character
        Next
        For Each item In lst
            Dim randomnumber As SByte = (item * 2) 'allows easier reading of the code to use an int instead of doing this calculation in the equation
            sbString1(randomnumber) = replacement 'replaces the character
            string1 = sbString1.ToString() 'sets what string 1 is
            Label2.Text = string1 'updates the on-screen text
        Next
        If (word.Contains(lettersabcd.Tag.ToString())) Then 'checks if the user clicked the correct character
            tries -= 1 'minuses a try (it is added back later)
            wincheck += 1 'adds 1 to the counter to check if the user has won
        End If
        If (wincheck = word.Length) Then 'if the user has got the right amount of characters (they win)
            PictureBox3.BackgroundImage = My.Resources.you_won_page 'shows the you won thing
            PictureBox3.Visible = True 'makes the image visible
            Label3.Text = "Well done, you beat hangman!"
            PictureBox6.Visible = False 'disables the flag
            PictureBox6.Enabled = False
            'rest of the code in this if statement makes the play again and exit game button visible
            PictureBox4.Visible = True
            PictureBox4.Enabled = True
            PictureBox5.Visible = True
            PictureBox5.Enabled = True
        End If
        tries += 1
        If (tries = 1) Then 'this nested if statement changes the flag
            PictureBox6.BackgroundImage = My.Resources.flag1
        ElseIf (tries = 2) Then
            PictureBox6.BackgroundImage = My.Resources.flag2
        ElseIf (tries = 3) Then
            PictureBox6.BackgroundImage = My.Resources.flag3
        ElseIf (tries = 4) Then
            PictureBox6.BackgroundImage = My.Resources.flag4
        ElseIf (tries = 5) Then
            PictureBox6.BackgroundImage = My.Resources.flagwithcount3
        ElseIf (tries = 6) Then
            PictureBox6.BackgroundImage = My.Resources.flagwithcount2
        ElseIf (tries = 7) Then
            PictureBox6.BackgroundImage = My.Resources.flagwithcount1
        ElseIf (tries = 8) Then
            PictureBox6.BackgroundImage = My.Resources.projectlieflag
            Timer1.Start() 'starts timer for ram
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'this is the animation of the flag flying
        PictureBox6.Location = New Point(PictureBox6.Location.X + 20, PictureBox6.Location.Y - 2)
        int3 += 1 'this allows the timer to stop and allows this function to stop
        If (int3 = 25) Then
            Timer1.Stop()
            tries += 1
            endgame() 'ends the game by displaying the losing page
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click 'go back to main menu
        Me.Dispose()
        StartingPage.Show()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click 'exits the game
        Me.Dispose()
    End Sub

    Private Sub endgame() 'is the losing page
        PictureBox3.BackgroundImage = My.Resources.you_lost_page
        PictureBox3.Visible = True
        Label3.Text = "The word was " & word & "!"
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
        PictureBox5.Visible = True
        PictureBox5.Enabled = True
        PictureBox6.Visible = False
        PictureBox6.Enabled = False
    End Sub

End Class