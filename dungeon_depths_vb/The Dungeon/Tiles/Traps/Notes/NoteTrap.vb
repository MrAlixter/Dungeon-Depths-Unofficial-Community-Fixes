Public Class NoteTrap
    Inherits Trap

    Protected note_text As String = ""

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.defaultnote

        note_text = "Hey!" & DDUtils.RNRN &
                    "This is the default note." & DDUtils.RNRN &
                    "Cool, cool!"
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        TextEvent.pushNote(note_text, AddressOf effect)
    End Sub

    Overridable Sub effect()
        'Implement for each subclass
    End Sub
End Class
