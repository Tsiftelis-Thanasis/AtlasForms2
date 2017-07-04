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


<div id="main-content">

    <div class="wrapper">

        <div class="main-top">
            <div class="kopa-ticker">
                <span class="ticker-title"><i class="fa fa-angle-double-right"></i>νεα ομίλου</span>
                <div class="ticker-wrap">
                    <dl class="ticker-1">
                        <dt></dt>
                        <dd>
                            <a><span>@Html.DisplayFor(Function(model) model.PostTitle)</span></a>
                        </dd>                        
                    </dl>
                    <!--ticker-1-->
                </div>
            </div>
            <!-- kopa-ticker -->           
        </div>
        <!-- main-top -->

        <div class="row">

            <div class="kopa-main-col">               
                <div class="kopa-entry-post">
                    <article class="entry-item">
                        <p class="entry-categories style-s"><a href="#">Αρχικη</a><a href="#">νεα ομίλου</a><a href="#">@Html.DisplayFor(Function(model) model.PostTitle)</a></p>
                        <h4 class="entry-title">@Html.DisplayFor(Function(model) model.PostTitle)</h4>
                        <div class="entry-meta">
                            <span class="entry-author">by <a href="#">@Html.DisplayFor(Function(model) model.editby)</a></span>
                            <span class="entry-date">@Html.DisplayFor(Function(model) model.editdate)</span>
                        </div>
                        <p class="short-des"><i>@Html.DisplayFor(Function(model) model.PostSummary)</i></p>
                        
                        <div class="entry-thumb">
                            <img src="@imageSrc" alt="">
                        </div>
                                              
                        <p Class="short-des"><i>@Html.TextAreaFor(Function(m) m.PostBody)   </i></p>
                        <br /><br />
                       
                        @code
                            If Model.Statslink <> "" Then
                                @<p Class="short-des" style="text-align:center">
                                    <a target = "_blank" href="http://atlasstatistics.gr/Games/Details/@Html.DisplayFor(Function(model) model.Statslink)">
                                        <img src = "~/Content/images/various/stats.jpg" border="0" />
                                    </a>
                                </p>
                            End If
                        End Code
                                               
                        @code
                            If Model.Youtubelink <> "" Then
                                @<iframe title="YouTube video player" Class="youtube-player" type="text/html"
                                        height = "315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                                        frameborder="0" allowFullScreen>
                                </iframe>
                            End If
                        End Code

                    </article>
                        
                </div>
                <!-- kopa-entry-post -->

            </div>
            <!-- main-col -->

            <div class="sidebar widget-area-11">
                              
                <div class="widget kopa-ads-widget">
                    <a href="#"><img src="http://www.atlasbasket.gr/images/banners/blueiceok.png" alt=""></a>
                </div>

                <div class="widget kopa-ads-widget">
                    <a href="#"><img src="http://www.atlasbasket.gr/images/banners/risko.jpg" alt=""></a>
                </div>

                <div class="widget kopa-ads-widget">
                    <a href="#"><img src="http://www.atlasbasket.gr/images/banners/65c14b0a-e3b2-4e15-8f14-1ba31c041f20.png" alt=""></a>
                </div>

                <div class="widget kopa-ads-widget">
                    <a href="#"><img src="~/Content/images/ads/1.jpg" alt=""></a>
                </div>
                <!-- widget -->
               
            </div>
            <!-- sidebar -->

        </div>
        <!-- row -->

    </div>
    <!-- wrapper -->

</div>
<!-- main-content -->

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
