Public NotInheritable Class FaePieTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "FaePie​TF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
        tfName = "FaePie​TF"
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 32767
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.equippedArmor = New Naked
        p.equippedWeapon = New BareFists
        p.equippedAcce = New noAcce

        Game.preBSInventory.Clear()
        For i = 0 To p.inv.upperBound
            Game.preBSInventory.Add(p.inv.getCountAt(i))
            p.inv.item(i).count = 0
        Next

        p.prt.setIAInd(pInd.eyes, 58, True, True)
        p.prt.setIAInd(pInd.mouth, 20, True, True)
        p.prt.setIAInd(pInd.wings, 8, True, False)

        p.perks(perk.isfae) = 1

        p.changeClass("Classless")
    End Sub
End Class
