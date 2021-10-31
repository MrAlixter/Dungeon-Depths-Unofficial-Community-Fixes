Public Class noGlasses
    Inherits Glasses
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
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("No glasses")
    End Sub
End Class
