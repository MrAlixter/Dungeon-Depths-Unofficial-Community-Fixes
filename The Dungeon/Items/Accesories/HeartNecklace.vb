Public Class HeartNecklace
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        MyBase.setName("Heart_Necklace")
        MyBase.setDesc("A small pink heart on a silver chain." & vbCrLf & _
                       "Provides no bonus.")
        id = 66
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean)(1, True)
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
