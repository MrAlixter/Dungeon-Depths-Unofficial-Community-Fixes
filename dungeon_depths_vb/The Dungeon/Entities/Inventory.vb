Public Class Inventory
    Dim internal_inventory As New Dictionary(Of String, Item)
    Dim armor() As Armor
    Dim weapons() As Weapon
    Dim acce() As Accessory
    Dim glasses() As Glasses
    Dim useable(), food(), potions(), services(), misc() As Item
    Public mPotions As List(Of MysteryPotion)
    Public invNeedsUDate As Boolean = False
    Public invIDorder As List(Of Integer)
    Dim sum As Integer = 0

    '|CONSTUCTOR|
    Sub New(Optional ByVal shufflePotions As Boolean = False)
        '0.1 - 0.4
        internal_inventory.Add(Compass.ITEM_NAME, New Compass)                       '0
        internal_inventory.Add(StickOfGum.ITEM_NAME, New StickOfGum)                 '1
        internal_inventory.Add(HealthPotion.ITEM_NAME, New HealthPotion)             '2
        internal_inventory.Add(VialOfSlime.ITEM_NAME, New VialOfSlime)               '3
        internal_inventory.Add(Spellbook.ITEM_NAME, New Spellbook)                   '4
        internal_inventory.Add(SteelArmor.ITEM_NAME, New SteelArmor)                 '5
        internal_inventory.Add(SteelSword.ITEM_NAME, New SteelSword)                 '6
        internal_inventory.Add(SteelBikini.ITEM_NAME, New SteelBikini)               '7
        internal_inventory.Add(ChickenSuit.ITEM_NAME, New ChickenSuit)               '8
        internal_inventory.Add(SoulBlade.ITEM_NAME, New SoulBlade)                   '9
        internal_inventory.Add(MagGirlOutfit.ITEM_NAME, New MagGirlOutfit)           '10
        internal_inventory.Add(MagGirlWand.ITEM_NAME, New MagGirlWand)               '11
        internal_inventory.Add(CatLingerie.ITEM_NAME, New CatLingerie)               '12
        internal_inventory.Add(ManaPotion.ITEM_NAME, New ManaPotion)                 '13
        internal_inventory.Add(RestorationPotion.ITEM_NAME, New RestorationPotion)   '14
        internal_inventory.Add(CatEars.ITEM_NAME, New CatEars)                       '15
        internal_inventory.Add(BunnySuit.ITEM_NAME, New BunnySuit)                   '16
        internal_inventory.Add(SorcerersRobes.ITEM_NAME, New SorcerersRobes)         '17
        internal_inventory.Add(WitchCosplay.ITEM_NAME, New WitchCosplay)             '18
        internal_inventory.Add(WarriorsCuirass.ITEM_NAME, New WarriorsCuirass)       '19
        internal_inventory.Add(BrawlerCosplay.ITEM_NAME, New BrawlerCosplay)         '20
        internal_inventory.Add(OakStaff.ITEM_NAME, New OakStaff)                     '21
        internal_inventory.Add(WizardStaff.ITEM_NAME, New WizardStaff)               '22
        internal_inventory.Add(BronzeXiphos.ITEM_NAME, New BronzeXiphos)             '23
        internal_inventory.Add(TargaxSword.ITEM_NAME, New TargaxSword)               '24
        internal_inventory.Add(BEPotion.ITEM_NAME, New BEPotion)                     '25
        internal_inventory.Add(HazardousPotion.ITEM_NAME, New HazardousPotion)       '26
        internal_inventory.Add(GentlePotion.ITEM_NAME, New GentlePotion)             '27
        internal_inventory.Add(GSPotion.ITEM_NAME, New GSPotion)                     '28
        internal_inventory.Add(FemininePotion.ITEM_NAME, New FemininePotion)         '29
        internal_inventory.Add(ChickenLeg.ITEM_NAME, New ChickenLeg)                 '30
        internal_inventory.Add(PApple.ITEM_NAME, New PApple)                         '31
        internal_inventory.Add(Apple.ITEM_NAME, New Apple)                           '32
        internal_inventory.Add(Herbs.ITEM_NAME, New Herbs)                           '33
        internal_inventory.Add(HeavyCream.ITEM_NAME, New HeavyCream)                 '34
        internal_inventory.Add(Cupcake.ITEM_NAME, New Cupcake)                       '35
        internal_inventory.Add(Mirror.ITEM_NAME, New Mirror)                         '36
        internal_inventory.Add(Glowstick.ITEM_NAME, New Glowstick)                   '37
        internal_inventory.Add(GoldArmor.ITEM_NAME, New GoldArmor)                   '38
        internal_inventory.Add(GoldAdornment.ITEM_NAME, New GoldAdornment)           '39
        internal_inventory.Add(GoldSword.ITEM_NAME, New GoldSword)                   '40
        internal_inventory.Add(GoldenStaff.ITEM_NAME, New GoldenStaff)               '41
        internal_inventory.Add(MidasGuantlet.ITEM_NAME, New MidasGuantlet)           '42
        internal_inventory.Add(Gold.ITEM_NAME, New Gold)                             '43
        internal_inventory.Add(AngelFood.ITEM_NAME, New AngelFood)                   '44
        internal_inventory.Add(MaidDuster.ITEM_NAME, New MaidDuster)                 '45
        internal_inventory.Add(TankTop.ITEM_NAME, New TankTop)                       '46
        internal_inventory.Add(SportBra.ITEM_NAME, New SportBra)                     '47
        internal_inventory.Add(HealthCharm.ITEM_NAME, New HealthCharm)               '48
        internal_inventory.Add(ManaCharm.ITEM_NAME, New ManaCharm)                   '49
        internal_inventory.Add(AttackCharm.ITEM_NAME, New AttackCharm)               '50
        internal_inventory.Add(DefenseCharm.ITEM_NAME, New DefenseCharm)             '51
        internal_inventory.Add(SpeedCharm.ITEM_NAME, New SpeedCharm)                 '52
        internal_inventory.Add(Key.ITEM_NAME, New Key)                               '53
        internal_inventory.Add(Ropes.ITEM_NAME, New Ropes)                           '54
        internal_inventory.Add(LiveArmor.ITEM_NAME, New LiveArmor)                   '55
        internal_inventory.Add(LiveLingerie.ITEM_NAME, New LiveLingerie)             '56
        internal_inventory.Add(DisarmentKit.ITEM_NAME, New DisarmentKit)             '57
        internal_inventory.Add(FusionCrystal.ITEM_NAME, New FusionCrystal)           '58
        internal_inventory.Add(MysPotion.ITEM_NAME, New MysPotion)                   '59
        internal_inventory.Add(BSPotion.ITEM_NAME, New BSPotion)                     '60
        internal_inventory.Add(MasculinePotion.ITEM_NAME, New MasculinePotion)       '61
        internal_inventory.Add(DitzyPotion.ITEM_NAME, New DitzyPotion)               '62
        internal_inventory.Add(SpidersilkWhip.ITEM_NAME, New SpidersilkWhip)         '63
        internal_inventory.Add(ChitArmor.ITEM_NAME, New ChitArmor)                   '64
        '0.5                                                                           
        internal_inventory.Add(ASpellbook.ITEM_NAME, New ASpellbook)                 '65
        '0.6                                                                           
        internal_inventory.Add(HeartNecklace.ITEM_NAME, New HeartNecklace)           '66
        internal_inventory.Add(RedHeadband.ITEM_NAME, New RedHeadband)               '67
        internal_inventory.Add(RubyCirclet.ITEM_NAME, New RubyCirclet)               '68
        internal_inventory.Add(ThrallCollar.ITEM_NAME, New ThrallCollar)             '69
        internal_inventory.Add(Cowbell.ITEM_NAME, New Cowbell)                       '70
        internal_inventory.Add(CowBra.ITEM_NAME, New CowBra)                         '71
        '0.7                                                                           
        internal_inventory.Add(MaidOutfit.ITEM_NAME, New MaidOutfit)                 '72
        internal_inventory.Add(GoddessGown.ITEM_NAME, New GoddessGown)               '73
        internal_inventory.Add(SuccubusGarb.ITEM_NAME, New SuccubusGarb)             '74
        internal_inventory.Add(PrincessGown.ITEM_NAME, New PrincessGown)             '75
        internal_inventory.Add(ClearPotion.ITEM_NAME, New ClearPotion)               '76
        internal_inventory.Add(ROfMinRegen.ITEM_NAME, New ROfMinRegen)               '77
        internal_inventory.Add(VNightLingerie.ITEM_NAME, New VNightLingerie)         '78
        internal_inventory.Add(VDayClothes.ITEM_NAME, New VDayClothes)               '79
        internal_inventory.Add(DissolvedClothes.ITEM_NAME, New DissolvedClothes)     '80     actually a part of 0.8
        internal_inventory.Add(ROAmaraphne.ITEM_NAME, New ROAmaraphne)               '81
        internal_inventory.Add(MajHealthPotion.ITEM_NAME, New MajHealthPotion)       '82
        internal_inventory.Add(BronzeArmor.ITEM_NAME, New BronzeArmor)               '83
        internal_inventory.Add(BronzeAxe.ITEM_NAME, New BronzeAxe)                   '84
        internal_inventory.Add(BronzeBikini.ITEM_NAME, New BronzeBikini)             '85
        internal_inventory.Add(PortalChalk.ITEM_NAME, New PortalChalk)               '86
        '0.8                                                                           
        internal_inventory.Add(BimboLesson.ITEM_NAME, New BimboLesson)               '87
        internal_inventory.Add(CombatManual.ITEM_NAME, New CombatManual)             '88
        internal_inventory.Add(UtilityManual.ITEM_NAME, New UtilityManual)           '89
        internal_inventory.Add(Panacea.ITEM_NAME, New Panacea)                       '90
        internal_inventory.Add(VialOfVenom.ITEM_NAME, New VialOfVenom)               '91
        internal_inventory.Add(AntiVenom.ITEM_NAME, New AntiVenom)                   '92
        internal_inventory.Add(BlindPotion.ITEM_NAME, New BlindPotion)               '93
        internal_inventory.Add(BunnySuitA.ITEM_NAME, New BunnySuitA)                 '94
        internal_inventory.Add(ValkyrieArmor.ITEM_NAME, New ValkyrieArmor)           '95
        internal_inventory.Add(ValkyrieSword.ITEM_NAME, New ValkyrieSword)           '96
        internal_inventory.Add(Bowtie.ITEM_NAME, New Bowtie)                         '97
        internal_inventory.Add(CHeavyCream.ITEM_NAME, New CHeavyCream)               '98
        internal_inventory.Add(AmaAttire.ITEM_NAME, New AmaAttire)                   '99
        internal_inventory.Add(CStickOfGum.ITEM_NAME, New CStickOfGum)               '100
        internal_inventory.Add(BarbArmor.ITEM_NAME, New BarbArmor)                   '101
        internal_inventory.Add(SAJumpsuit.ITEM_NAME, New SAJumpsuit)                 '102
        internal_inventory.Add(STBodysuit.ITEM_NAME, New STBodysuit)                 '103
        internal_inventory.Add(PhotonArmor.ITEM_NAME, New PhotonArmor)               '104
        internal_inventory.Add(PhotonBikini.ITEM_NAME, New PhotonBikini)             '105
        internal_inventory.Add(Labcoat.ITEM_NAME, New Labcoat)                       '106
        internal_inventory.Add(LabcoatSV.ITEM_NAME, New LabcoatSV)                   '107
        internal_inventory.Add(SShroom.ITEM_NAME, New SShroom)                       '108
        internal_inventory.Add(MStickOfGum.ITEM_NAME, New MStickOfGum)               '109
        internal_inventory.Add(Generator.ITEM_NAME, New Generator)                   '110
        internal_inventory.Add(ManaDisharge.ITEM_NAME, New ManaDisharge)             '111
        internal_inventory.Add(PhotonBlade.ITEM_NAME, New PhotonBlade)               '112
        internal_inventory.Add(AmazonLesson.ITEM_NAME, New AmazonLesson)             '113
        internal_inventory.Add(BasicClassChange.ITEM_NAME, New BasicClassChange)     '114 (formerly Barbarian Lesson [edited v11.0]
        internal_inventory.Add(WarlockRobe.ITEM_NAME, New WarlockRobe)               '115
        internal_inventory.Add(GCUniform.ITEM_NAME, New GCUniform)                   '116
        internal_inventory.Add(GardenSalad.ITEM_NAME, New GardenSalad)               '117
        internal_inventory.Add(CWarAxe.ITEM_NAME, New CWarAxe)                       '118
        internal_inventory.Add(BrokenRemote.ITEM_NAME, New BrokenRemote)             '119
        internal_inventory.Add(ShrinkRay.ITEM_NAME, New ShrinkRay)                   '120
        internal_inventory.Add(NameChange.ITEM_NAME, New NameChange)                 '121
        internal_inventory.Add(HGorgonLesson.ITEM_NAME, New HGorgonLesson)           '122
        internal_inventory.Add(RingOfUvona.ITEM_NAME, New RingOfUvona)               '123
        internal_inventory.Add(AdvClassChange.ITEM_NAME, New AdvClassChange)         '124 (formerly Warlock Lesson [edited v11.0]
        internal_inventory.Add(BBStickOfGum.ITEM_NAME, New BBStickOfGum)             '125
        internal_inventory.Add(OmniCharm.ITEM_NAME, New OmniCharm)                   '126
        internal_inventory.Add(VialOfBimbo.ITEM_NAME, New VialOfBimbo)               '127
        internal_inventory.Add(CryoGrenade.ITEM_NAME, New CryoGrenade)               '128
        internal_inventory.Add(ReverseBunnySuit.ITEM_NAME, New ReverseBunnySuit)     '129
        internal_inventory.Add(GalaxyDye.ITEM_NAME, New GalaxyDye)                   '130
        internal_inventory.Add(BFormReset.ITEM_NAME, New BFormReset)                 '131
        internal_inventory.Add(WStickOfGum.ITEM_NAME, New WStickOfGum)               '132
        internal_inventory.Add(WFeast.ITEM_NAME, New WFeast)                         '133
        internal_inventory.Add(MDelicacy.ITEM_NAME, New MDelicacy)                   '134
        internal_inventory.Add(TSpecial.ITEM_NAME, New TSpecial)                     '135
        internal_inventory.Add(VialOfPSlime.ITEM_NAME, New VialOfPSlime)             '136
        internal_inventory.Add(GelArmor.ITEM_NAME, New GelArmor)                     '137
        internal_inventory.Add(GelLinge.ITEM_NAME, New GelLinge)                     '138
        internal_inventory.Add(BracedHeadband.ITEM_NAME, New BracedHeadband)         '139
        internal_inventory.Add(EmeraldCirclet.ITEM_NAME, New EmeraldCirclet)         '140
        internal_inventory.Add(ActiveCamoflage.ITEM_NAME, New ActiveCamoflage)       '141
        internal_inventory.Add(CombatModule.ITEM_NAME, New CombatModule)             '142
        internal_inventory.Add(EveryNewItem.ITEM_NAME, New EveryNewItem)             '143
        internal_inventory.Add(CrystalArmor.ITEM_NAME, New CrystalArmor)             '144
        internal_inventory.Add(ScepterOfAsh.ITEM_NAME, New ScepterOfAsh)             '145
        '0.9                                                                           
        internal_inventory.Add(CatArmor.ITEM_NAME, New CatArmor)                     '146
        internal_inventory.Add(SkimpyTT.ITEM_NAME, New SkimpyTT)                     '147
        internal_inventory.Add(GrapplingHook.ITEM_NAME, New GrapplingHook)           '148
        internal_inventory.Add(ManaHibiscus.ITEM_NAME, New ManaHibiscus)             '149
        internal_inventory.Add(TwinBlades.ITEM_NAME, New TwinBlades)                 '150
        internal_inventory.Add(SLolitaDress.ITEM_NAME, New SLolitaDress)             '151
        internal_inventory.Add(WillCharm.ITEM_NAME, New WillCharm)                   '152
        internal_inventory.Add(AntiCurseTag.ITEM_NAME, New AntiCurseTag)             '153
        internal_inventory.Add(NewUCrystal.ITEM_NAME, New NewUCrystal)               '154
        internal_inventory.Add(BronzeSpear.ITEM_NAME, New BronzeSpear)               '155
        internal_inventory.Add(SteelSpear.ITEM_NAME, New SteelSpear)                 '156
        internal_inventory.Add(FlamingSpear.ITEM_NAME, New FlamingSpear)             '157
        internal_inventory.Add(SigSpear.ITEM_NAME, New SigSpear)                     '158
        internal_inventory.Add(SigStaff.ITEM_NAME, New SigStaff)                     '159
        internal_inventory.Add(SpikedStaff.ITEM_NAME, New SpikedStaff)               '160
        internal_inventory.Add(Blindfold.ITEM_NAME, New Blindfold)                   '161
        internal_inventory.Add(ThrowingKnife.ITEM_NAME, New ThrowingKnife)                         '162
        internal_inventory.Add(SigDagger.ITEM_NAME, New SigDagger)                   '163
        internal_inventory.Add(StealthGear.ITEM_NAME, New StealthGear)               '164
        internal_inventory.Add(MShank.ITEM_NAME, New MShank)                         '165
        internal_inventory.Add(FoNight.ITEM_NAME, New FoNight)                       '166
        internal_inventory.Add(WOShock.ITEM_NAME, New WOShock)                       '167
        internal_inventory.Add(Cursemark.ITEM_NAME, New Cursemark)                   '168
        internal_inventory.Add(MaidLingerie.ITEM_NAME, New MaidLingerie)             '169
        internal_inventory.Add(MagSlutOutfit.ITEM_NAME, New MagSlutOutfit)           '170
        internal_inventory.Add(MagSlutWand.ITEM_NAME, New MagSlutWand)               '171
        internal_inventory.Add(FlamingSword.ITEM_NAME, New FlamingSword)             '172
        internal_inventory.Add(SigWhip.ITEM_NAME, New SigWhip)                       '173
        internal_inventory.Add(CDefenseCharm.ITEM_NAME, New CDefenseCharm)           '174
        internal_inventory.Add(CozySweater.ITEM_NAME, New CozySweater)               '175
        internal_inventory.Add(ScaleArmor.ITEM_NAME, New ScaleArmor)                 '176
        internal_inventory.Add(ScaleBikini.ITEM_NAME, New ScaleBikini)               '177
        internal_inventory.Add(AntiFreeze.ITEM_NAME, New AntiFreeze)                 '178
        internal_inventory.Add(WOVoltage.ITEM_NAME, New WOVoltage)                   '179
        internal_inventory.Add(PPanties.ITEM_NAME, New PPanties)                     '180
        internal_inventory.Add(GothOutfit.ITEM_NAME, New GothOutfit)                 '181
        internal_inventory.Add(CursedCoupon.ITEM_NAME, New CursedCoupon)             '182
        internal_inventory.Add(KitsuneRobe.ITEM_NAME, New KitsuneRobe)               '183
        'v0.9.1                                                                        
        internal_inventory.Add(CommonClothes0.ITEM_NAME, New CommonClothes0)         '184
        internal_inventory.Add(CommonClothes1.ITEM_NAME, New CommonClothes1)         '185
        internal_inventory.Add(CommonClothes2.ITEM_NAME, New CommonClothes2)         '186
        internal_inventory.Add(CommonClothes3.ITEM_NAME, New CommonClothes3)         '187
        internal_inventory.Add(CommonClothes4.ITEM_NAME, New CommonClothes4)         '188
        internal_inventory.Add(CommonClothes5.ITEM_NAME, New CommonClothes5)         '189
        internal_inventory.Add(CommonClothes6.ITEM_NAME, New CommonClothes6)         '190
        internal_inventory.Add(SkimpyClothes.ITEM_NAME, New SkimpyClothes)           '191
        internal_inventory.Add(VSkimpyClothes.ITEM_NAME, New VSkimpyClothes)         '192
        internal_inventory.Add(UEPotion.ITEM_NAME, New UEPotion)                     '193
        internal_inventory.Add(DEPotion.ITEM_NAME, New DEPotion)                     '194
        internal_inventory.Add(CurseBGone.ITEM_NAME, New CurseBGone)                 '195
        internal_inventory.Add(CowCosplay.ITEM_NAME, New CowCosplay)                 '196
        internal_inventory.Add(Bimbell.ITEM_NAME, New Bimbell)                       '197
        internal_inventory.Add(KitsuneMask.ITEM_NAME, New KitsuneMask)               '198
        internal_inventory.Add(AngelicSweater.ITEM_NAME, New AngelicSweater)         '199
        internal_inventory.Add(CAttackCharm.ITEM_NAME, New CAttackCharm)             '200
        internal_inventory.Add(ProMagGirlOutfit.ITEM_NAME, New ProMagGirlOutfit)     '201
        internal_inventory.Add(MagGirlOutfitP.ITEM_NAME, New MagGirlOutfitP)         '202
        internal_inventory.Add(ProMagGirlWand.ITEM_NAME, New ProMagGirlWand)         '203
        internal_inventory.Add(MagGirlWandP.ITEM_NAME, New MagGirlWandP)             '204
        internal_inventory.Add(VialOfFire.ITEM_NAME, New VialOfFire)                 '205
        internal_inventory.Add(GemOfProg.ITEM_NAME, New GemOfProg)                   '206
        internal_inventory.Add(GemOfPink.ITEM_NAME, New GemOfPink)                   '207
        internal_inventory.Add(MagGirlOutfitD.ITEM_NAME, New MagGirlOutfitD)         '208
        internal_inventory.Add(MagGirlWandD.ITEM_NAME, New MagGirlWandD)             '209
        internal_inventory.Add(MagGirlOutfitR.ITEM_NAME, New MagGirlOutfitR)         '210
        internal_inventory.Add(ProMagGirlOutfitR.ITEM_NAME, New ProMagGirlOutfitR)   '211
        internal_inventory.Add(MagGirlWandR.ITEM_NAME, New MagGirlWandR)             '212
        internal_inventory.Add(ProMagGirlWandR.ITEM_NAME, New ProMagGirlWandR)       '213
        internal_inventory.Add(GemOfFlame.ITEM_NAME, New GemOfFlame)                 '214
        internal_inventory.Add(GemOfDark.ITEM_NAME, New GemOfDark)                   '215
        internal_inventory.Add(MagGirlOutfitC.ITEM_NAME, New MagGirlOutfitC)         '216
        internal_inventory.Add(DemWhip.ITEM_NAME, New DemWhip)                       '217
        internal_inventory.Add(ArchDemWhip.ITEM_NAME, New ArchDemWhip)               '218
        internal_inventory.Add(FoxEars.ITEM_NAME, New FoxEars)                       '219
        internal_inventory.Add(SkimpyClothesD.ITEM_NAME, New SkimpyClothesD)         '220
        internal_inventory.Add(CowCosplayD.ITEM_NAME, New CowCosplayD)               '221
        internal_inventory.Add(BunnySuitC.ITEM_NAME, New BunnySuitC)                 '222
        internal_inventory.Add(SevenBandedRing.ITEM_NAME, New SevenBandedRing)       '223
        internal_inventory.Add(FoxStatue.ITEM_NAME, New FoxStatue)                   '224
        internal_inventory.Add(BunnyEars.ITEM_NAME, New BunnyEars)                   '225
        internal_inventory.Add(CSpellbook.ITEM_NAME, New CSpellbook)                 '226
        internal_inventory.Add(CrimsonManual.ITEM_NAME, New CrimsonManual)           '227
        internal_inventory.Add(XPSandwich.ITEM_NAME, New XPSandwich)                 '228
        internal_inventory.Add(BitGold.ITEM_NAME, New BitGold)                       '229
        'v10.0.1                                                                     
        internal_inventory.Add(DragonFruit.ITEM_NAME, New DragonFruit)               '230
        internal_inventory.Add(MentalPotion.ITEM_NAME, New MentalPotion)             '231
        internal_inventory.Add(ChillingPotion.ITEM_NAME, New ChillingPotion)         '232
        internal_inventory.Add(USPotion.ITEM_NAME, New USPotion)                     '233
        internal_inventory.Add(DSPotion.ITEM_NAME, New DSPotion)                     '234
        internal_inventory.Add(HHealthPotion.ITEM_NAME, New HHealthPotion)           '235
        internal_inventory.Add(HManaPotion.ITEM_NAME, New HManaPotion)               '236
        internal_inventory.Add(SuccubusArmor.ITEM_NAME, New SuccubusArmor)           '237
        internal_inventory.Add(LanceOfDarkness.ITEM_NAME, New LanceOfDarkness)       '238
        internal_inventory.Add(SpidersilkBonds.ITEM_NAME, New SpidersilkBonds)       '239
        internal_inventory.Add(SpidersilkBikini.ITEM_NAME, New SpidersilkBikini)     '240
        internal_inventory.Add(MajManaPotion.ITEM_NAME, New MajManaPotion)           '241
        internal_inventory.Add(Spellcyclopedia.ITEM_NAME, New Spellcyclopedia)       '242
        internal_inventory.Add(BookOSpecials.ITEM_NAME, New BookOSpecials)           '243
        internal_inventory.Add(VialOfPotVenom.ITEM_NAME, New VialOfPotVenom)         '244
        internal_inventory.Add(CursePurge.ITEM_NAME, New CursePurge)                 '245
        internal_inventory.Add(BenedictPotion.ITEM_NAME, New BenedictPotion)         '246
        internal_inventory.Add(DodgePotion.ITEM_NAME, New DodgePotion)               '247
        internal_inventory.Add(IncandPotion.ITEM_NAME, New IncandPotion)             '248
        internal_inventory.Add(TeachFocusedMantra.ITEM_NAME, New TeachFocusedMantra) '249
        internal_inventory.Add(FamCostume.ITEM_NAME, New FamCostume)                 '250
        'v11.0.0                                                                     
        internal_inventory.Add(OldSnips.ITEM_NAME, New OldSnips)                     '251
        internal_inventory.Add(CollarSnips.ITEM_NAME, New CollarSnips)               '252
        internal_inventory.Add(CynnsMark.ITEM_NAME, New CynnsMark)                   '253
        internal_inventory.Add(CommonClothes7.ITEM_NAME, New CommonClothes7)         '254
        internal_inventory.Add(PlatinumAxe.ITEM_NAME, New PlatinumAxe)               '255
        internal_inventory.Add(PlatinumDaggers.ITEM_NAME, New PlatinumDaggers)       '256
        internal_inventory.Add(PlatinumStaff.ITEM_NAME, New PlatinumStaff)           '257
        internal_inventory.Add(CursedSword.ITEM_NAME, New CursedSword)               '258
        internal_inventory.Add(BewitchedWand.ITEM_NAME, New BewitchedWand)           '259
        internal_inventory.Add(JinxedWhip.ITEM_NAME, New JinxedWhip)                 '260
        internal_inventory.Add(A6Battery.ITEM_NAME, New A6Battery)                   '261
        internal_inventory.Add(CowArmor.ITEM_NAME, New CowArmor)                     '262
        internal_inventory.Add(UpgradeArmor.ITEM_NAME, New UpgradeArmor)             '263
        internal_inventory.Add(ArmorFragments.ITEM_NAME, New ArmorFragments)         '264
        internal_inventory.Add(PlatArmor.ITEM_NAME, New PlatArmor)                   '265
        internal_inventory.Add(PlatAdornment.ITEM_NAME, New PlatAdornment)           '266
        internal_inventory.Add(RocDrumstick.ITEM_NAME, New RocDrumstick)             '267
        internal_inventory.Add(DFStickOfGum.ITEM_NAME, New DFStickOfGum)             '268
        internal_inventory.Add(NatureKiss.ITEM_NAME, New NatureKiss)                 '269
        internal_inventory.Add(BetterHerbs.ITEM_NAME, New BetterHerbs)               '270
        internal_inventory.Add(MOTOx.ITEM_NAME, New MOTOx)                           '271
        internal_inventory.Add(Steak.ITEM_NAME, New Steak)                           '272
        internal_inventory.Add(PhasePistol.ITEM_NAME, New PhasePistol)               '273
        internal_inventory.Add(PhaseRifle.ITEM_NAME, New PhaseRifle)                 '274
        internal_inventory.Add(PhaseHammer.ITEM_NAME, New PhaseHammer)               '275
        internal_inventory.Add(PhaseDrill.ITEM_NAME, New PhaseDrill)                 '276
        internal_inventory.Add(PaleoDiary.ITEM_NAME, New PaleoDiary)                 '277
        internal_inventory.Add(MarissasNotes.ITEM_NAME, New MarissasNotes)           '278
        internal_inventory.Add(AAAAAASpecs.ITEM_NAME, New AAAAAASpecs)               '279
        internal_inventory.Add(PhaseVibrator.ITEM_NAME, New PhaseVibrator)           '280
        internal_inventory.Add(PhaseDeflector.ITEM_NAME, New PhaseDeflector)         '281
        internal_inventory.Add(TimeCopClothes.ITEM_NAME, New TimeCopClothes)         '282
        internal_inventory.Add(HallowedTalisman.ITEM_NAME, New HallowedTalisman)     '283
        internal_inventory.Add(LargeStick.ITEM_NAME, New LargeStick)                 '284
        internal_inventory.Add(CommonClothes8.ITEM_NAME, New CommonClothes8)         '285
        internal_inventory.Add(TomeOfKnowlege.ITEM_NAME, New TomeOfKnowlege)         '286
        internal_inventory.Add(ExtraLife.ITEM_NAME, New ExtraLife)                   '287
        internal_inventory.Add(CultistCloak.ITEM_NAME, New CultistCloak)             '288
        internal_inventory.Add(CrimsonCloak.ITEM_NAME, New CrimsonCloak)             '289
        internal_inventory.Add(SkimpyClothesG.ITEM_NAME, New SkimpyClothesG)         '290
        internal_inventory.Add(GoldenGum.ITEM_NAME, New GoldenGum)                   '291
        internal_inventory.Add(ImmitationCowbell.ITEM_NAME, New ImmitationCowbell)   '292
        internal_inventory.Add(MagMimicWand.ITEM_NAME, New MagMimicWand)             '293
        internal_inventory.Add(VialOfRockJuice.ITEM_NAME, New VialOfRockJuice)       '294
        internal_inventory.Add(IcePop.ITEM_NAME, New IcePop)                         '295
        internal_inventory.Add(IcePopB.ITEM_NAME, New IcePopB)                       '296
        internal_inventory.Add(TidemageStaff.ITEM_NAME, New TidemageStaff)           '297
        internal_inventory.Add(LimeBikini.ITEM_NAME, New LimeBikini)                 '298
        internal_inventory.Add(SummerShades.ITEM_NAME, New SummerShades)             '299
        'v11.5.0                                                                     
        internal_inventory.Add(NecromancerRobe.ITEM_NAME, New NecromancerRobe)       '300
        internal_inventory.Add(PaladinArmor.ITEM_NAME, New PaladinArmor)             '301
        internal_inventory.Add(AmaArmor.ITEM_NAME, New AmaArmor)                     '302
        internal_inventory.Add(PlantBikini.ITEM_NAME, New PlantBikini)               '303
        internal_inventory.Add(MagGirlOutfitG.ITEM_NAME, New MagGirlOutfitG)         '304
        internal_inventory.Add(ProMagGirlOutfitG.ITEM_NAME, New ProMagGirlOutfitG)   '305
        internal_inventory.Add(GemOfIvy.ITEM_NAME, New GemOfIvy)                     '306
        internal_inventory.Add(MagGirlWandG.ITEM_NAME, New MagGirlWandG)             '307
        internal_inventory.Add(RedRimmedSpecs.ITEM_NAME, New RedRimmedSpecs)         '308
        internal_inventory.Add(SmallGlasses.ITEM_NAME, New SmallGlasses)             '309
        internal_inventory.Add(CircularGlasses.ITEM_NAME, New CircularGlasses)       '310
        internal_inventory.Add(ThickRimmedSpecs.ITEM_NAME, New ThickRimmedSpecs)     '311
        internal_inventory.Add(Shades.ITEM_NAME, New Shades)                         '312
        internal_inventory.Add(Monocle.ITEM_NAME, New Monocle)                       '313
        internal_inventory.Add(Eyepatch.ITEM_NAME, New Eyepatch)                     '314
        internal_inventory.Add(MasqueraderMask.ITEM_NAME, New MasqueraderMask)       '315
        internal_inventory.Add(CyberVisorP.ITEM_NAME, New CyberVisorP)               '316
        internal_inventory.Add(CyberVisorO.ITEM_NAME, New CyberVisorO)               '317
        internal_inventory.Add(CyberVisorG.ITEM_NAME, New CyberVisorG)               '318
        internal_inventory.Add(AllSeeingShades.ITEM_NAME, New AllSeeingShades)       '319
        internal_inventory.Add(Ballgag.ITEM_NAME, New Ballgag)                       '320
        internal_inventory.Add(SpectralGag.ITEM_NAME, New SpectralGag)               '321 
        internal_inventory.Add(MaidArmor.ITEM_NAME, New MaidArmor)                   '322
        internal_inventory.Add(BunnySuitG.ITEM_NAME, New BunnySuitG)                 '323
        internal_inventory.Add(AmaraphneVestment.ITEM_NAME, New AmaraphneVestment)   '324
        internal_inventory.Add(AmaraphneRaiment.ITEM_NAME, New AmaraphneRaiment)     '325
        internal_inventory.Add(FeatherSword.ITEM_NAME, New FeatherSword)             '326
        internal_inventory.Add(MOAmaraphne.ITEM_NAME, New MOAmaraphne)               '327
        internal_inventory.Add(OuijaBoard.ITEM_NAME, New OuijaBoard)                 '328
        internal_inventory.Add(SwashMagicEPatch.ITEM_NAME, New SwashMagicEPatch)     '329
        internal_inventory.Add(PirateHandbook.ITEM_NAME, New PirateHandbook)         '330
        'v12.0.0 
        internal_inventory.Add(SkimpyClothesF.ITEM_NAME, New SkimpyClothesF)         '331
        internal_inventory.Add(CommonClothesF.ITEM_NAME, New CommonClothesF)         '332
        internal_inventory.Add(RegalLingerieF.ITEM_NAME, New RegalLingerieF)         '333
        internal_inventory.Add(GAStickOfGum.ITEM_NAME, New GAStickOfGum)             '334
        internal_inventory.Add(RegalGownF.ITEM_NAME, New RegalGownF)                 '335
        internal_inventory.Add(SkycladRunes.ITEM_NAME, New SkycladRunes)             '336
        internal_inventory.Add(MedusaEye.ITEM_NAME, New MedusaEye)                   '337
        internal_inventory.Add(SthenoSalve.ITEM_NAME, New SthenoSalve)               '338
        internal_inventory.Add(VipersFang.ITEM_NAME, New VipersFang)                 '339
        internal_inventory.Add(FaeForgedRing.ITEM_NAME, New FaeForgedRing)           '340
        internal_inventory.Add(FaePApple.ITEM_NAME, New FaePApple)                   '341
        internal_inventory.Add(FaeRose.ITEM_NAME, New FaeRose)                       '342
        internal_inventory.Add(FaeLingerie.ITEM_NAME, New FaeLingerie)               '343
        internal_inventory.Add(CursedBridle.ITEM_NAME, New CursedBridle)             '344
        internal_inventory.Add(ArmoredLimeBikini.ITEM_NAME, New ArmoredLimeBikini)   '345
        internal_inventory.Add(FaeStockings.ITEM_NAME, New FaeStockings)             '346
        internal_inventory.Add(Acorn.ITEM_NAME, New Acorn)                           '347
        internal_inventory.Add(Tulip.ITEM_NAME, New Tulip)                           '348
        internal_inventory.Add(FaeQueenAmulet.ITEM_NAME, New FaeQueenAmulet)         '349
        internal_inventory.Add(LingerieCatalog.ITEM_NAME, New LingerieCatalog)       '350
        internal_inventory.Add(IronDagger.ITEM_NAME, New IronDagger)                 '351
        internal_inventory.Add(LumpOfIron.ITEM_NAME, New LumpOfIron)                 '352
        internal_inventory.Add(FeatherDagger.ITEM_NAME, New FeatherDagger)           '353
        internal_inventory.Add(FaerieWitchRobes.ITEM_NAME, New FaerieWitchRobes)     '354
        internal_inventory.Add(DiamondCirclet.ITEM_NAME, New DiamondCirclet)         '355
        internal_inventory.Add(PinkHeadband.ITEM_NAME, New PinkHeadband)             '356
        internal_inventory.Add(CrystalBikini.ITEM_NAME, New CrystalBikini)           '357
        internal_inventory.Add(HPStickOfGum.ITEM_NAME, New HPStickOfGum)             '358
        internal_inventory.Add(SWRestoration.ITEM_NAME, New SWRestoration)           '359
        internal_inventory.Add(MPStickOfGum.ITEM_NAME, New MPStickOfGum)             '360
        internal_inventory.Add(ScaleTalisman.ITEM_NAME, New ScaleTalisman)           '361
        internal_inventory.Add(LanceOfSFury.ITEM_NAME, New LanceOfSFury)             '362
        internal_inventory.Add(BunnySuitS.ITEM_NAME, New BunnySuitS)                 '363
        internal_inventory.Add(GShowgirlOutfit.ITEM_NAME, New GShowgirlOutfit)       '364
        internal_inventory.Add(StickWand.ITEM_NAME, New StickWand)                   '365
        internal_inventory.Add(FantomaWand.ITEM_NAME, New FantomaWand)               '366
        internal_inventory.Add(HBSWand.ITEM_NAME, New HBSWand)                       '367
        internal_inventory.Add(HealFeelWand.ITEM_NAME, New HealFeelWand)             '368
        internal_inventory.Add(DitzDazeWand.ITEM_NAME, New DitzDazeWand)             '369
        internal_inventory.Add(RNDPolyWand.ITEM_NAME, New RNDPolyWand)               '370
        internal_inventory.Add(MGReset.ITEM_NAME, New MGReset)                       '371
        internal_inventory.Add(LepSlimeWhip.ITEM_NAME, New LepSlimeWhip)             '372
        internal_inventory.Add(VialOfManyNames.ITEM_NAME, New VialOfManyNames)       '373
        internal_inventory.Add(FaerieBlossom.ITEM_NAME, New FaerieBlossom)           '374
        internal_inventory.Add(IronCollar.ITEM_NAME, New IronCollar)                 '375
        internal_inventory.Add(FaeQueensCrown.ITEM_NAME, New FaeQueensCrown)         '376
        internal_inventory.Add(Hyacinth.ITEM_NAME, New Hyacinth)                     '377
        internal_inventory.Add(Lepanacea.ITEM_NAME, New Lepanacea)                   '378
        internal_inventory.Add(RosePetalSpellbook.ITEM_NAME, New RosePetalSpellbook) '379
        internal_inventory.Add(CynnTonic.ITEM_NAME, New CynnTonic)                   '380
        internal_inventory.Add(Rose.ITEM_NAME, New Rose)                             '381
        internal_inventory.Add(HealthPotionHB.ITEM_NAME, New HealthPotionHB)         '382
        internal_inventory.Add(ManaPotionHB.ITEM_NAME, New ManaPotionHB)             '383
        internal_inventory.Add(CommonClothes9.ITEM_NAME, New CommonClothes9)         '384
        internal_inventory.Add(Orange.ITEM_NAME, New Orange)                         '385
        'v12.1.0
        internal_inventory.Add(EyeOfTheBeholder.ITEM_NAME, New EyeOfTheBeholder)     '386
        internal_inventory.Add(CynthiasRemote.ITEM_NAME, New CynthiasRemote)         '387
        internal_inventory.Add(PixieDuster.ITEM_NAME, New PixieDuster)               '388
        internal_inventory.Add(SPCursemark.ITEM_NAME, New SPCursemark)               '389
        internal_inventory.Add(CrackedBrick.ITEM_NAME, New CrackedBrick)             '390
        'v12.2.0
        internal_inventory.Add(RingOfTheRabbit.ITEM_NAME, New RingOfTheRabbit)       '391
        internal_inventory.Add(SpaceBun.ITEM_NAME, New SpaceBun)                     '392
        internal_inventory.Add(NanosilkQipaoP.ITEM_NAME, New NanosilkQipaoP)         '393
        internal_inventory.Add(AcolyteCosplay.ITEM_NAME, New AcolyteCosplay)         '394
        internal_inventory.Add(VialOfSuccubus.ITEM_NAME, New VialOfSuccubus)         '395
        internal_inventory.Add(BimbovisionGoggles.ITEM_NAME, New BimbovisionGoggles) '396
        internal_inventory.Add(TargetingSystem.ITEM_NAME, New TargetingSystem)       '397
        internal_inventory.Add(CyberValkyrieArmor.ITEM_NAME, New CyberValkyrieArmor) '398
        internal_inventory.Add(CyberValkyrieSword.ITEM_NAME, New CyberValkyrieSword) '399
        internal_inventory.Add(UpgradeValkyrieSword.ITEM_NAME, New UpgradeValkyrieSword) '400
        internal_inventory.Add(HellflamingSword.ITEM_NAME, New HellflamingSword)     '401
        internal_inventory.Add(BerserkerCursemark.ITEM_NAME, New BerserkerCursemark) '402
        internal_inventory.Add(SellHellfireBlade.ITEM_NAME, New SellHellfireBlade)   '403
        internal_inventory.Add(PaladinBikini.ITEM_NAME, New PaladinBikini)           '404
        internal_inventory.Add(SpiralBikini.ITEM_NAME, New SpiralBikini)             '405
        internal_inventory.Add(DubiousRations.ITEM_NAME, New DubiousRations)         '406
        internal_inventory.Add(SafeRations.ITEM_NAME, New SafeRations)               '407
        internal_inventory.Add(BewitchedRations.ITEM_NAME, New BewitchedRations)     '408
        internal_inventory.Add(MarissasRation.ITEM_NAME, New MarissasRation)         '409
        internal_inventory.Add(ShimmeringHairbrush.ITEM_NAME, New ShimmeringHairbrush) '410
        internal_inventory.Add(TidemageTattoo.ITEM_NAME, New TidemageTattoo)         '411
        internal_inventory.Add(RunecursedDagger.ITEM_NAME, New RunecursedDagger)     '412
        internal_inventory.Add(DarkplateBikini.ITEM_NAME, New DarkplateBikini)       '413
        internal_inventory.Add(CynnsBimboMark.ITEM_NAME, New CynnsBimboMark)         '414
        internal_inventory.Add(GumGun20mm.ITEM_NAME, New GumGun20mm)                 '415
        internal_inventory.Add(GumGrenade.ITEM_NAME, New GumGrenade)                 '416

        armor = {New Naked,
                 Me.item(5), Me.item(7), Me.item(8), Me.item(10),
                 Me.item(12), Me.item(16), Me.item(17), Me.item(18),
                 Me.item(19), Me.item(20), Me.item(38), Me.item(39),
                 Me.item(46), Me.item(47), Me.item(54), Me.item(55),
                 Me.item(56), Me.item(64), Me.item(71), Me.item(72),
                 Me.item(73), Me.item(74), Me.item(75), Me.item(78),
                 Me.item(79), Me.item(83), Me.item(85), Me.item(80),
                 Me.item(94), Me.item(95), Me.item(99), Me.item(101),
                 Me.item(102), Me.item(103), Me.item(104), Me.item(105),
                 Me.item(106), Me.item(107), Me.item(115), Me.item(116),
                 Me.item(129), Me.item(137), Me.item(138), Me.item(144),
                 Me.item(146), Me.item(147), Me.item(151), Me.item(166),
                 Me.item(169), Me.item(170), Me.item(175), Me.item(176),
                 Me.item(177), Me.item(181), Me.item(183), Me.item(184),
                 Me.item(185), Me.item(186), Me.item(187), Me.item(188),
                 Me.item(189), Me.item(190), Me.item(191), Me.item(192),
                 Me.item(196), Me.item(199), Me.item(201), Me.item(202),
                 Me.item(208), Me.item(210), Me.item(211), Me.item(216),
                 Me.item(220), Me.item(221), Me.item(222), Me.item(237),
                 Me.item(239), Me.item(240), Me.item(250), Me.item(254),
                 Me.item(262), Me.item(265), Me.item(266), Me.item(282),
                 Me.item(285), Me.item(288), Me.item(289), Me.item(290),
                 Me.item(298), Me.item(300), Me.item(301), Me.item(302),
                 Me.item(303), Me.item(304), Me.item(305), Me.item(322),
                 Me.item(323), Me.item(324), Me.item(325), Me.item(331),
                 Me.item(332), Me.item(333), Me.item(335), Me.item(336),
                 Me.item(343), Me.item(345), Me.item(354), Me.item(357),
                 Me.item(363), Me.item(364), Me.item(384), Me.item(393),
                 Me.item(394), Me.item(398), Me.item(404), Me.item(405),
                 Me.item(413)}

        weapons = {New BareFists(),
                   Me.item(6), Me.item(9), Me.item(11), Me.item(21),
                   Me.item(22), Me.item(23), Me.item(24), Me.item(40),
                   Me.item(41), Me.item(42), Me.item(45), Me.item(63),
                   Me.item(84), Me.item(96), Me.item(111), Me.item(112),
                   Me.item(118), Me.item(120), Me.item(145), Me.item(150),
                   Me.item(155), Me.item(156), Me.item(157), Me.item(158),
                   Me.item(159), Me.item(160), Me.item(162), Me.item(163),
                   Me.item(165), Me.item(167), Me.item(171), Me.item(172),
                   Me.item(173), Me.item(179), Me.item(203), Me.item(204),
                   Me.item(209), Me.item(212), Me.item(213), Me.item(217),
                   Me.item(218), Me.item(238), Me.item(255), Me.item(256),
                   Me.item(257), Me.item(258), Me.item(259), Me.item(260),
                   Me.item(273), Me.item(274), Me.item(275), Me.item(276),
                   Me.item(284), Me.item(293), Me.item(297), Me.item(307),
                   Me.item(326), Me.item(339), Me.item(348), Me.item(351),
                   Me.item(353), Me.item(362), Me.item(365), Me.item(366),
                   Me.item(367), Me.item(368), Me.item(369), Me.item(370),
                   Me.item(372), Me.item(377), Me.item(381), Me.item(388),
                   Me.item(390), Me.item(399), Me.item(401), Me.item(412),
                   Me.item(415)}

        useable = {Me.item(0), Me.item(3), Me.item(4), Me.item(65),
                   Me.item(15), Me.item(36), Me.item(37), Me.item(48),
                   Me.item(49), Me.item(50), Me.item(51), Me.item(52),
                   Me.item(57), Me.item(58), Me.item(81), Me.item(86),
                   Me.item(88), Me.item(89), Me.item(91), Me.item(119),
                   Me.item(126), Me.item(127), Me.item(128), Me.item(130),
                   Me.item(136), Me.item(142), Me.item(143), Me.item(148),
                   Me.item(149), Me.item(152), Me.item(153), Me.item(154),
                   Me.item(155), Me.item(156), Me.item(157), Me.item(158),
                   Me.item(162), Me.item(174), Me.item(182), Me.item(195),
                   Me.item(200), Me.item(205), Me.item(206), Me.item(207),
                   Me.item(214), Me.item(215), Me.item(219), Me.item(226),
                   Me.item(227), Me.item(238), Me.item(244), Me.item(251),
                   Me.item(252), Me.item(277), Me.item(278), Me.item(279),
                   Me.item(280), Me.item(286), Me.item(294), Me.item(306),
                   Me.item(327), Me.item(328), Me.item(330), Me.item(338),
                   Me.item(344), Me.item(350), Me.item(362), Me.item(373),
                   Me.item(375), Me.item(379), Me.item(380), Me.item(387),
                   Me.item(388), Me.item(390), Me.item(395), Me.item(410),
                   Me.item(416)}

        food = {Me.item(1), Me.item(30), Me.item(31), Me.item(32),
                Me.item(33), Me.item(34), Me.item(35), Me.item(44),
                Me.item(90), Me.item(98), Me.item(100), Me.item(108),
                Me.item(109), Me.item(117), Me.item(125), Me.item(132),
                Me.item(133), Me.item(134), Me.item(135), Me.item(178),
                Me.item(228), Me.item(230), Me.item(267), Me.item(268),
                Me.item(269), Me.item(270), Me.item(272), Me.item(291),
                Me.item(295), Me.item(296), Me.item(334), Me.item(341),
                Me.item(347), Me.item(358), Me.item(360), Me.item(385),
                Me.item(386), Me.item(392), Me.item(406), Me.item(407),
                Me.item(408), Me.item(409)}

        acce = {New noAcce(),
                Me.item(66), Me.item(67), Me.item(68), Me.item(69),
                Me.item(70), Me.item(77), Me.item(81), Me.item(97),
                Me.item(110), Me.item(123), Me.item(139), Me.item(140),
                Me.item(141), Me.item(149), Me.item(164), Me.item(168),
                Me.item(180), Me.item(197), Me.item(198), Me.item(223),
                Me.item(225), Me.item(253), Me.item(271), Me.item(281),
                Me.item(283), Me.item(292), Me.item(320), Me.item(321),
                Me.item(327), Me.item(337), Me.item(340), Me.item(342),
                Me.item(344), Me.item(346), Me.item(349), Me.item(355),
                Me.item(356), Me.item(361), Me.item(374), Me.item(375),
                Me.item(376), Me.item(389), Me.item(391), Me.item(402),
                Me.item(411), Me.item(414)}

        services = {Me.item(87), Me.item(113), Me.item(114), Me.item(121),
                    Me.item(122), Me.item(124), Me.item(131), Me.item(245),
                    Me.item(249), Me.item(263), Me.item(359), Me.item(371),
                    Me.item(400), Me.item(403)}

        potions = {Me.item(2), Me.item(13), Me.item(14), Me.item(25),
                   Me.item(26), Me.item(27), Me.item(28), Me.item(29),
                   Me.item(59), Me.item(60), Me.item(61), Me.item(62),
                   Me.item(76), Me.item(82), Me.item(92), Me.item(93),
                   Me.item(193), Me.item(194), Me.item(231), Me.item(232),
                   Me.item(233), Me.item(234), Me.item(235), Me.item(236),
                   Me.item(241), Me.item(246), Me.item(247), Me.item(248),
                   Me.item(378), Me.item(382), Me.item(383)}

        Array.Sort(potions)

        misc = {Me.item(43), Me.item(53), Me.item(224), Me.item(229),
                Me.item(242), Me.item(243), Me.item(261), Me.item(264),
                Me.item(287), Me.item(352)}

        glasses = {New noGlasses(),
                   Me.item(161), Me.item(299), Me.item(308), Me.item(309),
                   Me.item(310), Me.item(311), Me.item(312), Me.item(313),
                   Me.item(314), Me.item(315), Me.item(316), Me.item(317),
                   Me.item(318), Me.item(319), Me.item(329), Me.item(396),
                   Me.item(397)}

        invIDorder = New List(Of Integer)

        If shufflePotions Then setPotionNames()
    End Sub
    Sub setPotionNames()
        Dim names = New List(Of String)
        names.AddRange({"Red_Potion", "Green_Potion", "Blue_Potion", "Golden_Potion",
                      "Azure_Potion", "Rose_Potion", "Mauve_Potion", "Jet_Potion",
                      "Ruby_Potion", "Emerald_Potion", "Sapphire_Potion", "Silver_Potion",
                      "Murky_Potion", "Smokey_Potion", "Pink_Potion", "Glittery_Potion",
                      "Fluorescent_Potion", "Coral_Potion", "Steely_Potion", "Cyan_Potion",
                      "Violet_Potion", "Pewter_Potion", "Pearly_Potion", "Verdant_Potion",
                      "Lilac_Potion", "Fuchsia_Potion", "Cornflower_Potion"})
        mPotions = New List(Of MysteryPotion)
        For i = 0 To UBound(potions)
            If potions(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then mPotions.Add(potions(i))
        Next
        Randomize()
        For Each p In mPotions
            Dim r = Int(Rnd() * names.Count)
            p.setFName(names(r))
            names.RemoveAt(r)
        Next
    End Sub

    '|UTILITY|
    Sub merge(ByRef inv As Inventory)
        For i = 0 To upperBound()
            item(i).add(inv.item(i).count)
        Next
    End Sub
    Sub mergeRevalue(ByRef inv As Inventory)
        For i = 0 To upperBound()
            item(i).value = inv.item(i).value
            item(i).add(inv.item(i).count)
        Next
    End Sub
    Sub add(ByVal key As String, ByVal count As Integer)
        If internal_inventory.Keys.Contains(key) Then
            internal_inventory(key).add(count)
        Else
            DDError.missingInvItemError(key)
        End If
        sum += count
    End Sub
    Sub add(ByVal id As Integer, ByVal count As Integer)
        If id >= 0 And id <= upperBound() Then
            Dim key = internal_inventory.Keys(id)
            internal_inventory(key).add(count)
        End If
        sum += count
    End Sub
    Sub setCount(k As String, v As Integer)
        sum -= item(k).count
        If internal_inventory.Keys.Contains(k) Then
            item(k).count = v
        End If
        sum += v
    End Sub
    Sub setCount(i As Integer, v As Integer)
        sum -= item(i).count
        item(i).count = v
        sum += v
    End Sub

    '|SAVE/LOAD|
    Public Function save() As String
        Dim out = CStr(upperBound()) & ":"
        For i = 0 To upperBound()
            out += getKeyByID(i) & "~" & item(i).count & "~" & item(i).durability & ":"
        Next

        If Not mPotions Is Nothing Then
            out += CStr(mPotions.Count - 1) & ":"
            For i = 0 To mPotions.Count - 1
                out += mPotions(i).getName() & "~" & mPotions(i).hasBeenUsed & ":"
            Next
        Else
            out += "na:"
        End If

        out += "*"
        Return out
    End Function
    Sub load(ByVal input As String)
        Dim parse As String() = input.Split(":")

        For i As Integer = 1 To parse(0) + 1
            Dim subParse As String() = parse(i).Split("~")
            If internal_inventory.Keys.Contains(subParse(0)) Then
                add(subParse(0), CInt(subParse(1)))
                item(i - 1).durability = CInt(subParse(2))
            End If
        Next
        Dim x = CInt(parse(0)) + 2

        If Not parse(x).Equals("na") And Not mPotions Is Nothing Then
            For i = x + 1 To x + CInt(parse(x))
                Dim subParse As String() = parse(i).Split("~")
                mPotions(i - (x + 1)).setFName(subParse(0))
                mPotions(i - (x + 1)).hasBeenUsed = CBool(subParse(1))
                If mPotions(i - (x + 1)).hasBeenUsed Then mPotions(i - (x + 1)).reveal()
            Next
        End If
        calcSum()
    End Sub

    '|GETTERS|
    Public Function item(ByVal n As String) As Item
        If internal_inventory.Keys.Contains(n) Then
            Return internal_inventory(n)
        Else
            For Each p In potions
                If p.getName = n Then Return p
            Next

            If n.Equals(Hyacinth.TFED_NAME) Then Return item(Hyacinth.ITEM_NAME)
            If n.Equals(Rose.TFED_NAME) Then Return item(Rose.ITEM_NAME)
            If n.Equals(Tulip.TFED_NAME) Then Return item(Tulip.ITEM_NAME)

            Return Nothing
        End If
    End Function
    Public Function item(ByVal id As Integer) As Item
        If id < 0 Or id > upperBound() Then Return Nothing
        Dim key = internal_inventory.Keys(id)
        Return internal_inventory(key)
    End Function
    Public Function getKeyByID(ByVal id As Integer) As String
        Return internal_inventory.Keys(id)
    End Function
    Public Function idOfKey(ByVal n As String) As Integer
        If Not internal_inventory.Keys.Contains(n) Then Return -1
        Return item(n).id
    End Function
    Public Function getCountAt(ByVal i As Integer) As Integer
        If item(i) Is Nothing Then Return 0
        Return item(i).getCount()
    End Function
    Public Function getCountAt(ByVal n As String) As Integer
        If item(n) Is Nothing Then Return 0
        Return item(n).getCount()
    End Function
    Public Function calcSum() As Integer
        Dim totalSum As Integer = 0
        For i = 0 To upperBound()
            totalSum += getCountAt(i)
        Next

        sum = totalSum

        Return totalSum
    End Function

    Function getArmors() As Tuple(Of String(), Armor())
        Dim s(UBound(armor)) As String
        For i = 0 To UBound(armor)
            s(i) = armor(i).getName
        Next
        Return New Tuple(Of String(), Armor())(s, armor)
    End Function
    Function getWeapons() As Tuple(Of String(), Weapon())
        Dim s(UBound(weapons)) As String
        For i = 0 To UBound(weapons)
            s(i) = weapons(i).getName
        Next
        Return New Tuple(Of String(), Weapon())(s, weapons)
    End Function
    Function getAccesories() As Tuple(Of String(), Accessory())
        Dim s(UBound(acce)) As String
        For i = 0 To UBound(acce)
            s(i) = acce(i).getName
        Next
        Return New Tuple(Of String(), Accessory())(s, acce)
    End Function
    Function getUseable() As Item()
        Return useable
    End Function
    Function getFood() As Item()
        Return food
    End Function
    Function getPotions() As Item()
        Return potions
    End Function
    Function getServices() As Item()
        Return services
    End Function
    Function getMisc() As Item()
        Return misc
    End Function
    Function getGlasses() As Tuple(Of String(), Glasses())
        Dim s(UBound(glasses)) As String
        For i = 0 To UBound(glasses)
            s(i) = glasses(i).getName
        Next
        Return New Tuple(Of String(), Glasses())(s, glasses)

    End Function
    Function getMPotions() As List(Of MysteryPotion)
        Return mPotions
    End Function
    Public Function getSum() As Integer
        Return sum
    End Function

    Function upperBound() As Integer
        Return internal_inventory.Count - 1
    End Function
    Function count() As Integer
        Return internal_inventory.Count
    End Function
End Class
