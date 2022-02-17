Public Class DemWhip
    Inherits Whip

    Public Const ITEM_NAME As String = "Demonic_Whip"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 217
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = True

        '|Stats|
        a_boost = 38
        count = 0
        value = 3333

        '|Description|
        setDesc("A black leather whip that burns with a naughty aura and critically hits more often than a standard sword.  " & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor IsNot Nothing AndAlso Game.currFloor.floorNumber > 7 Then
            Return 3
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 10
        Return MyBase.attack(p, m)
    End Function
End Class
