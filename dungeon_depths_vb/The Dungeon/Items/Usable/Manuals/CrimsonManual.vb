Public Class CrimsonManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Crimson_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 227
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 666

        '|Description|
        setDesc("A smoldering leather-bound book that contains something practical written by a succubus.")
    End Sub

    Public Shared Shadows Function getSpecials() As String()
        Return New CrimsonManual().specials
    End Function
    Public Overrides Function specials() As String()
        Return {"Tits Up", "Tits Down", "Ass Up", "Ass Down", "Dick Up", "Dick Down", "Chameleon"}
    End Function

    Public Overrides Function getTier() As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier()
    End Function
End Class
