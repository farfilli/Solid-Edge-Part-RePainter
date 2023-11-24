Imports SolidEdgeFramework
Imports System.Reflection

Public Class PartRepainter

    Dim objApp As SolidEdgeFramework.Application
    Dim objPart As Object

    Dim UsedStyles As New Collection

    Private Sub PartRepainter_Load(sender As Object, e As EventArgs) Handles Me.Load

        StylesGrid.AutoGenerateColumns = False

        Connect()

        For Each tmpStile As SolidEdgeFramework.FaceStyle In objPart.FaceStyles

            MenuStyles.Items.Add(tmpStile.StyleName, ColorIcon(tmpStile.Opacity, tmpStile.DiffuseRed, tmpStile.DiffuseGreen, tmpStile.DiffuseBlue).ToBitmap)

        Next

    End Sub

    Private Sub PartRepainter_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Ricarica()

    End Sub

    Private Sub Connect()

        Try
            objApp = GetObject(, "SolidEdge.Application")
        Catch ex As Exception
            MsgBox("Solid Edge must be running")
            End
        End Try

        If objApp.Documents.Count = 0 Then
            MsgBox("A part or sheetmetal document must be open")
            End
        End If

        Select Case objApp.ActiveDocumentType
            Case Is = SolidEdgeFramework.DocumentTypeConstants.igPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncSheetMetalDocument

            Case Else
                MsgBox("A part or sheetmetal document must be open")
                End

        End Select

        objPart = objApp.ActiveDocument

    End Sub

    Private Sub DeConnect()

        objPart = Nothing
        objApp = Nothing

    End Sub

    Private Sub Ricarica()

        StylesGrid.DataSource = Nothing
        UsedStyles.Clear()
        'StylesGrid.Refresh()

        Cursor = Cursors.WaitCursor
        Status.Text = "Retrieving used styles"
        Connect()

        Dim Models As SolidEdgePart.Models = objPart.Models

        If Models.Count = 0 Then
            MsgBox("No design bodies found")
            End
        Else

            Dim totModel As Integer = 0

            For Each tmpModel As SolidEdgePart.Model In Models

                totModel += 1
                Status.Text = "Retrieving used styles on model " & totModel.ToString

                Try

                    Dim tmpBody As SolidEdgeGeometry.Body = tmpModel.Body

                    If Not IsNothing(tmpBody.Style) Then
                        If Not UsedStyles.Contains(tmpBody.Style.StyleName) Then

                            Dim tmpStile As New Stile
                            tmpStile.Name = tmpBody.Style.StyleName
                            tmpStile.Original = tmpBody.Style.StyleName
                            tmpStile.Bodies.Add(tmpBody)
                            tmpStile.BodiesCount = 1
                            UsedStyles.Add(tmpStile, tmpBody.Style.StyleName)

                        Else

                            UsedStyles.Item(tmpBody.Style.StyleName).Bodies.Add(tmpBody)
                            UsedStyles.Item(tmpBody.Style.StyleName).BodiesCount += 1

                        End If

                    End If

                    Dim FaceType = SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll
                    Dim tmpFaces As SolidEdgeGeometry.Faces = tmpBody.Faces(FaceType)

                    Dim totFaceCount As Integer = 0
                    For Each tmpFace As SolidEdgeGeometry.Face In tmpFaces
                        totFaceCount += 1
                        Status.Text = "Retrieving used styles on model " & totModel & " Face " & totFaceCount.ToString & "/" & tmpFaces.Count.ToString

                        If tmpFace.Style IsNot Nothing Then

                            Dim tmpNome As String = tmpFace.Style.StyleName

                            If Not UsedStyles.Contains(tmpNome) Then

                                Dim tmpStile As New Stile
                                tmpStile.Name = tmpNome
                                tmpStile.Original = tmpNome
                                tmpStile.Faces.Add(tmpFace)
                                tmpStile.FacesCount = 1
                                UsedStyles.Add(tmpStile, tmpNome)

                            Else

                                UsedStyles.Item(tmpNome).Faces.Add(tmpFace)
                                UsedStyles.Item(tmpNome).FacesCount += 1

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

            Next

            Dim totFeatures As Integer = 0
            For Each tmpFeature In objPart.DesignEdgebarFeatures

                totFeatures += 1
                Status.Text = "Retrieving used styles on feature " & totFeatures.ToString & "/" & objPart.DesignEdgebarFeatures.Count.ToString

                Try
                    Dim tmpStyle As SolidEdgeFramework.FaceStyle = tmpFeature.GetStyle
                    If Not IsNothing(tmpStyle) Then
                        If Not UsedStyles.Contains(tmpStyle.StyleName) Then

                            Dim tmpStile As New Stile
                            tmpStile.Name = tmpStyle.StyleName
                            tmpStile.Original = tmpStyle.StyleName
                            tmpStile.Features.Add(tmpFeature)
                            tmpStile.FeaturesCount = 1
                            UsedStyles.Add(tmpStile, tmpStyle.StyleName)

                        Else

                            UsedStyles.Item(tmpStyle.StyleName).Features.Add(tmpFeature)
                            UsedStyles.Item(tmpStyle.StyleName).FeaturesCount += 1

                        End If
                    End If

                Catch ex As Exception

                End Try

            Next

            StylesGrid.DataSource = UsedStyles

            Try
                StylesGrid.Refresh()
            Catch ex As Exception
            End Try


        End If

        DeConnect()
        Cursor = Cursors.Default
        Status.Text = "Ready"

    End Sub

    Private Sub StylesGrid_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StylesGrid.CellMouseClick

        If e.Button = MouseButtons.Right Then

            StylesGrid.CurrentCell = StylesGrid(e.ColumnIndex, e.RowIndex)
            MenuStyles.Show(StylesGrid, New Point(e.X, e.Y))

        End If

    End Sub

    Private Sub MenuStyles_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStyles.ItemClicked

        Cursor = Cursors.WaitCursor
        Connect()

        MenuStyles.Hide()

        Dim OldStyleIndex As Integer = StylesGrid.CurrentCell.RowIndex + 1
        Dim NewStyle As String = e.ClickedItem.Text

        Dim tmpStile As Stile = UsedStyles.Item(OldStyleIndex)
        Dim counter As Integer = 1

        For Each tmpBody As SolidEdgeGeometry.Body In tmpStile.Bodies
            Status.Text = "Change style in body " & counter.ToString & "/" & tmpStile.Bodies.Count.ToString
            tmpBody.Style = objPart.FaceStyles.Item(NewStyle)
            counter += 1
        Next

        counter = 1

        For Each tmpFeature As Object In tmpStile.Features
            Status.Text = "Change style in feature " & counter.ToString & "/" & tmpStile.Features.Count.ToString
            tmpFeature.SetStyle(objPart.FaceStyles.Item(NewStyle))
            counter += 1
        Next

        counter = 1

        For Each tmpFace As SolidEdgeGeometry.Face In tmpStile.Faces
            Status.Text = "Change style in face " & counter.ToString & "/" & tmpStile.Faces.Count.ToString
            tmpFace.Style = objPart.FaceStyles.Item(NewStyle)
            counter += 1
        Next

        UsedStyles.Item(OldStyleIndex).Name = NewStyle
        StylesGrid.Refresh()

        Status.Text = "Ready"
        Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

        Ricarica()

    End Sub

    Private Function ColorIcon(A As Double, R As Double, G As Double, B As Double) As Icon

        Dim oIcon As Icon = Nothing
        Dim area As Integer = 16
        Try

            Dim bm As New Bitmap(area, area)
            Dim gph As Graphics = Graphics.FromImage(CType(bm, Image))
            gph.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias

            Dim rec As New Rectangle(0, 0, area - 1, area - 1)

            Dim brushy As Brush
            brushy = New Drawing.SolidBrush(Color.FromArgb(A * 255, R * 255, G * 255, B * 255))

            Dim penny As Pen
            penny = New Drawing.Pen(New Drawing.SolidBrush(Color.FromArgb(255, R * 128, G * 128, B * 128)), 1)

            gph.FillEllipse(brushy, rec)
            'gph.DrawEllipse(Pens.Black, rec)
            gph.DrawEllipse(penny, rec)

            oIcon = Drawing.Icon.FromHandle(bm.GetHicon)

            gph.Dispose()
            bm.Dispose()

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

        Return oIcon

    End Function

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

        Cursor = Cursors.WaitCursor
        Connect()

        For Each tmpStile As Stile In UsedStyles

            If tmpStile.Name <> tmpStile.Original Then

                Dim counter As Integer = 1

                For Each tmpBody As SolidEdgeGeometry.Body In tmpStile.Bodies
                    Status.Text = "Change style in body " & counter.ToString & "/" & tmpStile.Bodies.Count.ToString
                    tmpBody.Style = objPart.FaceStyles.Item(tmpStile.Original)
                    counter += 1
                Next

                counter = 1
                For Each tmpFeature As Object In tmpStile.Features
                    Status.Text = "Change style in feature " & counter.ToString & "/" & tmpStile.Features.Count.ToString
                    tmpFeature.SetStyle(objPart.FaceStyles.Item(tmpStile.Original))
                    counter += 1
                Next

                counter = 1

                For Each tmpFace As SolidEdgeGeometry.Face In tmpStile.Faces
                    Status.Text = "Change style in face " & counter.ToString & "/" & tmpStile.Faces.Count.ToString
                    tmpFace.Style = objPart.FaceStyles.Item(tmpStile.Original)
                    counter += 1
                Next

                tmpStile.Name = tmpStile.Original
                StylesGrid.Refresh()

            End If

        Next

        Status.Text = "Ready"
        Cursor = Cursors.Default

    End Sub

    Private Sub PartRepainter_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Connect()
        Dim objHighlightSet As SolidEdgeFramework.HighlightSet

        If objPart.HighlightSets.Count > 0 Then

            objHighlightSet = objPart.HighlightSets.Item(1)
            objHighlightSet.RemoveAll()

            objHighlightSet.Draw()

        End If
        DeConnect()

    End Sub

    Private Sub StylesGrid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StylesGrid.CellMouseEnter

        If e.ColumnIndex = -1 And e.RowIndex <> -1 Then

            Connect()

            Dim StyleIndex As Integer = e.RowIndex + 1
            Dim tmpStile As Stile = UsedStyles.Item(StyleIndex)

            Dim objHighlightSet As SolidEdgeFramework.HighlightSet

            If objPart.HighlightSets.Count > 0 Then

                objHighlightSet = objPart.HighlightSets.Item(1)
                objHighlightSet.RemoveAll()

            Else

                objHighlightSet = objPart.HighlightSets.Add()

            End If

            For Each item In tmpStile.Bodies
                objHighlightSet.AddItem(item)
            Next

            For Each item In tmpStile.Features
                objHighlightSet.AddItem(item)
            Next

            For Each item In tmpStile.Faces
                objHighlightSet.AddItem(item)
            Next

            objHighlightSet.Draw()

        Else

            Connect()
            Dim objHighlightSet As SolidEdgeFramework.HighlightSet

            If objPart.HighlightSets.Count > 0 Then

                objHighlightSet = objPart.HighlightSets.Item(1)
                objHighlightSet.RemoveAll()

                objHighlightSet.Draw()

            End If
            DeConnect()

        End If

    End Sub

    Private Sub PartRepainter_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

        Connect()
        Dim objHighlightSet As SolidEdgeFramework.HighlightSet

        If objPart.HighlightSets.Count > 0 Then

            objHighlightSet = objPart.HighlightSets.Item(1)
            objHighlightSet.RemoveAll()

            objHighlightSet.Draw()

        End If
        DeConnect()

    End Sub


End Class

Public Class Stile
    Public Property Name As String
    Public Property Original As String
    Public Property Bodies As New Collection
    Public Property BodiesCount As Integer = 0
    Public Property Features As New Collection
    Public Property FeaturesCount As Integer = 0
    Public Property Faces As New Collection
    Public Property FacesCount As Integer = 0

End Class