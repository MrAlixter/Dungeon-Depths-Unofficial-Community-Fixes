Public Class BBoyshorts
    Inherits Accessory
    Sub New()
        setName("Cursemark")
        setDesc("" & vbCrLf & _
                       "+10 Mana" & vbCrLf & _
                       "-10 WILL")
        id = 140
        tier = Nothing
        usable = false
        MyBase.m_boost = 10
        w_boost = -10
        count = 0
        value = 0

        cursed = True

        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        underClothes = True
    End Sub

    Public Overrides Sub discard()
        Game.pushLblEvent("You can't discard this!")
        Game.pushLstLog("You can't discard this!")
    End Sub

    Shared Function getForm() As preferredForm
        Return New preferredForm(Color.White, Color.FromArgb(255, 255, 78, 78), True, True, 2, True, 0, 26, 6)
    End Function
End Class
