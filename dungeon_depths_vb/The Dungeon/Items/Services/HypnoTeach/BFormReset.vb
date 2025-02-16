Public Class BFormReset
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Base_Form_Reset"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 131
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = Sub() teach(h_ind.formreset)

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Not happy with your current base form?  I can cause you to forget it, and default you to how you are now.  Well, as long as you're in a stable form, that is...""")
    End Sub

    Protected Overrides Function passesPreCheck(ByRef p As Player) As Boolean
        If Not canHypnotize(p) Then
            failToHypno(p, False)
            TextEvent.pushNPCDialog("""Unfortunately, you seem to be in a rather unstable state.  I am afraid that I will not be able to set your base state at this time.""")
            Return False
        End If

        Return True
    End Function

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return Transformation.canBeTFed(p)
    End Function
    Protected Overrides Function getNoticedChanges(ByRef p As Player) As String
        If HypnosisEffect.hypnotize(p, 80, h_ind.strip) AndAlso HypnosisEffect.trigger(p, h_ind.strip) Then
            Return "The form reset.  She already did it?  But you've always looked like this..." & DDUtils.RNRN & "Stripping naked, you give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it..."
        End If

        Return "The form reset.  She already did it?  But you've always looked like this..." & DDUtils.RNRN & "You give the hypnotist a dirty look.  If she was going to rip you off, your mistress could have done a better job of hiding it..."
    End Function
End Class

