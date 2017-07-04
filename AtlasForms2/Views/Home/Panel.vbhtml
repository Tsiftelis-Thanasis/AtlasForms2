@Code
    ViewData("Title") = "διαχειριση"
End Code
<h2>@ViewBag.Title</h2>
<hr />  

<div class="row ">   
    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-cpanel homeicons"></i> άρθρα</h4>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Λίστα όλων των άρθων", "All", "Posts") </p>
            </div>
        </div>
    </div>
    
     <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-cpanel homeicons"></i> Κατηγοριες</h4>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Λίστα Κατηγοριών", "Index", "Kathgories") </p>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-cpanel homeicons"></i> Υπο - Κατηγοριες</h4>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Λίστα Υπο-Κατηγοριών", "Index", "Ypokathgories") </p>
            </div>
        </div>
    </div>

</div>

<div class="row ">
    <div class="col-md-3">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-useralt homeicons"></i> Διαχειριση χρηστων</h4>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Χρήστες", "Index", "UsersAdmin") </p>

            </div>
        </div>
    </div>
</div>




