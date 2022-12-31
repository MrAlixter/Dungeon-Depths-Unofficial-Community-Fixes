Public Enum tfind
    amaraphneangel
    angel
    alraune
    amazon
    arachne
    archdemoness
    beehoney
    berrybimbo
    blindness
    blueox
    bimbo
    bimbomaid
    bimbomino
    bimboplus
    blowupdoll
    blowupdollbeach
    broodmother
    bunnybimbo
    bunnygirlbackfire
    cakebackfire
    cherrybimbo
    combatmod
    coserv
    cow
    cynndisguise
    cynntonic
    dancer
    darkpact
    demonbimbo
    demonmino
    dragonpolymorph
    dragonfruitbimbo
    faebimbo
    faecleric
    faepie
    faeprincess
    faerie
    femmino
    femminopolymorph
    gabimbo
    goddess
    goldbimbo
    googirl
    goth
    gynoid
    gynoid2
    halfgorgon
    halfsuccubus
    horse
    hpbimbo
    humanpolymorph
    inversion
    kitsune
    maggirl
    maggirld
    maggirlg
    maggirlmimic
    maggirlp
    maggirlr
    maid
    marissasbimbo
    malmino
    magslut
    mimicmino
    mindless
    mintbimbo
    mpbimbo
    neko
    plantfolk
    plush
    promaggirl
    promaggirlr
    prefform
    princess
    princessbackfire
    rando
    scaletalisman
    sheepbackfire
    shrunken
    slime
    slimepolymorph
    slolita
    spacebun
    spotfuse
    succubusmaid
    succubuspolymorph
    targax
    thrall
    tigresspolymorph
    unicornpolymorph
    valkyrie
    vialofslime
    watermelonbimbo
End Enum

