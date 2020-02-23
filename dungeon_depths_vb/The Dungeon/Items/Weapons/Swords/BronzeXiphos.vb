Public Class BronzeXiphos
    Inherits Sword
    'The BronzeXiphos is a weapon with the following damage breakdown
    '4 D3s + 25 + players attack
    'if all four roll 1, then it misses
    'if the sum of the rolls is 11 or 12, then it criticals
    'lust applies
    Sub New()
        MyBase.setName("Bronze_Xiphos")
        MyBase.setDesc("A neat curved double-edged blade forged from bronze." & vbcrlf &
		               "+25 ATK")
        id = 23
        tier = 3
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        count = 0
        value = 900
    End Sub
End Class
