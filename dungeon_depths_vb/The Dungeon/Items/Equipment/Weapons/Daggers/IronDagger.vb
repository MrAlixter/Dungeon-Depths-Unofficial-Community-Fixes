Public Class IronDagger
    Inherits Dagger

    Public Const ITEM_NAME As String = "Iron_Dagger"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 351
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 470
        a_boost = 6
        s_boost = 10

        '|Description|
        setDesc("A shiny blade small enough to be concealed and drawn at will.  The blade may not be particularly sharp, the quality of iron contained within makes it very effective against fae-type enemies." & DDUtils.RNRN &
                "When attacking, the user hits twice." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso Not p.currTarget Is Nothing AndAlso p.currTarget.getNameWithTitle.Contains("Fae") Then
            Return 36
        Else
            Return MyBase.getABoost(p)
        End If
    End Function

    Public Overrides Function getDesc() As Object
        Return "A shiny blade small enough to be concealed and drawn at will.  The blade may not be particularly sharp, the quality of iron contained within makes it very effective against fae-type enemies." & DDUtils.RNRN &
               "When attacking, the user hits twice." & DDUtils.RNRN &
               getStatInformation()
    End Function
End Class
