Public NotInheritable Class FaePieTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.faepie

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 32767
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.equippedArmor = New Naked
        p.equippedWeapon = New BareFists
        p.equippedAcce = New noAcce

        Game.floor_4_starting_inv.Clear()
        For i = 0 To p.inv.upperBound
            Game.floor_4_starting_inv.Add(p.inv.getCountAt(i))
            p.inv.item(i).count = 0
        Next

        p.prt.setIAInd(pInd.eyes, 58, True, True)
        p.prt.setIAInd(pInd.mouth, 20, True, True)
        p.prt.setIAInd(pInd.wings, 8, True, False)

        p.perks(perk.isfae) = 1

        p.changeClass("Classless")
    End Sub

    Public Shared Sub applyForXTurns(ByRef p As Player, ByVal x As Integer)
        EquipmentDialogBackend.equipArmor(p, "Naked", True)
        p.changeHairColor(BimboTF.bimboyellow2)

        If p.breastSize > 3 Then p.breastSize = 3
        If p.buttSize > 3 Then p.buttSize = 3

        p.savePState()

        p.perks(perk.polymorphed) = If(Game.combat_engaged, 4, x)
        p.changeForm("Faerie (B)")
    End Sub
End Class
