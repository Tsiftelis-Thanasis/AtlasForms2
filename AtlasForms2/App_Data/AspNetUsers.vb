'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class AspNetUsers
    Public Property Id As String
    Public Property Email As String
    Public Property EmailConfirmed As Boolean
    Public Property PasswordHash As String
    Public Property SecurityStamp As String
    Public Property PhoneNumber As String
    Public Property PhoneNumberConfirmed As Boolean
    Public Property TwoFactorEnabled As Boolean
    Public Property LockoutEndDateUtc As Nullable(Of Date)
    Public Property LockoutEnabled As Boolean
    Public Property AccessFailedCount As Integer
    Public Property UserName As String
    Public Property IsLocked As Nullable(Of Integer)
    Public Property IsEnabled As Nullable(Of Integer)
    Public Property Fullname As String
    Public Property Address As String
    Public Property Perioxi As String
    Public Property Poli As String
    Public Property Tk As String
    Public Property Afm As String
    Public Property Phone As String

    Public Overridable Property AspNetUserClaims As ICollection(Of AspNetUserClaims) = New HashSet(Of AspNetUserClaims)
    Public Overridable Property AspNetUserLogins As ICollection(Of AspNetUserLogins) = New HashSet(Of AspNetUserLogins)
    Public Overridable Property AspNetRoles As ICollection(Of AspNetRoles) = New HashSet(Of AspNetRoles)

End Class