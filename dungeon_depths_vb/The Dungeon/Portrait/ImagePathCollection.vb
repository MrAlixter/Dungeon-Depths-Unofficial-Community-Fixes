Public Class ImagePathCollection
    Inherits Object

    Public Const null_path = "img/bkg/blank.png"

    Public atrs As Dictionary(Of pInd, ImagePathAttribute)
    Public mfEquivalentIndexes As Dictionary(Of pInd, MFRouting)

    Sub New(ByVal libID As Integer)
        'initialize the attribute dictionary object
        atrs = New Dictionary(Of pInd, ImagePathAttribute)

        'populate the attribute dictionary
        Select Case libID
            Case 0
                createDefaultImageLib()
            Case 1
                createAllImageLib()
                mfEquivalentIndexes = MFRouting.createMFEqInd()
            Case 2
                createNPCLib()
            Case Else
                createAllImageLib()
                mfEquivalentIndexes = MFRouting.createMFEqInd()
        End Select
    End Sub
    Sub createDefaultImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fClothing2, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAcce,
       fHat, fRearHair2, bkg As ImagePathDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mClothing2, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAcce,
            mHat, mRearHair2 As ImagePathDump

        Dim wings, horns, hbow, tail As ImagePathDump
        Dim shoulders, chest, genitalia, bodyoverlay As ImagePathDump

        Dim ndoM, ndoF As Integer

        '-backgrounds
        bkg = New ImagePathDump("img/bkg")
        atrs.Add(pInd.bkg, New ImagePathAttribute(bkg, bkg.Count))

        '-tail
        tail = New ImagePathDump("img/Tails")
        atrs.Add(pInd.tail, New ImagePathAttribute(tail, tail.Count))

        '-wings
        wings = New ImagePathDump("img/Wings")
        atrs.Add(pInd.wings, New ImagePathAttribute(wings, wings.Count))

        '-rear hair
        fRearHair2 = New ImagePathDump("img/fRearHair2")
        mRearHair2 = New ImagePathDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        atrs.Add(pInd.rearhair, New ImagePathAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-hairacc
        hbow = New ImagePathDump("img/HairBows")
        atrs.Add(pInd.hairacc, New ImagePathAttribute(hbow, hbow.Count))

        '-body
        fBody = New ImagePathDump("img/fBody")
        mBody = New ImagePathDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        atrs.Add(pInd.body, New ImagePathAttribute(fBody, mBody, ndoF, ndoM))

        '-genetalia
        genitalia = New ImagePathDump("img/Gen")
        Dim gM = New ImagePathDump(New List(Of String)({genitalia.getPathAt(1)}))
        Dim gF = New ImagePathDump(New List(Of String)({genitalia.getPathAt(4)}))
        ndoF = gF.Count
        ndoM = gM.Count
        atrs.Add(pInd.genitalia, New ImagePathAttribute(gF, gM, ndoF, ndoM))

        '-shoulders
        shoulders = New ImagePathDump("img/Shoulders")
        atrs.Add(pInd.shoulders, New ImagePathAttribute(shoulders, shoulders.Count))

        '-chest
        chest = New ImagePathDump("img/Chest")
        gM = New ImagePathDump(New List(Of String)({chest.getPathAt(0)}))
        gF = New ImagePathDump(New List(Of String)({chest.getPathAt(2)}))
        ndoF = gF.Count
        ndoM = gM.Count
        atrs.Add(pInd.chest, New ImagePathAttribute(gF, gM, ndoF, ndoM))

        '-bodyoverlay
        bodyoverlay = New ImagePathDump("img/BodyOverlay")
        atrs.Add(pInd.bodyoverlay, New ImagePathAttribute(bodyoverlay, bodyoverlay.Count))

        '-clothes
        fClothing = New ImagePathDump("img/fClothing")
        mClothing = New ImagePathDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        atrs.Add(pInd.clothes, New ImagePathAttribute(fClothing, mClothing, ndoF, ndoM))

        '-clothesbtm
        fClothing2 = New ImagePathDump("img/fClothing2")
        mClothing2 = New ImagePathDump("img/mClothing2")
        ndoF = fClothing2.Count
        ndoM = mClothing2.Count
        atrs.Add(pInd.clothesbtm, New ImagePathAttribute(fClothing2, mClothing2, ndoF, ndoM))

        '-face
        fFace = New ImagePathDump("img/fFace")
        mFace = New ImagePathDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        atrs.Add(pInd.face, New ImagePathAttribute(fFace, mFace, ndoF, ndoM))

        '-blush
        atrs.Add(pInd.blush, New ImagePathAttribute(bkg, bkg.Count))

        '-mid hair
        fRearHair1 = New ImagePathDump("img/fRearHair1")
        mRearHair1 = New ImagePathDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        atrs.Add(pInd.midhair, New ImagePathAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-horns
        horns = New ImagePathDump("img/Horns")
        atrs.Add(pInd.horns, New ImagePathAttribute(horns, horns.Count))

        '-ears
        fEars = New ImagePathDump("img/fEars")
        mEars = New ImagePathDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        atrs.Add(pInd.ears, New ImagePathAttribute(fEars, mEars, ndoF, ndoM))

        '-nose
        fNose = New ImagePathDump("img/fNose")
        mNose = New ImagePathDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        atrs.Add(pInd.nose, New ImagePathAttribute(fNose, mNose, ndoF, ndoM))

        '-mouth
        fMouth = New ImagePathDump("img/fMouth")
        mMouth = New ImagePathDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        atrs.Add(pInd.mouth, New ImagePathAttribute(fMouth, mMouth, ndoF, ndoM))

        '-eyes
        fEyes = New ImagePathDump("img/fEyes")
        mEyes = New ImagePathDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        atrs.Add(pInd.eyes, New ImagePathAttribute(fEyes, mEyes, ndoF, ndoM))

        '-eyebrows
        fEyebrows = New ImagePathDump("img/fEyebrows")
        mEyebrows = New ImagePathDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add(pInd.eyebrows, New ImagePathAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-facial mark
        fFacialMark = New ImagePathDump("img/fFacialMark")
        mFacialMark = New ImagePathDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add(pInd.facemark, New ImagePathAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-glasses
        fGlasses = New ImagePathDump("img/fGlasses")
        mGlasses = New ImagePathDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        atrs.Add(pInd.glasses, New ImagePathAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-cloak
        fCloak = New ImagePathDump("img/fCloakF")
        mCloak = New ImagePathDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add(pInd.cloak, New ImagePathAttribute(fCloak, mCloak, ndoF, ndoM))

        '-accessory
        fAcce = New ImagePathDump("img/fAcce")
        mAcce = New ImagePathDump("img/mAcce")
        ndoF = fAcce.Count
        ndoM = mAcce.Count
        atrs.Add(pInd.accessory, New ImagePathAttribute(fAcce, mAcce, ndoF, ndoM))

        '-front hair
        fFrontHair = New ImagePathDump("img/fFrontHair")
        mFrontHair = New ImagePathDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        atrs.Add(pInd.fronthair, New ImagePathAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-hat
        fHat = New ImagePathDump("img/fHat")
        mHat = New ImagePathDump("img/mHat")
        ndoF = fHat.Count
        ndoM = mHat.Count
        atrs.Add(pInd.hat, New ImagePathAttribute(fHat, mHat, ndoF, ndoM))
    End Sub
    Sub createAllImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fClothing2, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAcce,
       fHat, fRearHair2, bkg As ImagePathDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mClothing2, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAcce,
            mHat, mRearHair2 As ImagePathDump

        Dim fTFAcce, fTFBody, fTFClothes, fTFClothes2, fTFEars, fTFEyes, fTFface,
            fTfFrontHair, fTFMouth, fTFNose, fTFRearhair1, fTfRearhair2, fTFGlasses,
            fTFHat As ImagePathDump
        Dim mTFAcce, mTFBody, mTFClothes, mTFClothes2, mTFEars, mTFEyes, mTFface,
            mTfFrontHair, mTFMouth, mTFNose, mTFRearhair1, mTfRearhair2 As ImagePathDump

        Dim wings, horns, hbow, tail As ImagePathDump
        Dim shoulders, chest, genitalia, bodyoverlay As ImagePathDump

        Dim ndoM, ndoF As Integer

        '-backgrounds
        bkg = New ImagePathDump("img/bkg")
        atrs.Add(pInd.bkg, New ImagePathAttribute(bkg, bkg.Count))

        '-tail
        tail = New ImagePathDump("img/Tails")
        atrs.Add(pInd.tail, New ImagePathAttribute(tail, tail.Count))

        '-wings
        wings = New ImagePathDump("img/Wings")
        atrs.Add(pInd.wings, New ImagePathAttribute(wings, wings.Count))

        '-rear hair
        fRearHair2 = New ImagePathDump("img/fRearHair2")
        mRearHair2 = New ImagePathDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        fTfRearhair2 = New ImagePathDump("img/fTF/tfRearHair2")
        mTfRearhair2 = New ImagePathDump("img/mTF/tfRearHair2")
        fRearHair2.AddRange(fTfRearhair2)
        mRearHair2.AddRange(mTfRearhair2)
        atrs.Add(pInd.rearhair, New ImagePathAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-hairacc
        hbow = New ImagePathDump("img/HairBows")
        atrs.Add(pInd.hairacc, New ImagePathAttribute(hbow, hbow.Count))

        '-body
        fBody = New ImagePathDump("img/fBody")
        mBody = New ImagePathDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        fTFBody = New ImagePathDump("img/fTF/tfBody")
        mTFBody = New ImagePathDump("img/mTF/tfBody")
        fBody.AddRange(fTFBody)
        mBody.AddRange(mTFBody)
        atrs.Add(pInd.body, New ImagePathAttribute(fBody, mBody, ndoF, ndoM))

        '-genetalia
        genitalia = New ImagePathDump("img/Gen")
        atrs.Add(pInd.genitalia, New ImagePathAttribute(genitalia, genitalia.Count))

        '-shoulders
        shoulders = New ImagePathDump("img/Shoulders")
        atrs.Add(pInd.shoulders, New ImagePathAttribute(shoulders, shoulders.Count))

        '-chest
        chest = New ImagePathDump("img/Chest")
        atrs.Add(pInd.chest, New ImagePathAttribute(chest, chest.Count))

        '-bodyoverlay
        bodyoverlay = New ImagePathDump("img/BodyOverlay")
        atrs.Add(pInd.bodyoverlay, New ImagePathAttribute(bodyoverlay, bodyoverlay.Count))

        '-clothes
        fClothing = New ImagePathDump("img/fClothing")
        mClothing = New ImagePathDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        fTFClothes = New ImagePathDump("img/fTF/tfClothes")
        mTFClothes = New ImagePathDump("img/mTF/tfClothes")
        fClothing.AddRange(fTFClothes)
        mClothing.AddRange(mTFClothes)
        atrs.Add(pInd.clothes, New ImagePathAttribute(fClothing, mClothing, ndoF, ndoM))

        '-clothesbtm
        fClothing2 = New ImagePathDump("img/fClothing2")
        mClothing2 = New ImagePathDump("img/mClothing2")
        ndoF = fClothing2.Count
        ndoM = mClothing2.Count
        fTFClothes2 = New ImagePathDump("img/fTF/tfClothes2")
        mTFClothes2 = New ImagePathDump("img/mTF/tfClothes2")
        fClothing2.AddRange(fTFClothes2)
        mClothing2.AddRange(mTFClothes2)
        atrs.Add(pInd.clothesbtm, New ImagePathAttribute(fClothing2, mClothing2, ndoF, ndoM))

        '-face
        fFace = New ImagePathDump("img/fFace")
        mFace = New ImagePathDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        fTFface = New ImagePathDump("img/fTF/tfFace")
        mTFface = New ImagePathDump("img/mTF/tfFace")
        fFace.AddRange(fTFface)
        mFace.AddRange(mTFface)
        atrs.Add(pInd.face, New ImagePathAttribute(fFace, mFace, ndoF, ndoM))

        '-blush
        atrs.Add(pInd.blush, New ImagePathAttribute(bkg, bkg.Count))

        '-mid hair
        fRearHair1 = New ImagePathDump("img/fRearHair1")
        mRearHair1 = New ImagePathDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        fTFRearhair1 = New ImagePathDump("img/fTF/tfRearHair1")
        mTFRearhair1 = New ImagePathDump("img/mTF/tfRearHair1")
        fRearHair1.AddRange(fTFRearhair1)
        mRearHair1.AddRange(mTFRearhair1)
        atrs.Add(pInd.midhair, New ImagePathAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-horns
        horns = New ImagePathDump("img/Horns")
        atrs.Add(pInd.horns, New ImagePathAttribute(horns, horns.Count))

        '-ears
        fEars = New ImagePathDump("img/fEars")
        mEars = New ImagePathDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        fTFEars = New ImagePathDump("img/fTF/tfEars")
        mTFEars = New ImagePathDump("img/mTF/tfEars")
        fEars.AddRange(fTFEars)
        mEars.AddRange(mTFEars)
        atrs.Add(pInd.ears, New ImagePathAttribute(fEars, mEars, ndoF, ndoM))

        '-nose
        fNose = New ImagePathDump("img/fNose")
        mNose = New ImagePathDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        fTFNose = New ImagePathDump("img/fTF/tfNose")
        mTFNose = New ImagePathDump("img/mTF/tfNose")
        fNose.AddRange(fTFNose)
        mNose.AddRange(mTFNose)
        atrs.Add(pInd.nose, New ImagePathAttribute(fNose, mNose, ndoF, ndoM))

        '-mouth
        fMouth = New ImagePathDump("img/fMouth")
        mMouth = New ImagePathDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        fTFMouth = New ImagePathDump("img/fTF/tfMouth")
        mTFMouth = New ImagePathDump("img/mTF/tfMouth")
        fMouth.AddRange(fTFMouth)
        mMouth.AddRange(mTFMouth)
        atrs.Add(pInd.mouth, New ImagePathAttribute(fMouth, mMouth, ndoF, ndoM))

        '-eyes
        fEyes = New ImagePathDump("img/fEyes")
        mEyes = New ImagePathDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        fTFEyes = New ImagePathDump("img/fTF/tfEyes")
        mTFEyes = New ImagePathDump("img/mTF/tfEyes")
        fEyes.AddRange(fTFEyes)
        mEyes.AddRange(mTFEyes)
        atrs.Add(pInd.eyes, New ImagePathAttribute(fEyes, mEyes, ndoF, ndoM))

        '-eyebrows
        fEyebrows = New ImagePathDump("img/fEyebrows")
        mEyebrows = New ImagePathDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add(pInd.eyebrows, New ImagePathAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-face mark
        fFacialMark = New ImagePathDump("img/fFacialMark")
        mFacialMark = New ImagePathDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add(pInd.facemark, New ImagePathAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-glasses
        fGlasses = New ImagePathDump("img/fGlasses")
        fTFGlasses = New ImagePathDump("img/fTF/tfGlasses")
        mGlasses = New ImagePathDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        fGlasses.AddRange(fTFGlasses)
        atrs.Add(pInd.glasses, New ImagePathAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-cloak
        fCloak = New ImagePathDump("img/fCloakF")
        mCloak = New ImagePathDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add(pInd.cloak, New ImagePathAttribute(fCloak, mCloak, ndoF, ndoM))

        '-accessory
        fAcce = New ImagePathDump("img/fAcce")
        mAcce = New ImagePathDump("img/mAcce")
        ndoF = fAcce.Count
        ndoM = mAcce.Count
        fTFAcce = New ImagePathDump("img/fTF/tfAcce")
        mTFAcce = New ImagePathDump("img/mTF/tfAcce")
        fAcce.AddRange(fTFAcce)
        mAcce.AddRange(mTFAcce)
        atrs.Add(pInd.accessory, New ImagePathAttribute(fAcce, mAcce, ndoF, ndoM))

        '-front hair
        fFrontHair = New ImagePathDump("img/fFrontHair")
        mFrontHair = New ImagePathDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        fTfFrontHair = New ImagePathDump("img/fTF/tfFrontHair")
        mTfFrontHair = New ImagePathDump("img/mTF/tfFrontHair")
        fFrontHair.AddRange(fTfFrontHair)
        mFrontHair.AddRange(mTfFrontHair)
        atrs.Add(pInd.fronthair, New ImagePathAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-hat
        fHat = New ImagePathDump("img/fHat")
        mHat = New ImagePathDump("img/mHat")
        fTFHat = New ImagePathDump("img/fTF/tfHat")
        ndoF = Int(fHat.Count)
        ndoM = mHat.Count
        fHat.AddRange(fTFHat)
        atrs.Add(pInd.hat, New ImagePathAttribute(fHat, mHat, ndoF, ndoM))

        For Each ind In System.Enum.GetValues(GetType(pInd))
            atrs(ind).key = ind
            atrs(ind).setDumpKey()
        Next

        removePlaceholderNullImg(null_path)
    End Sub
    Sub createNPCLib()
        Dim npcImg As ImagePathDump

        '-npcImg
        npcImg = New ImagePathDump("img/npcImg")
        atrs.Add(0, New ImagePathAttribute(npcImg, npcImg.Count))
    End Sub
    Sub removePlaceholderNullImg(ByVal null As String)
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
    Public Function fAttributes() As List(Of String)()
        Dim out As List(Of List(Of String)) = New List(Of List(Of String))
        For i = 0 To Portrait.NUM_IMG_LAYERS
            out.Add(atrs(atrs.Keys(i)).getF)
        Next
        Return out.ToArray
    End Function
    Public Function mAttributes() As List(Of String)()
        Dim out As List(Of List(Of String)) = New List(Of List(Of String))
        For i = 0 To Portrait.NUM_IMG_LAYERS
            out.Add(atrs(atrs.Keys(i)).getM)
        Next
        Return out.ToArray
    End Function
End Class
