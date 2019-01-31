Public Class ImageCollection
    Inherits Object
    Public atrs As Dictionary(Of String, ImageAttribute) = New Dictionary(Of String, ImageAttribute)

    Sub New(ByVal libID As Integer)
        Select Case libID
            Case 0
                createDefaultImageLib()
            Case 1
                createAllImageLib()
            Case Else
                createAllImageLib()
        End Select
    End Sub
    Sub createDefaultImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAccA,
       fHat, fRearHair2, bkg As ImageDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAccA,
            mHat, mRearHair2 As ImageDump

        Dim wings, horns, tails As ImageDump

        Dim ndoM, ndoF As Integer

        '-index 0 (backgrounds)
        bkg = New ImageDump("img/bkg")
        atrs.Add("bkg", New ImageAttribute(bkg, bkg.Count))

        '-index 1 (rear hair layer 2)
        fRearHair2 = New ImageDump("img/fRearHair2")
        mRearHair2 = New ImageDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        atrs.Add("RearHair2", New ImageAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-index 2 (body)
        fBody = New ImageDump("img/fBody")
        mBody = New ImageDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        atrs.Add("Body", New ImageAttribute(fBody, mBody, ndoF, ndoM))

        '-index 3 (clothes)
        fClothing = New ImageDump("img/fClothing")
        mClothing = New ImageDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        atrs.Add("Clothes", New ImageAttribute(fClothing, mClothing, ndoF, ndoM))

        '-index 4 (face)
        fFace = New ImageDump("img/fFace")
        mFace = New ImageDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        atrs.Add("Face", New ImageAttribute(fFace, mFace, ndoF, ndoM))

        '-index 5 (rear hair layer 1)
        fRearHair1 = New ImageDump("img/fRearHair1")
        mRearHair1 = New ImageDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        atrs.Add("RearHair1", New ImageAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-index 6 (ears)
        fEars = New ImageDump("img/fEars")
        mEars = New ImageDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        atrs.Add("Ears", New ImageAttribute(fEars, mEars, ndoF, ndoM))

        '-index 7 (nose)
        fNose = New ImageDump("img/fNose")
        mNose = New ImageDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        atrs.Add("Nose", New ImageAttribute(fNose, mNose, ndoF, ndoM))

        '-index 8 (mouth)
        fMouth = New ImageDump("img/fMouth")
        mMouth = New ImageDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        atrs.Add("Mouth", New ImageAttribute(fMouth, mMouth, ndoF, ndoM))

        '-index 9 (eyes)
        fEyes = New ImageDump("img/fEyes")
        mEyes = New ImageDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        atrs.Add("Eyes", New ImageAttribute(fEyes, mEyes, ndoF, ndoM))

        '-index 10 (eyebrows)
        fEyebrows = New ImageDump("img/fEyebrows")
        mEyebrows = New ImageDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add("Eyebrows", New ImageAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-index 11 (facial mark)
        fFacialMark = New ImageDump("img/fFacialMark")
        mFacialMark = New ImageDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add("FacialMark", New ImageAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-index 12 (glasses)
        fGlasses = New ImageDump("img/fGlasses")
        mGlasses = New ImageDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        atrs.Add("Glasses", New ImageAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-index 13 (cloak)
        fCloak = New ImageDump("img/fCloakF")
        mCloak = New ImageDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add("Cloak", New ImageAttribute(fCloak, mCloak, ndoF, ndoM))

        '-index 14 (AccA)
        fAccA = New ImageDump("img/fAccA")
        mAccA = New ImageDump("img/mAccA")
        ndoF = fAccA.Count
        ndoM = mAccA.Count
        atrs.Add("AccA", New ImageAttribute(fAccA, mAccA, ndoF, ndoM))

        '-index 15 (front hair)
        fFrontHair = New ImageDump("img/fFrontHair")
        mFrontHair = New ImageDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        atrs.Add("FrontHair", New ImageAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-index 16 (hat)
        fHat = New ImageDump("img/fHat")
        mHat = New ImageDump("img/mHat")
        ndoF = fHat.Count
        ndoM = mHat.Count
        atrs.Add("Hat", New ImageAttribute(fHat, mHat, ndoF, ndoM))

        wings = New ImageDump("img/Wings")
        atrs.Add("Wings", New ImageAttribute(wings, wings.Count))

        horns = New ImageDump("img/Horns")
        atrs.Add("Horns", New ImageAttribute(horns, horns.Count))
    End Sub
    Sub createAllImageLib()
        Dim fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak,
       fClothing, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAccA,
       fHat, fRearHair2, bkg As ImageDump
        Dim mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak,
            mClothing, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAccA,
            mHat, mRearHair2 As ImageDump

        Dim fTFAccA, fTFBody, fTFClothes, fTFEars, fTFEyes, fTFface,
            fTfFrontHair, fTFMouth, fTFNose, fTFRearhair1, fTfRearhair2 As ImageDump
        Dim mTFAccA, mTFBody, mTFClothes, mTFEars, mTFEyes, mTFface,
            mTfFrontHair, mTFMouth, mTFNose, mTFRearhair1, mTfRearhair2 As ImageDump

        Dim wings, horns, tails As ImageDump

        Dim ndoM, ndoF As Integer

        '-index 0 (backgrounds)
        bkg = New ImageDump("img/bkg")
        atrs.Add("bkg", New ImageAttribute(bkg, bkg.Count))

        '-index 1 (rear hair layer 2)
        fRearHair2 = New ImageDump("img/fRearHair2")
        mRearHair2 = New ImageDump("img/mRearHair2")
        ndoF = fRearHair2.Count
        ndoM = mRearHair2.Count
        fTfRearhair2 = New ImageDump("img/fTF/tfRearHair2")
        mTfRearhair2 = New ImageDump("img/mTF/tfRearHair2")
        fRearHair2.merge(fTfRearhair2)
        mRearHair2.merge(mTfRearhair2)
        atrs.Add("RearHair2", New ImageAttribute(fRearHair2, mRearHair2, ndoF, ndoM))

        '-index 2 (body)
        fBody = New ImageDump("img/fBody")
        mBody = New ImageDump("img/mBody")
        ndoF = fBody.Count
        ndoM = mBody.Count
        fTFBody = New ImageDump("img/fTF/tfBody")
        mTFBody = New ImageDump("img/mTF/tfBody")
        fBody.merge(fTFBody)
        mBody.merge(mTFBody)
        atrs.Add("Body", New ImageAttribute(fBody, mBody, ndoF, ndoM))

        '-index 3 (clothes)
        fClothing = New ImageDump("img/fClothing")
        mClothing = New ImageDump("img/mClothing")
        ndoF = fClothing.Count
        ndoM = mClothing.Count
        fTFClothes = New ImageDump("img/fTF/tfClothes")
        mTFClothes = New ImageDump("img/mTF/tfClothes")
        fClothing.merge(fTFClothes)
        mClothing.merge(mTFClothes)
        atrs.Add("Clothes", New ImageAttribute(fClothing, mClothing, ndoF, ndoM))

        '-index 4 (face)
        fFace = New ImageDump("img/fFace")
        mFace = New ImageDump("img/mFace")
        ndoF = fFace.Count
        ndoM = mFace.Count
        fTFface = New ImageDump("img/fTF/tfFace")
        mTFface = New ImageDump("img/mTF/tfFace")
        fFace.merge(fTFface)
        mFace.merge(mTFface)
        atrs.Add("Face", New ImageAttribute(fFace, mFace, ndoF, ndoM))

        '-index 5 (rear hair layer 1)
        fRearHair1 = New ImageDump("img/fRearHair1")
        mRearHair1 = New ImageDump("img/mRearHair1")
        ndoF = fRearHair1.Count
        ndoM = mRearHair1.Count
        fTFRearhair1 = New ImageDump("img/fTF/tfRearHair1")
        mTFRearhair1 = New ImageDump("img/mTF/tfRearHair1")
        fRearHair1.merge(fTFRearhair1)
        mRearHair1.merge(mTFRearhair1)
        atrs.Add("RearHair1", New ImageAttribute(fRearHair1, mRearHair1, ndoF, ndoM))

        '-index 6 (ears)
        fEars = New ImageDump("img/fEars")
        mEars = New ImageDump("img/mEars")
        ndoF = fEars.Count
        ndoM = mEars.Count
        fTFEars = New ImageDump("img/fTF/tfEars")
        mTFEars = New ImageDump("img/mTF/tfEars")
        fEars.merge(fTFEars)
        mEars.merge(mTFEars)
        atrs.Add("Ears", New ImageAttribute(fEars, mEars, ndoF, ndoM))

        '-index 7 (nose)
        fNose = New ImageDump("img/fNose")
        mNose = New ImageDump("img/mNose")
        ndoF = fNose.Count
        ndoM = mNose.Count
        fTFNose = New ImageDump("img/fTF/tfNose")
        mTFNose = New ImageDump("img/mTF/tfNose")
        fNose.merge(fTFNose)
        mNose.merge(mTFNose)
        atrs.Add("Nose", New ImageAttribute(fNose, mNose, ndoF, ndoM))

        '-index 8 (mouth)
        fMouth = New ImageDump("img/fMouth")
        mMouth = New ImageDump("img/mMouth")
        ndoF = fMouth.Count
        ndoM = mMouth.Count
        fTFMouth = New ImageDump("img/fTF/tfMouth")
        mTFMouth = New ImageDump("img/mTF/tfMouth")
        fMouth.merge(fTFMouth)
        mMouth.merge(mTFMouth)
        atrs.Add("Mouth", New ImageAttribute(fMouth, mMouth, ndoF, ndoM))

        '-index 9 (eyes)
        fEyes = New ImageDump("img/fEyes")
        mEyes = New ImageDump("img/mEyes")
        ndoF = fEyes.Count
        ndoM = mEyes.Count
        fTFEyes = New ImageDump("img/fTF/tfEyes")
        mTFEyes = New ImageDump("img/mTF/tfEyes")
        fEyes.merge(fTFEyes)
        mEyes.merge(mTFEyes)
        atrs.Add("Eyes", New ImageAttribute(fEyes, mEyes, ndoF, ndoM))

        '-index 10 (eyebrows)
        fEyebrows = New ImageDump("img/fEyebrows")
        mEyebrows = New ImageDump("img/mEyebrows")
        ndoF = fEyebrows.Count
        ndoM = mEyebrows.Count
        atrs.Add("Eyebrows", New ImageAttribute(fEyebrows, mEyebrows, ndoF, ndoM))

        '-index 11 (facial mark)
        fFacialMark = New ImageDump("img/fFacialMark")
        mFacialMark = New ImageDump("img/mFacialMark")
        ndoF = fFacialMark.Count
        ndoM = mFacialMark.Count
        atrs.Add("FacialMark", New ImageAttribute(fFacialMark, mFacialMark, ndoF, ndoM))

        '-index 12 (glasses)
        fGlasses = New ImageDump("img/fGlasses")
        mGlasses = New ImageDump("img/mGlasses")
        ndoF = fGlasses.Count
        ndoM = mGlasses.Count
        atrs.Add("Glasses", New ImageAttribute(fGlasses, mGlasses, ndoF, ndoM))

        '-index 13 (cloak)
        fCloak = New ImageDump("img/fCloakF")
        mCloak = New ImageDump("img/mCloakF")
        ndoF = fCloak.Count
        ndoM = mCloak.Count
        atrs.Add("Cloak", New ImageAttribute(fCloak, mCloak, ndoF, ndoM))

        '-index 14 (AccA)
        fAccA = New ImageDump("img/fAccA")
        mAccA = New ImageDump("img/mAccA")
        ndoF = fAccA.Count
        ndoM = mAccA.Count
        fTFAccA = New ImageDump("img/fTF/tfAccA")
        mTFAccA = New ImageDump("img/mTF/tfAccA")
        fAccA.merge(fTFAccA)
        mAccA.merge(mTFAccA)
        atrs.Add("AccA", New ImageAttribute(fAccA, mAccA, ndoF, ndoM))

        '-index 15 (front hair)
        fFrontHair = New ImageDump("img/fFrontHair")
        mFrontHair = New ImageDump("img/mFrontHair")
        ndoF = fFrontHair.Count
        ndoM = mFrontHair.Count
        fTfFrontHair = New ImageDump("img/fTF/tfFrontHair")
        mTfFrontHair = New ImageDump("img/mTF/tfFrontHair")
        fFrontHair.merge(fTfFrontHair)
        mFrontHair.merge(mTfFrontHair)
        atrs.Add("FrontHair", New ImageAttribute(fFrontHair, mFrontHair, ndoF, ndoM))

        '-index 16 (hat)
        fHat = New ImageDump("img/fHat")
        mHat = New ImageDump("img/mHat")
        ndoF = fHat.Count
        ndoM = mHat.Count
        fHat.add(fTFBody.getImageAt(10))
        fHat.add(fTFBody.getImageAt(12))
        fHat.add(fTFBody.getImageAt(13))
        mHat.add(fTFBody.getImageAt(5))
        mHat.add(fTFBody.getImageAt(7))
        atrs.Add("Hat", New ImageAttribute(fHat, mHat, ndoF, ndoM))

        wings = New ImageDump("img/Wings")
        atrs.Add("Wings", New ImageAttribute(wings, wings.Count))

        horns = New ImageDump("img/Horns")
        atrs.Add("Horns", New ImageAttribute(horns, horns.Count))

        For i = 0 To atrs.Keys.Count - 1
            atrs(atrs.Keys(i)).key = atrs.Keys(i)
        Next

        removePlaceholderNullImg(Nothing)
    End Sub
    Sub removePlaceholderNullImg(ByVal null As Image)
        'replace the red "no image" images with transparent images
        atrs("Glasses").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("Glasses").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs("Cloak").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("Cloak").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs("AccA").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("AccA").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs("Hat").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("Hat").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs("FacialMark").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("FacialMark").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)

        atrs("FrontHair").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, True, False), null)
        atrs("FrontHair").setAt(New Tuple(Of Integer, Boolean, Boolean)(0, False, False), null)
    End Sub

    Public Function fAttributes() As List(Of Image)()
        Dim out As List(Of List(Of Image)) = New List(Of List(Of Image))
        For i = 0 To 16
            out.Add(atrs(atrs.Keys(i)).getF)
        Next
        Return out.ToArray
    End Function
    Public Function mAttributes() As List(Of Image)()
        Dim out As List(Of List(Of Image)) = New List(Of List(Of Image))
        For i = 0 To 16
            out.Add(atrs(atrs.Keys(i)).getM)
        Next
        Return out.ToArray
    End Function

    Public Overrides Function ToString() As String
        Return "bing"
    End Function
End Class
