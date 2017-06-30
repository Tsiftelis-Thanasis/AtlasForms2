Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization

Public Class Ypokathgories

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <Display(Name:="Κατηγορία")>
    Public Property kathgoriaid As Integer

    <Required()>
        <StringLength(50)>
    <Display(Name:="Υποκατηγορία")>
    Public Property Ypokathgorianame As String

    <Required()>
    <Display(Name:="Ενεργή/Μή ενεργή")>
    Public Property ActiveYpoKathgoria As Boolean

    <Display(Name:="Δημιουργία απο")>
    Public Property createdby As String
    <Display(Name:="Ημ/νια δημιουργίας")>
    Public Property creationdate As Date
    <Display(Name:="Αλλαγή απο")>
    Public Property editby As String
    <Display(Name:="Ημ/νια αλλαγής")>
    Public Property editdate As Date

    Public Sub New()

    End Sub

End Class