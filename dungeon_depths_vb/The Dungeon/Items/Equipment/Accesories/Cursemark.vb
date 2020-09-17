Public Class Cursemark
    Inherits Accessory
    Sub New()
        MyBase.setName("Cursemark")
        MyBase.setDesc("" & vbCrLf & _
                       "+10 Mana" & vbCrLf & _
                       "-10 WILL")
        id = 168
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 10
        MyBase.wBoost = -10
        MyBase.count = 0
        MyBase.value = 0

        isCursed = True

        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        underClothes = True
    End Sub

    Public Overrides Sub discard()
        Game.pushLblEvent("You can't discard this!")
        Game.pushLstLog("You can't discard this!")
    End Sub

    Shared Function getForm() As preferedForm
        Return New preferedForm(Color.White, Color.FromArgb(255, 255, 78, 78), True, True, 2, True, 0, 26, 6)
    End Function
End Class
