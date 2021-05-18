Public Class HeartNecklace
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        setName("Heart_Necklace")
        setDesc("A small pink heart on a silver chain." & vbCrLf & _
                       "Provides no bonus.")
        id = 66
        tier = Nothing
        usable = false
        count = 0
        value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
    End Sub
End Class
