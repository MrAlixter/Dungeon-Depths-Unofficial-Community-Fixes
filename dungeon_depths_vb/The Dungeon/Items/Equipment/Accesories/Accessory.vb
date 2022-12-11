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
    Public under_chin As Boolean = False
    Public under_t_clothes As Boolean = False
    Public under_b_clothes As Boolean = False
    Public hide_mouth As Boolean = False
    Public hide_eyes As Boolean = False
    Public hide_dick As Boolean = False
    Public gag As Boolean = False

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedAcce.getAName.Equals(getAName) Then
            TextEvent.push("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub

    Public Overridable Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        If p.prt.iArrInd(pInd.shoulders).Item2 Then
            If Not p.equippedAcce.fInd Is Nothing Then Return p.equippedAcce.fInd Else Return p.equippedAcce.mInd
        Else
            If Not p.equippedAcce.mInd Is Nothing Then Return p.equippedAcce.mInd Else Return p.equippedAcce.fInd
        End If
    End Function
End Class
