Public Class Lepanacea
    Inherits Item

    Public Const ITEM_NAME As String = "Fantoma's_Lepanacea"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 378
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1277

        '|Description|
        setDesc("A magical, mystical, wondrous, super-dee-duper drug that heals all wounds and returns one to their original form* with a satisfying 'poof'!" & DDUtils.RNRN &
                "Sketched across the label is a lady magician holding a simple black wand alof, and a speach bubble from her mouth that reads ""Now with 50% less Snake Oil!""." & DDUtils.RNRN & DDUtils.RNRN &
                "*Side effects may include (but are not limited to): Tiredness, Headache, Rabbit Ears, Increased Libido, Womanly Curves, Transfiguration of Armor, Transfiguration of Weapon, Transfiguration of ""Your Card"", Snake Intoxication, Reduction of Intelligence, Desire to Sing Showtunes, Hair Growth, Hare Growth, Bunniculitis, ""The Taps"", and in rare cases Eventual Long-Term Death.")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        '| - Targax Exception - |
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the Lepanacea on the ground, kicking the sham medicine all over the dungeon floor.  As you go back to your business, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            TextEvent.pushAndLog("You spike the Lepanacea on the ground!")
            p.UIupdate()
            Exit Sub
        End If

        '| - Primary Effect - |
        Dim av = New AntiVenomEffect
        Dim be = New BunnyEarsEffect
        av.apply(p)
        p.resetPerks()
        Equipment.antiClothingCurse(p)
        p.health = 1.0
        p.revertToSState()
        be.apply(p)

        '| - Side Effects - |
        Dim side_effects As PEffect() = {New BimbHairEffect, New BimFaceEffect, New MajBEEffect, New UEEffect, New ShowgirlArmorEffect, New ShowgirlArmorEffect, New ShowgirlWeaponEffect}
        For Each side_effect In side_effects
            If Not p.passDieRoll(3, 2) Then
                TextEvent.pushLog(translatePEffect(side_effect))
                side_effect.apply(p)
            End If
        Next

        count -= 1
    End Sub

    Private Function translatePEffect(ByRef effect As PEffect) As String
        If effect.GetType Is GetType(BimbHairEffect) Then
            Return "Hair Transformation effect applied!"
        ElseIf effect.GetType Is GetType(BimFaceEffect) Then
            Return "Face Transformation effect applied!"
        ElseIf effect.GetType Is GetType(MajBEEffect) Then
            Return "Major Breast Enlargement effect applied!"
        ElseIf effect.GetType Is GetType(UEEffect) Then
            Return "Ass Enlargement effect applied!"
        ElseIf effect.GetType Is GetType(ShowgirlArmorEffect) Then
            Return "Armor Transfiguration effect applied!"
        ElseIf effect.GetType Is GetType(ShowgirlWeaponEffect) Then
            Return "Weapon Transfiguration effect applied!"
        End If

        Return "Unknown side effect applied!"
    End Function
End Class
