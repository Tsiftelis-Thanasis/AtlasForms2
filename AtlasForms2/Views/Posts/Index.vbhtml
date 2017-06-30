@ModelType IEnumerable(Of AtlasForms2.Posts)
@Code
    ViewData("Title") = "Τελευταία νέα"
End Code


<div class="content-wrap">
    
    <div class="row">

        <div class="kopa-main">

            <div class="widget-area-2">

                <div class="widget kopa-article-list-widget article-list-1">
                    <h3 class="widget-title style2">Τελευταια νεα</h3>


                    <div id="container">
                        <table id="newstable">
                            <tbody>
                                    
                            </tbody>
                        </table>
                    </div>
                                       
                </div>
                <!-- widget -->

            </div>
            <!-- widget-area-2 -->
            
        </div>
        <!-- main-col -->

     

    </div>
    <!-- row -->

</div>
<!-- content-wrap -->


@Section Scripts
    <script type="text/javascript" language="javascript">
    $(document).ready(function () {

        $('#rowid').val('');

        $('#newstable').DataTable({
            "sAjaxSource": baseUrl + '@Url.Action("GetNews")',
            "contentType": "application/json; charset=utf-8",
            "language": {
                "url": baseUrl + "/Scripts/DataTables/Greek.json"
            },
            "aLengthMenu": [[5, 10, 20, 50, -1], [5, 10, 20, 50, "All"]],
            "iDisplayLength": 5,
            "bProcessing": true,
            "aoColumns": [{}]
            ,
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';
                            
                            var dd = '<article class="entry-item"> ' +
                                        ' <a href="@Url.Action("Details", "Posts")/' + row.Id + '"> ' +
                                        ' <div class="entry-thumb"> ' +
                                        ' <img src="' + row.PostPhoto + '" alt="">' +
                                        ' </div> ' +
                                        ' <div class="entry-content"> ' +
                                        ' <div class="content-top"> ' +
                                        ' <h4 class="entry-title"> <b>' + row.PostTitle + ' </b> </h4> ' +
                                        ' </div> ' +
                                        ' <p>' + row.PostSummary + '.... </p> ' +
                                        ' <footer> ' +
                                        '   <p class="entry-author">by Michel bellar</p> ' +
                                        ' </footer> ' +
                                        ' </div>    ' +
                                        ' </a> ' +
                                        ' </article> ';

                            return dd;
                        }

                    }
            ]
            });

        });
    </script>
End Section
