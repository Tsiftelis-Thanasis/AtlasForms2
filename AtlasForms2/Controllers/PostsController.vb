﻿Imports System.IO
Imports System.Web.Mvc

Namespace Controllers
    Public Class PostsController
        Inherits Controller

        Private pdb As New atlasEntities
        Private pdb2 As New atlasStatisticsEntities

        ' GET: Posts
        Function Index(Optional a As Integer = 0,
                      Optional ByVal k As Integer = 0, Optional ByVal yk As Integer = 0) As ActionResult

            ViewBag.AtlasOmilos = a
            ViewBag.Kathgoria = k
            ViewBag.Ypokathgoria = yk

            Return View()

        End Function



        ' GET: Posts
        <Authorize(Roles:="Admins")>
        Function All() As ActionResult

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
        <Authorize(Roles:="Admins")>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Posts/Create
        <HttpPost()>
        <Authorize(Roles:="Admins")>
        Function Create(ByVal p1 As Posts, ByVal kathgoria As String(), ByVal ypokathgoria As String(),
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


                    Dim newpost As New BlogPostsTable

                    newpost.PostTitle = p1.PostTitle
                    newpost.PostBody = p1.PostBody
                    If Not logodata Is Nothing Then
                        newpost.PostPhoto = logodata
                    End If
                    newpost.Youtubelink = p1.Youtubelink
                    newpost.Statslink = p1.Statslink
                    newpost.Activepost = p1.Activepost
                    newpost.CreatedBy = User.Identity.Name
                    newpost.CreationDate = Now()
                    newpost.EditBy = User.Identity.Name
                    newpost.EditDate = Now()
                    pdb.SaveChanges()

                    Dim kat = If(kathgoria Is Nothing, Nothing, kathgoria(0))
                    Dim ypokat = If(ypokathgoria Is Nothing, Nothing, ypokathgoria(0))

                    If Not (kat Is Nothing And ypokat Is Nothing) Then

                        Dim newlink As New BlogPostKathgoriaTable
                        newlink.PostId = newpost.Id
                        If Not (kat Is Nothing) Then newlink.KathgoriaId = kat
                        If Not (ypokat Is Nothing) Then newlink.YpokathgoriaId = ypokat
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

        ' GET: Posts/Edit/5
        <Authorize(Roles:="Admins")>
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
        <Authorize(Roles:="Admins")>
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

        '' GET: Posts/Delete/5
        '<Authorize(Roles:="Admins")>
        'Function Delete(ByVal id As Integer) As ActionResult
        '    Return View()
        'End Function

        '' POST: Posts/Delete/5
        '<HttpPost()>
        '<Authorize(Roles:="Admins")>
        'Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        '    Try
        '        ' TODO: Add delete logic here

        '        Return RedirectToAction("Index")
        '    Catch
        '        Return View()
        '    End Try
        'End Function



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

            If yk > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                         Join p3 In pdb.BlogYpokathgoriesTable On p3.Id Equals p1.YpokathgoriaId
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p3.KathgoriaId
                         Where (p1.KathgoriaId Is Nothing And p1.YpokathgoriaId = yk)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                                 PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                                KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                     AsEnumerable().[Select](
                     Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
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

                'Thanasis - Erwtisi...
                'na fernei ta posts tou omilou? ta posts twn ypokathgoriwn tou omilou?
                'pws na to sxediasoume???


                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                         Join p3 In pdb.BlogYpokathgoriesTable On p3.KathgoriaId Equals p2.Id
                         Where (p1.KathgoriaId = k And p1.YpokathgoriaId Is Nothing)
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                            KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
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



        Function GetLastNewsByCategory2(ByVal nCount As Integer, ByVal KathgoriaId As Integer,
                                        Optional ByVal IsKathgoria As Integer = 0,
                                        Optional ByVal IsYpokathgoria As Integer = 0,
                                        Optional ByVal IsAtlasOmilos As Integer = 0,
                                        Optional ByVal IsAtlasKathgoria As Integer = 0) As JsonResult


            'Thanasis - Erwtisi...
            'na fernei ta posts tou omilou? ta posts twn ypokathgoriwn tou omilou?
            'pws na to sxediasoume???

            If IsYpokathgoria > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable2 On p1.PostId Equals p.Id
                         Join p3 In pdb.BlogYpokathgoriesTable On p3.Id Equals p1.AtlasKathgoriaId
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p3.KathgoriaId
                         Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsYpokathgoria = True
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                                 PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                                KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                     AsEnumerable().[Select](
                     Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
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

            ElseIf IsKathgoria > 0 Then

                Dim q = (From p In pdb.BlogPostsTable
                         Join p1 In pdb.BlogPostKathgoriaTable2 On p1.PostId Equals p.Id
                         Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.AtlasKathgoriaId
                         Join p3 In pdb.BlogYpokathgoriesTable On p3.KathgoriaId Equals p2.Id
                         Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsKathgoria = True
                         Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy,
                            KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
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

            ElseIf IsAtlasOmilos > 0 Then

                Dim ar1 = (From o In pdb2.OmilosTable
                           Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                           Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                           AsEnumerable().Select(Function(a) New With {
                           .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                           }).ToArray

                Dim ar2 = (From p In pdb.BlogPostsTable
                           Join p1 In pdb.BlogPostKathgoriaTable2 On p1.PostId Equals p.Id
                           Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsAtlasOmilos = True
                           Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                        }).ToArray

                Dim q = (From a2 In ar2
                         Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                         Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname, .Ypokatname = o.KathgoriaName
                        }).ToList

                Dim dtm As New DataTableModel
                If q IsNot Nothing Then
                    dtm.data = q.Cast(Of Object).ToList
                End If
                dtm.draw = 0
                dtm.recordsTotal = dtm.data.Count
                dtm.recordsFiltered = dtm.recordsTotal

                Return Json(dtm, JsonRequestBehavior.AllowGet)

            Else

                Dim ar1 = (From o In pdb2.OmilosTable
                           Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                           Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                           AsEnumerable().Select(Function(a) New With {
                           .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                           }).ToArray

                Dim ar2 = (From p In pdb.BlogPostsTable
                           Join p1 In pdb.BlogPostKathgoriaTable2 On p1.PostId Equals p.Id
                           Where p1.AtlasKathgoriaId = KathgoriaId And p1.IsAtlasKathgoria = True
                           Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                             PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                        }).ToArray

                Dim q = (From a2 In ar2
                         Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                         Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname, .Ypokatname = o.KathgoriaName
                        }).ToList

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


        Function GetLastNewsByBothCategories(ByVal nCount As Integer, ByVal AtlasOmilosid As Integer,
                                             ByVal KathgoriaId As Integer,
                                        Optional ByVal IsKathgoria As Integer = 0,
                                        Optional ByVal IsYpokathgoria As Integer = 0,
                                        Optional ByVal IsAtlasOmilos As Integer = 0,
                                        Optional ByVal IsAtlasKathgoria As Integer = 0) As JsonResult


            Dim ar1 = (From o In pdb2.OmilosTable
                       Join k In pdb2.KathgoriesTable On k.Omilosid Equals o.Id
                       Select Omilos = o.Id, o.OmilosName, Kathgoria = k.Id, k.KathgoriaName).
                    AsEnumerable().Select(Function(a) New With {
                    .Omilos = a.Omilos, .Omilosname = a.OmilosName, .Kathgoria = a.Kathgoria, .KathgoriaName = a.KathgoriaName
                    }).ToArray

            Dim ar2 = (From p In pdb.BlogPostsTable
                       Join p1 In pdb.BlogPostKathgoriaTable2 On p1.PostId Equals p.Id
                       Where
                           If(KathgoriaId > 0, p1.KathgoriaId = KathgoriaId, 1 = 1) And
                           If(AtlasOmilosid > 0, p1.AtlasKathgoriaId = AtlasOmilosid, 1 = 1)
                       Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, PostBody = p.PostBody,
                        PostPhoto = p.PostPhoto, Youtubelink = p.Youtubelink, editBy = p.EditBy, kathgoria = p1.AtlasKathgoriaId).
                AsEnumerable().[Select](
                Function(o) New With {.Id = o.Id, .Kathgoria = o.kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                .PostPhoto = If(o.PostPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PostPhoto))), .Youtubelink = o.Youtubelink
                }).ToArray

            Dim q = (From a2 In ar2
                     Join a1 In ar1 On a2.Kathgoria Equals a1.Kathgoria
                     Select a1.Omilos, a1.Omilosname, a1.Kathgoria, a1.KathgoriaName, a2.Id, a2.PostTitle, a2.PostSummary, a2.PostBody,
                         a2.PostPhoto, a2.Youtubelink, a2.editBy).
                        AsEnumerable().[Select](
                        Function(o) New With {.Id = o.Id, .Kathgoria = o.Kathgoria, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .PostBody = o.PostBody, .editBy = o.editBy,
                        .PostPhoto = o.PostPhoto, .Youtubelink = o.Youtubelink, .KatName = o.Omilosname, .Ypokatname = o.KathgoriaName
                        }).ToList


            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)

        End Function


        Function GetAllNewsWithCategory() As JsonResult


            Dim q = (From p In pdb.BlogPostsTable
                     Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                     Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                     Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary,
                     editBy = p.EditBy, editDate = p.EditDate, KatName = p2.KathgoriaName, Ypokatname = "").
                     Union(
                        From p In pdb.BlogPostsTable
                        Join p1 In pdb.BlogPostKathgoriaTable On p1.PostId Equals p.Id
                        Join p3 In pdb.BlogYpokathgoriesTable On p3.Id Equals p1.YpokathgoriaId
                        Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p3.KathgoriaId
                        Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary,
                        editBy = p.EditBy, editDate = p.EditDate,
                        KatName = p2.KathgoriaName, Ypokatname = p3.YpokathgoriaName).
                    AsEnumerable().[Select](
                    Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary,
                    .editBy = o.editBy, .editDate = CDate(o.editDate).ToString("dd/MM/yyyy"), .KatName = o.KatName, .Ypokatname = o.Ypokatname}).ToList

            Dim dtm As New DataTableModel
            If q IsNot Nothing Then
                dtm.data = q.Cast(Of Object).ToList
            End If
            dtm.draw = 0
            dtm.recordsTotal = dtm.data.Count
            dtm.recordsFiltered = dtm.recordsTotal

            Return Json(dtm, JsonRequestBehavior.AllowGet)


        End Function

    End Class
End Namespace