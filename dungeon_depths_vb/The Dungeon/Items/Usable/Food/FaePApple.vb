Public Class FaePApple
    Inherits Food

    Public Const ITEM_NAME As String = "Apple​​"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 341
        tier = Nothing

        '|Item Flags|
        usable = True
        only_drop_one = True
        rando_inv_allowed = False
        stores_inanimate_ent = True

        '|Stats|
        count = 0

        '|Description|
        setDesc("An ""normal"" purple apple with sinister aura that seems out of line with what you'd expect of fruit.")
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If getInanimateEnt() Is Nothing OrElse Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function
    Overrides Function getCalories()
        If Not getInanimateEnt() Is Nothing Then Return getInanimateEnt.max_mana

        Return 0
    End Function

    Public Overrides Sub effect(ByRef p As Player)
        If Not getInanimateEnt() Is Nothing Then
            p.savePState()

            p.breastSize = Math.Min(1, CInt(getInanimateEnt().extra2))
            p.reverseAllRoute()

            p.changeHairColor(getInanimateEnt().prt.haircolor)
            p.changeSkinColor(getInanimateEnt().prt.skincolor)
        End If

        If Game.combat_engaged = True Or Game.shop_npc_engaged = True Or Not p.canMoveFlag Then
            FaePrincessTF.step3()
        Else
            FaePrincessTF.step1()
        End If
    End Sub

    Public Overrides Function getDescription() As Object
        Return "An ""normal"" purple apple with sinister aura that seems in line with what you'd expect of fruit." &
                If(getInanimateEnt() Is Nothing, "", DDUtils.RNRN & "+" & getCalories() & " Stamina")
    End Function

    Public Shared Sub appleTF()
        Game.player1.inanimateTF(Nothing, FaePApple.ITEM_NAME, False)

        TextEvent.push("With little more than an *eep*, you vanish in a poof of pixie dust." & DDUtils.RNRN &
                       "You've been turned into an apple by the fae!", AddressOf Game.player1.die)
    End Sub

    Public Overrides Sub setInanimateEnt(ByRef ent As InanimateEntity, ByRef source As Entity)
        If Not source.getPlayer() Is Nothing Then
            Dim p = source.getPlayer()

            ent.extra2 = p.breastSize
            ent.extra3 = p.dickSize
            ent.extra4 = p.buttSize
        End If

        MyBase.setInanimateEnt(ent, source)
    End Sub
End Class
