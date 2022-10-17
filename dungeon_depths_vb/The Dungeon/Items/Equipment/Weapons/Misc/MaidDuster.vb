Public Class MaidDuster
    Inherits Weapon

    Public Const ITEM_NAME As String = "Feather_Duster"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 45
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        a_boost = 5
        s_boost = 10
        count = 0
        value = 375

        '|Description|
        setDesc("A grey feather duster that looks like you could use it for cleaning." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDesc() As Object
        Return "A grey feather duster that looks like you could use it for cleaning." & DDUtils.RNRN &
                getStatInformation()
    End Function

    Overrides Sub use(ByRef p As Player)
        p.ongoingTFs.Add(New MaidTF())
        p.update()
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso (p.className.Contains("Maid") And Not p.className.Equals("Maiden")) Then
            p.inv.add(MaidDuster.ITEM_NAME, -1)
            p.inv.add(FeatherDagger.ITEM_NAME, 1)

            If p.equippedWeapon.getAName.Equals(ITEM_NAME) Then EquipmentDialogBackend.equipWeapon(p, FeatherDagger.ITEM_NAME)

            TextEvent.pushLog("With a poof, your " & ITEM_NAME & " turns into a " & FeatherDagger.ITEM_NAME & "!")

            p.inv.invNeedsUDate = True
            p.UIupdate()
        End If

        Return MyBase.getABoost(p)
    End Function
End Class
