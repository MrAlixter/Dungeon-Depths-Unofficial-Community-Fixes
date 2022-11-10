Public Enum tile
    tile
    wall
    fog
    stairs
    stairsboss
    stairslock
    chest
    trap
    statue
    note
    crystal
    path
    item
    player
    bimbo
    demon
    succubus
    dragon
    broodmother
    frog
    cow
    sheep
    horse
    unicorn
    blob
    sk
    sw
    ht
    fv
    ws
    mg
    cb
    tt
    extra1
    extra2
    extra3
    extra4
    extra5
    extra6
    extra7
    extra8
    extra9
    extra10
    extra11
    extra12
    sk_barrel
    sk_crate
End Enum
Public Enum tSet
    dungeon
    forest
    space
    legacy
    fogforest
    hub
    desert
    cloudb
    cave
    caveh
    mossdungeon
End Enum
Public Class mTile
    'since the original (not picture) board was made of labels, and the picture board eliminated the need
    'for it to be seen, I've replaced the labels with a smaller data type that uses only the essential
    'portions of the label (the tag, text, and forecolor)
    Public Tag As Integer
    Public Text As String
    Public ForeColor As Color

    Public Shared imgLib As TileImageCollection

    Shared Sub init()
        imgLib = New TileImageCollection()
    End Sub

    'New creates a new instance of a mTile
    Sub New(ByVal t As Integer, ByVal s As String, ByVal c As Color)
        Tag = t
        Text = s
        ForeColor = c
    End Sub
    'dispose removes an old instance of a mTile
    Public Sub Dispose()
        Tag = Nothing
        Text = Nothing
        ForeColor = Nothing
        Me.Finalize()
    End Sub
End Class
