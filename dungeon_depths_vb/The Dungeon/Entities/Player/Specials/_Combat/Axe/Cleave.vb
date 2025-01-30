Public Class Cleave
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Cleave")
        MyBase.setUOC(True)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Game.combat_engaged Then
            Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
            dmg += ((p.getATK) + (p.equippedWeapon.getABoost(p))) * 1.1
            dmg = Entity.calcDamage(dmg, getTarget.defense * 0.5)

            specHit(getName, dmg, getUser, getTarget)
        Else
            If Not p.equippedWeapon.GetType().IsSubclassOf(GetType(Axe)) Then
                TextEvent.fpushAndLog("...but you don't have an axe equipped.")

                p.stamina += getCost()
                Exit Sub
            End If

            Dim floor = Game.currFloor
            Dim success As Boolean = False
            If floor.chestList.count > 0 Then
                For i = 0 To floor.chestList.count - 1
                    If p.pos = floor.chestList.Item(i).pos Then
                        TextEvent.pushLog("You crack the chest with your " & p.equippedWeapon.getName.Replace("_", " ") & ".")
                        floor.chestList.Item(i).open(False)
                        If floor.floorNumber = 13 AndAlso p.quests(qInd.faewoods2a).canGet Then TextEvent.lblEventOnClose = AddressOf FaeWoodsQ2A.altInit
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
        Return "A focused attack that deals 1.1x damage, and only checks against 0.5x of the enemy's defense.  If an axe is equipped, can be used outside of combat to open chests without activating a mimic."
    End Function
End Class
