Public Class Cursemark
    Inherits Accessory
    Sub New()
        '|ID Info|
        MyBase.setName("Cursemark")
        id = 168
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        isCursed = True
        underClothes = True

        '|Stats|
        MyBase.count = 0
        MyBase.value = 0

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        '|Description|
        MyBase.setDesc("A glowing pink tattoo that displays one's status as under the effect of demonic magic." & DDUtils.RNRN &
                       "Negates attack while increasing Max MP and WILL" & vbCrLf &
                       "Raises minimum lust based on availible MP" & vbCrLf &
                       "Mana does not re-generate" & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub discard()
        Game.pushLblEvent("You can't discard this!")
        Game.pushLstLog("You can't discard this!")
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return -1 * (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p))
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p)) / 2
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return (((p.attack + p.aBuff) * p.pForm.a * p.pClass.a) + p.equippedArmor.getABoost(p) + p.equippedWeapon.getABoost(p)) / 2
    End Function

    Public Overrides Function getDesc() As Object
        Return "A glowing pink tattoo that displays one's status as under the effect of demonic magic." & DDUtils.RNRN &
               "Negates attack while increasing Max MP and WILL" & vbCrLf &
               "Raises minimum lust based on availible MP" & vbCrLf &
               "Mana does not re-generate" & DDUtils.RNRN &
               getStatInformation()
    End Function
    Shared Function getForm() As preferedForm
        Return New preferedForm(Color.White, Color.FromArgb(255, 255, 78, 78), True, True, 2, True, 0, 26, 6)
    End Function
End Class
