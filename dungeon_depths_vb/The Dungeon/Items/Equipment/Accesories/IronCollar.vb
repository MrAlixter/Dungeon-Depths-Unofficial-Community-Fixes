Public Class IronCollar
    Inherits Accessory

    Public Const ITEM_NAME As String = "Iron_Collar"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 375
        tier = Nothing

        '|Item Flags|
        usable = False
        under_chin = True

        '|Stats|
        d_boost = 26
        s_boost = -13
        count = 0
        value = 555

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)

        '|Description|
        setDesc("A restrictive neckpiece made of silver metal." & DDUtils.RNRN &
                getStatInformation() & DDUtils.RNRN &
                "If unequipped, can be used to greatly debuff a fae during combat.")
    End Sub

    Public Overrides Function getUsable() As Boolean
        Return Game.combat_engaged And Not Game.player1 Is Nothing And Not Game.player1.currTarget Is Nothing AndAlso (Not Game.player1.equippedAcce.getAName.Equals(ITEM_NAME) And Game.player1.currTarget.getSName.Contains("Fae") And Not Game.player1.currTarget.debuffed)
    End Function

    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        If Not p.currTarget Is Nothing Then
            p.currTarget.maxHealth /= 10
            p.currTarget.mana /= 10
            p.currTarget.maxMana /= 10
            p.currTarget.attack /= 10
            p.currTarget.defense /= 10
            p.currTarget.speed /= 10
            p.currTarget.will /= 10

            p.currTarget.debuffed = True
            TextEvent.pushAndLog("You clamp the collar around the neck of " & p.currTarget.getNameWithTitle & "!")
            If TypeOf p.currTarget Is FaeQueen Then TextEvent.pushAndLog("""W-what the hell is this?!?"" " & p.currTarget.getNameWithTitle & " exclaims, clearly rattled...")
        Else
            TextEvent.pushAndLog("You lunge in with the collar... but you miss your target!")
        End If

        count -= 1
    End Sub
End Class
