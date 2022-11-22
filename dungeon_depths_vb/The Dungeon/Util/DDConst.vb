Public Class DDConst
    Public Shared ReadOnly TILE_SIZES() As Integer = {15, 30, 45, 60, 90}
    Public Shared ReadOnly CHEAT_LIST() As String = {"asss", "daaa", "wawa", "sasa", "gogo", "seee", "aeio", "wasd", "aaaa", "sawd", "swda", "ssss", "eaea", "ffff"}

    Public Shared ReadOnly ALWAYS_REDRAWN_CHARS() As String = {"-", "|", ">", "<", "⇦", "⇨", "/", "\", "a", "¢", "£", "¤", "¥", "¦", "§", "±", "µ", "¡", "¶", "¿", "×", "ø", "æ"}
    Public Shared ReadOnly NOT_REDRAWN_CHARS() As String = {"", "#", "+", "@", "$", "x", "H", "♩"}
    Public Shared ReadOnly SAVED_CHARS() As String = {"x", "a", "¢", "£", "¤", "¥", "¦", "§", "±", "µ", "¡", "¶", "¿", "×", "ø", "æ"}

    Public Shared ReadOnly SELECT_INDS() As Char = "abcdefghij".ToCharArray

    Public Shared ReadOnly BASE_CHEST As Chest = New Chest()
End Class
