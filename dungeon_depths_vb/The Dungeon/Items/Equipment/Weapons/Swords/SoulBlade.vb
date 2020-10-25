Public Class SoulBlade
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("SoulBlade")
        id = 9
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)

        '|Stats|
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 100

        '|Description|
        MyBase.setDesc("A ornate sword forged from someone's soul." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Sub Absorb(ByRef m As Monster)
        MyBase.setName("SoulBlade") ' (" & m.name.Split()(0) & ")")
        MyBase.setDesc("A ornate sword forged from " & m.name.Split()(0) & "'s soul.")
        MyBase.setUsable(False)
        MyBase.aBoost = m.attack
        MyBase.value = m.maxHealth
        m.toBlade()
    End Sub

    Public Overrides Function getDesc()
        Return "A ornate sword forged from someone's soul." & DDUtils.RNRN &
                       getStatInformation()
    End Function
End Class
