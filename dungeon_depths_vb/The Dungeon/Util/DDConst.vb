Public Class DDConst
    Public Shared ReadOnly CHEAT_LIST() As String = {"asss", "daaa", "wawa", "sasa", "gogo", "seee", "aeio", "wasd", "aaaa", "sawd", "swda", "ssss", "eaea"}

    Public Shared ReadOnly ALWAYS_REDRAWN_CHARS() As String = {"-", "|", ">", "<", "⇦", "⇨", "/", "\"}
    Public Shared ReadOnly NOT_REDRAWN_CHARS() As String = {"", "#", "+", "@", "$", "x", "H", "♩"}

    Public Shared ReadOnly SELECT_INDS() As Char = "abcdefghijk".ToCharArray

    Public Shared ReadOnly BASE_CHEST As Chest = New Chest()
End Class
