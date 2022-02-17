Public Class Accessory
    Inherits EquipmentItem

    '| -- Constructor Layout Example -- |
    '|ID Info|


    '|Item Flags|


    '|Stats|


    '|Image Index|


    '|Description|


    'Accessories are equippable items that provide small passive buffs
    Public fInd As Tuple(Of Integer, Boolean, Boolean)
    Public mInd As Tuple(Of Integer, Boolean, Boolean)
    Public under_t_clothes As Boolean = False
    Public under_b_clothes As Boolean = False
    Public hide_mouth As Boolean = False

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedAcce.getAName.Equals(getAName) Then
            TextEvent.push("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub
End Class
