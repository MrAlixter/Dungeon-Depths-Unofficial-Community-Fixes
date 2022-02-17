Public Class Glasses
    Inherits EquipmentItem

    '| -- Constructor Layout Example -- |
    '|ID Info|


    '|Item Flags|


    '|Stats|


    '|Image Index|


    '|Description|


    Public imgInd As Tuple(Of Integer, Boolean, Boolean)

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedAcce.getAName.Equals(getAName) Then
            TextEvent.push("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
