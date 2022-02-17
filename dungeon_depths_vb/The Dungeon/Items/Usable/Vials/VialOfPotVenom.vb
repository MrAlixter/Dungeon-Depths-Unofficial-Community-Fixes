Public Class VialOfPotVenom
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_Potent_Venom"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 244
        tier = Nothing

        '|Item Flags|
        usable = true
        droppable = True

        '|Stats|
        count = 0
        value = 1

        '|Description|
        setDesc("A small glass bottle filled with an translucent golden ichor that gives off a subtle glow.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())
        Dim out As String = "You drink the vial of potent venom!  You rapidly transform into an arachne!"

        ArachneTF.rapidTF(p)

        count -= 1
    End Sub
End Class
