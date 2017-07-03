@ModelType AtlasForms2.Posts
@Code
    ViewData("Title") = Model.PostTitle



    Dim pdb As New atlasEntities

    Dim imageSrc As String = ""
    If Model.PostPhoto IsNot Nothing Then
        Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)
    End If

    Dim firstChar As String = "<span Class='kopa-dropcap dc1'>" & Mid(Model.PostBody, 1, 1) & "</span>"




End Code




<div id="main-content">

    <div class="wrapper">

        <div class="main-top">
            <div class="kopa-ticker">
                <span class="ticker-title"><i class="fa fa-angle-double-right"></i>νεα διοργανωσης</span>
                <div class="ticker-wrap">
                    <dl class="ticker-1">
                        <dt></dt>
                        <dd>
                            <a href="viewNews.aspx?typ=org&title=Διασκέδαση, θέαμα και υψηλό επίπεδο στο All Star Game">Διασκέδαση, θέαμα και υψηλό επίπεδο στο All Star Game</a>
                        </dd>
                        <dd>
                            <a href="viewNews.aspx?typ=org&title=Summer League 2017">Summer League 2017</a>
                        </dd>
                        <dd>
                            <a href="viewNews.aspx?typ=org&title=Διασταυρώσεις Κύπελλου">Διασταυρώσεις Κύπελλου</a>
                        </dd>
                    </dl>
                    <!--ticker-1-->
                </div>
            </div>
            <!-- kopa-ticker -->

            <div class="social-links style1">
                <ul class="clearfix">
                    <li><a href="#" class="fa fa-facebook"></a></li>
                    <li><a href="#" class="fa fa-twitter"></a></li>
                    <li><a href="#" class="fa fa-google-plus"></a></li>
                    <li><a href="#" class="fa fa-instagram"></a></li>
                </ul>
            </div>
        </div>
        <!-- main-top -->

        <div class="row">

            <div class="kopa-main-col">
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
                        <p class="entry-categories style-s"><a href="#">Αρχικη</a><a href="#">νεα ομίλου</a><a href="#">@Html.DisplayFor(Function(model) model.PostTitle)</a></p>
                        <h4 class="entry-title">@Html.DisplayFor(Function(model) model.PostTitle)</h4>
                        <div class="entry-meta">
                            <span class="entry-author">by <a href="#">@Html.DisplayFor(Function(model) model.editby)</a></span>
                            <span class="entry-date">@Html.DisplayFor(Function(model) model.editdate)</span>
                        </div>
                        <div class="entry-thumb">
                            <img src="@imageSrc" alt="">
                        </div>
                        <p class="short-des"><i>@Html.DisplayFor(Function(model) model.PostSummary)</i></p>
                        @*<div class="kopa-share-post social-links style-bg-color">
                            <ul class="clearfix">
                                <li><a href="#" class="fa fa-facebook"></a></li>
                                <li><a href="#" class="fa fa-twitter"></a></li>
                                <li><a href="#" class="fa fa-rss"></a></li>
                                <li><a href="#" class="fa fa-google-plus"></a></li>
                                <li><a href="#" class="fa fa-pinterest"></a></li>
                                <li><a href="#" class="fa fa-instagram"></a></li>
                            </ul>
                        </div>*@
                        <!-- kopa-share-post -->
                        <!-- here goes the body-->
                        @firstChar 
                        <p Class="short-des"><i>@Html.TextAreaFor(Function(m) m.PostBody)   </i></p>
                        @*@Html.DisplayFor(Function(model) model.PostBody, New With {.class = "kopa-dropcap dc1"})*@
                        <br /><br />
                        


                        @code
                            If Model.Statslink <> "" Then
                        End Code
                        <p Class="short-des" style="text-align:center">
                            <a target = "_blank" href="http://atlasstatistics.gr/Games/Details/@Html.DisplayFor(Function(model) model.Statslink)">
                                <img src = "~/Content/images/various/stats.jpg" border="0" />
                            </a>
                        </p>
                        @code
                            End If
                        End Code

                        <!-- end of body-->

                        @code
                            If Model.Youtubelink <> "" Then
                        End Code
                        <hr />
                        <iframe title="YouTube video player" class="youtube-player" type="text/html"
                                height="315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                                frameborder="0" allowFullScreen>
                        </iframe>
                        @code
                            End If
                        End Code





                    </article>

                    @*<div class="kopa-tag-box">
                        <span>Tags : </span>
                        <a href="#">Awesome</a>
                        &nbsp;&#92;&nbsp;
                        <a href="#">Psd</a>
                        &nbsp;&#92;&nbsp;
                        <a href="#">Creative</a>
                    </div>*@
                    <!-- kopa-tag-box -->

                    @*<div class="kopa-share-post social-links style-bg-color">
                        <ul class="clearfix">
                            <li><a href="#" class="fa fa-facebook"></a></li>
                            <li><a href="#" class="fa fa-twitter"></a></li>
                            <li><a href="#" class="fa fa-rss"></a></li>
                            <li><a href="#" class="fa fa-google-plus"></a></li>
                            <li><a href="#" class="fa fa-pinterest"></a></li>
                            <li><a href="#" class="fa fa-instagram"></a></li>
                        </ul>
                    </div>*@
                    <!-- kopa-share-post -->
                    @*                        <div class="kopa-post-review">
                        <div class="pd-20">
                            <div class="rv-thumb">
                                <p>10.0</p>
                                <div class="kopa-rating">
                                    <ul>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                    </ul>
                                </div>
                                <span>editor</span>
                            </div>
                            <div class="rv-thumb">
                                <p>10.0</p>
                                <div class="kopa-rating">
                                    <ul>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                        <li><span class="fa fa-star"></span></li>
                                    </ul>
                                </div>
                                <span>user</span>
                            </div>
                            <div class="rv-content">
                                <h3>ReVIEW</h3>
                                <p>Suscipit sed at montes at tellus. Aliquam nisl penatibus commodo massa mi rutrum, ut massa mollis dolor dui at, tortor ullamcorper vel diam pretium sit leo, pellentesque in leo eu mauris mollis aliquam, ultricies adipiscing eu a dui sollicitudin posuere. </p>
                            </div>
                        </div>
                        <div class="pd-20">
                            <div class="progress">
                                <div class="progress-bar" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width: 90%;">
                                    <span class="sr-only">design</span>
                                </div>
                                <span class="sr-num">9.0</span>
                            </div>
                            <div class="progress">
                                <div class="progress-bar" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width: 90%;">
                                    <span class="sr-only">wordpress</span>
                                </div>
                                <span class="sr-num">9.0</span>
                            </div>
                            <div class="progress">
                                <div class="progress-bar" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" style="width: 90%;">
                                    <span class="sr-only">development</span>
                                </div>
                                <span class="sr-num">9.0</span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="kopa-slider">
                                <input type="text" class="kopa-slider-ip" value="" data-slider-value="0" data-slider-step="5" data-slider-max="100" data-slider-min="0" data-slider-handle="custom">
                            </div>
                            <!-- slider -->
                        </div>
                    </div>*@
                    <!-- kopa-post-review -->

                    @*<div class="single-other-post clearfix">
                        <div class="entry-item prev-post">
                            <div class="entry-thumb">
                                <a href="#"><img src="~/Content/images/single/1.jpg" alt=""></a>
                            </div>
                            <div class="entry-content">
                                <a href="#" class="">PREVIoUS POST</a>
                                <h4 class="entry-title"><a href="#">ProIN EU SAPIEN ID SODALES DUI PELLENTESQUE AC EST RISUS</a></h4>
                            </div>
                        </div>
                        <div class="entry-item next-post">
                            <div class="entry-thumb">
                                <a href="#"><img src="~/Content/images/single/2.jpg" alt=""></a>
                            </div>
                            <div class="entry-content">
                                <a href="#" class="">NExt POST</a>
                                <h4 class="entry-title"><a href="#">ProIN EU SAPIEN ID SODALES DUI PELLENTESQUE AC EST RISUS</a></h4>
                            </div>
                        </div>
                    </div>*@
                    <!-- single-other-post -->
                    @*                        <div class="kopa-related-post">
                        <h3 class="widget-title style12">recommended<span class="ttg"></span></h3>
                        <ul class="row clearfix">
                            <li class="col-md-3 col-sm-3 col-xs-3">
                                <article class="entry-item">
                                    <div class="entry-thumb">
                                        <a href="#"><img src="images/relate/1.jpg" alt=""></a>
                                    </div>
                                    <h4 class="entry-title"><a href="#">Duf-man returns: Dufner in action Down Under</a></h4>
                                </article>
                            </li>
                            <li class="col-md-3 col-sm-3 col-xs-3">
                                <article class="entry-item">
                                    <div class="entry-thumb">
                                        <a href="#"><img src="images/relate/2.jpg" alt=""></a>
                                    </div>
                                    <h4 class="entry-title"><a href="#">Duf-man returns: Dufner in action Down Under</a></h4>
                                </article>
                            </li>
                            <li class="col-md-3 col-sm-3 col-xs-3">
                                <article class="entry-item">
                                    <div class="entry-thumb">
                                        <a href="#"><img src="images/relate/3.jpg" alt=""></a>
                                    </div>
                                    <h4 class="entry-title"><a href="#">Duf-man returns: Dufner in action Down Under</a></h4>
                                </article>
                            </li>
                            <li class="col-md-3 col-sm-3 col-xs-3">
                                <article class="entry-item">
                                    <div class="entry-thumb">
                                        <a href="#"><img src="images/relate/4.jpg" alt=""></a>
                                    </div>
                                    <h4 class="entry-title"><a href="#">Duf-man returns: Dufner in action Down Under</a></h4>
                                </article>
                            </li>
                        </ul>
                    </div>
                    <!-- kopa-related-post --> *@

                    @*<div id="comments">
                        <h3 class="">+Show Comment+</h3>
                        <ol class="comments-list clearfix">
                            <li class="comment clearfix">
                                <article class="comment-wrap clearfix">
                                    <div class="comment-avatar">
                                        <img alt="" src="images/single/comment.jpg">
                                    </div>
                                    <div class="media-body clearfix">
                                        <header class="clearfix">
                                            <div class="pull-left">
                                                <h4>Kopasoft themes</h4>
                                                <span class="comment-date">Mar 23, 2014 at 7:59 pm</span>
                                            </div>
                                            <div class="comment-button pull-right">
                                                <a class="comment-reply-link" href="#">reply</a>
                                            </div>
                                        </header>
                                        <p>Proin eleifend volutpat massa, vitae venenatis quam cursus sit amet. Aenean sed lacus enim. Fusce adipiscing tristique lorem, non pellentesque nisi porta elementum. Pellentesque</p>
                                    </div>
                                </article>
                                <ul class="children">
                                    <li class="comment clearfix">
                                        <article class="comment-wrap clearfix">
                                            <div class="comment-avatar">
                                                <img alt="" src="images/single/comment.jpg">
                                            </div>
                                            <div class="media-body clearfix">
                                                <header class="clearfix">
                                                    <div class="pull-left">
                                                        <h4>Kopasoft themes</h4>
                                                        <span class="comment-date">Mar 23, 2014 at 7:59 pm</span>
                                                    </div>
                                                    <div class="comment-button pull-right">
                                                        <a class="comment-reply-link" href="#">reply</a>
                                                    </div>
                                                </header>
                                                <p>Proin eleifend volutpat massa, vitae venenatis quam cursus sit amet. Aenean sed lacus enim. Fusce adipiscing tristique lorem, non pellentesque nisi porta elementum. Pellentesque</p>
                                            </div>
                                        </article>
                                    </li>
                                </ul>
                            </li>
                            <li class="comment clearfix">
                                <article class="comment-wrap clearfix">
                                    <div class="comment-avatar">
                                        <img alt="" src="images/single/comment.jpg">
                                    </div>
                                    <div class="media-body clearfix">
                                        <header class="clearfix">
                                            <div class="pull-left">
                                                <h4>Kopasoft themes</h4>
                                                <span class="comment-date">Mar 23, 2014 at 7:59 pm</span>
                                            </div>
                                            <div class="comment-button pull-right">
                                                <a class="comment-reply-link" href="#">reply</a>
                                            </div>
                                        </header>
                                        <p>Proin eleifend volutpat massa, vitae venenatis quam cursus sit amet. Aenean sed lacus enim. Fusce adipiscing tristique lorem, non pellentesque nisi porta elementum. Pellentesque</p>
                                    </div>
                                </article>
                            </li>
                        </ol>
                        <div class="kopa-pagination">
                            <ul class="clearfix">
                                <li><a href="#" class="prev fa fa-chevron-left"></a></li>
                                <li><a href="#">Older</a></li>
                                <li><span class="current">1</span></li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">5</a></li>
                                <li><a href="#">Newer</a></li>
                                <li><a href="#" class="next fa fa-chevron-right"></a></li>
                            </ul>
                        </div>
                    </div>
                    *@
                    <!-- comment -->
                    @*<div class="widget kopa-comment-form-widget">

                        <h3 class="widget-title style12">leave a reply<span class="ttg"></span></h3>
                        <p><i>Your email address will not be published. Required fields are marked *</i></p>

                        <div class="comment-box">
                            <form id="comments-form" class="clearfix" action="#" method="post" novalidate="novalidate">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4 col-xs-4">
                                        <p class="input-label">Name<span>(*)</span></p>
                                        <p class="input-block">
                                            <input type="text" value="" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" id="comment_name" name="name" class="valid">
                                        </p>
                                    </div>
                                    <!-- col-md-4 -->

                                    <div class="col-md-4 col-sm-4 col-xs-4">
                                        <p class="input-label">Email<span>(*)</span></p>
                                        <p class="input-block">
                                            <input type="text" value="" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" id="comment_email" name="email" class="valid">
                                        </p>
                                    </div>
                                    <!-- col-md-4 -->

                                    <div class="col-md-4 col-sm-4 col-xs-4">
                                        <p class="input-label">Website</p>
                                        <p class="input-block">
                                            <input type="text" value="" onfocus="if(this.value=='')this.value='';" onblur="if(this.value=='')this.value='';" id="comment_ws-link" name="website" class="valid">
                                        </p>
                                    </div>
                                    <!-- col-md-4 -->

                                </div>
                                <!-- row -->
                                <p class="textarea-block">
                                    <textarea name="message" id="comment_message" cols="88" rows="12"></textarea>
                                </p>
                                <p class="comment-button clearfix">
                                    <span><input type="submit" value="Post Comment" id="submit-comment"></span>
                                </p>
                            </form>
                            <div id="response"></div>
                        </div>
                        <!-- comment-box -->

                    </div>
                    *@<!-- widget -->

                </div>
                <!-- kopa-entry-post -->

            </div>
            <!-- main-col -->

            <div class="sidebar widget-area-11">

                @*<div class="widget widget_search style1">
                    <h3 class="widget-title style3"><span class="fa fa-search"></span>search</h3>
                    <div class="search-box">
                        <form action="#" class="search-form clearfix" method="get">
                            <input type="text" onblur="if (this.value == '') this.value = this.defaultValue;" onfocus="if (this.value == this.defaultValue) this.value = '';" value="Search..." name="s" class="search-text">
                            <button type="submit" class="search-submit">
                                <span class="fa fa-search"></span>
                            </button>
                        </form>
                        <!-- search-form -->
                    </div>
                </div>
                <!-- widget -->
                *@

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
                @*                    <div class="widget kopa-tab-1-widget">
                    <div class="kopa-tab style6">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#headlines" data-toggle="tab"><span>headlines</span></a></li>
                            <li><a href="#news" data-toggle="tab"><span>club news</span></a></li>
                        </ul>
                        <!-- nav-tabs -->
                        <div class="tab-content">
                            <div class="tab-pane active" id="headlines">
                                <ul class="kopa-list clearfix">
                                    <li>
                                        <a href="#">Royals slip by Orioles for 3-0 advantage</a>
                                    </li>
                                    <li>
                                        <a href="#">Error hands Giants victory over Cards, NLCS </a>
                                    </li>
                                    <li>
                                        <a href="#">Lawyer: Hearing won't impact Winston's </a>
                                    </li>
                                    <li>
                                        <span class="bg-red">Live</span>
                                        <a href="#">Analyzing possible outcomes in Winston</a>
                                    </li>
                                    <li>
                                        <a href="#">USMNT draws with Honduras despite</a>
                                    </li>
                                    <li>
                                        <span class="bg-blue">Must read</span>
                                        <a href="#">New concern with concus</a>
                                    </li>
                                    <li>
                                        <a href="#">Pavelski boosts Sharks over Capitals</a>
                                    </li>
                                </ul>
                            </div>
                            <!-- tab-pane -->
                            <div class="tab-pane" id="news">
                                <ul class="kopa-list clearfix">
                                    <li>
                                        <a href="#">USMNT draws with Honduras despite</a>
                                    </li>
                                    <li>
                                        <span class="bg-blue">Must read</span>
                                        <a href="#">New concern with concus</a>
                                    </li>
                                    <li>
                                        <a href="#">Pavelski boosts Sharks over Capitals</a>
                                    </li>
                                    <li>
                                        <a href="#">Royals slip by Orioles for 3-0 advantage</a>
                                    </li>
                                    <li>
                                        <a href="#">Error hands Giants victory over Cards, NLCS </a>
                                    </li>
                                    <li>
                                        <a href="#">Lawyer: Hearing won't impact Winston's </a>
                                    </li>
                                    <li>
                                        <span class="bg-red">Live</span>
                                        <a href="#">Analyzing possible outcomes in Winston</a>
                                    </li>
                                </ul>

                            </div>
                            <!-- tab-pane -->
                        </div>
                    </div>
                    <!-- kopa-tab -->

                </div>
                <!-- widget -->

                <div class="widget kopa-article-list-widget article-list-5">
                    <h3 class="widget-title style14">
                        <span>planet futbol</span>
                        <a href="#">more <span class="fa fa-chevron-right"></span></a>
                    </h3>
                    <ul class="clearfix">
                        <li>
                            <article class="entry-item video-post">
                                <div class="entry-thumb">
                                    <a href="#"><img src="images/one-post/1.jpg" alt=""></a>
                                    <a class="thumb-icon style1" href="#"></a>
                                </div>
                                <div class="entry-content">
                                    <div class="content-top">
                                        <h4 class="entry-title"><a href="#">USMNT friendly roster about Dollovan, but also</a></h4>
                                        <p class="entry-comment"><a href="#">52</a></p>
                                    </div>
                                    <footer>
                                        <p class="entry-author">by <a href="#">Michel bellar</a></p>
                                    </footer>
                                </div>
                                <div class="post-share-link style-bg-color">
                                    <span><i class="fa fa-share-alt"></i></span>
                                    <ul>
                                        <li><a href="#" class="fa fa-facebook"></a></li>
                                        <li><a href="#" class="fa fa-twitter"></a></li>
                                        <li><a href="#" class="fa fa-google-plus"></a></li>
                                    </ul>
                                </div>
                            </article>
                        </li>
                    </ul>
                </div>
                <!-- widget --> *@

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
