Public Class Monocle
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Monocle")
        id = 313
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)

        '|Description|
        setDesc("A classy glass eyepiece with only a single lens." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
