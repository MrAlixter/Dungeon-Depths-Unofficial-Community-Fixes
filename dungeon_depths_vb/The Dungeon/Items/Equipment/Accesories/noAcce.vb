Public Class noAcce
    Inherits Accessory
    Sub New()
        '|ID Info|
        setName("Nothing")
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("NO accessory")
    End Sub
End Class
