Public Class mBoard
    Private mBoardWidth As Integer = 60
    Private mBoardHeight As Integer = 60

    Public boardPic As Bitmap
    Public seenBoardPic As Bitmap
    Public savedBoardPic As Bitmap
    Public boxBoard As PictureBox
    Public testingImageBoard As Boolean = False

    Public mBoard(,) As mTile
    Public mPics(,) As PictureBox       '(NOT SAVED)
    Public floor As Integer = 0
    Public floorCode As String
    Public stairs As Point

    Public chestFreqMin As Integer = 3
    Public chestFreqRange As Integer = 8
    Public chestSizeDependence As Integer = 30
    Public chestRichnessBase As Integer = 1
    Public chestRichnessRange As Integer = 5
    Public encounterRate As Integer = 25
    Public eClockResetVal As Integer = 5

    Public trapFreqMin As Integer = 3
    Public trapFreqRange As Integer = 5
    Public trapSizeDependence As Integer = 30

    Public baseChest As Chest = New Chest()
    Public chestList As List(Of Chest) = New List(Of Chest)
    Public statueList As ArrayList = New ArrayList()    '(NOT SAVED)
    Public trapList As ArrayList = New ArrayList()

    Public beatboss() As Boolean = {False, False, False, False, False, False}  'which bosses have been beat?
    Public floorboss() As String = {"Floor0", "Marissa the Enchantress", "Targax the Brutal", "Key", "Key", "Medusa"} 'boss names (NOT SAVED)
    Public floorLayouts As ArrayList = New ArrayList()

    Public npcList As List(Of NPC) = New List(Of NPC)     'list of non-player updatables (NOT SAVED)
    Public shopkeeper, swiz, hteach As ShopNPC

    Sub New()

    End Sub
    Sub New(ByVal w As Integer, ByVal h As Integer)

    End Sub
    Sub New(ByVal w As Integer, ByVal h As Integer, ByVal cfm As Integer, ByVal cfr As Integer,
            ByVal csd As Integer, ByVal crb As Integer, ByVal crr As Integer, ByVal er As Integer,
            ByVal crv As Integer, ByVal tfm As Integer, ByVal tfr As Integer, ByVal tsd As Integer)

    End Sub


End Class
