Public Class Equipment
    'Form3 is the form that handles the equiping of armor and weapons

    'instance variables for Form3
    'armor
    Private aList As Dictionary(Of String, Armor) = New Dictionary(Of String, Armor)
    'weapons
    Private wList As Dictionary(Of String, Weapon) = New Dictionary(Of String, Weapon)
    'accessories
    Private acList As Dictionary(Of String, Accessory) = New Dictionary(Of String, Accessory)

    'init triggers an initialion Form3's global variables 
    Public Sub init()
        Dim p = Game.player1
        Dim a As Tuple(Of String(), Armor())
        Dim w As Tuple(Of String(), Weapon())
        Dim ac As Tuple(Of String(), Accessory())

        a = p.inv.getArmors
        w = p.inv.getWeapons
        ac = p.inv.getAccesories

        aList.Clear()
        wList.Clear()
        acList.Clear()

        For i = 0 To UBound(a.Item1)
            aList.Add(a.Item1(i), a.Item2(i))
        Next

        For i = 0 To UBound(w.Item1)
            wList.Add(w.Item1(i), w.Item2(i))
        Next

        For i = 0 To UBound(ac.Item1)
            acList.Add(ac.Item1(i), ac.Item2(i))
        Next
    End Sub

    'handles the click of the 'ok' button
    Private Sub btnACPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACPT.Click
        Dim p = Game.player1
        Dim needsToUpdate As Boolean = False

        'equip the new equipment
        needsToUpdate = equipArmor(p, cboxArmor.Text)
        needsToUpdate = needsToUpdate Or equipWeapon(p, cboxWeapon.Text)
        needsToUpdate = needsToUpdate Or equipAcce(p, cboxAccessory.Text)

        'updates the player, the stat display, and the portrait before the form closes
        p.drawPort()
        p.UIupdate()

        'update the pnlDescription image too, if necessary
        If Game.pnlDescription.Visible Then
            Game.picDescPort.BackgroundImage = Portrait.CreateFullBodyBMP(p.prt.iArr)
        End If

        Me.Close()
    End Sub
    Public Shared Function equipArmor(ByRef p As Player, ByVal armor As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        Return EquipmentDialogBackend.equipArmor(p, armor, considerCurse)
    End Function
    Public Shared Function equipWeapon(ByRef p As Player, ByVal weapon As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        Return EquipmentDialogBackend.equipWeapon(p, weapon, considerCurse)
    End Function
    Public Shared Function equipAcce(ByRef p As Player, ByVal acce As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        Return EquipmentDialogBackend.equipAcce(p, acce, considerCurse)
    End Function

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Close()

        EquipmentDialogBackend.showEquipDialog(Game.player1)
    End Sub
    Sub defaultClothesOptions(ByRef options As ComboBox.ObjectCollection)
        EquipmentDialogBackend.defaultArmorOptions(options)
    End Sub
    Sub defaultClothesOptions(ByRef options As List(Of String))
        EquipmentDialogBackend.defaultArmorOptions(options)
    End Sub


    Function clothingCurse1(ByRef p As Player) As Boolean
        Return EquipmentDialogBackend.clothingCurse(p)
    End Function
    Function antiClothingCurse(ByRef p As Player) As Boolean
        Return EquipmentDialogBackend.antiClothingCurse(p)
    End Function

    Public Sub clothesChange(ByRef p As Player, ByVal clothes As String, Optional doEquipHandlers As Boolean = True)
        EquipmentDialogBackend.armorChange(p, clothes, doEquipHandlers)
    End Sub
    Public Sub weaponChange(ByRef p As Player, ByVal weapon As String, Optional doEquipHandlers As Boolean = True)
        EquipmentDialogBackend.weaponChange(p, weapon, doEquipHandlers)
    End Sub
    Public Sub accChange(ByRef p As Player, ByVal acc As String, Optional doEquipHandlers As Boolean = True)
        EquipmentDialogBackend.accessoryChange(p, acc, doEquipHandlers)
    End Sub
End Class