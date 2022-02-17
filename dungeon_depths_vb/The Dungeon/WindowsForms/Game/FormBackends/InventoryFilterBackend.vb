Public Class InventoryFilterBackend
    Public Shared invFilters() As Boolean = {True, True, True, True, True, True, True, True}

    Shared Sub New()
        Game.chkUseable.Checked = True
        Game.chkPotion.Checked = True
        Game.chkFood.Checked = True
        Game.chkArmor.Checked = True
        Game.chkWeapon.Checked = True
        Game.chkMisc.Checked = True
        Game.chkAcc.Checked = True
        Game.chkGlasses.Checked = True
    End Sub

    Public Shared Sub btnFilter_Click(sender As Object, e As EventArgs)
        Game.pnlInvFilter.Visible = True

        Game.chkUseable.Visible = True
        Game.chkPotion.Visible = True
        Game.chkFood.Visible = True
        Game.chkArmor.Visible = True
        Game.chkWeapon.Visible = True
        Game.chkMisc.Visible = True
        Game.chkAcc.Visible = True
        Game.chkGlasses.Visible = True

        Game.btnOk.Visible = True
        Game.btnAll.Visible = True
        Game.btnNone.Visible = True

        If Game.chkUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
        If Game.chkPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
        If Game.chkFood.Checked Then invFilters(2) = True Else invFilters(2) = False
        If Game.chkArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
        If Game.chkWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
        If Game.chkMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
        If Game.chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
        If Game.chkGlasses.Checked Then invFilters(7) = True Else invFilters(7) = False
    End Sub
    Public Shared Sub btnOk_Click(sender As Object, e As EventArgs)
        Game.pnlInvFilter.Visible = False
        Game.chkUseable.Visible = False
        Game.chkPotion.Visible = False
        Game.chkFood.Visible = False
        Game.chkArmor.Visible = False
        Game.chkWeapon.Visible = False
        Game.chkMisc.Visible = False
        Game.chkAcc.Visible = False
        Game.chkGlasses.Visible = False
        Game.btnOk.Visible = False
        Game.btnAll.Visible = False
        Game.btnNone.Visible = False
        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Public Shared Sub fUseable_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkUseable.Checked Then invFilters(0) = True Else invFilters(0) = False
    End Sub
    Public Shared Sub fPotion_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkPotion.Checked Then invFilters(1) = True Else invFilters(1) = False
    End Sub
    Public Shared Sub fFood_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkFood.Checked Then invFilters(2) = True Else invFilters(2) = False
    End Sub
    Public Shared Sub fArmor_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkArmor.Checked Then invFilters(3) = True Else invFilters(3) = False
    End Sub
    Public Shared Sub fWeapon_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkWeapon.Checked Then invFilters(4) = True Else invFilters(4) = False
    End Sub
    Public Shared Sub fMisc_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkMisc.Checked Then invFilters(5) = True Else invFilters(5) = False
    End Sub
    Public Shared Sub chkAcc_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkAcc.Checked Then invFilters(6) = True Else invFilters(6) = False
    End Sub
    Public Shared Sub chkGlasses_CheckedChanged(sender As Object, e As EventArgs)
        If Game.chkGlasses.Checked Then invFilters(7) = True Else invFilters(7) = False
    End Sub

    Public Shared Sub btnAll_Click(sender As Object, e As EventArgs)
        Game.chkUseable.Checked = True
        Game.chkPotion.Checked = True
        Game.chkFood.Checked = True
        Game.chkArmor.Checked = True
        Game.chkWeapon.Checked = True
        Game.chkMisc.Checked = True
        Game.chkAcc.Checked = True
        Game.chkGlasses.Checked = True
    End Sub
    Public Shared Sub btnNone_Click(sender As Object, e As EventArgs)
        Game.chkUseable.Checked = False
        Game.chkPotion.Checked = False
        Game.chkFood.Checked = False
        Game.chkArmor.Checked = False
        Game.chkWeapon.Checked = False
        Game.chkMisc.Checked = False
        Game.chkAcc.Checked = False
        Game.chkGlasses.Checked = False
    End Sub
End Class
