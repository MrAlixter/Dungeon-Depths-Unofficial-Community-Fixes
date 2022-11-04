Public Class MFRouting
    Dim mInds As List(Of Tuple(Of Integer, Boolean, Boolean))
    Dim fInds As List(Of Tuple(Of Integer, Boolean, Boolean))

    Sub New(ByVal m As Tuple(Of Integer, Boolean, Boolean)(), ByVal f As Tuple(Of Integer, Boolean, Boolean)())
        mInds = New List(Of Tuple(Of Integer, Boolean, Boolean))(m)
        fInds = New List(Of Tuple(Of Integer, Boolean, Boolean))(f)
    End Sub

    Public Function getMfromF(ByVal f As Tuple(Of Integer, Boolean, Boolean)) As Tuple(Of Integer, Boolean, Boolean)
        Dim i = fInds.IndexOf(f)

        If i >= 0 And i < mInds.Count Then Return mInds(i)

        Return f
    End Function
    Public Function getFfromM(ByVal m As Tuple(Of Integer, Boolean, Boolean)) As Tuple(Of Integer, Boolean, Boolean)
        Dim i = mInds.IndexOf(m)

        If i >= 0 And i < fInds.Count Then Return fInds(i)

        Return m
    End Function

    Shared Function createMFEqInd() As Dictionary(Of pInd, MFRouting)
        Dim mfEquivalentIndexes = New Dictionary(Of pInd, MFRouting)

        'bkg
        mfEquivalentIndexes.Add(pInd.bkg, New MFRouting({},
                                                        {}))
        'tail
        mfEquivalentIndexes.Add(pInd.tail, New MFRouting({},
                                                         {}))
        'wings
        mfEquivalentIndexes.Add(pInd.wings, New MFRouting({},
                                                          {}))
        'rearhair
        mfEquivalentIndexes.Add(pInd.rearhair, New MFRouting({Portrait.mkIAInd(0, False, False), Portrait.mkIAInd(1, False, False), Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(3, False, False), Portrait.mkIAInd(4, False, False), Portrait.mkIAInd(5, False, False), Portrait.mkIAInd(6, False, False), Portrait.mkIAInd(5, False, True), Portrait.mkIAInd(6, False, True)},
                                                             {Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(6, True, False), Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(11, True, True), Portrait.mkIAInd(21, True, True)}))
        'hairacc
        mfEquivalentIndexes.Add(pInd.hairacc, New MFRouting({},
                                                            {}))
        'genitalia
        mfEquivalentIndexes.Add(pInd.genitalia, New MFRouting({Portrait.mkIAInd(0, False, True), Portrait.mkIAInd(1, False, True), Portrait.mkIAInd(2, False, True), Portrait.mkIAInd(3, False, True), Portrait.mkIAInd(4, False, True)},
                                                              {Portrait.mkIAInd(-1, True, True), Portrait.mkIAInd(-1, True, True), Portrait.mkIAInd(-1, True, True), Portrait.mkIAInd(-1, True, True), Portrait.mkIAInd(-1, True, True)}))
        'shoulders
        mfEquivalentIndexes.Add(pInd.shoulders, New MFRouting({},
                                                              {}))
        'body
        mfEquivalentIndexes.Add(pInd.body, New MFRouting({Portrait.mkIAInd(0, False, False), Portrait.mkIAInd(2, False, True), Portrait.mkIAInd(5, False, True)},
                                                         {Portrait.mkIAInd(0, True, False), Portrait.mkIAInd(0, True, False), Portrait.mkIAInd(2, False, True)}))
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
        mfEquivalentIndexes.Add(pInd.clothes, New MFRouting({Portrait.mkIAInd(5, False, True)},
                                                            {Portrait.mkIAInd(47, True, True)}))
        'face
        mfEquivalentIndexes.Add(pInd.face, New MFRouting({Portrait.mkIAInd(0, False, False), Portrait.mkIAInd(1, False, False), Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(3, False, False), Portrait.mkIAInd(4, False, False)},
                                                         {Portrait.mkIAInd(3, True, False), Portrait.mkIAInd(0, True, False), Portrait.mkIAInd(1, True, False), Portrait.mkIAInd(2, True, False), Portrait.mkIAInd(4, True, False)}))
        'midhair
        mfEquivalentIndexes.Add(pInd.midhair, New MFRouting({Portrait.mkIAInd(1, False, False), Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(5, False, True), Portrait.mkIAInd(6, False, True), Portrait.mkIAInd(7, False, True)},
                                                            {Portrait.mkIAInd(11, True, False), Portrait.mkIAInd(8, True, True), Portrait.mkIAInd(45, True, True), Portrait.mkIAInd(24, True, True), Portrait.mkIAInd(5, True, False)}))
        'horns
        mfEquivalentIndexes.Add(pInd.horns, New MFRouting({},
                                                          {}))
        'nose
        mfEquivalentIndexes.Add(pInd.nose, New MFRouting({},
                                                         {}))
        'ears
        mfEquivalentIndexes.Add(pInd.ears, New MFRouting({Portrait.mkIAInd(6, False, True), Portrait.mkIAInd(7, False, True), Portrait.mkIAInd(8, False, True)},
                                                         {Portrait.mkIAInd(11, True, True), Portrait.mkIAInd(8, True, True), Portrait.mkIAInd(14, True, True)}))
        'mouth
        mfEquivalentIndexes.Add(pInd.mouth, New MFRouting({Portrait.mkIAInd(5, False, True), Portrait.mkIAInd(9, False, True)},
                                                          {Portrait.mkIAInd(10, True, True), Portrait.mkIAInd(26, True, True)}))
        'eyes
        mfEquivalentIndexes.Add(pInd.eyes, New MFRouting({Portrait.mkIAInd(0, False, False), Portrait.mkIAInd(1, False, False), Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(3, False, False), Portrait.mkIAInd(4, False, False), Portrait.mkIAInd(5, False, False), Portrait.mkIAInd(6, False, False), Portrait.mkIAInd(7, False, False), Portrait.mkIAInd(8, False, False), Portrait.mkIAInd(9, False, False),
                                                          Portrait.mkIAInd(5, False, True), Portrait.mkIAInd(6, False, True), Portrait.mkIAInd(7, False, True), Portrait.mkIAInd(8, False, True), Portrait.mkIAInd(9, False, True), Portrait.mkIAInd(10, False, True), Portrait.mkIAInd(11, False, True), Portrait.mkIAInd(12, False, True), Portrait.mkIAInd(14, False, True), Portrait.mkIAInd(15, False, True), Portrait.mkIAInd(16, False, True), Portrait.mkIAInd(17, False, True), Portrait.mkIAInd(18, False, True)},
                                                         {Portrait.mkIAInd(0, True, False), Portrait.mkIAInd(1, True, False), Portrait.mkIAInd(4, True, False), Portrait.mkIAInd(5, True, False), Portrait.mkIAInd(6, True, False), Portrait.mkIAInd(7, True, False), Portrait.mkIAInd(8, True, False), Portrait.mkIAInd(9, True, False), Portrait.mkIAInd(10, True, False), Portrait.mkIAInd(11, True, False),
                                                          Portrait.mkIAInd(11, True, True), Portrait.mkIAInd(14, True, True), Portrait.mkIAInd(15, True, True), Portrait.mkIAInd(19, True, True), Portrait.mkIAInd(20, True, True), Portrait.mkIAInd(33, True, True), Portrait.mkIAInd(36, True, True), Portrait.mkIAInd(38, True, True), Portrait.mkIAInd(52, True, True), Portrait.mkIAInd(54, True, True), Portrait.mkIAInd(55, True, True), Portrait.mkIAInd(61, True, True), Portrait.mkIAInd(62, True, True)}))
        'eyebrows
        mfEquivalentIndexes.Add(pInd.eyebrows, New MFRouting({},
                                                             {}))
        'facial mark
        mfEquivalentIndexes.Add(pInd.facemark, New MFRouting({Portrait.mkIAInd(0, False, False), Portrait.mkIAInd(1, False, False), Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(3, False, False), Portrait.mkIAInd(4, False, False), Portrait.mkIAInd(5, False, False), Portrait.mkIAInd(6, False, False)},
                                                             {Portrait.mkIAInd(0, True, False), Portrait.mkIAInd(1, True, False), Portrait.mkIAInd(2, True, False), Portrait.mkIAInd(3, True, False), Portrait.mkIAInd(4, True, False), Portrait.mkIAInd(5, True, False), Portrait.mkIAInd(6, True, False)}))
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
        mfEquivalentIndexes.Add(pInd.fronthair, New MFRouting({Portrait.mkIAInd(2, False, False), Portrait.mkIAInd(4, False, False), Portrait.mkIAInd(5, False, False), Portrait.mkIAInd(6, False, True), Portrait.mkIAInd(7, False, True)},
                                                              {Portrait.mkIAInd(37, True, True), Portrait.mkIAInd(2, True, False), Portrait.mkIAInd(4, True, False), Portrait.mkIAInd(22, True, True), Portrait.mkIAInd(6, True, True)}))
        'hat
        mfEquivalentIndexes.Add(pInd.hat, New MFRouting({},
                                                        {}))

        Return mfEquivalentIndexes
    End Function
End Class
