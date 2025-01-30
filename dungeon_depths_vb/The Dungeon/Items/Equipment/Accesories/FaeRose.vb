Public Class FaeRose
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae-Touched_Rose"

    Private Shared img_ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 342
        tier = Nothing

        '|Item Flags|
        usable = False
        only_drop_one = True
        rando_inv_allowed = False
        stores_inanimate_ent = True

        '|Stats|
        h_boost = 35
        m_boost = 25
        count = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)

        '|Description|
        setDesc("A tiny flower, radiating with magical energy..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If getInanimateEnt() Is Nothing Then
            Equipment.accChange(p, "Nothing")
            count = 0
            TextEvent.pushAndLog("The rose crumbles to dust...")
        End If
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A tiny " & Trim(Player.getColor(If(getInanimateEnt() Is Nothing, Color.White, getInanimateEnt().prt.haircolor))) & " flower, radiating with magical energy..." & DDUtils.RNRN &
               getStatInformation()
    End Function

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If getInanimateEnt() Is Nothing OrElse Game.player1.inv.getCountAt(ITEM_NAME) > 0 Then Return Nothing

        Return 2
    End Function

    Public Sub makeAccImg()
        Dim h_color = getInanimateEnt().prt.haircolor

        Dim layer1 = Portrait.hairRecolor(Portrait.imgLib.atrs(pInd.accessory).getAt(fInd), h_color)
        Dim layer2 = Portrait.imgLib.atrs(pInd.accessory).getAt(mInd)

        Dim img = Portrait.CreateFullBodyBMP({layer1, layer2})

        img_ind = New Tuple(Of Integer, Boolean, Boolean)(Portrait.imgLib.atrs(pInd.accessory).getF().Count, True, False)
        Portrait.imgLib.atrs(pInd.accessory).getF().Add(img)
    End Sub

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        If Not getInanimateEnt() Is Nothing AndAlso img_ind.Item1 = 0 Then makeAccImg()
        Return img_ind
    End Function
End Class