Public MustInherit Class Transformation
    Implements Updatable

    Protected curr_step As Integer
    Protected num_steps As Integer
    Protected turns_until_next_step As Integer
    Protected next_step As Action
    Protected will_impact As Double
    Protected can_be_stopped As Boolean
    Protected tf_name As tfind
    Protected tf_done As Boolean
    Protected update_during_combat As Boolean = True

    'constuctors
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        Dim p As Player = Game.player1
        p.savePState()
        curr_step = 0
        num_steps = n
        turns_until_next_step = tts
        will_impact = wi
        can_be_stopped = cbs
        tf_done = False
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        curr_step = cs
        num_steps = n
        turns_until_next_step = tts
        will_impact = wi
        can_be_stopped = cbs
        tf_done = tfd
    End Sub

    'shared methods
    Shared Function newTF(s() As String) As Transformation
        Dim cs As Integer = CInt(s(0))
        Dim n As Integer = CInt(s(1))
        Dim tts As Integer = CInt(s(2))
        Dim wi As Double = CDbl(s(3))
        Dim cbs As Boolean = CBool(s(4))
        Dim tf As tInd = CInt(s(5))
        Dim tfd As Boolean = CBool(s(6))

        If tf = tfind.amaraphneangel Then
            Return New AmaraphneAngelTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.angel Then
            Return New AngelTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.alraune Then
            Return New AlrauneTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.amazon Then
            Return New AmazonTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.arachne Then
            Return New ArachneTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.archdemoness Then
            Return New ArchDemonessTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.beehoney Then
            Return New BeeHoneyTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.berrybimbo Then
            Return New BBBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.blindness Then
            Return New Blindness(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.blueox Then
            Return New MoxBTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bimbo Then
            Return New BimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bimbomaid Then
            Return New BimboMaidTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bimbomino Then
            Return New BimBellTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bimboplus Then
            Return New BimboPlusTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.blowupdoll Then
            Return New BUDollTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.blowupdollbeach Then
            Return New BUDollTFBeach(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.broodmother Then
            Return New BroodmotherTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bunnybimbo Then
            Return New BunnyBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.bunnygirlbackfire Then
            Return New BunnyGirlTFB(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.cakebackfire Then
            Return New TTCCBF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.cherrybimbo Then
            Return New CBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.combatmod Then
            Return New CombatModTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.coserv Then
            Return New COServ(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.cow Then
            Return New CowTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.cynntonic Then
            Return New CynnTonicTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.cynndisguise Then
            Return New CynnDisguiseTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.dancer Then
            Return New DancerTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.darkpact Then
            Return New DarkPactTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.demonbimbo Then
            Return New DemBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.demonmino Then
            Return New MinoDTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.dragonpolymorph Then
            Return New DragonTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.dragonfruitbimbo Then
            Return New DragonfruitBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.faebimbo Then
            Return New FBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.faecleric Then
            Return New FClericTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.faepie Then
            Return New FaePieTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.faeprincess Then
            Return New FaePrincessTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.faerie Then
            Return New FaerieTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.femmino Then
            Return New MinoFTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.femminopolymorph Then
            Return New MinotaurCowTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.gabimbo Then
            Return New GABimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.goddess Then
            Return New GoddessTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.goldbimbo Then
            Return New GBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.googirl Then
            Return New GooGirlTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.goth Then
            Return New GothGFTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.gynoid Then
            Return New GynoidTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.gynoid2 Then
            Return New GynoidTF2(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.halfgorgon Then
            Return New HGorgonTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.halfsuccubus Then
            Return New HalfSuccubusTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.horse Then
            Return New HorseTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.hpbimbo Then
            Return New HPBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.humanpolymorph Then
            Return New HumanTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.inversion Then
            Return New InversionTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.kitsune Then
            Return New KitsuneTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirl Then
            Return New DancerTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirld Then
            Return New MagGirlDTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirlg Then
            Return New MagGirlGTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirlmimic Then
            Return New MagMimicTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirlp Then
            Return New MagGirlPTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maggirlr Then
            Return New MagGirlRTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.maid Then
            Return New MaidTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.marissasbimbo Then
            Return New MASBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.malmino Then
            Return New MinoMTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.magslut Then
            Return New MagSlutTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.mimicmino Then
            Return New MimicMinoTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.mindless Then
            Return New MindlessTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.mintbimbo Then
            Return New MBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.mpbimbo Then
            Return New MPBimboTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.neko Then
            Return New NekoTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.plantfolk Then
            Return New PlantfolkTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.plush Then
            Return New PlushTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.promaggirl Then
            Return New ProMagGirlTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.promaggirlr Then
            Return New ProMagGirlRTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.prefform Then
            Return New PreferredFormTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.princess Then
            Return New PrincessTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.princessbackfire Then
            Return New PrincessTFB(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.rando Then
            Return New RandoTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.scaletalisman Then
            Return New ScaleTalismanTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.sheepbackfire Then
            Return New SheepTFB(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.shrunken Then
            Return New ShrunkenTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.slime Then
            Return New SlimeETF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.slimepolymorph Then
            Return New SlimeTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.slolita Then
            Return New LolitaSTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.spacebun Then
            Return New SpaceBunTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.spotfuse Then
            Return New SpotFuseTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.succubusmaid Then
            Return New SuccubusMaidTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.succubuspolymorph Then
            Return New SuccubusTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.targax Then
            Return New TargaxTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.thrall Then
            Return New ThrallTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.tigresspolymorph Then
            Return New TigressTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.unicornpolymorph Then
            Return New UnicornTF(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.valkyrie Then
            Return New ValkyrieTF2(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.vialofslime Then
            Return New VialOfslimetf(cs, n, tts, wi, cbs, tfd)

        ElseIf tf = tfind.watermelonbimbo Then
            Return New WBimboTF(cs, n, tts, wi, cbs, tfd)

        Else
            Return Nothing
        End If
    End Function
    Shared Function canBeTFed(ByRef p As Player) As Boolean
        If Game.player1.ongoingTFs.count < 1 And
            p.pClass.canBeTFed And
            p.pForm.canBeTFed And
            p.prt.oneLayerImgCheck(p.formName, p.className) Is Nothing And
            Not p.perks(perk.polymorphed) > 0 And
            Not p.perks(perk.astatue) > 1 And Not p.isPetrified And
            p.perks(perk.tfedbyweapon) < 0 And p.perks(perk.tfcausingwand) < 0 And p.perks(perk.tfcausingsword) < 0 And
            Not p.perks(perk.pdeflector) > 0 Then

            Return True
        End If

        Return False
    End Function

    Shared Function doPartialRevert() As Boolean
        Return False
    End Function

    'updateable implementation 
    Overridable Sub update() Implements Updatable.update
        If Not update_during_combat And Game.combat_engaged Then Exit Sub
        If turns_until_next_step = 0 Then
            next_step = getNextStep(curr_step)
            next_step()
            curr_step += 1
            setWaitTime(curr_step)
            next_step = getNextStep(curr_step)
            If curr_step > num_steps Then stopTF()
        ElseIf turns_until_next_step = -1 Then
            Dim i = 1
        Else
            turns_until_next_step -= 1
        End If
    End Sub
    Overridable Sub removeFromTFList()
    End Sub

    'sequential tf methods
    Sub setCurrStep(i As Integer)
        curr_step = i
    End Sub
    Sub setTurnsTilStep(i As Integer)
        turns_until_next_step = i
    End Sub
    Overridable Sub stopTF()
        tf_done = True
    End Sub
    Overridable Sub setWaitTime(ByVal stage As Integer)
        turns_until_next_step = 1
        turns_until_next_step += generatWILResistance()
    End Sub
    Function generatWILResistance()
        Return CInt(turns_until_next_step * (Game.player1.getWIL() / 13) * will_impact)
    End Function

    'toString for save / load
    Public Overrides Function ToString() As String
        Return curr_step & "$" & num_steps & "$" & turns_until_next_step & "$" & _
            will_impact & "$" & can_be_stopped & "$" & tf_name & "$" & tf_done
    End Function
    Public Function save() As String
        Return curr_step & SaveFile.VALUE_DELIMITER &
               num_steps & SaveFile.VALUE_DELIMITER &
               turns_until_next_step & SaveFile.VALUE_DELIMITER &
               will_impact & SaveFile.VALUE_DELIMITER &
               can_be_stopped & SaveFile.VALUE_DELIMITER &
               tf_name & SaveFile.VALUE_DELIMITER &
               tf_done
    End Function
    'accessor methods
    Public Function getCanBeStopped() As Boolean
        Return can_be_stopped
    End Function
    Public Function getTurnsTilNextStep() As Integer
        Return turns_until_next_step
    End Function
    Public Overridable Function getTFDone() As Boolean
        Return tf_done
    End Function
    Public Function getTFName() As String
        Return tf_name
    End Function
    Public Function getNextStep() As Action
        Return next_step
    End Function
    MustOverride Function getNextStep(ByVal stage As Integer) As action
End Class
