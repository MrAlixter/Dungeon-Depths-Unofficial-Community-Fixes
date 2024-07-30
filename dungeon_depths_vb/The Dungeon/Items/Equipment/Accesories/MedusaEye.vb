Public Class MedusaEye
    Inherits Accessory

    Public Const ITEM_NAME As String = "Medusa's_Eye"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 337
        tier = Nothing

        '|Item Flags|
        usable = True
        hide_eyes = True
        under_m_hair = True
        rando_inv_allowed = False
    
        '|Stats|
        m_boost = 17
        w_boost = 17
        s_boost = 12
        count = 0
        value = 7777

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)

        '|Description|
        setDesc("A glistening lime gemstone that seems to phase through your bare skin.  A slit of endless black running across its surface stares back at you with icy distain." & DDUtils.RNRN &
                "While it isn't usually a good idea to stick weird magic rocks into your face, something tells you this may be an exception." & DDUtils.RNRN &
                "[Medusa's gaze will not affect shopkeepers or bosses.]" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        TextEvent.pushYesNo("The eye gives you chills...  Look deeper?", AddressOf use2, Nothing)
    End Sub

    Public Sub use2()
        Dim pturns = 9999999
        Game.player1.petrify(Color.DarkGray, pturns)
        TextEvent.push(CStr("As you gaze into the crystal's jet-black pupil, it gazes back with vengance and petrifies you for " & pturns & " turns!"))
        TextEvent.pushLog(CStr("Medusa's eye gazes back with vengance and petrifies you for " & pturns & " turns!"))
    End Sub
End Class
