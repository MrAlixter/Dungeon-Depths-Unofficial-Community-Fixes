Public Class PPanties
    Inherits Accessory
    Sub New()
        MyBase.setName("Pink_Panties")
        MyBase.setDesc("" & vbCrLf & _
                       "+10 Mana" & vbCrLf & _
                       "-10 WILL")
        id = 180
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.hBoost = 10
        MyBase.mBoost = 10
        MyBase.aBoost = 10
        MyBase.dBoost = 10
        MyBase.sBoost = 10
        MyBase.wBoost = 10
        MyBase.count = 0
        MyBase.value = 0

        isCursed = False
        isRandoTFAcceptable = True

        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(14, False, True)

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
