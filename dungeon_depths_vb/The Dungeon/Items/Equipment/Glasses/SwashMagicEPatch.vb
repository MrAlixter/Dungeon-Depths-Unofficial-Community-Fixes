Public Class SwashMagicEPatch
    Inherits Glasses

    Public Const ITEM_NAME = "Hornswoggler's_Oculus"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 329
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 3442

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        '|Description|
        setDesc("While it may simply look like an ornate eyepatch, a closer look reveals that it hides a magic eyepiece." & DDUtils.RNRN &
                "While equipped, rank-and-file monsters will drop twice as much gold as usual." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
