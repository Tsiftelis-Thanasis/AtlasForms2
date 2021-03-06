﻿@ModelType IEnumerable(Of AtlasForms2.Posts)
@Code


End Code

<div id="main-content" Class="style1">

    <div Class="wrapper">
        <div Class="content-wrap">
            <div Class="row">
                <div Class="kopa-main-col">
                                       
                    <div id="divcommon" Class="widget-area-2">
                        <div Class="widget kopa-article-list-widget article-list-1">
                            <h3 Class="widget-title style2">ολα τα αρθρα</h3>
                            <table id="newstable">
                                <thead>
                                    <tr>
                                        <th>Άρθρο</th>
                                        <th>Κατηγορία</th>
                                        <th>Υποκατηγορία</th>
                                        <th>Αλλαγή απο</th>
                                        <th>Ημερομηνία</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                                @*<tr>
                                    <td>
                                        <ul class="clearfix"></ul>
                                    </td>
                                </tr>*@
                            </table>
                        </div>
                        <!-- widget -->
                    </div>
                    <!-- widget-area-2 -->
                
                </div>
                <!-- main-col -->

                <div Class="sidebar widget-area-11">

                    <div Class="widget kopa-ads-widget">
                        <a href="http://www.blue-ice.gr/"> <img src="http://www.atlasbasket.gr/images/banners/blueiceok.png" alt=""></a>
                    </div>

                    <div Class="widget kopa-ads-widget">
                        <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="http://www.atlasbasket.gr/images/banners/risko.jpg" alt=""></a>
                    </div>

                    <div Class="widget kopa-ads-widget">
                        <a href="http://www.atlassportswear.gr/"> <img src="http://www.atlasbasket.gr/images/banners/65c14b0a-e3b2-4e15-8f14-1ba31c041f20.png" alt=""></a>
                    </div>
                    <!-- widget -->

                </div>
                <!-- sidebar -->

            </div>
            <!-- row -->

        </div>
        <!-- content-wrap -->


    </div>
    <!-- wrapper -->

</div>
<!-- main-content -->




@Section Scripts
    <Script type="text/javascript" language="javascript">
    $(document).ready(function () {
                     

        $('#newstable').DataTable({
            "sAjaxSource": baseUrl + '@Url.Action("GetAllNewsWithCategory")',           
            "contentType": "application/json; charset=utf-8",
            "language": {
                "url": baseUrl + "/Scripts/DataTables/Greek.json"
            },
            "aLengthMenu": [[5, 10, 20, 50, -1], [5, 10, 20, 50, "All"]],
            "iDisplayLength": 5,
            "bProcessing": true,           
            "aoColumns": [
                          {},
                          { "mData": "KatName" },
                          { "mData": "Ypokatname" },
                          { "mData": "editBy"},
                          { "mData": "editDate", "sType": "date-eu" },
            ],
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';

                            var dd = //'<li>'+
                                ' <article class="entry-item"> ' +
                                ' <div class="entry-content"> ' +
                                '   <div class="content-top"> ' +
                                '       <a href="@Url.Action("Edit", "Posts")/' + row.Id + '"> ' +
                                '           <h4 class="entry-title"> <b>' + row.PostTitle + ' </b> </h4> ' +
                                '       </a> ' +
                                '   </div> ' +
                                '   <p>' + row.PostSummary + ' .... </p> ' +
                                ' </div>    ' +
                                ' </a> ' +
                                ' </article> ';
                                ///'</li>';

                            return dd;
                        }

                    }
            ]
        });

   



    });
    </Script>
End Section
