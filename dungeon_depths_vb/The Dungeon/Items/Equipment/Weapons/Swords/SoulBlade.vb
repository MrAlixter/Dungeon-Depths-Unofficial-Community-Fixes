Public Class SoulBlade
    Inherits Sword

    Sub New()
        MyBase.setName("SoulBlade")
        MyBase.setDesc("A ornate sword forged from someone's soul.")
        id = 9
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Public Sub Absorb(ByRef m As Monster)
        MyBase.setName("SoulBlade") ' (" & m.name.Split()(0) & ")")
        MyBase.setDesc("A ornate sword forged from " & m.name.Split()(0) & "'s soul.")
        MyBase.setUsable(False)
        MyBase.aBoost = m.attack
        MyBase.value = m.maxHealth
        m.toBlade()
    End Sub
End Class
