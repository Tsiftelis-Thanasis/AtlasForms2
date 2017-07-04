@ModelType AtlasForms2.Posts

@Code
    ViewData("Title") = "EDIT " & Model.PostTitle

    @Html.ValidationMessage("error_msg")

    Dim pdb As New atlasEntities
    Dim katlist As New List(Of SelectListItem)
    Dim ypokatlist As New List(Of SelectListItem)

    '    Dim list1 = (From p1 In pdb.BlogKathgoriesTable
    '                 Where Not (From tp In pdb.TeamsandPlayersTable
    '                            Where tp.TeamId = Model.Id
    '                            Select tp.PlayerId).Contains(p1.Id)
    '                 Select p1.Id, playername = p1.LastName & ", " & p1.FirstName, checkid = 0) _
    '.Union(From p1 In pdb.PlayersTable
    '       Where (From tp In pdb.TeamsandPlayersTable
    '              Where tp.TeamId = Model.Id
    '              Select tp.PlayerId).Contains(p1.Id)
    '       Select p1.Id, playername = p1.LastName & ", " & p1.FirstName, checkid = 1).OrderBy(Function(p) p.playername).ToList

    '    For Each it In list1
    '        If it.checkid = 1 Then
    '            katlist.Add(New SelectListItem() With {.Selected = True, .Text = it.playername, .Value = it.Id})
    '        Else
    '            katlist.Add(New SelectListItem() With {.Selected = False, .Text = it.playername, .Value = it.Id})
    '        End If
    '    Next


    '    Dim list2 = (From p1 In pdb.KathgoriesTable
    '                 Where Not (From tp In pdb.TeamsandKathgoriesTable
    '                            Where tp.TeamId = Model.Id
    '                            Select tp.KathgoriaId).Contains(p1.Id)
    '                 Select p1.Id, p1.KathgoriaName, checkid = 0) _
    '.Union(From p1 In pdb.KathgoriesTable
    '       Where (From tp In pdb.TeamsandKathgoriesTable
    '              Where tp.TeamId = Model.Id
    '              Select tp.KathgoriaId).Contains(p1.Id)
    '       Select p1.Id, p1.KathgoriaName, checkid = 1).OrderBy(Function(p) p.KathgoriaName).ToList
    '    For Each it In list2
    '        If it.checkid = 1 Then
    '            ypokatlist.Add(New SelectListItem() With {.Selected = True, .Text = it.KathgoriaName, .Value = it.Id})
    '        Else
    '            ypokatlist.Add(New SelectListItem() With {.Selected = False, .Text = it.KathgoriaName, .Value = it.Id})
    '        End If
    '    Next

    Dim imageSrc As String = ""
    If Model.PostPhoto IsNot Nothing Then
        Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)
    End If



End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Edit", "Posts", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @Html.HiddenFor(Function(model) model.Id)

    @<div Class="kopa-entry-post">
    
    <article Class="entry-item">
        <p Class="entry-categories style-s">
        <a href="#">ΕΔΩ ΘΑ ΜΠΕΙ ΤΟ ΟΝΟΜΑ ΤΗΣ ΚΑΤΗΓΟΡΙΑΣ η ΥΠΟΚΑΤΗΓΟΡΙΑΣ</a>

            @*<div class="row">
            <div class="col-sm-4"><label>Κατηγορίες</label></div>
            <div class="col-sm-8">
                @Html.DropDownList("kathgorieslist", kathgorieslist, New With {.id = "kathgorieslist", .class = "form-control chosen-select", .multiple = "true"})
                </div>
            </div>*@
            
            
        </p>
        <p Class="short-des">
            @Html.EditorFor(Function(model) model.PostTitle)
        </p>


        <h4 Class="entry-title" >@Html.EditorFor(Function(model) model.PostSummary)</h4>

        <p Class="short-des"><i>@Html.TextAreaFor(Function(m) m.PostBody)   </i></p>
        Youtube link (code): <p Class="short-des"><i>@Html.EditorFor(Function(model) model.Youtubelink)</i></p>
        Statistics Link (just the number): <p Class="short-des"><i>@Html.EditorFor(Function(model) model.Statslink)</i></p>

        Activate : <p Class="short-des"><i>@Html.CheckBoxFor(Function(m) m.Activepost)</i></p>
        
        <div Class="entry-meta">
            <span Class="entry-author">Created by @Html.DisplayFor(Function(model) model.createdby)</span>
            <span Class="entry-date">Created on @Html.DisplayFor(Function(model) model.creationdate)</span>
            <br />
            <span Class="entry-author">Edit by @Html.DisplayFor(Function(model) model.editby)</span>
            <span Class="entry-date">Edited on @Html.DisplayFor(Function(model) model.editdate)</span>
        </div>

        @Html.LabelFor(Function(m) m.PostPhoto)
        <div Class="entry-thumb">
            <img src="@imageSrc" style="height:320px;width:320px;"/>
        </div>
        
        <input type="file" id="uploadEditorImage" name="uploadEditorImage" />
        @Html.Label("uploaddone", "Upload is done...", New With {.id = "uploaddone"})
        

        @*<hr />
            <iframe title = "YouTube video player" Class="youtube-player" type="text/html"
                height="315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                frameborder="0" allowFullScreen></iframe>*@

    </article>




</div>

@<div class="form-group">
    <input type="submit" name="Command" value="Αποθήκευση" class="btn btn-default" />
</div>

End Using

<hr />
<div>
    @Html.ActionLink("Επιστροφή", "Index", "Posts")
</div>


@Section Scripts
    <script type="text/javascript">


    tinymce.init({
        selector: 'textarea',
        height: 500,
        menubar: false,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code'
        ],
        toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        content_css: [
            '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
            '//www.tinymce.com/css/codepen.min.css']
    });

    //$(function () {
    //    $('.chosen-select').chosen();
    //    $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
    //});


    $(document).ready(function () {
        $("#createdby").attr('readonly', 'readonly');
        $("#creationdate").attr('readonly', 'readonly');
        $("#editby").attr('readonly', 'readonly');
        $("#editdate").attr('readonly', 'readonly');

        $('#uploaddone').hide();

        $("#uploadEditorImage").change(function () {
            var data = new FormData();
            var files = $("#uploadEditorImage").get(0).files;
            if (files.length > 0) {
                $('#uploaddone').show();
            }
            else {
                $('#uploaddone').hide();
            }
        });
    });


    </script>
End Section
