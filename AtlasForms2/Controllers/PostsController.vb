Imports System.IO
Imports System.Web.Mvc

Namespace Controllers
    Public Class PostsController
        Inherits Controller

        Private pdb As New atlasEntities

        ' GET: Posts
        Function Index(Optional ByVal k As Integer = 0, Optional ByVal yk As Integer = 0) As ActionResult


            ViewBag.Kathgoria = k
            ViewBag.Ypokathgoria = yk

            Return View()

        End Function

        ' GET: Posts/Details/5
        Function Details(ByVal id As Integer, Optional ByVal k As Integer = 0, Optional ByVal yk As Integer = 0) As ActionResult

            Dim q = (From t In pdb.BlogPostsTable
                     Where t.Id = id
                     Select t).First

            Dim t1 As New Posts
            t1.Id = q.Id
            t1.Activepost = q.Activepost
            t1.PostTitle = q.PostTitle
            t1.PostBody = q.PostBody
            t1.PostPhoto = q.PostPhoto
            t1.PostSummary = q.PostSummary
            t1.Youtubelink = "https://www.youtube.com/embed/" & q.Youtubelink & "?rel=0"
            t1.Statslink = q.Statslink
            t1.createdby = q.CreatedBy
            t1.creationdate = q.CreationDate
            t1.editby = q.EditBy
            t1.editdate = q.EditDate

            Return View(t1)

        End Function

        ' GET: Posts/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Posts/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Posts/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult

            Dim q = (From t In pdb.BlogPostsTable
                     Where t.Id = id
                     Select t).First

            Dim t1 As New Posts
            t1.Id = q.Id
            t1.Activepost = q.Activepost
            t1.PostTitle = q.PostTitle
            t1.PostSummary = q.PostSummary
            t1.PostBody = q.PostBody
            t1.PostPhoto = q.PostPhoto
            t1.Youtubelink = q.Youtubelink
            t1.Statslink = q.Statslink
            t1.createdby = q.CreatedBy
            t1.creationdate = q.CreationDate
            t1.editby = q.EditBy
            t1.editdate = q.EditDate

            Return View(t1)


        End Function

        ' POST: /Posts/Edit
        '<Authorize(Roles:="Admins")>

        <HttpPost()>
        Function Edit(ByVal p1 As Posts, ByVal kathgoria As String(), ByVal ypokathgoria As String(),
            ByVal uploadEditorImage As HttpPostedFileBase) As ActionResult

            Dim logodata As Byte() = Nothing

            If uploadEditorImage IsNot Nothing Then
                If uploadEditorImage.ContentLength > 0 Then

                    Dim target As New MemoryStream()
                    uploadEditorImage.InputStream.CopyTo(target)
                    logodata = target.ToArray()

                End If
            End If

            If ModelState.IsValid Then

                Try

                    Dim editpost = pdb.BlogPostsTable.Find(p1.Id)

                    editpost.PostTitle = p1.PostTitle
                    editpost.PostBody = p1.PostBody
                    If Not logodata Is Nothing Then
                        editpost.PostPhoto = logodata
                    End If
                    editpost.Youtubelink = p1.Youtubelink
                    editpost.Statslink = p1.Statslink
                    editpost.Activepost = p1.Activepost
                    editpost.EditBy = User.Identity.Name
                    editpost.EditDate = Now()
                    pdb.SaveChanges()


                    Dim deletejoins = From tp In pdb.BlogPostKathgoriaTable
                                      Where tp.PostId = p1.Id
                                      Select tp

                    For Each k In deletejoins.ToList()
                        pdb.BlogPostKathgoriaTable.Remove(k)
                        pdb.SaveChanges()
                    Next


                    Dim kat = If(kathgoria Is Nothing, Nothing, kathgoria(0))
                    Dim ypokat = If(ypokathgoria Is Nothing, Nothing, ypokathgoria(0))

                    If Not (kat Is Nothing And ypokat Is Nothing) Then

                        Dim newlink As New BlogPostKathgoriaTable
                        newlink.PostId = p1.Id
                        If Not (kat Is Nothing) Then newlink.KathgoriaId = kat
                        If Not (ypokat Is Nothing) Then newlink.YpokathgoriaId = ypokat
                        newlink.CreatedBy = User.Identity.Name
                        newlink.CreationDate = Now()
                        newlink.EditBy = User.Identity.Name
                        newlink.EditDate = Now()
                        pdb.BlogPostKathgoriaTable.Add(newlink)
                        pdb.SaveChanges()


                    End If

                    Return RedirectToAction("Index", "Posts")

                Catch ex As Exception
                    ModelState.AddModelError("error_msg", ex.Message)
                    Return View(p1)
                End Try


            Else
                ModelState.AddModelError("error_msg", "error with model")
                Return View(p1)

            End If

        End Function

        ' GET: Posts/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Posts/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function



        Function GetNews() As JsonResult

            Dim q = (From p In pdb.BlogPostsTable
                     Select p).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editby = o.EditBy,
                    .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)
        End Function


        Function GetLastNews(ByVal nCount As Integer) As JsonResult

            Dim q = (From p In pdb.BlogPostsTable
                     Select p
                     Order By p.Id Descending
                         ).Take(nCount).AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                    .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto)))}).ToList()

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)
        End Function


        Function GetLastNewsByCategory(ByVal nCount As Integer, Optional ByVal k As Integer = 0, Optional ByVal yk As Integer = 0) As JsonResult

            'Dim newAnonType = New With {Key .Id = 0, .PostTitle = "", .PostSummary = "", .PostBody = "",
            '                        .PostPhoto = "", .Youtubelink = "", .KatName = "", .Ypokatname = ""}


            If yk > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                         Join p3 In pdb.BlogYpokathgoriesTable On p3.Id Equals p1.YpokathgoriaId
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p3.KathgoriaId
                         Where (p1.KathgoriaId Is Nothing And p1.YpokathgoriaId = yk)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                                 PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink,
                                KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                     AsEnumerable().[Select](
                     Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                     .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink,
                     .KatName = o.KatName, .Ypokatname = o.Ypokatname}).ToList

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Where (p1.KathgoriaId = k And p1.YpokathgoriaId Is Nothing)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink,
                            KatName = p2.KathgoriaName, Ypokatname = "").
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink,
                        .KatName = o.KatName, .Ypokatname = o.Ypokatname}).ToList
                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            End If




        End Function

    End Class
End Namespace