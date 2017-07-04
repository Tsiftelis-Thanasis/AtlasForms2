@ModelType AtlasForms2.Ypokathgories
@Code
    ViewData("Title") = Model.Ypokathgorianame
    @Html.ValidationMessage("error_msg")

    Dim pdb As New atlasEntities

    Dim katlist As New List(Of SelectListItem)
    Dim l3 = (From p In pdb.BlogKathgoriesTable
              Select p.Id, p.KathgoriaName).OrderBy(Function(m) m.kathgorianame).ToList

    For Each it In l3
        If it.Id = Model.kathgoriaid Then
            katlist.Add(New SelectListItem() With {.Selected = True, .Text = it.kathgorianame, .Value = it.Id})
        Else
            katlist.Add(New SelectListItem() With {.Selected = False, .Text = it.kathgorianame, .Value = it.Id})
        End If
    Next


End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Edit", "Ypokathgories", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @Html.HiddenFor(Function(model) model.Id)

    @<div class="row">
        @Html.Label("Κατηγορίες", htmlAttributes:=New With {.class = "control-label"})
        @Html.DropDownList("kathgorieslist", katlist, New With {.id = "kathgorieslist", .class = "form-control chosen-select"})
    </div>


    @<div Class="row">
        @Html.LabelFor(Function(m) m.Ypokathgorianame, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.EditorFor(Function(m) m.Ypokathgorianame, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
        @Html.LabelFor(Function(m) m.ActiveYpoKathgoria, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.CheckBoxFor(Function(m) m.ActiveYpoKathgoria, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<div Class="row">
        @Html.LabelFor(Function(m) m.createdby, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.EditorFor(Function(m) m.createdby, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
        @Html.LabelFor(Function(m) m.creationdate, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.EditorFor(Function(m) m.creationdate, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
        @Html.LabelFor(Function(m) m.editby, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.EditorFor(Function(m) m.editby, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div Class="row">
        @Html.LabelFor(Function(m) m.editdate, htmlAttributes:=New With {.class = "control-label col-md-4"})
        @Html.EditorFor(Function(m) m.editdate, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<div class="form-group">
        <input type="submit" name="Command" value="Αλλαγή" Class="btn btn-default" />
    </div>

End Using

<hr />
<div>
    @Html.ActionLink("Επιστροφή", "Index", "Ypokathgories")
</div>

@Scripts.Render("~/bundles/jqueryval")
@Section Scripts
    <script type="text/javascript">

        $(document).ready(function () {

            $("#createdby").attr('readonly', 'readonly');
            $("#creationdate").attr('readonly', 'readonly');
            $("#editby").attr('readonly', 'readonly');
            $("#editdate").attr('readonly', 'readonly');

        });


    </script>
End Section
