@ModelType AtlasForms2.Posts
@Code
    ViewData("Title") = Model.PostTitle

    Dim pdb As New atlasEntities

    Dim imageSrc As String = ""
    If Model.PostPhoto IsNot Nothing Then
        Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)
    End If


End Code



<div class="kopa-breadcrumb">
    <div class="wrapper clearfix">
        <span itemtype="http://data-vocabulary.org/Breadcrumb" itemscope="">
            <a itemprop="url" href="#">
                <span itemprop="title">Αρχικη</span>
            </a>
        </span>
        &nbsp;|&nbsp;
        <span itemtype="http://data-vocabulary.org/Breadcrumb" itemscope="">
            <a itemprop="url" href="#">
                <span itemprop="title">νεα ομίλου</span>
            </a>
        </span>
        &nbsp;|&nbsp;
        <span itemtype="http://data-vocabulary.org/Breadcrumb" itemscope="">
            <a itemprop="url" class="current-page">
                <span itemprop="title">@Html.DisplayFor(Function(model) model.PostTitle)</span>
            </a>
        </span>
    </div>
</div>
<!--/end .breadcrumb-->

<div class="kopa-entry-post">


    <article class="entry-item">
        <p class="entry-categories style-s"><a href="#">νεα ομίλου</a><a href="#">@Html.DisplayFor(Function(model) model.PostTitle)</a></p>
        <h4 class="entry-title">@Html.DisplayFor(Function(model) model.PostTitle)</h4>
        <div class="entry-meta">
            <span class="entry-author">by @Html.DisplayFor(Function(model) model.editby)</span>
            <span class="entry-date">on @Html.DisplayFor(Function(model) model.editdate)</span>
        </div>
        <div class="entry-thumb">
            <img src="@imageSrc" />
        </div>
        <p class="short-des">

          
        </p>
        
        <hr />

        @Html.TextAreaFor(Function(model) model.PostBody, New With {.class = "mceselector"})



        <hr />
            <iframe title="YouTube video player" class="youtube-player" type="text/html"
                height="315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                frameborder="0" allowFullScreen></iframe>
    
    </article>
    
    


</div>
                       

<p>    
    @Html.ActionLink("Επιστροφή στην αρχική", "Index")
</p>



@Section Scripts
    <script type="text/javascript">

        tinymce.init({
            selector: 'textarea',
            height: 500,
            menubar: false,
            readonly: true,
            statusbar: false, toolbar: false, menubar: false,
            branding: false,
            content_css: [
                '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
                '//www.tinymce.com/css/codepen.min.css']
        });



    </script>
End Section