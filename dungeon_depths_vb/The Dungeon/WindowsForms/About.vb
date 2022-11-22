Public NotInheritable Class About

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Me.TextBoxDescription.Text = "Dungeon Depths is a 2D dungeon crawler with art made in Kisekae2.0 featuring adult transformation and hypnosis content.  Please do not play this game if you are younger than 18 years old." & DDUtils.RNRN &
                                     "-----------------------------------------------" & DDUtils.RNRN &
                                     "Outside of myself (VHU), there have been several people to join the game's development team.  I would like to recognize:" & DDUtils.RNRN &
                                     "- Houdini111 for extensive contributions in debugging and game features, namely in the design and implementation of the debug menu, the current shop UI, and the dungeon customization menu." & DDUtils.RNRN &
                                     "- Lazerlite142 for the creation and management of the game's discord server, the creation of several image packs that signifiganty change up the game's visuals, and for the creation of in-game art assets, such as the Slime dissolved shirt, and the full body images for the Goddess Gown, Steel Armor, Gold Armor, Sorcerer's Robes, and Warrior's Curiass." & DDUtils.RNRN &
                                     "These two have greatly improved our game through their being a part of it, and for that I am eternally grateful." & DDUtils.RNRN &
                                     "-----------------------------------------------" & DDUtils.RNRN &
                                     "Writing Credits: " & DDUtils.RNRN &
                                    "- Marionette: Slime Loss/TF Scenes, yet-to-be-implemented Vial of Slime & Mimic loss scenes" & DDUtils.RNRN &
                                    "- Big Iron Red: Unwilling versions of Maid TF, Marissa Loss, and Slut curse passages; yet-to-be-implemented Gothic & Sweet Lolita TF, Victorian Mannequin TF scenes" & DDUtils.RNRN &
                                    "- Lazerbear7: Proofreading and editing of some passages" & DDUtils.RNRN &
                                     "-----------------------------------------------" & DDUtils.RNRN &
                                     "I would also like to send a special thanks to:" & DDUtils.RNRN &
                                     "- undercoversam for advice on the balancing of weapons and armor" & DDUtils.RNRN &
                                     "- Rangorak for advice on Kisekae2.0 and for the design of the fourth default clothing options, as well as extensive contributions to debugging." & DDUtils.RNRN &
                                     "- Storm for the ability to bodyswap with the explorer" & DDUtils.RNRN &
                                     "- Arrhae Khellian for help cleaning up the BitBucket"
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
