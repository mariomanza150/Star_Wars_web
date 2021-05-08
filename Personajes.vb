Imports System.Data.SqlClient

Public Class Personajes
    Private _Id As String
    Private _Nombre As String
    Private _Faccion As String
    Private _Poder As String
    Private _Nacimiento As String

    Public Property Id As String
        Get
            Return _Id
        End Get
        Set
            _Id = Value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set
            _Nombre = Value
        End Set
    End Property

    Public Property Faccion As String
        Get
            Return _Faccion
        End Get
        Set
            _Faccion = Value
        End Set
    End Property

    Public Property Poder As String
        Get
            Return _Poder
        End Get
        Set
            _Poder = Value
        End Set
    End Property

    Public Property Nacimiento As String
        Get
            Return _Nacimiento
        End Get
        Set
            _Nacimiento = Value
        End Set
    End Property

#Region "Definicion de Metodos"
    Public Function PersonajeAlta() As Boolean
        Dim cnx As New SqlConnection("Server=DESKTOP-SLN622U; database=StarWars; Integrated Security=true")
        Dim cmd As New SqlCommand("dbo.PersonajeAlta", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id", _Id))
        cmd.Parameters.Add(New SqlParameter("@Nombre", _Nombre))
        cmd.Parameters.Add(New SqlParameter("@Faccion", _Faccion))
        cmd.Parameters.Add(New SqlParameter("@Poder", _Poder))
        cmd.Parameters.Add(New SqlParameter("@Nacimiento", _Nacimiento))
        cnx.Open()
        cmd.ExecuteScalar()
        cnx.Close()
        Return True
    End Function

    Public Function PersonajeBaja() As Boolean
        Dim cnx As New SqlConnection("Server=DESKTOP-SLN622U; database=StarWars; Integrated Security=true")
        Dim cmd As New SqlCommand("dbo.PersonajeBaja", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id", _Id))
        cnx.Open()
        cmd.ExecuteScalar()
        cnx.Close()
        Return True
    End Function

    Public Function PersonajeCambio() As Boolean
        Dim cnx As New SqlConnection("Server=DESKTOP-SLN622U; database=StarWars; Integrated Security=true")
        Dim cmd As New SqlCommand("dbo.PersonajeCambio", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id", _Id))
        cmd.Parameters.Add(New SqlParameter("@Nombre", _Nombre))
        cmd.Parameters.Add(New SqlParameter("@Faccion", _Faccion))
        cmd.Parameters.Add(New SqlParameter("@Poder", _Poder))
        cmd.Parameters.Add(New SqlParameter("@Nacimiento", _Nacimiento))
        cnx.Open()
        cmd.ExecuteScalar()
        cnx.Close()
        Return True
    End Function

    Public Function PersonajeConsulta() As String()
        Dim cnx As New SqlConnection("Server=DESKTOP-SLN622U; database=StarWars; Integrated Security=true")
        Dim cmd As New SqlCommand("dbo.PersonajeConsulta", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        Dim nombre, faccion, poder, nacimiento As String
        cmd.Parameters.Add(New SqlParameter("@Id", _Id))
        cnx.Open()
        Dim leer As SqlDataReader
        leer = cmd.ExecuteReader
        If leer.Read() Then
            Console.WriteLine(leer(1))
            nombre = leer(1).ToString()
            faccion = leer(2).ToString()
            poder = leer(3).ToString()
            nacimiento = leer(4).ToString()
            cnx.Close()
            Return New String() {nombre, faccion, poder, nacimiento}
        End If
        Return New String() {"empty"}
    End Function
#End Region
End Class
