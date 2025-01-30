Public Class InanimateEntity
    Public name As String
    Public p_form As String
    Public p_class As String

    Public max_health As Integer
    Public max_mana As Integer
    Public atk As Integer
    Public def As Integer
    Public spd As Integer
    Public wil As Integer

    Public level As Integer
    Public pos As Point

    Public prt As Portrait = Nothing

    Public extra1 As String
    Public extra2 As String
    Public extra3 As String
    Public extra4 As String
    Public extra5 As String
    Public extra6 As String
    Public extra7 As String
    Public extra8 As String

    Protected session As String

    Protected Sub New()
    End Sub
    Public Sub New(ByRef ent As Entity)
        name = ent.name

        max_health = ent.maxHealth
        max_mana = ent.maxMana
        atk = ent.attack
        def = ent.defense
        spd = ent.speed
        wil = ent.will

        level = ent.level
        pos = New Point(ent.pos.X, ent.pos.Y)

        If Not ent.getPlayer Is Nothing Then
            p_class = ent.getPlayer.className
            p_form = ent.getPlayer.formName
            prt = ent.getPlayer.prt.Clone
            session = Game.sessionID
            extra1 = ent.getPlayer.sex
        ElseIf Not ent.getNPC.title.Replace(" ", "") = "" Then
            name = "a " & name
        End If
    End Sub
    Public Function revert() As Entity
        If Not session = "" Then
            Dim p As Player = New Player

            p.name = name
            p.changeClass(p_class)
            p.changeForm(p_form)

            p.maxHealth = max_health
            p.maxMana = max_mana
            p.attack = atk
            p.defense = def
            p.speed = spd
            p.will = wil

            p.level = level
            p.pos = pos

            p.prt = prt.Clone
            p.prt.ent = p

            Game.sessionID = session

            p.sex = extra1

            p.allRoute()

            Return p
        End If

        Return New player
    End Function

    Public Sub writeToFile(ByVal item_id As Integer)
        Dim output = CStr(
            "INENT" & SaveFile.VALUE_DELIMITER &
            name & SaveFile.VALUE_DELIMITER &
            p_form & SaveFile.VALUE_DELIMITER &
            p_class & SaveFile.VALUE_DELIMITER &
            max_health & SaveFile.VALUE_DELIMITER &
            max_mana & SaveFile.VALUE_DELIMITER &
            atk & SaveFile.VALUE_DELIMITER &
            def & SaveFile.VALUE_DELIMITER &
            spd & SaveFile.VALUE_DELIMITER &
            wil & SaveFile.VALUE_DELIMITER &
            level & SaveFile.VALUE_DELIMITER &
            extra1 & SaveFile.VALUE_DELIMITER &
            extra2 & SaveFile.VALUE_DELIMITER &
            extra3 & SaveFile.VALUE_DELIMITER &
            extra4 & SaveFile.VALUE_DELIMITER &
            extra5 & SaveFile.VALUE_DELIMITER &
            extra6 & SaveFile.VALUE_DELIMITER &
            extra7 & SaveFile.VALUE_DELIMITER &
            extra8 & SaveFile.VALUE_DELIMITER &
            session & SaveFile.SEGMENT_DELIMITER & vbCrLf)

        If Not session = "" Then
            output += "PNT" & SaveFile.VALUE_DELIMITER &
                      pos.X & SaveFile.VALUE_DELIMITER &
                      pos.Y & SaveFile.SEGMENT_DELIMITER & vbCrLf
            output += "CLR" & SaveFile.VALUE_DELIMITER &
                      prt.haircolor.A & SaveFile.VALUE_DELIMITER &
                      prt.haircolor.R & SaveFile.VALUE_DELIMITER &
                      prt.haircolor.G & SaveFile.VALUE_DELIMITER &
                      prt.haircolor.B & SaveFile.SEGMENT_DELIMITER & vbCrLf
            output += "CLR" & SaveFile.VALUE_DELIMITER &
                      prt.skincolor.A & SaveFile.VALUE_DELIMITER &
                      prt.skincolor.R & SaveFile.VALUE_DELIMITER &
                      prt.skincolor.G & SaveFile.VALUE_DELIMITER &
                      prt.skincolor.B & SaveFile.SEGMENT_DELIMITER & vbCrLf
            output += "PRT" & SaveFile.VALUE_DELIMITER & UBound(prt.iArrInd) & SaveFile.SEGMENT_DELIMITER & vbCrLf
            For Each img_ind In prt.iArrInd
                output += "IMG" & SaveFile.VALUE_DELIMITER &
                          img_ind.Item1 & SaveFile.VALUE_DELIMITER &
                          img_ind.Item2 & SaveFile.VALUE_DELIMITER &
                          img_ind.Item3 & SaveFile.SEGMENT_DELIMITER & vbCrLf
            Next
        End If

        Dim writer As IO.StreamWriter
        Dim filename As String = "items\" & Game.sessionID & "_" & item_id & ".itm"
        IO.File.Delete(filename)
        writer = IO.File.CreateText(filename)
        writer.Write(output)
        writer.Flush()
        writer.Close()
    End Sub
    Public Shared Function loadFromFile(ByVal item_id As Integer, Optional ByVal sessionID As String = "") As InanimateEntity

        If sessionID = "" Then sessionID = DDUtils.getSessionID(DDUtils.getPathUsingWC("items\", "*_" & item_id & ".itm"))
        Dim filename As String = "items\" & sessionID & "_" & item_id & ".itm"
      
        Dim in_ent As InanimateEntity = New InanimateEntity()

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Try
            '| - Load the Header - |
            Dim head_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)
            in_ent.name = head_seg(1)
            in_ent.p_form = head_seg(2)
            in_ent.p_class = head_seg(3)
            in_ent.max_health = head_seg(4)
            in_ent.max_mana = head_seg(5)
            in_ent.atk = head_seg(6)
            in_ent.def = head_seg(7)
            in_ent.spd = head_seg(8)
            in_ent.wil = head_seg(9)
            in_ent.level = head_seg(10)
            in_ent.extra1 = head_seg(11)
            in_ent.extra2 = head_seg(12)
            in_ent.extra3 = head_seg(13)
            in_ent.extra4 = head_seg(14)
            in_ent.extra5 = head_seg(15)
            in_ent.extra6 = head_seg(16)
            in_ent.extra7 = head_seg(17)
            in_ent.extra8 = head_seg(18)
            in_ent.session = head_seg(19)

            If Not in_ent.session = "" Then
                '| - Load the Pos - |
                Dim pt_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)
                in_ent.pos = New Point(pt_seg(1), pt_seg(2))

                '| - Load the PRT - |
                in_ent.prt = New Portrait(in_ent.extra1.ToLower.Equals("female"), Nothing)
                Dim hair_c_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)
                Dim skin_c_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)

                in_ent.prt.haircolor = Color.FromArgb(hair_c_seg(1), hair_c_seg(2), hair_c_seg(3), hair_c_seg(4))
                in_ent.prt.skincolor = Color.FromArgb(skin_c_seg(1), skin_c_seg(2), skin_c_seg(3), skin_c_seg(4))

                Dim iarr_ub_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)
                For i As Integer = 0 To iarr_ub_seg(1)
                    Dim img_seg = (reader.ReadLine()).Replace(SaveFile.SEGMENT_DELIMITER, "").Split(SaveFile.VALUE_DELIMITER)
                    in_ent.prt.iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(img_seg(1), img_seg(2), img_seg(3))
                Next
            End If
        Catch e As Exception
            TextEvent.pushLog(" >>: Error loading data from " & filename & ".  Deleting corrupted file.")
            reader.Dispose()
            IO.File.Delete(filename)
            Return Nothing
        Finally
            reader.Close()
        End Try

        Return in_ent
    End Function
End Class
