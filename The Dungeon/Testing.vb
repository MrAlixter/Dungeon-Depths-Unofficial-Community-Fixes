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
        testQueue.Add(AddressOf playerMoveTests)

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

        Dim output1 = "75:Compass~2:Stick_of_Gum~0:Health_Potion~0:Vial_of_Slime~0:Spellbook~3:Steel_Armor~0:Steel_Sword~0:Steel_Bikini~0:Chicken_Suit~0:SoulBlade~0:Magic_Girl_Outfit~0:Magic_Girl_Wand~0:Cat_Lingerie~0:Mana_Potion~0:Restore_Potion~0:Cat_Ears~0:Bunny_Suit~0:Sorcerer's_Robes~0:Witch_Cosplay~0:Warrior's_Cuirass~0:Brawler_Cosplay~0:Oak_Staff~0:Wizard_Staff~0:Bronze_Xiphos~0:Sword_of_the_Brutal~0:Golden_Potion~0:Red_Potion~0:Green_Potion~0:Mauve_Potion~0:Rose_Potion~0:Chicken_Leg~0:Apple~0:Apple​~0:Medicinal_Tea~0:Heavy_Cream~0:Cupcake~0:Mirror~0:Glowstick~0:Gold_Armor~0:Gold_Adornment~0:Gold_Sword~0:Golden_Staff~0:Midas_Gauntlet~0:Gold~0:Angel_Food_Cake~0:Duster~1:Tanktop~0:Sports_Bra~0:Health_Charm~0:Mana_Charm~0:Attack_Charm~0:Defence_Charm~0:Speed_Charm~0:Key~0:Ropes~0:Living_Armor~0:Living_Lingerie~6:Disarment_Kit~0:Fusion_Crystal~0:Blue_Potion~0:Murky_Potion~0:Azure_Potion~0:Glittery_Potion~0:Spidersilk_Whip~0:Chitin_Armor~0:Advanced_Spellbook~0:Heart_Necklace~0:Red_Headband~0:Ruby_Circlet~0:Slave_Collar~0:Cowbell~0:Cow_Print_Bra~0:Maid_Outfit~0:Goddess_Gown~0:Succubus_Garb~0:Regal_Gown~0:*"

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
    Shared Function playerMoveTests()
        'Dim p = New Player()
        'p.pos = New Point(3, 3)
        'p.moveUp()
        'p.moveUp()
        'p.moveLeft()
        'Dim test1 As Tuple(Of Boolean, String) = expectEQ("Player.moveUp(); Player.moveUp(); Player.moveLeft()", New Point(2, 1), p.pos)
        'If Not test1.Item1 Then Return test1

        'p.pos = New Point(3, 3)
        'p.moveDown()
        'p.moveLeft()
        'p.moveRight()
        'Dim test2 As Tuple(Of Boolean, String) = expectEQ("Player.moveDown(); Player.moveLeft(); Player.moveRight()", New Point(3, 4), p.pos)
        'If Not test2.Item1 Then Return test2

        'p.pos = New Point(3, 3)
        'p.moveDown()
        'p.moveRight()
        'p.moveRight()
        'Dim test3 As Tuple(Of Boolean, String) = expectEQ("Player.moveUp(); Player.moveUp(); Player.moveLeft()", New Point(5, 4), p.pos)
        'If Not test3.Item1 Then Return test3


        Return New Tuple(Of Boolean, String)(True, "Player.Move tests successful.")
    End Function
End Class
