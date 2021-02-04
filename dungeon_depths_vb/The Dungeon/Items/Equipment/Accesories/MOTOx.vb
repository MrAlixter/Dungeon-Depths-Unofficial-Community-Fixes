Public Class MOTOx
    Inherits Accessory
    Sub New()
        '|ID Info|
        MyBase.setName("Mark_of_the_Ox")
        id = 271
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        isCursed = True
        underClothes = True
        MyBase.isRandoTFAcceptable = False
        MyBase.isMonsterDrop = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 0

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)

        '|Description|
        MyBase.setDesc("A glowing blue tattoo in the shape of a cowbell that displays one's status as under the effect of a bovine enchantment." & DDUtils.RNRN &
                       "Transformation triggered by equipping this item." & vbCrLf &
                       "Increase Max Mana based on stamina")
    End Sub

    Public Overrides Sub discard()
        Game.pushLblEvent("You can't discard this!")
        Game.pushLstLog("You can't discard this!")
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
