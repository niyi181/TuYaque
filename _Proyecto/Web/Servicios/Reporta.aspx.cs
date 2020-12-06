using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Services;

namespace TuYaque
{
	public partial class Reporta : System.Web.UI.Page
	{

		[WebMethod]
		public static string xAgregar(HttpContext context)
		{
			string vMsg = string.Empty;
			//bool bien = 
			//	DataAccess.Datos.ReporteAgregar(
			//		out vMsg, Problema, Ubicacion, UsuarioNombre, UsuarioCorreo,
			//		Archivo1, Archivo2
			//	);
			//if (bien)
			//{
			//	return "Reporte Guardado";
			//}
			if (!String.IsNullOrEmpty(vMsg))
			{
				return "Error: " + vMsg;
			}
			return "El reporte no pudo ser guardado";
		}

		[WebMethod]
		public static string Agregar(
			string Problema, string Ubicacion,
			string UsuarioNombre,
			string UsuarioCorreo
		)
		{
			Respuesta rp = new Respuesta();
			string vMsg;
			bool bien =
				DataAccess.Datos.ReporteAgregar(
					out vMsg, Problema, Ubicacion, UsuarioNombre, UsuarioCorreo,
					null, null
				);
			if (bien)
			{
				rp.Mensaje = "Reporte Guardado";
				return JsonConvert.SerializeObject(rp);
			}
			if (!String.IsNullOrEmpty(vMsg))
			{
				rp.ConError = true;
				rp.Mensaje = "Error: " + vMsg;
				return JsonConvert.SerializeObject(rp);
			}
			rp.ConError = true;
			rp.Mensaje = "El reporte no pudo ser guardado";
			return JsonConvert.SerializeObject(rp);
		}

	}
}