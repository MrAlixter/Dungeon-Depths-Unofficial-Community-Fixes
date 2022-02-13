Public Class MOTOx
    Inherits Accessory
    Sub New()
        '|ID Info|
        setName("Mark_of_the_Ox")
        id = 271
        tier = Nothing

        '|Item Flags|
        usable = false
        cursed = True
        under_b_clothes = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)

        '|Description|
        setDesc("A glowing blue tattoo in the shape of a cowbell that displays one's status as under the effect of a bovine enchantment." & DDUtils.RNRN &
                "Transformation triggered by equipping this item." & vbCrLf &
                "Increases Max Mana based on stamina")
    End Sub

    Public Overrides Sub discard()
        TextEvent.push("You can't discard this!")
        TextEvent.pushLog("You can't discard this!")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        Dim tf = New MoxBTF
        tf.step1()

        p.drawPort()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub

    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return p.stamina / 2
    End Function
End Class
