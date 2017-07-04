@ModelType AtlasForms2.Ypokathgories

@Code
    ViewData("Title") = "Δημιουργια υποκατηγοριας"
    @Html.ValidationMessage("error_msg")

    Dim pdb As New atlasEntities
    Dim katlist As New List(Of SelectListItem)
    Dim l1 = (From p In pdb.BlogKathgoriesTable
              Select p.Id, p.KathgoriaName).OrderBy(Function(m) m.kathgorianame).ToList

    For Each tmp In l1.ToList()
        katlist.Add(New SelectListItem() With {.Text = tmp.kathgorianame, .Value = tmp.Id})
    Next



End Code
<h2>@ViewBag.Title</h2>
<hr />


@Using (Html.BeginForm("Create", "Ypokathgories", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)


    @<div class="row">
    @Html.Label("Κατηγορίες", htmlAttributes:=New With {.class = "control-label"})
        @Html.DropDownList("kathgorieslist", katlist, New With {.id = "kathgorieslist", .class = "form-control chosen-select"})
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(m) m.Ypokathgorianame, htmlAttributes:=New With {.class = "control-label"})
        @Html.EditorFor(Function(m) m.Ypokathgorianame, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<div class="row">
        @Html.LabelFor(Function(m) m.ActiveYpoKathgoria, htmlAttributes:=New With {.class = "control-label"})
        @Html.CheckBoxFor(Function(m) m.ActiveYpoKathgoria, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<input type="submit" value="Αποθήκευση" class="btn btn-default" />

End Using

<hr />

<div>
    @Html.ActionLink("Επιστροφή", "Index", "Ypokathgories")
</div>



@Section Scripts
    <script type="text/javascript">


    $(function () {
        $('.chosen-select').chosen();
        $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
    });



    </script>
End Section
