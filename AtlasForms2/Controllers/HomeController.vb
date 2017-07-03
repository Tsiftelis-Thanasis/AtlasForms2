Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    <Authorize(Roles:="Admins")>
    Function Panel() As ActionResult
        ViewData("Message") = "Control panel page."

        Return View()
    End Function

End Class
