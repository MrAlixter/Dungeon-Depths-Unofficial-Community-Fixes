Public Class ShimmeringHairbrush
    Inherits Item

    Public Const ITEM_NAME As String = "Shimmering_Hairbrush"

    Shared met_ghost As Boolean = False
    Dim plyr As Player = Nothing

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 410
        tier = 3

        '|Item Flags|
        usable = True


        '|Stats|
        count = 0
        value = 2740

        '|Description|
        setDesc("A simple black hairbrush that faintly sparkles with a soft eerie glow.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 4
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        If met_ghost Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(162), """Hello again...  Would... would you like another makeover?""" & DDUtils.PAKTC)
        Else
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(162), "As you run the brush through your hair, you feel a soft breath on the back of your neck.  Whipping around, you find yourself face to face with the glowing apparition of a woman!" & DDUtils.RNRN &
                                                                  """Oh... hello there... I'm sorry, I didn't mean to intrude... but, um..." & DDUtils.RNRN &
                                                                  "Do you mind if I possess your body for a bit?  I've always had an eye for fashion... but ever since... well, nevermind.  When I'm possessing someone, I can..." & DDUtils.RNRN &
                                                                  """Oh, it's probably better for me to just show you...""" & DDUtils.PAKTC)

            met_ghost = True
        End If
        TextEvent.lblEventOnClose = AddressOf restyle
        plyr = p
    End Sub

    Sub restyle()
        Dim gen = New RestyleCharacterGenerator
        gen.ShowDialog()

        gen.Dispose()

        Dim excuse = ""

        Select Case Int(Rnd() * 4)
            Case 1
                excuse = "Someone needs to be turned into a pretty pretty princess so as to murder a handsome handsome prince."
            Case 2
                excuse = "An elder dragon would like to experiment with makeup, and I need to go source a small fortune's worth of cosmetics and a bucket."
            Case 3
                excuse = "Someone is calling on my tremendous phantom power for a tan."
            Case 4
                excuse = "Someone wants to grow a tasteful beard, but is a bit unclear on what that looks like."
            Case Else
                excuse = "Someone wants to be a blonde, but, like, just for a little bit."
        End Select

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(163), """Wow... you look great!"" the spectral stylist says, as she drifts around to get a better look at you." & DDUtils.RNRN &
                                                              """I'd love to stay and chat... but unfortunately... I... um..." & DDUtils.RNRN &
                                                              "Goodbye... for now...""" & DDUtils.RNRN &
                                                              "As she says her farewell, the ghost fades away into nothingness." & DDUtils.RNRN &
                                                              "Hmm... you do look good.")

        Dim p = If(plyr Is Nothing, Game.player1, plyr)
        p.drawPort()
    End Sub
End Class
