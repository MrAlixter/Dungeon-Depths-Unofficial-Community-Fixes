Public Class MGReset
    Inherits Item

    Public Const ITEM_NAME As String = "Magical_Girl_Reset"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 371
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf restore

        '|Stats|
        count = 0
        value = 10

        '|Description|
        setDesc("""Do you, ah, need a hand?  If someone did a bit of work on your Magical Girl transformed form, I can get you reset to zero...""")
    End Sub

    Sub restore()
        Dim p = Game.player1
        Dim out = "Alright, hand me your wand..." & DDUtils.RNRN & "...and you're set!"

        Game.shopMenu.Close()

        EquipmentDialogBackend.equipWeapon(p, "Fists", False)

        TextEvent.pushNPCDialog(out, AddressOf reset)

        p.drawPort()
    End Sub

    Private Shared Sub reset()
        Dim p = Game.player1

        p.magGState = New State()
    End Sub
End Class
