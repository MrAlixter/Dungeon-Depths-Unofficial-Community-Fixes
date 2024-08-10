Public Class Frostsheer
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Frostsheer")
        settier(2)
        setcost(12)
        setUOC(True)
    End Sub
    Public Overrides Sub effect()
        If Game.combat_engaged Then
            Dim dmg As Integer = 47

            If getTarget.perks(npc_perk.freeze) > -1 Then dmg = Math.Min(dmg * 5, 750)
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)
            getCaster.hit(dmg, getTarget, "", "shatter")
        Else
            Dim floor = Game.currFloor
            Dim success As Boolean = False

            If floor.chestList.Count > 0 Then
                For i = 0 To floor.chestList.Count - 1
                    If getCaster.pos = floor.chestList.Item(i).pos Then
                        TextEvent.pushLog("You crack the chest open with ice magic.")
                        floor.chestList.Item(i).open(False)
                        If floor.floorNumber = 13 AndAlso getCaster.quests(qInd.faewoods2a).canGet Then TextEvent.lblEventOnClose = AddressOf FaeWoodsQ2A.altInit
                        floor.chestList.RemoveAt(i)
                        success = True
                        Exit For
                    End If
                Next
            End If

            If Not success Then
                TextEvent.fpushAndLog("...but there's no chest here.")
            End If
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 offensive spell that deals a medium amount of magic damage, with a low chance of missing altogether.  If the target is frozen, deals x5 damage (with a maximum of 750 damage)." & DDUtils.RNRN &
               "Can be used outside of combat to crack open a chest without allowing mimics to activate."
    End Function
End Class
