Public Class Pluck
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Pluck")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim potentialSteals As List(Of Item) = New List(Of Item)

        For i = 0 To getTarget.inv.upperBound()
            If getTarget.inv.item(i).count > 0 And Not getTarget.inv.item(i).getName = "Gold" And getTarget.inv.item(i).can_be_stolen Then potentialSteals.Add(getTarget.inv.item(i))
        Next

        If potentialSteals.count < 1 Then
            TextEvent.pushAndLog(CStr("Pluck! " & getTarget.title & MyBase.getTarget.getName & " doesn't really have anything to steal..."))
        Else
            Dim i As Item = potentialSteals(Int(Rnd() * potentialSteals.Count))
            getTarget.inv.add(i.id, -1)
            getUser.inv.add(i.id, 1)

            getUser.UIupdate()

            TextEvent.pushAndLog(CStr("Pluck!  You snatch yourself a " & i.getName & " from" & getTarget.title.ToLower & MyBase.getTarget.getName & "'s belongings."))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Snatches an item at random from the target's inventory."
    End Function
End Class
