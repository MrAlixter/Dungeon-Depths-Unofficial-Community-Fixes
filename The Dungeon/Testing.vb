Imports System.IO
Public Class Testing
    '|DRIVERS|
    Shared Sub runTests()
        Dim out As StreamWriter
        out = IO.File.CreateText("TestLog.txt")
        out.WriteLine("TEST LOG FOR D_D v" & Application.ProductVersion.ToString & " - RAN ON " & Date.Today.Date.ToString.Split()(0))

        runUnitTests(out)

        out.Flush()
        out.Dispose()
    End Sub
    Shared Sub runUnitTests(ByRef out As StreamWriter)
        Dim testQueue As List(Of Func(Of Tuple(Of Boolean, String))) = New List(Of Func(Of Tuple(Of Boolean, String)))
        testQueue.Add(AddressOf inventoryItemTestsByID)
        testQueue.Add(AddressOf inventoryItemTestsByName)
        testQueue.Add(AddressOf inventoryMergeTests)
        testQueue.Add(AddressOf inventoryAddTests)
        testQueue.Add(AddressOf inventorySaveTests)
        testQueue.Add(AddressOf inventoryLoadTests)
        testQueue.Add(AddressOf imagecollectionAtrsInitializationTests)
        testQueue.Add(AddressOf imageattributeIndexingTests)

        Dim successes = 0
        Dim failures = 0
        out.WriteLine(vbCrLf & "-||UNIT TESTS:")
        For i = 0 To testQueue.Count - 1
            Dim result As Tuple(Of Boolean, String) = testQueue(i).Invoke
            If Not result.Item1 Then
                out.WriteLine(vbCrLf & "Test Failed!:")
                out.WriteLine(result.Item2 & vbCrLf)
                failures += 1
            Else
                out.WriteLine(result.Item2)
                successes += 1
            End If
        Next
        out.WriteLine(vbCrLf & successes & "/" & (successes + failures) & " tests passed." & vbCrLf)

    End Sub
    '|UTILITY METHODS|
    Shared Function expectEQ(m_call As String, arg1 As Object, arg2 As Object)
        'check that arg1 is not nothing if arg2 is not.
        If arg1 Is Nothing And Not arg2 Is Nothing Then
            Return New Tuple(Of Boolean, String)(False, m_call & " returns """ & arg2.ToString & """, not Nothing.")
        End If
        'check that arg1 is not nothing if arg2 is not.
        If arg2 Is Nothing And Not arg1 Is Nothing Then
            Return New Tuple(Of Boolean, String)(False, m_call & " returns Nothing, not """ & arg1.ToString & """.")
        End If
        'check that arg1 equals arg2.
        If arg1 Is Nothing And arg2 Is Nothing Then
            Return New Tuple(Of Boolean, String)(True, m_call & " returns Nothing, which is correct.")
        End If
        If Not arg1.Equals(arg2) Then
            Return New Tuple(Of Boolean, String)(False, m_call & " returns """ & arg2.ToString & """, not """ & arg1.ToString & """.")
        End If
        Return New Tuple(Of Boolean, String)(True, m_call & " returns """ & arg2.ToString & """, which is correct.")
    End Function
    Shared Function makeNewPlayer()
        Dim p = New Player
        Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0}
        p.name = "TEST"

        For i = 0 To 16
            p.iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(sInts(i), True, False)
        Next

        Return p
    End Function
    '|IMAGECOLLECTION UNIT TESTS|
    Shared Function imagecollectionAtrsInitializationTests() As Tuple(Of Boolean, String)
        Dim defimgcol = New ImageCollection(0)
        Dim allimgcol = New ImageCollection(1)

        Dim test1 As Tuple(Of Boolean, String) = expectEQ("defimgcol.atrs.count", 19, defimgcol.atrs.Count)
        If Not test1.Item1 Then Return test1

        Dim test2 As Tuple(Of Boolean, String) = expectEQ("allimgcol.atrs.count", 19, allimgcol.atrs.Count)
        If Not test2.Item1 Then Return test2

        For i = 0 To 16
            Dim diCT, aiCT As Integer
            diCT = defimgcol.atrs(defimgcol.atrs.Keys(i)).Count
            aiCT = allimgcol.atrs(allimgcol.atrs.Keys(i)).Count

            Dim test3 As Tuple(Of Boolean, String) = expectEQ("for i = " & i & ", diCT <= aiCT", True, diCT <= aiCT)
            If Not test3.Item1 Then Return test3
        Next

        Return New Tuple(Of Boolean, String)(True, "ImageCollection.new() tests successful.")
    End Function
    '|IMAGEATTRIBUTE UNIT TESTS|
    Shared Function imageattributeIndexingTests() As Tuple(Of Boolean, String)
        Dim allimgcol = New ImageCollection(1)

        For i = 1 To 16
            Dim fInd = allimgcol.atrs(allimgcol.atrs.Keys(i)).rosf(allimgcol.atrs(allimgcol.atrs.Keys(i)).osf(10))
            Dim test1 As Tuple(Of Boolean, String) = expectEQ("for attr. i = " & i & ", rosf(osf(10))", 10, fInd)
            If Not test1.Item1 Then Return test1

            Dim mInd = allimgcol.atrs(allimgcol.atrs.Keys(i)).rosm(allimgcol.atrs(allimgcol.atrs.Keys(i)).osm(10))
            Dim testm As Tuple(Of Boolean, String) = expectEQ("for attr. i = " & i & ", rosm(osm(10))", 10, mInd)
            If Not test1.Item1 Then Return test1
        Next

        Return New Tuple(Of Boolean, String)(True, "ImageAttribute offset indexing tests successful.")
    End Function
    '|INVENTORY UNIT TESTS|
    Shared Function inventoryItemTestsByName() As Tuple(Of Boolean, String)
        Dim testInventory = New Inventory

        Dim output1 = testInventory.item("Liopleurodon")
        Dim output2 = testInventory.item("Dromiceiomimus")

        '
        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(""Liopleurodon"")", Nothing, output1)
        If Not test1.Item1 Then Return test1
        Dim test2 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(""Dromiceiomimus"")", Nothing, output2)
        If Not test2.Item1 Then Return test2

        For i = 0 To testInventory.upperBound()
            Dim keyi = testInventory.getKeyByID(i)
            Dim outputi = testInventory.item(keyi).getName()
            If Not outputi.Equals("Mystery_Potion") Then
                Dim testi As Tuple(Of Boolean, String) = expectEQ("Inventory.item(""" & i & """)", keyi, outputi)
                If Not testi.Item1 Then Return testi
            End If
        Next

        Return New Tuple(Of Boolean, String)(True, "Inventory.item (by name) tests successful.")
    End Function
    Shared Function inventoryItemTestsByID() As Tuple(Of Boolean, String)
        Dim testInventory = New Inventory

        Dim output1 = testInventory.item(3823695)
        Dim output2 = testInventory.item(-3)

        '
        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(3823695)", Nothing, output1)
        If Not test1.Item1 Then Return test1
        Dim test2 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(-3)", Nothing, output2)
        If Not test2.Item1 Then Return test2

        For i = 0 To testInventory.upperBound()
            Dim outputi = testInventory.item(i).getName()
            If Not outputi.Equals("Mystery_Potion") Then
                Dim keyi = testInventory.getKeyByID(i)
                Dim testi As Tuple(Of Boolean, String) = expectEQ("Inventory.item(" & i & ")", keyi, outputi)
                If Not testi.Item1 Then Return testi
            End If
        Next

        Return New Tuple(Of Boolean, String)(True, "Inventory.item (by id) tests successful.")
    End Function
    Shared Function inventoryMergeTests() As Tuple(Of Boolean, String)
        Dim testInventory1 = New Inventory
        Dim testInventory2 = New Inventory

        testInventory1.item(0).add(2)
        testInventory1.item(4).add(2)
        testInventory1.item(34).add(1)
        testInventory1.item(56).add(1)

        testInventory2.item(0).add(1)
        testInventory2.item(1).add(2)
        testInventory2.item(34).add(3)
        testInventory2.item(40).add(5)

        testInventory1.merge(testInventory2)

        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(0)", 3, testInventory1.item(0).count)
        If Not test1.Item1 Then Return test1
        Dim test2 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(1)", 2, testInventory1.item(1).count)
        If Not test2.Item1 Then Return test2
        Dim test3 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(4)", 2, testInventory1.item(4).count)
        If Not test3.Item1 Then Return test3
        Dim test4 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(34)", 4, testInventory1.item(34).count)
        If Not test4.Item1 Then Return test4
        Dim test5 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(40)", 5, testInventory1.item(40).count)
        If Not test5.Item1 Then Return test5
        Dim test6 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(56)", 1, testInventory1.item(56).count)
        If Not test6.Item1 Then Return test6

        Return New Tuple(Of Boolean, String)(True, "Inventory.merge tests successful.")
    End Function
    Shared Function inventoryAddTests() As Tuple(Of Boolean, String)
        Dim testInventory1 = New Inventory

        testInventory1.add("Compass", 2)
        testInventory1.add(0, 2)
        testInventory1.add("Spellbook", 3)
        testInventory1.add(45, 1)
        testInventory1.add(56, 6)

        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(0)", 4, testInventory1.item(0).count)
        If Not test1.Item1 Then Return test1
        Dim test2 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(4)", 3, testInventory1.item(4).count)
        If Not test2.Item1 Then Return test2
        Dim test3 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(""Duster"")", 1, testInventory1.item("Duster").count)
        If Not test3.Item1 Then Return test3
        Dim test4 As Tuple(Of Boolean, String) = expectEQ("Inventory.item(""Living_Lingerie"")", 6, testInventory1.item("Living_Lingerie").count)
        If Not test4.Item1 Then Return test4

        Return New Tuple(Of Boolean, String)(True, "Inventory.add tests successful.")
    End Function
    Shared Function inventorySaveTests() As Tuple(Of Boolean, String)
        Dim testInventory1 = New Inventory

        testInventory1.add("Compass", 2)
        testInventory1.add("Spellbook", 3)
        testInventory1.add("Duster", 1)
        testInventory1.add("Living_Lingerie", 6)

        Dim output1 = testInventory1.save

        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.save", output1, testInventory1.save)
        If Not test1.Item1 Then Return test1

        Return New Tuple(Of Boolean, String)(True, "Inventory.save tests successful.")
    End Function
    Shared Function inventoryLoadTests() As Tuple(Of Boolean, String)
        Dim testInventory1 = New Inventory

        Dim input1 = "5:Compass~2:Spellbook~3:Witch_Cosplay~1:Key~4:Bad_Item_No_Good~2:*"
        Try
            testInventory1.load(input1)
        Catch ex As Exception
            Return New Tuple(Of Boolean, String)(False, ex.ToString & " thrown during Inventory.load")
        End Try

        Dim test1 As Tuple(Of Boolean, String) = expectEQ("Inventory.getCountAt(""Compass"")", 2, testInventory1.getCountAt("Compass"))
        If Not test1.Item1 Then Return test1

        Dim test2 As Tuple(Of Boolean, String) = expectEQ("Inventory.getCountAt(""Spellbook"")", 3, testInventory1.getCountAt("Spellbook"))
        If Not test2.Item1 Then Return test2

        Dim test3 As Tuple(Of Boolean, String) = expectEQ("Inventory.getCountAt(""Witch_Cosplay"")", 1, testInventory1.getCountAt("Witch_Cosplay"))
        If Not test3.Item1 Then Return test3

        Dim test4 As Tuple(Of Boolean, String) = expectEQ("Inventory.getCountAt(""Key"")", 4, testInventory1.getCountAt("Key"))
        If Not test4.Item1 Then Return test4

        For i = 0 To testInventory1.upperBound()
            Dim keyi = testInventory1.getKeyByID(i)
            Dim outputi = testInventory1.getCountAt(i)
            If Not keyi.Equals("Compass") And Not keyi.Equals("Spellbook") And Not keyi.Equals("Witch_Cosplay") And Not keyi.Equals("Key") Then
                Dim testi As Tuple(Of Boolean, String) = expectEQ("Inventory.getCountAt(""" & i & """)", 0, outputi)
                If Not testi.Item1 Then Return testi
            End If
        Next

        Return New Tuple(Of Boolean, String)(True, "Inventory.load tests successful.")
    End Function
    '|PLAYER UNIT TESTS|
    '|EQUIPMENT TESTS|
End Class
