Public Class DDConst
    Public Shared ReadOnly NEXT_LEVEL_FLOOR As Integer = 125
    Public Shared ReadOnly PINK_MIST_OFFSET As Integer = 1000
    Public Shared ReadOnly TILE_SIZES() As Integer = {15, 30, 45, 60, 90}
    Public Shared ReadOnly CHEAT_LIST() As String = {"asss", "daaa", "wawa", "sasa", "gogo", "seee", "aeio", "wasd", "aaaa", "sawd", "swda", "ssss", "eaea", "ffff"}

    Public Shared ReadOnly MAG_GIRL_UNIFORM_IDS() As Integer = {10, 170, 201, 202, 208, 210, 211, 304}

    Public Shared ReadOnly ALWAYS_REDRAWN_CHARS() As String = {"-", "|", ">", "<", "⇦", "⇨", "/", "\", "a", "¢", "£", "¤", "¥", "¦", "§", "±", "µ", "¡", "¶", "¿", "×", "ø", "æ", "═", "╕", "║", "╙", "╔", "╝"}
    Public Shared ReadOnly NOT_REDRAWN_CHARS() As String = {"", "#", "+", "@", "$", "x", "H", "♩"}
    Public Shared ReadOnly SAVED_CHARS() As String = {"x", "a", "¢", "£", "¤", "¥", "¦", "§", "±", "µ", "¡", "¶", "¿", "×", "ø", "æ"}

    Public Shared ReadOnly SELECT_INDS() As Char = "abcdefghij".ToCharArray

    Public Shared ReadOnly STATNAME_LEVEL As String = "LEVEL"
    Public Shared ReadOnly STATNAME_HP As String = "HP"
    Public Shared ReadOnly STATNAME_MP As String = "MP"
    Public Shared ReadOnly STATNAME_ATK As String = "ATK"
    Public Shared ReadOnly STATNAME_DEF As String = "DEF"
    Public Shared ReadOnly STATNAME_SPD As String = "SPD"
    Public Shared ReadOnly STATNAME_WILL As String = "WILL"
    Public Shared ReadOnly STATNAME_LUST As String = "LUST"
    Public Shared ReadOnly STATNAME_GOLD As String = "GOLD"

    Public Shared ReadOnly BASE_CHEST As Chest = New Chest()
End Class
