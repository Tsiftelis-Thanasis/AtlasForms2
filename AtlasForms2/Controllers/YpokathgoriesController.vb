Imports System.IO
Imports System.Net.Http
Imports System.Net

Public Class YpokathgoriesController

    Inherits System.Web.Mvc.Controller

    Private pdb As New atlasEntities

    Function Index() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Public Function GetKathgories(ByVal id As Integer) As JsonResult

        Dim q = (From d In pdb.BlogKathgoriesTable
                 Select d.KathgoriaName, did = d.Id
                ).AsEnumerable().[Select](
                Function(o) New With {.text = o.KathgoriaName, .value = o.did})

        Return Json(q.ToArray(), JsonRequestBehavior.AllowGet)

    End Function


    Function GetYpokathgoriesList() As JsonResult

        Dim q = (From t In pdb.BlogYpokathgoriesTable
                 Join o In pdb.BlogKathgoriesTable On o.Id Equals t.KathgoriaId
                 Select t.Id, t.YpokathgoriaName, o.KathgoriaName
        ).AsEnumerable().[Select](
        Function(o) New With {.Ypokathgoriesid = o.Id, .YpokathgoriaName = o.YpokathgoriaName, .KathgoriaName = o.KathgoriaName}).ToList

        Dim dtm As New DataTableModel
        If q IsNot Nothing Then
            dtm.data = q.Cast(Of Object).ToList
        End If
        dtm.draw = 0
        dtm.recordsTotal = dtm.data.Count
        dtm.recordsFiltered = dtm.recordsTotal

        Return Json(dtm, JsonRequestBehavior.AllowGet)
    End Function

    '
    ' GET: /Profile/Create
    '<Authorize(Roles:="Admins")>
    Function Create() As ActionResult

        Dim t = New Ypokathgories
        t.ActiveYpoKathgoria = True
        Return View(t)

    End Function

    '
    ' POST: /Profile/Create
    '<Authorize(Roles:="Admins")>
    <HttpPost()>
    Function Create(ByVal ypo As Ypokathgories, ByVal KathgoriesList As String()) As ActionResult
        Try

            If ModelState.IsValid Then

                Try

                    Dim kathgoriaid = KathgoriesList(0)

                    Dim newypo As New BlogYpokathgoriesTable

                    newypo.KathgoriaId = kathgoriaid
                    newypo.YpokathgoriaName = ypo.Ypokathgorianame
                    newypo.ActiveKathgoria = If(ypo.ActiveYpoKathgoria, 1, 0)

                    newypo.CreatedBy = User.Identity.Name
                    newypo.CreationDate = Now()
                    newypo.EditBy = User.Identity.Name
                    newypo.EditDate = Now()
                    pdb.BlogYpokathgoriesTable.Add(newypo)
                    pdb.SaveChanges()


                Catch ex As Exception
                    ViewBag.Error = "an error"
                    ModelState.AddModelError("error_msg", "an error")
                    Return View(ypo)
                End Try

                Return RedirectToAction("Index", "Ypokathgories")

            Else
                Return View(ypo)

            End If

        Catch ex As Exception

            ViewBag.Error = ex.Message
            ModelState.AddModelError("error_msg", ex.Message)
            Return View(ypo)

        End Try

    End Function


    ' GET: /Profile/Edit/5
    '<Authorize(Roles:="Admins")>
    Function Edit(ByVal id As Integer) As ActionResult

        Dim q = (From t In pdb.BlogYpokathgoriesTable
                 Where t.Id = id
                 Select t).First

        Dim t1 As New Ypokathgories
        t1.Id = q.Id
        t1.kathgoriaid = q.KathgoriaId
        t1.Ypokathgorianame = q.YpokathgoriaName
        t1.ActiveYpoKathgoria = q.ActiveKathgoria
        t1.createdby = q.CreatedBy
        t1.creationdate = q.CreationDate
        t1.editby = q.EditBy
        t1.editdate = q.EditDate

        Return View(t1)

    End Function




    ' POST: /Profile/Edit
    '<Authorize(Roles:="Admins")>
    <HttpPost()>
    Function Edit(ByVal t1 As Ypokathgories, ByVal kathgorieslist As String()) As ActionResult

        If ModelState.IsValid Then

            Try

                Dim kat = kathgorieslist(0)

                Dim editYpokathgories = pdb.BlogYpokathgoriesTable.Find(t1.Id)
                editYpokathgories.KathgoriaId = kat
                editYpokathgories.YpokathgoriaName = t1.Ypokathgorianame
                editYpokathgories.ActiveKathgoria = t1.ActiveYpoKathgoria
                editYpokathgories.EditBy = User.Identity.Name
                editYpokathgories.EditDate = Now()
                pdb.SaveChanges()

                Return RedirectToAction("Index", "Ypokathgories")

            Catch ex As Exception
                ModelState.AddModelError("error_msg", ex.Message)
                Return View(t1)
            End Try


        Else
            ModelState.AddModelError("error_msg", "error with model")
            Return View(t1)

        End If

    End Function


    ' GET: /Profile/Details/5
    Function Details(ByVal id As Integer) As ActionResult

        Dim q = (From t In pdb.BlogYpokathgoriesTable
                 Where t.Id = id
                 Select t).First

        Dim t1 As New Ypokathgories
        t1.Id = q.Id
        t1.kathgoriaid = q.KathgoriaId
        t1.Ypokathgorianame = q.YpokathgoriaName
        t1.ActiveYpoKathgoria = q.ActiveKathgoria

        Return View(t1)

    End Function



    Private Function Fixdate(ByVal str As String) As String

        Dim mydate As Date
        Try
            If str = "1900-01-01 00:00:00" Then
                Return ""
                Exit Function
            End If
            mydate = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", Nothing)
            Return mydate.ToString("dd/MM/yyyy")
        Catch ex As Exception
            Return str
        End Try

    End Function

End Class



