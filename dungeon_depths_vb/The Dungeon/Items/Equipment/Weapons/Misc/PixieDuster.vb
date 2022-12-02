Public Class PixieDuster
    Inherits Weapon

    Public Const ITEM_NAME As String = "Pixie_Duster"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 388
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        a_boost = 10
        s_boost = 15
        count = 0
        value = 475

        '|Description|
        setDesc("A lavender feather duster that looks like you could use it for cleaning, though it seems to have already been used to dust off something glittery..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        If floor_num = 13 Then Return 2

        Return MyBase.getTier(floor_num)
    End Function

    Overrides Sub use(ByRef p As Player)
        If Not p.prt.checkFemInd(pInd.wings, 10) Then
            TextEvent.push("As you hold the duster aloft, the shimmering dust catches the wind and blows into your face." & DDUtils.RNRN &
                           "Suprised, you let out a small sneeze before falling into a coughing fit.  A sudden buzzing gust from behind you clears the air, clueing you into your new wings!" & DDUtils.RNRN &
                           "The duster seems to be covered in pixie dust... maybe you should give it another shake?" & DDUtils.RNRN &
                           "You look like a faerie!")
            FaerieTF.step1VisualOnly(p)
            p.drawPort()
        Else
            p.ongoingTFs.add(New BimboMaidTF())
            p.update()
        End If
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso (p.className.Contains("Maid") And Not p.className.Equals("Maiden")) Then
            p.inv.add(PixieDuster.ITEM_NAME, -1)
            p.inv.add(FeatherDagger.ITEM_NAME, 1)

            If p.equippedWeapon.getAName.Equals(ITEM_NAME) Then EquipmentDialogBackend.equipWeapon(p, FeatherDagger.ITEM_NAME)

            TextEvent.pushLog("With a poof, your " & ITEM_NAME & " turns into a " & FeatherDagger.ITEM_NAME & "!")

            p.inv.invNeedsUDate = True
            p.UIupdate()
        End If

        Return MyBase.getABoost(p)
    End Function
End Class
