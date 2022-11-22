Public Class FaeQueenAmulet
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae_Queen's_Talisman"

    Sub New()
        '|ID Info|
        setName("Fae_Queen's_Talisman")
        id = 349
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        under_t_clothes = True

        '|Stats|
        count = 0
        value = 6026

        '|Image Index|
        mInd = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)

        '|Description|
        setDesc("A small golden talisman bearing the image of a rose." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If Transformation.canBeTFed(p) Then
            p.ongoingTFs.add(New FaerieTF())
            p.update()
        End If
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If p.formName = "Faerie" Then p.revertToPState()
    End Sub
End Class
