Public Class Steak
    Inherits Food

    Public Const ITEM_NAME As String = """Normal""_Steak"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 272
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 530
        setCalories(50)

        '|Description|
        setDesc("A massive slab of meat slathered in spices and freshly seared off a grill.  The Food Vendor is adamant that it came from a normal, everyday cow and specifically not from the legendary Blue Cattle of the Divine Pasture." & DDUtils.RNRN &
                "+50 Stamina")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 7) = 0 Or Settings.active(setting.norng) Then
            Dim tf = New MoxBTF
            tf.step1()

            p.drawPort()
        End If
    End Sub
End Class
