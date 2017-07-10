Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    Private pdb As New atlasStatisticsEntities

    <Authorize(Roles:="Admins")>
    Function Panel() As ActionResult
        ViewData("Message") = "Control panel page."

        Return View()
    End Function


    <HttpPost>
    Public Function GetWeeklyReportStat1(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat1All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalpoints}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat2(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat2All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalassists}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat3(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat3All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalrebounds}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat4(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat4All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalsteals}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function

    <HttpPost>
    Public Function GetWeeklyReportStat5(ByVal thisid As Integer?) As JsonResult

        Dim s = (From proc In pdb.GetWeeklyReportStat5All(thisid)
                 Select proc).ToList

        Dim stats
        stats = s.AsEnumerable.Select(Function(o) New With {.pid = o.thisid, .pname = o.thisname, .pphoto = If(o.PlayerPhoto Is Nothing, "", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(o.PlayerPhoto))),
                                                            .tid = o.teamId, .tname = o.teamname,
                                                            .kathgoriaid = o.KathgoriaId, .omilosname = o.OmilosName & "-" & o.KathgoriaName,
                                                            .Row = o.Row,
                                                            .val = o.totalblocks}).OrderByDescending(Function(a) a.val).ToArray.Take(10)
        Return Json(stats, JsonRequestBehavior.AllowGet)

    End Function


    <HttpPost>
    Public Function GetRankingsStats(ByVal kathgoriaid As Integer) As JsonResult

        Dim omilosid = (From o In pdb.OmilosTable
                        Join k In pdb.KathgoriesTable On o.Id Equals k.Omilosid
                        Where k.Id = kathgoriaid
                        Select o.Id).FirstOrDefault

        Dim diorganwshid = (From d In pdb.DiorganwshTable
                            Join o In pdb.OmilosTable On d.Id Equals o.Diorganwshid
                            Where o.Id = omilosid
                            Select d.Id).FirstOrDefault

        Dim seasonid = (From s1 In pdb.SeasonTable
                        Join d In pdb.DiorganwshTable On s1.Id Equals d.Seasonid
                        Where d.Id = diorganwshid
                        Select s1.Id).FirstOrDefault

        Dim s = (From proc In pdb.getallteamsrankings(seasonid, diorganwshid, omilosid, kathgoriaid)
                 Select proc).ToList

        Dim stats = s.AsEnumerable.Select(Function(o) New With {.sid = o.thisid, .scount = o.ncount, .sname = o.thisname, .season = o.SeasonName, .diorganwsh = o.DiorganwshName,
                                                                    .omilos = o.OmilosName, .kathgoria = o.KathgoriaName,
                                                                    .nikes = o.nikes, .isopalies = o.isopalies, .httes = o.httes, .totalplayed = o.totalplayed, .totalpoints = o.totalpoints,
                                                                    .diaforapontwn = o.diaforapontwn, .bathmoi = o.bathmoi, .mhdenismoi = o.mhdenismoi
                                                                    }).ToArray


        Return Json(stats, JsonRequestBehavior.AllowGet)


    End Function


    <HttpPost>
    Public Function Getdiorganwseis() As JsonResult

        Dim kat = (From d In pdb.DiorganwshTable
                   Join s In pdb.SeasonTable On s.Id Equals d.Seasonid
                   Where s.ActiveSeason = True
                   Order By d.DiorganwshName
                   Select d.DiorganwshName, d.Id).ToList

        Return Json(kat, JsonRequestBehavior.AllowGet)


    End Function

    <HttpPost>
    Public Function GetOmiloiByDiorganwsh(ByVal dId As Integer) As JsonResult

        Dim om = (From o In pdb.OmilosTable
                  Join d In pdb.DiorganwshTable On d.Id Equals o.Diorganwshid
                  Where d.Id = dId
                  Order By o.OmilosName
                  Select o.OmilosName, o.Id).ToList

        Return Json(om, JsonRequestBehavior.AllowGet)


    End Function


End Class
