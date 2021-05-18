Public Class Ropes
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Ropes")
        id = 54
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.cursed = True
        MyBase.bind_wearer = True
        hide_dick = False

        '|Stats|
        MyBase.a_boost = -5
        MyBase.d_boost = -5
        MyBase.s_boost = -5
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(63, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(72, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(73, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(74, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(75, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(76, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(46, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)

        '|Description|
        setDesc("A tightened set of ropes that both reduces mobility and leaves one nearly naked." & DDUtils.RNRN & _
                       getSizeInformation() & vbCrLf &
                       "-5 ATK" & vbCrLf &
                       "-5 DEF" & vbCrLf &
                       "-5 SPD" & vbCrLf &
                       "May not be easy to remove")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pForm.canBeBound Then
            Equipment.equipArmor(p, "Naked")
            Game.pushLblEvent("You effortlessly break your bonds.")
            Game.pushLstLog("You effortlessly break your bonds.")
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.bind_wearer = False
        MyBase.bind_wearer = True
    End Sub
End Class
