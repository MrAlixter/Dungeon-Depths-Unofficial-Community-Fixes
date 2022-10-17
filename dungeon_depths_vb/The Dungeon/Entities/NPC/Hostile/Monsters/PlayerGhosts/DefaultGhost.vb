Public Class DefaultGhost
    Inherits PlayerGhost

    Public Shadows Const BASE_NAME As String = "Default Ghost"

    '| - LOADING THE GHOST - |
    Protected Overrides Function loadGhost() As Boolean
        'personal information
        name = "Amber the Bimbo"
        first_name = "Amber"
        deathfloor = Game.currFloor.floorNumber - 1
        class_name = "Bimbo"

        'stats
        health = 1.0
        maxHealth = 100
        attack = 25
        mana = 25
        defense = 25
        speed = 25
        will = 25

        'portrait
        sex_bool = True
        eye_ind = New Tuple(Of Integer, Boolean, Boolean)(56, True, True)
        haircolor = BimboTF.bimboyellow2

        'inventory


        Return True
    End Function
End Class
