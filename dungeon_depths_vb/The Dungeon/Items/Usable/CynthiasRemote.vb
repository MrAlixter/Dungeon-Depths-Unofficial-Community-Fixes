Public Class CynthiasRemote
    Inherits Item

    Public Const ITEM_NAME As String = "Cynthia's_Remote"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 387
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 375

        '|Description|
        setDesc("This item is for testing the various modes of the Lance of Scarlet Fury, and should not be in the base game")
    End Sub
    Public Overrides Sub use(ByRef p As Player)
        If LanceOfSFury.current_mode = LanceOfSFury.mode.bimbo Then
            LanceOfSFury.current_mode = LanceOfSFury.mode.normal
            LanceOfSFury.setImg(LanceOfSFury.current_mode)
            TextEvent.pushLog("The " & LanceOfSFury.ITEM_NAME & " glows red!")
        Else
            LanceOfSFury.current_mode = LanceOfSFury.mode.bimbo
            LanceOfSFury.setImg(LanceOfSFury.current_mode)
            TextEvent.pushLog("The " & LanceOfSFury.ITEM_NAME & " glows pink!")
        End If
    End Sub
End Class
