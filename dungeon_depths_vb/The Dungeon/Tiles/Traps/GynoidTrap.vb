Public Class GynoidTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.gynoid1
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        TextEvent.push("Before you, you see a large silver canister with a translucent pink screen propped open by two hydraulic arms.  Looking closer at the chamber, you spot the text ""G.C.U"" written on the side, and a holographic countdown timer projected from a chrome pedestal next to it." & DDUtils.RNRN &
                       "This timer seems to be counting down to something called ""ConvProccess.exe"", and as you size up the device it's clear you could squeeze yourself in with the lid sealed even if you have no clue what will happen if you do...", AddressOf gConvChamb, AddressOf gcuCancel, "Get in the G.C.U?")
    End Sub

    Shared Sub gcuCancel()
        TextEvent.push("The lid slams tightly shut, and the system begins whatever it was going to do.  You can not get in anymore.")
    End Sub
    Shared Sub gConvChamb()
        Dim out = "You climb into the chamber, mere seconds until the timer hits zero." & DDUtils.RNRN &
                  "As soon as your body is completely in, the lid slams tightly shut and while you aren't exactly familiar with this level of technology, a forceful 'CHNK' is probably a sign that you won't be getting out until it's hatch opens back up." & DDUtils.RNRN &
                  "Suddenly, a pink visor drops down onto your face from above.  A log of information starts scrolling on the visor, and concealed mechanical arms pop out from the padded interior of the container and position two antennae over your ears." & DDUtils.RNRN &
                  "Looking closer, you notice that some of the rapidly moving information is... yours?  Name, sex, age... this machine is reading your mind!" & DDUtils.RNRN &
                  "While this has you slightly worried, the fact that it seems to be populating a ""DELETION QUEUE"" has you ready to attempt to escape.  As you squirm, the machine takes notice and soon ""SECOND THOUGHTS PROTOCOL"" is flashing on the visor." & DDUtils.RNRN &
                  "As you take a sigh of relief that at least this crazy device has a failsafe, you fail to notice until it's too late that the deletion queue has been re-arranged.  All of a sudden, both the visor and the chambers lid become flashing strobes, and with each flash one of your attributes is marked as ""[deleted]"".  ""MOTOR FUNCTION"" is the first to go, followed by ""NAME"", ""AGE"", and ""LANGUAGE"", and before long a list of your negative emotions fly by on the screen.  Unable to fear, or even mourn your loss, you sit idly as your body's abilities to do, well, anything, are erased one by one." & DDUtils.RNRN &
                  "Finally, after a timeless eternity ""CONSCIOUSNESS"" is at the head of the queue.  With a final flash, everything goes dark."

        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.ears, 9, True, True)

        If p.inv.getCountAt("Cyber_Visor_(P)") < 1 Then p.inv.add("Cyber_Visor_(P)", 1)
        EquipmentDialogBackend.glassesChange(p, "Cyber_Visor_(P)")

        p.ongoingTFs.add(New GynoidTF)

        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
