Public Class Shapeshift
    Inherits Special
    Private mode As String = ""

    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Shapeshift")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Sub New(ByRef u As Player, ByRef t As NPC, ByVal m As String)
        Me.New(u, t)

        mode = m
    End Sub


    Public Overrides Sub effect()
        Dim p = MyBase.getUser()

        p.savePState()
        shapeshift()
    End Sub

    Public Sub shapeshift()
        If Not DDUtils.isEmpty(mode) Then
            Select Case mode
                Case "bdn"
                    bdn(getUser)
                Case "bup"
                    bup(getUser)
                Case "ddn"
                    ddn(getUser)
                Case "dup"
                    dup(getUser)
                Case "wdn"
                    wdn(getUser)
                Case "wup"
                    wup(getUser)
            End Select

            Exit Sub
        End If

        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        options.Add(New Tuple(Of String, Action)("Breast size up", Sub() bup(getUser)))
        options.Add(New Tuple(Of String, Action)("Dick size up", Sub() dup(getUser)))
        options.Add(New Tuple(Of String, Action)("Waist size up", Sub() wup(getUser)))
        options.Add(New Tuple(Of String, Action)("Breast size down", Sub() bdn(getUser)))
        options.Add(New Tuple(Of String, Action)("Dick size down", Sub() ddn(getUser)))
        options.Add(New Tuple(Of String, Action)("Waist size down", Sub() wdn(getUser)))

        TextEvent.pushManySelect("Shapeshift how?", options)
    End Sub
    Private Sub ddn(ByRef p As Player)
        p.ds()
        p.lust += 10

        TextEvent.push("Dick Down!  Your cock squeezes uncomfortably...")

        p.drawPort()
    End Sub
    Private Sub dup(ByRef p As Player)
        p.de()
        p.lust += 10

        TextEvent.push("Dick Up!  Your cock tingles plesently...")

        p.drawPort()
    End Sub
    Private Sub bdn(ByRef p As Player)
        p.bs()
        p.lust += 10

        TextEvent.push("Tits Down!  Your breasts squeeze uncomfortably...")

        p.drawPort()
    End Sub
    Private Sub bup(ByRef p As Player)
        p.be()
        p.lust += 10

        TextEvent.push("Tits Up!  Your breasts tingle plesently...")

        p.drawPort()
    End Sub
    Private Sub wdn(ByRef p As Player)
        p.us()
        p.lust += 10

        TextEvent.push("Ass Down!  Your butt squeezes uncomfortably...")

        p.drawPort()
    End Sub
    Private Sub wup(ByRef p As Player)
        p.ue()
        p.lust += 10

        TextEvent.push("Ass Up!  Your butt tingles plesently...")

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance through the infernal dexterity of a succubus."
    End Function
End Class
