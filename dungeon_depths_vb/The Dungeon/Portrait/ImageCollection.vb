Public Class ImageCollection
    Inherits Object
    Public atrs As Dictionary(Of pInd, ImageAttribute)
    Public mfEquivalentIndexes As Dictionary(Of pInd, MFRouting)
    Sub New(ByVal libID As Integer)
        'initialize the attribute dictionary object
        atrs = New Dictionary(Of pInd, ImageAttribute)

        'populate the attribute dictionary
        Select Case libID
            Case 0
                createDefaultImageLib()
            Case 1
                createAllImageLib()
                createMFEqInd()
            Case 2
                createNPCLib()
            Case Else
                createAllImageLib()
                createMFEqInd()
        End Select
    End Sub
    Sub createDefaultImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fClothing2, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAcce,
       fHat, fRearHair2, bkg As ImageDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mClothing2, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAcce,
            mHat, mRearHair2 As ImageDump

        Dim wings, horns, hbow, tail As ImageDump
        Dim shoulders, chest, genitalia, bodyoverlay As ImageDump

        Dim ndoM, ndoF As Integer

        '-backgrounds
        bkg = New ImageDump("img/bkg")
        atrs.Add(pInd.bkg, New ImageAttribute(bkg, bkg.Count))

        '-tail
        tail = New ImageDump("img/Tails")
        atrs.Add(pInd.tail, New ImageAttribute(tail, tail.Count))

        '-wings
        wings = New ImageDump("img/Wings")
        atrs.Add(pInd.wings, New ImageAttribute(wings, wings.Count))

        '-rear hair
        fRearHair2 = New ImageDump("img/fRearHair2")
        mRearHair2 = New ImageDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        atrs.Add(pInd.rearhair, New ImageAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-hairacc
        hbow = New ImageDump("img/HairBows")
        atrs.Add(pInd.hairacc, New ImageAttribute(hbow, hbow.Count))

        '-body
        fBody = New ImageDump("img/fBody")
        mBody = New ImageDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        atrs.Add(pInd.body, New ImageAttribute(fBody, mBody, ndoF, ndoM))

        '-genetalia
        genitalia = New ImageDump("img/Gen")
        Dim gM = New ImageDump(New List(Of Image)({genitalia.getImageAt(1)}))
        Dim gF = New ImageDump(New List(Of Image)({genitalia.getImageAt(4)}))
        ndoF = gF.Count
        ndoM = gM.Count
        atrs.Add(pInd.genitalia, New ImageAttribute(gF, gM, ndoF, ndoM))

        '-shoulders
        shoulders = New ImageDump("img/Shoulders")
        atrs.Add(pInd.shoulders, New ImageAttribute(shoulders, shoulders.Count))

        '-chest
        chest = New ImageDump("img/Chest")
        gM = New ImageDump(New List(Of Image)({chest.getImageAt(0)}))
        gF = New ImageDump(New List(Of Image)({chest.getImageAt(2)}))
        ndoF = gF.Count
        ndoM = gM.Count
        atrs.Add(pInd.chest, New ImageAttribute(gF, gM, ndoF, ndoM))

        '-bodyoverlay
        bodyoverlay = New ImageDump("img/BodyOverlay")
        atrs.Add(pInd.bodyoverlay, New ImageAttribute(bodyoverlay, bodyoverlay.Count))

        '-clothes
        fClothing = New ImageDump("img/fClothing")
        mClothing = New ImageDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        atrs.Add(pInd.clothes, New ImageAttribute(fClothing, mClothing, ndoF, ndoM))

        '-clothesbtm
        fClothing2 = New ImageDump("img/fClothing2")
        mClothing2 = New ImageDump("img/mClothing2")
        ndoF = fClothing2.Count
        ndoM = mClothing2.Count
        atrs.Add(pInd.clothesbtm, New ImageAttribute(fClothing2, mClothing2, ndoF, ndoM))

        '-face
        fFace = New ImageDump("img/fFace")
        mFace = New ImageDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        atrs.Add(pInd.face, New ImageAttribute(fFace, mFace, ndoF, ndoM))

        '-blush
        atrs.Add(pInd.blush, New ImageAttribute(bkg, bkg.Count))

        '-mid hair
        fRearHair1 = New ImageDump("img/fRearHair1")
        mRearHair1 = New ImageDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        atrs.Add(pInd.midhair, New ImageAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-horns
        horns = New ImageDump("img/Horns")
        atrs.Add(pInd.horns, New ImageAttribute(horns, horns.Count))

        '-ears
        fEars = New ImageDump("img/fEars")
        mEars = New ImageDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        atrs.Add(pInd.ears, New ImageAttribute(fEars, mEars, ndoF, ndoM))

        '-nose
        fNose = New ImageDump("img/fNose")
        mNose = New ImageDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        atrs.Add(pInd.nose, New ImageAttribute(fNose, mNose, ndoF, ndoM))

        '-mouth
        fMouth = New ImageDump("img/fMouth")
        mMouth = New ImageDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        atrs.Add(pInd.mouth, New ImageAttribute(fMouth, mMouth, ndoF, ndoM))

        '-eyes
        fEyes = New ImageDump("img/fEyes")
        mEyes = New ImageDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        atrs.Add(pInd.eyes, New ImageAttribute(fEyes, mEyes, ndoF, ndoM))

        '-eyebrows
        fEyebrows = New ImageDump("img/fEyebrows")
        mEyebrows = New ImageDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add(pInd.eyebrows, New ImageAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-facial mark
        fFacialMark = New ImageDump("img/fFacialMark")
        mFacialMark = New ImageDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add(pInd.facemark, New ImageAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-glasses
        fGlasses = New ImageDump("img/fGlasses")
        mGlasses = New ImageDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        atrs.Add(pInd.glasses, New ImageAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-cloak
        fCloak = New ImageDump("img/fCloakF")
        mCloak = New ImageDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add(pInd.cloak, New ImageAttribute(fCloak, mCloak, ndoF, ndoM))

        '-accessory
        fAcce = New ImageDump("img/fAcce")
        mAcce = New ImageDump("img/mAcce")
        ndoF = fAcce.Count
        ndoM = mAcce.Count
        atrs.Add(pInd.accessory, New ImageAttribute(fAcce, mAcce, ndoF, ndoM))

        '-front hair
        fFrontHair = New ImageDump("img/fFrontHair")
        mFrontHair = New ImageDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        atrs.Add(pInd.fronthair, New ImageAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-hat
        fHat = New ImageDump("img/fHat")
        mHat = New ImageDump("img/mHat")
        ndoF = fHat.Count
        ndoM = mHat.Count
        atrs.Add(pInd.hat, New ImageAttribute(fHat, mHat, ndoF, ndoM))
    End Sub
    Sub createAllImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fClothing2, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAcce,
       fHat, fRearHair2, bkg As ImageDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mClothing2, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAcce,
            mHat, mRearHair2 As ImageDump

        Dim fTFAcce, fTFBody, fTFClothes, fTFClothes2, fTFEars, fTFEyes, fTFface,
            fTfFrontHair, fTFMouth, fTFNose, fTFRearhair1, fTfRearhair2, fTFGlasses,
            fTFHat As ImageDump
        Dim mTFAcce, mTFBody, mTFClothes, mTFClothes2, mTFEars, mTFEyes, mTFface,
            mTfFrontHair, mTFMouth, mTFNose, mTFRearhair1, mTfRearhair2 As ImageDump

        Dim wings, horns, hbow, tail As ImageDump
        Dim shoulders, chest, genitalia, bodyoverlay As ImageDump

        Dim ndoM, ndoF As Integer

        '-backgrounds
        bkg = New ImageDump("img/bkg")
        atrs.Add(pInd.bkg, New ImageAttribute(bkg, bkg.Count))

        '-tail
        tail = New ImageDump("img/Tails")
        atrs.Add(pInd.tail, New ImageAttribute(tail, tail.Count))

        '-wings
        wings = New ImageDump("img/Wings")
        atrs.Add(pInd.wings, New ImageAttribute(wings, wings.Count))

        '-rear hair
        fRearHair2 = New ImageDump("img/fRearHair2")
        mRearHair2 = New ImageDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        fTfRearhair2 = New ImageDump("img/fTF/tfRearHair2")
        mTfRearhair2 = New ImageDump("img/mTF/tfRearHair2")
        fRearHair2.merge(fTfRearhair2)
        mRearHair2.merge(mTfRearhair2)
        atrs.Add(pInd.rearhair, New ImageAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-hairacc
        hbow = New ImageDump("img/HairBows")
        atrs.Add(pInd.hairacc, New ImageAttribute(hbow, hbow.Count))

        '-body
        fBody = New ImageDump("img/fBody")
        mBody = New ImageDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        fTFBody = New ImageDump("img/fTF/tfBody")
        mTFBody = New ImageDump("img/mTF/tfBody")
        fBody.merge(fTFBody)
        mBody.merge(mTFBody)
        atrs.Add(pInd.body, New ImageAttribute(fBody, mBody, ndoF, ndoM))

        '-genetalia
        genitalia = New ImageDump("img/Gen")
        atrs.Add(pInd.genitalia, New ImageAttribute(genitalia, genitalia.Count))

        '-shoulders
        shoulders = New ImageDump("img/Shoulders")
        atrs.Add(pInd.shoulders, New ImageAttribute(shoulders, shoulders.Count))

        '-chest
        chest = New ImageDump("img/Chest")
        atrs.Add(pInd.chest, New ImageAttribute(chest, chest.Count))

        '-bodyoverlay
        bodyoverlay = New ImageDump("img/BodyOverlay")
        atrs.Add(pInd.bodyoverlay, New ImageAttribute(bodyoverlay, bodyoverlay.Count))

        '-clothes
        fClothing = New ImageDump("img/fClothing")
        mClothing = New ImageDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        fTFClothes = New ImageDump("img/fTF/tfClothes")
        mTFClothes = New ImageDump("img/mTF/tfClothes")
        fClothing.merge(fTFClothes)
        mClothing.merge(mTFClothes)
        atrs.Add(pInd.clothes, New ImageAttribute(fClothing, mClothing, ndoF, ndoM))

        '-clothesbtm
        fClothing2 = New ImageDump("img/fClothing2")
        mClothing2 = New ImageDump("img/mClothing2")
        ndoF = fClothing2.Count
        ndoM = mClothing2.Count
        fTFClothes2 = New ImageDump("img/fTF/tfClothes2")
        mTFClothes2 = New ImageDump("img/mTF/tfClothes2")
        fClothing2.merge(fTFClothes2)
        mClothing2.merge(mTFClothes2)
        atrs.Add(pInd.clothesbtm, New ImageAttribute(fClothing2, mClothing2, ndoF, ndoM))

        '-face
        fFace = New ImageDump("img/fFace")
        mFace = New ImageDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        fTFface = New ImageDump("img/fTF/tfFace")
        mTFface = New ImageDump("img/mTF/tfFace")
        fFace.merge(fTFface)
        mFace.merge(mTFface)
        atrs.Add(pInd.face, New ImageAttribute(fFace, mFace, ndoF, ndoM))

        '-blush
        atrs.Add(pInd.blush, New ImageAttribute(bkg, bkg.Count))

        '-mid hair
        fRearHair1 = New ImageDump("img/fRearHair1")
        mRearHair1 = New ImageDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        fTFRearhair1 = New ImageDump("img/fTF/tfRearHair1")
        mTFRearhair1 = New ImageDump("img/mTF/tfRearHair1")
        fRearHair1.merge(fTFRearhair1)
        mRearHair1.merge(mTFRearhair1)
        atrs.Add(pInd.midhair, New ImageAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-horns
        horns = New ImageDump("img/Horns")
        atrs.Add(pInd.horns, New ImageAttribute(horns, horns.Count))

        '-ears
        fEars = New ImageDump("img/fEars")
        mEars = New ImageDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        fTFEars = New ImageDump("img/fTF/tfEars")
        mTFEars = New ImageDump("img/mTF/tfEars")
        fEars.merge(fTFEars)
        mEars.merge(mTFEars)
        atrs.Add(pInd.ears, New ImageAttribute(fEars, mEars, ndoF, ndoM))

        '-nose
        fNose = New ImageDump("img/fNose")
        mNose = New ImageDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        fTFNose = New ImageDump("img/fTF/tfNose")
        mTFNose = New ImageDump("img/mTF/tfNose")
        fNose.merge(fTFNose)
        mNose.merge(mTFNose)
        atrs.Add(pInd.nose, New ImageAttribute(fNose, mNose, ndoF, ndoM))

        '-mouth
        fMouth = New ImageDump("img/fMouth")
        mMouth = New ImageDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        fTFMouth = New ImageDump("img/fTF/tfMouth")
        mTFMouth = New ImageDump("img/mTF/tfMouth")
        fMouth.merge(fTFMouth)
        mMouth.merge(mTFMouth)
        atrs.Add(pInd.mouth, New ImageAttribute(fMouth, mMouth, ndoF, ndoM))

        '-eyes
        fEyes = New ImageDump("img/fEyes")
        mEyes = New ImageDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        fTFEyes = New ImageDump("img/fTF/tfEyes")
        mTFEyes = New ImageDump("img/mTF/tfEyes")
        fEyes.merge(fTFEyes)
        mEyes.merge(mTFEyes)
        atrs.Add(pInd.eyes, New ImageAttribute(fEyes, mEyes, ndoF, ndoM))

        '-eyebrows
        fEyebrows = New ImageDump("img/fEyebrows")
        mEyebrows = New ImageDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add(pInd.eyebrows, New ImageAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-face mark
        fFacialMark = New ImageDump("img/fFacialMark")
        mFacialMark = New ImageDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add(pInd.facemark, New ImageAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-glasses
        fGlasses = New ImageDump("img/fGlasses")
        fTFGlasses = New ImageDump("img/fTF/tfGlasses")
        mGlasses = New ImageDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        fGlasses.merge(fTFGlasses)
        atrs.Add(pInd.glasses, New ImageAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-cloak
        fCloak = New ImageDump("img/fCloakF")
        mCloak = New ImageDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add(pInd.cloak, New ImageAttribute(fCloak, mCloak, ndoF, ndoM))

        '-accessory
        fAcce = New ImageDump("img/fAcce")
        mAcce = New ImageDump("img/mAcce")
        ndoF = fAcce.Count
        ndoM = mAcce.Count
        fTFAcce = New ImageDump("img/fTF/tfAcce")
        mTFAcce = New ImageDump("img/mTF/tfAcce")
        fAcce.merge(fTFAcce)
        mAcce.merge(mTFAcce)
        atrs.Add(pInd.accessory, New ImageAttribute(fAcce, mAcce, ndoF, ndoM))

        '-front hair
        fFrontHair = New ImageDump("img/fFrontHair")
        mFrontHair = New ImageDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        fTfFrontHair = New ImageDump("img/fTF/tfFrontHair")
        mTfFrontHair = New ImageDump("img/mTF/tfFrontHair")
        fFrontHair.merge(fTfFrontHair)
        mFrontHair.merge(mTfFrontHair)
        atrs.Add(pInd.fronthair, New ImageAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-hat
        fHat = New ImageDump("img/fHat")
        mHat = New ImageDump("img/mHat")
        fTFHat = New ImageDump("img/fTF/tfHat")
        ndoF = Int(fHat.Count)
        ndoM = mHat.Count
        fHat.merge(fTFHat)
        atrs.Add(pInd.hat, New ImageAttribute(fHat, mHat, ndoF, ndoM))

        For Each ind In System.Enum.GetValues(GetType(pInd))
            atrs(ind).key = ind
            atrs(ind).setDumpKey()
        Next

        removePlaceholderNullImg(Nothing)
    End Sub
    Sub createNPCLib()
        Dim npcImg As ImageDump

        '-npcImg
        npcImg = New ImageDump("img/npcImg")
        atrs.Add(0, New ImageAttribute(npcImg, npcImg.Count))
    End Sub
    Sub removePlaceholderNullImg(ByVal null As Image)
        'replace the red "no image" images with transparent images
        atrs(pInd.glasses).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.glasses).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs(pInd.cloak).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.cloak).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs(pInd.accessory).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.accessory).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs(pInd.hat).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.hat).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs(pInd.facemark).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.facemark).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs(pInd.fronthair).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs(pInd.fronthair).setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)
    End Sub
    Sub createMFEqInd()
        mfEquivalentIndexes = New Dictionary(Of pInd, MFRouting)
        'bkg
        mfEquivalentIndexes.Add(pInd.bkg, New MFRouting({},
                                              {}))
        'tail
        mfEquivalentIndexes.Add(pInd.tail, New MFRouting({},
                                              {}))
        'wings
        mfEquivalentIndexes.Add(pInd.wings, New MFRouting({},
                                              {}))
        'rearhair2
        mfEquivalentIndexes.Add(pInd.rearhair, New MFRouting({5, 6},
                                              {13, 21}))
        'hairacc
        mfEquivalentIndexes.Add(pInd.hairacc, New MFRouting({},
                                              {}))
        'genitalia
        mfEquivalentIndexes.Add(pInd.genitalia, New MFRouting({0, 1, 2, 3, 4},
                                              {-1, -1, -1, -1, -1}))
        'shoulders
        mfEquivalentIndexes.Add(pInd.shoulders, New MFRouting({},
                                              {}))
        'body
        mfEquivalentIndexes.Add(pInd.body, New MFRouting({0},
                                              {0}))
        'chest
        mfEquivalentIndexes.Add(pInd.chest, New MFRouting({},
                                              {}))
        'bodyoverlay
        mfEquivalentIndexes.Add(pInd.bodyoverlay, New MFRouting({},
                                              {}))
        'clothesbtm
        mfEquivalentIndexes.Add(pInd.clothesbtm, New MFRouting({},
                                              {}))
        'clothes
        mfEquivalentIndexes.Add(pInd.clothes, New MFRouting({5},
                                              {47}))
        'face
        mfEquivalentIndexes.Add(pInd.face, New MFRouting({},
                                              {}))
        'rearhair1
        mfEquivalentIndexes.Add(pInd.midhair, New MFRouting({5, 6},
                                              {15, 24}))
        'horns
        mfEquivalentIndexes.Add(pInd.horns, New MFRouting({},
                                              {}))
        'nose
        mfEquivalentIndexes.Add(pInd.nose, New MFRouting({},
                                              {}))
        'ears
        mfEquivalentIndexes.Add(pInd.ears, New MFRouting({5, 6, 8},
                                              {5, 11, 14}))
        'mouth
        mfEquivalentIndexes.Add(pInd.mouth, New MFRouting({5, 6, 9},
                                              {10, 16, 26}))
        'eyes
        mfEquivalentIndexes.Add(pInd.eyes, New MFRouting({5, 6, 7, 8, 9, 10, 11, 12, 15, 16, 18},
                                                         {11, 14, 15, 19, 20, 33, 36, 38, 54, 55, 62}))
        'eyebrows
        mfEquivalentIndexes.Add(pInd.eyebrows, New MFRouting({},
                                              {}))
        'facial mark
        mfEquivalentIndexes.Add(pInd.facemark, New MFRouting({},
                                              {}))
        'glasses
        mfEquivalentIndexes.Add(pInd.glasses, New MFRouting({},
                                              {}))
        'cloak
        mfEquivalentIndexes.Add(pInd.cloak, New MFRouting({},
                                              {}))
        'accessories
        mfEquivalentIndexes.Add(pInd.accessory, New MFRouting({},
                                              {}))
        'fronthair
        mfEquivalentIndexes.Add(pInd.fronthair, New MFRouting({},
                                              {}))
        'hat
        mfEquivalentIndexes.Add(pInd.hat, New MFRouting({},
                                              {}))
    End Sub
    Public Function fAttributes() As List(Of Image)()
        Dim out As List(Of List(Of Image)) = New List(Of List(Of Image))
        For i = 0 To Portrait.NUM_IMG_LAYERS
            out.Add(atrs(atrs.Keys(i)).getF)
        Next
        Return out.ToArray
    End Function
    Public Function mAttributes() As List(Of Image)()
        Dim out As List(Of List(Of Image)) = New List(Of List(Of Image))
        For i = 0 To Portrait.NUM_IMG_LAYERS
            out.Add(atrs(atrs.Keys(i)).getM)
        Next
        Return out.ToArray
    End Function
End Class
