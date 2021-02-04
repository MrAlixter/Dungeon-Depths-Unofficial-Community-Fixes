Public Class Steak
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("""Normal""_Steak")
        id = 272
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False
        MyBase.isMonsterDrop = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 530
        setCalories(50)

        '|Description|
        MyBase.setDesc("A massive slab of meat slathered in spices and freshly seared off a grill.  The Food Vendor is adamant that it came from a normal, everyday cow and specifically not from the legendary Blue Cattle of the Divine Pasture." & DDUtils.RNRN &
                       "+50 Stamina")
    End Sub

    Public Overrides Sub Effect()
        Dim p As Player = Game.player1

        If Int(Rnd() * 7) = 0 Or Game.noRNG Then
            Dim tf = New MoxBTF
            tf.step1()

            p.drawPort()
        End If
    End Sub
End Class
