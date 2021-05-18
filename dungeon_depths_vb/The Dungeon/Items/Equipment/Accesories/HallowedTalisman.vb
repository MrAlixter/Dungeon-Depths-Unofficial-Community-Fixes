Public Class HallowedTalisman
    Inherits Accessory

    Sub New()
        setName("Hallowed_Talisman")
        setDesc("A simple, beaded necklace that always boosts its wearer's spirit." & DDUtils.RNRN &
                       getStatInformation() & DDUtils.RNRN &
                       "Damage Deflection Effect")
        id = 283
        tier = Nothing
        usable = false
        underClothes = True
        MyBase.m_boost = 10
        count = 0
        value = 125
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
    End Sub
End Class
