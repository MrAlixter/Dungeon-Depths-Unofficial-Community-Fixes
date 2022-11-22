Public NotInheritable Class HorseTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.horse

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
        Game.player1.equippedArmor = New Naked
        Game.player1.equippedWeapon = New BareFists
        If Not Game.player1.equippedAcce.getAName = CursedBridle.ITEM_NAME Then Game.player1.equippedAcce = New noAcce
        Game.player1.changeClass("Classless")

        If FaeWoodsQ2A.horseTFongoing Then FaeWoodsQ2AS2.init()
    End Sub
End Class
