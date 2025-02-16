Public Class NameChange
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Name_Change"
    Dim new_p_name As String = ""

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 121
        tier = Nothing

        '|Item Flags|
        usable = True
        can_be_stolen = False
        rando_inv_allowed = False
        MyBase.onBuy = Sub() teach(h_ind.namechange)

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Not happy with your current name?  Maybe you've evolved past who you were when it fit you?  I can give you a new name, no questions asked.""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        HypnosisEffect.trigger(p, i, new_p_name)
    End Sub

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        If DDUtils.isEmpty(new_p_name) Then
            new_p_name = InputBox("What do you want for a name?").Replace(SaveFile.SEGMENT_DELIMITER, "").Replace(SaveFile.VALUE_DELIMITER, "").Replace(SaveFile.VALUE_SPLIT_DELIMITER, "")
        End If

        Return DDUtils.isEmpty(new_p_name)
    End Function
    Protected Overrides Function getNoticedChanges(ByRef p As Player) As String
        If HypnosisEffect.hypnotize(p, 80, h_ind.strip) AndAlso HypnosisEffect.trigger(p, h_ind.strip) Then
            Return "The name change.  She already did it?  But you've always been " & p.name & "..." & DDUtils.RNRN & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it..."
        End If

        Return "The name change.  She already did it?  But you've always been " & p.name & "..." & DDUtils.RNRN & "You give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it..."
    End Function
End Class
