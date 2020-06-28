Public Class Bowtie
    Inherits Accessory

    Sub New()
        MyBase.setName(perk.bowtie)
        MyBase.setDesc("A high class necktie that improves agility and speed.  While it seems ordinary enough at a glance, every once and a while it sparks suspiciously." & vbCrLf & _
                       "+5 Speed, Dodge Effect" & vbCrLf &
                       "If equipped by a Bunny Girl, +Max Mana and ATK based on equipped clothing")
        id = 97
        tier = 3
        MyBase.setUsable(False)
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 2000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.bowtie) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.bowtie) = -1
    End Sub
End Class
