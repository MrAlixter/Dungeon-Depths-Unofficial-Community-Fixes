Public NotInheritable Class HorseTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "Horse​TF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 32767
    End Sub

    Public Overrides Sub step1()
        Game.player1.equippedArmor = New Naked
        Game.player1.equippedWeapon = New BareFists
        Game.player1.equippedAcce = New noAcce
        Game.player1.inv = New Inventory(True)
        Game.player1.pClass = Game.player1.classes("Classless")
    End Sub
End Class
