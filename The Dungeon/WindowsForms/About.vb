Public NotInheritable Class About

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'scale to the screen size
        'Dim startingWidth = Me.Width
        'Dim startingHeight = Me.Height
        'If Game.screenSize = "Small" Then
        '    Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        'ElseIf Game.screenSize = "Medium" Then
        '    Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        'End If
        'Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        'Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 381))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            'Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            'Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            'Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            'Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next


        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = "Dungeon_Depths is a 2D dungeon crawler with art made in Kisekae2.0 featuring TF fetish content, made for adults." & vbCrLf &
                                     "-----------------------------------------------" & vbCrLf &
                                     "Outside of myself (VHU), there have been several people to join the game's development team.  I would like to recognize:" & vbCrLf & vbCrLf &
                                     "- Houdini111 for extensive contributions in debugging and game features, namely in the design and implementation of the debug menu, the current shop UI, and the dungeon customization menu." & vbCrLf & vbCrLf &
                                     "- Lazerlite142 for the creation and management of the game's discord server, the creation of several image packs that signifiganty change up the game's visuals, and for the creation of in-game art assets, such as the Slime dissolved shirt." & vbCrLf & vbCrLf &
                                     "These two have greatly improved our game through their being a part of it, and for that I am eternally grateful." & vbCrLf &
                                     "-----------------------------------------------" & vbCrLf &
                                     "I would also like to send a special thanks to:" & vbCrLf & vbCrLf &
                                     "- undercoversam for advice on the balancing of weapons and armor through simulated dice" & vbCrLf & vbCrLf &
                                     "- Rangorak for advice on Kisekae2.0 and for the design of the fourth default clothing options, as well as extensive contributions to debugging." & vbCrLf & vbCrLf &
                                     "- Storm for the ability to bodyswap with the explorer" & vbCrLf & vbCrLf &
                                     "- Arrhae Khellian for help cleaning up the BitBucket"
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
