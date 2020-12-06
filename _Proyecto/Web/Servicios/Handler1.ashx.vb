Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services

Public Class Handler1
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest



        Dim json As String = String.Empty


        Dim result As InfoReturnResult = New InfoReturnResult()
        Dim filesCollection As HttpFileCollection = Nothing

        Dim noFounded As List(Of String) = New List(Of String)()
        Dim Founded As List(Of String) = New List(Of String)()

        Dim countFounded As Integer = 0
        Dim countNoFounded As Integer = 0

        Dim notif As New resultNotifModel
        notif.asunto = context.Request.Form("asunto")
        notif.tipoMensaje = context.Request.Form("tipoMensaje")
        notif.mensaje = context.Request.Form("mensaje")
        notif.idAvisoPublico = 0

        If context.Request.Files.Count > 0 Then
            notif.filesCollection = context.Request.Files
        End If

        Dim codigo = context.Request.Form("codigo")
        Dim codigos As String() = codigo.Split(",")

        For Each item In codigos
            Dim existe As Boolean = UsuarioExiste(item)

            If existe Then
                notif.login = item
                Dim executed As Integer = EnviarMensaje(notif)

                If executed = 0 Then
                    noFounded.Add(item)
                    countNoFounded += 1
                Else
                    Founded.Add(item)
                    countFounded += 1
                End If
            Else
                noFounded.Add(item)
                countNoFounded += 1
            End If
        Next

        result.Result = CInt(HttpStatusCode.OK)
        result.descNoFoundedResult = noFounded
        result.descFoundedResult = Founded
        result.countFounded = countFounded
        result.countNoFounded = countNoFounded

        Dim finalResult As String = New JavaScriptSerializer().Serialize(result)

        context.Response.StatusCode = CInt(HttpStatusCode.OK)
        context.Response.ContentType = "text/json"
        context.Response.Write(finalResult)
        context.Response.End()


    End Sub

    Private Function UsuarioExiste(LOGIN As String) As Boolean
        Dim lnEnvioMensajes As New adAvisosMensajesOFV.AvisosMensajes
        Dim result As Boolean = False
        If lnEnvioMensajes.CONSULTA_USR_LOGIN(LOGIN) > 0 Then
            result = True
        End If
        lnEnvioMensajes = Nothing
        Return result
    End Function

    Private Function EnviarMensaje(notif As resultNotifModel)
        Dim lnEnvioMensajes As New adAvisosMensajesOFV.AvisosMensajes
        Dim idMensaje As Integer = lnEnvioMensajes.InsertaMensajes(notif.login, notif.asunto, notif.tipoMensaje, notif.mensaje)
        Dim result As Integer = 0
        lnEnvioMensajes = Nothing
        If idMensaje > 0 Then

            result = idMensaje

            If notif.filesCollection.Count > 0 Then
                For i As Integer = 0 To notif.filesCollection.Count - 1

                    Dim postedFile As HttpPostedFile = notif.filesCollection(i)
                    Dim fileName As String = Path.GetFileName(postedFile.FileName)
                    result = Adjuntar_archivos(idMensaje, postedFile, fileName)
                Next

            End If
        End If
        Return result
    End Function
    Private Function Adjuntar_archivos(IdMensaje As Integer, postedFile As HttpPostedFile, fileName As String) As Integer
        'Dim empty As String = String.Empty
        Dim nombre_archivo As String
        Dim contentType As String = String.Empty

        If postedFile.ContentLength > 0 Then
            Try
                Dim archivo As Byte()
                nombre_archivo = HttpUtility.HtmlEncode(fileName)
                contentType = postedFile.ContentType
                Using fs As Stream = postedFile.InputStream
                    Using br As BinaryReader = New BinaryReader(fs)
                        archivo = br.ReadBytes(CType(fs.Length, Integer))
                    End Using
                End Using

                Insertar_archivo(IdMensaje, nombre_archivo, contentType, archivo)
            Catch ex As Exception
                Return 0
            End Try
            Return 1
        End If


    End Function
    Private Function Insertar_archivo(Id_mensaje As Integer, nombre_archivo As String, tipo_archivo As String, archivo As Byte()) As Boolean
        Dim lnEnvioMensajes As New adAvisosMensajesOFV.AvisosMensajes
        Dim num As Integer = lnEnvioMensajes.InsertaArchivosMensajes(Id_mensaje, nombre_archivo, tipo_archivo, archivo)
        Return num > 0
    End Function
    Private Function PostedFiles(postedFile As HttpPostedFile, ByRef typeFile As String) As Byte()
        Dim array As Byte() = Nothing
        Try
            ' The following expression was wrapped in a checked-expression
            array = New Byte() {} '(myFileUpload.PostedFile.ContentLength + 1 - 1) {}
            postedFile.InputStream.Read(array, 0, postedFile.ContentLength)
            typeFile = postedFile.ContentType
        Catch ex As Exception
            'Dim text As String = "ERROR: " & ex.Message.ToString
        End Try
        Return array
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Public Class InfoReturnResult
        Public Property descNoFoundedResult As List(Of String)
        Public Property descFoundedResult As List(Of String)
        Public Property countFounded As Integer
        Public Property countNoFounded As Integer
        Public Property Result As Int32
    End Class

    Public Class resultNotifModel
        Public Property idmensaje As Integer
        Public Property login As String
        Public Property asunto As String
        Public Property fechaCreacion As DateTime
        Public Property tipoMensaje As Integer
        Public Property fechaVencto As DateTime?
        Public Property mensaje As String
        Public Property idAvisoPublico As Integer
        Public Property codigo As String()
        Public Property filesCollection As HttpFileCollection
    End Class
End Class