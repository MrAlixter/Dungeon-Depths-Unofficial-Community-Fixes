Public Class GalaxyDye
    Inherits Item

    Sub New()
        MyBase.setName("Galaxy_Dye")
        MyBase.setDesc("A swirling nebula of lights that looks like it could contain countless stars.  Who knows what would happen if you follow the instructions on its side and apply it to your hair?")
        id = 130
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1345
    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.pushLstLog("You apply the " & getName())

        Dim geffect As GalaxyDyeEffect = New GalaxyDyeEffect
        geffect.apply(p)
        count -= 1
    End Sub
End Class
