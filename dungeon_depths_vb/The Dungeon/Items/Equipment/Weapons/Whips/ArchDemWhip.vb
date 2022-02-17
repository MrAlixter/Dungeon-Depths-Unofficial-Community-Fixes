Public Class ArchDemWhip
    Inherits Whip

    Public Const ITEM_NAME As String = "Archdemon_Whip"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 218
        tier = 3

        '|Item Flags|
        usable = False
        droppable = True

        '|Stats|
        a_boost = 66
        count = 0
        value = 6666

        '|Description|
        setDesc("A studded black leather whip that burns with a naughty aura that critically hits more often than a standard sword." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor IsNot Nothing AndAlso Game.currFloor.floorNumber > 14 Then
            Return 3
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 20
        Return MyBase.attack(p, m)
    End Function
End Class
