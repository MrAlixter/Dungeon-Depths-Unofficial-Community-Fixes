Public Class DDError
    '| - PUSH METHODS - |
    Private Shared Sub push(ByVal code As String, ByVal msg As String)
        MessageBox.Show(("Error!  " & msg), ("D_D Error " & code), MessageBoxButtons.OK)
    End Sub
    Private Shared Sub pushRestart(ByVal code As String, ByVal msg As String)
        If MessageBox.Show(("Error!  " & msg & "  Restart application?"), ("D_D Error " & code), MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Application.Restart()
        Else
            'Application.Exit()
        End If
    End Sub

    '| - ERRORS - |
    Public Shared Sub characterCreationError()
        pushRestart("001", "Exception thrown while applying selected image.")
    End Sub
    Public Shared Sub missingImageError(ByVal layer As String, ByVal index As Integer)
        push("002", layer & ": Image #" & index & " not found.")
    End Sub
    Public Shared Sub incorrectSaveVersionError()
        push("003", "Incorrect save file version.")
    End Sub
    Public Shared Sub noSaveDetectedError()
        push("004", "No save detected.")
    End Sub
    Public Shared Sub saveFileError()
        pushRestart("005", "The selected save file cannot be loaded due to one or more errors.")
    End Sub
    Public Shared Sub invalidControlKeyError()
        push("006", "Invalid control key entered.")
    End Sub
    Public Shared Sub controlKeyInUseError(ByVal key As String)
        push("007", key & " is already in use.")
    End Sub
    Public Shared Sub transformationMissingNameError(ByVal tf As String)
        push("008", tf & " transformation missing name field.")
    End Sub
    Public Shared Sub transformationError(ByVal tf As String)
        push("009", tf & " transformation has thrown an unhandled exception.")
    End Sub
    Public Shared Sub questMissingNameError(ByVal quest As String)
        push("010", quest & " quest missing name field.")
    End Sub
    Public Shared Sub questError(ByVal quest As String)
        push("011", quest & " quest has thrown an unhandled exception.")
    End Sub
    Public Shared Sub playerClassChangeError(ByVal new_class As String)
        push("012", new_class & " is not a recognized player class.")
    End Sub
    Public Shared Sub playerFormChangeError(ByVal new_form As String)
        push("013", new_form & " is not a recognized player form.")
    End Sub
    Public Shared Sub portraitCreationError(ByVal i As pInd)
        push("014", "Exception thrown in portrait creation (specifically in the " & Portrait.imgLib.atrs.Keys(i).ToString & " layer).")
    End Sub
    Public Shared Sub saveFileImageError()
        push("015", "Missing one or more save images.")
    End Sub
    Public Shared Sub missingInvItemError(ByVal key As String)
        push("016", "Inventory item """ & key & """ not detected.")
    End Sub
    Public Shared Sub badPolymorphError(ByVal poly As String)
        push("017", "Polymorph """ & poly & """ is not valid.")
    End Sub
    Public Shared Sub failedToLoadSettings()
        pushRestart("018", "Unable to load settings file, reverting to default settings.")
    End Sub
    Public Shared Sub failedToLoadTile(ByVal t As tile, ByVal s As tSet)
        push("019", "Failed to find/load the " & t.ToString & " tile from the " & s.ToString & " tileset.")
    End Sub
    Public Shared Sub failedToLoadFBImg(ByVal i As Integer)
        push("020", "Failed to find/load full-body image with index """ & i & """.")
    End Sub
End Class
