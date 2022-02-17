Public Class SoulBlade
    Inherits Sword

    Public Const ITEM_NAME As String = "SoulBlade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 9
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 5
        count = 0
        value = 100

        '|Description|
        setDesc("A ornate sword forged from someone's soul." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Sub Absorb(ByRef m As Monster)
        setName("SoulBlade") ' (" & m.name.Split()(0) & ")")
        setDesc("A ornate sword forged from " & m.name.Split()(0) & "'s soul.")
        usable = false
        MyBase.a_boost = m.attack
        value = m.maxHealth
        m.toBlade()
    End Sub

    Public Overrides Function getDesc()
        Return "A ornate sword forged from someone's soul." & DDUtils.RNRN &
                       getStatInformation()
    End Function
End Class
