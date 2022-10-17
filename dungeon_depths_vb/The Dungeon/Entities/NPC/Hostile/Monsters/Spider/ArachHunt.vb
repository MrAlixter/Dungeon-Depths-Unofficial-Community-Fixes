Public Class ArachHunt
    Inherits Monster

    Public Const BASE_NAME As String = "Arachne Huntress"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 110
        attack = 65
        defense = 10
        speed = 60
        will = 15

        '|Inventory|
        setInventory({63, 64})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Dim out As String = "It's clear that you can't beat the huntress, weakened as you are.  Dodging even the simplest of her lightning quick strikes is taking more and more of a toll, and you decide that a hasty retreat might be the best bet if you want to survive.  As you turn to run, you hear a giggle over your shoulder.  Sparing a quick glance back, you see the arach... *WHAP!!!*  Suddenly, you can no longer move.  Shocked, you find that you are caught in a large web, and your assailant approaches you slowly." &
            DDUtils.RNRN & """Sshhh, little one..."" she whispers, spinning a tight bond of webbing around your hands and feet before lowering you to the floor,  ""You aren't going to die yet.  Our sisterhood can always use new members, and you can be so much stronger than you are now."""
        TextEvent.push(out, AddressOf arachneDeath2)
    End Sub
    Sub arachneDeath2()
        Dim p As Player = Game.player1
        Dim out As String = "She grips your neck firmly, before baring her small fangs and giving you a quick bite.  You can feel her potent venom as it is injected, and almost immediately your body flushes with arousal.  Everything about your captor, from her supple bossom to her glistening chitinous legs has you lusting for more, and as she positions her slit over your face, your hazy mind loses all control.  Even as your mistress lowers her body onto your face, your tongue begins lapping at her folds." &
            DDUtils.RNRN & """Mmmm..."", the huntress moans, blushing, ""Someone's eager...""." &
            DDUtils.RNRN & "With her approval, you double your efforts and soon your tongue finds her clit.  She begins squirming with pleasure, her warmth radiating onto your face.  Whether it's from the venom or your lover's reaction, your entire body is burning with passion, on the verge of a climax yourself and as you caress her clit with your tongue she isn't far behind you.  With a cry, she orgasms, her fangs spraying golden ichor, though your burning lust continues."
        TextEvent.push(out, AddressOf arachneDeath3)
    End Sub
    Sub arachneDeath3()
        Dim p As Player = Game.player1
        Dim out As String = "Basking in the afterglow of her climax for mere moments, the arachne moves from your face, leaving your immobilized body unable to do much but flail wildly as the heat of your love continues to burn away all rationality." &
            DDUtils.RNRN & """Ooh, you are a fun one..."" she tenderly murmurs, drips from her pussy still falling into your thisty mouth, ""Come and find me when you've finished changing, 'dungeon explorer'""." &
            DDUtils.RNRN & "With that, she leaves your field of view, and you are left smoldering mess of unfulfilled lust soaked in pussy juice, venom, and webbing."
        TextEvent.push(out, AddressOf arachneDeath4)
    End Sub
    Sub arachneDeath4()
        Dim p As Player = Game.player1
        If p.perks(perk.avenom) = -1 And p.perks(perk.svenom) = -1 Then
            p.perks(perk.svenom) = 1
            p.perks(perk.avenom) = 1
            p.ongoingTFs.Add(New ArachneTF(p.perks(perk.svenom)))
        Else
            Dim tf = New ArachneTF(p.perks(perk.svenom))
            tf.setCurrStep(p.perks(perk.svenom))
            tf.setTurnsTilStep(0)
        End If
        Dim out As String = "Hours later, the embers of your venom-fueled passion are all that remain.  You are able to inch yourself to a shallow well, and once in the cool water you break free of your snare and clean yourself off, reflecting on the encounter.  Although the aphrodesiac qualities of the venom have subsided, you can still feel it flow through you.  Given what your mistr...that huntress said, it's likely that you have some physical changes in store.  Part of you wonders why you would even bother stopping them."
        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
