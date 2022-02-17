Public Class DoctorScanner
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.doctor
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        TextEvent.push("""Hello again Doctor, "" a metallic voice chimes from a terminal to your right.  ""I was not aware of your return.  My appologies.  Would you like me to execute standard dress protocols at this time?""", AddressOf doctorAccept, AddressOf doctorCancel, "Give the command?")
    End Sub

    Sub doctorAccept()
        TextEvent.push("""Very good.  Please step onto the equipping pad.""" & DDUtils.RNRN &
                          "Spotting a raised area of the floor that looks to be equipped with all sorts of fancy machinery, you step onto it." & DDUtils.RNRN &
                          """Thank you.  Please remain still.""" & DDUtils.RNRN &
                          """Suddenly, the pad's machinery whirs to life.  While some of its many mechanical arms quickly strip you, others prepare a clinical looking labcoat and begin dressing you in it.  Finally, one arm places a pair of small glasses carefully onto your face and the pad returns to its idle state." & DDUtils.RNRN &
                          """Have a nice day, doctor."" chimes the terminal, before darkening and going to sleep.")

        If Game.player1.inv.getCountAt("Labcoat") < 1 Then Game.player1.inv.add("Labcoat", 1)
        EquipmentDialogBackend.armorChange(Game.player1, "Labcoat")

        Game.player1.prt.setIAInd(pInd.glasses, 2, True, False)

        Game.player1.drawPort()
    End Sub
    Sub doctorCancel()
        TextEvent.push("""Very well.  Have a nice day, doctor."" chimes the terminal, before darkening and going to sleep.")
    End Sub
End Class
