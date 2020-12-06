using System;
using System.Web.Services;

namespace TuYaque
{
	public partial class Movilizate : System.Web.UI.Page
	{
		[WebMethod]
		public static string Agregar(
			string Fecha,
			string Nombre,
			string Lugar,
			string Descripcion,
			string UsuarioNombre, string UsuarioCorreo, string UsuarioTelefono
		)
		{
			DateTime vFecha;
			if(!DateTime.TryParseExact(
					Fecha, "dd/MM/yyyy", null, 
					System.Globalization.DateTimeStyles.None, out vFecha)
				)
			{
				return "Error, formato de fecha inválida";
			}

			string vMsg;
			bool bien =
				DataAccess.Datos.MovilizateAgregar(
					out vMsg, vFecha, Nombre, Lugar, Descripcion,
					UsuarioNombre, UsuarioCorreo, UsuarioTelefono
				);
			if (bien)
			{
				return "Actividad Guardada";
			}
			if (!String.IsNullOrEmpty(vMsg))
			{
				return "Error: " + vMsg;
			}
			return "La Actividad no pudo guardarse";
		}

	}
}