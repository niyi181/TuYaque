using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;

namespace TuYaque
{

	[Serializable]
	public class Respuesta
	{
		public string Data;
		public bool ConError;
		public string Mensaje;
	}

	public partial class Movilizate : System.Web.UI.Page
	{

		[Serializable]
		public class Actividades
		{
			public decimal MovilizateID;
			public string Nombre;
			public string Lugar;
			public string Fecha;
			public string Descripcion;
			public string UsuarioNombre;
			public string UsuarioCorreo;
			public string UsuarioTelefono;

		}

		[WebMethod]
		public static string Lista()
		{
			List<Actividades> lst = new List<Actividades>();
			string vMsg = string.Empty;
			TUYAQUEDB.MovilizateDataTable dt = DataAccess.Datos.MovilizateObtener(out vMsg);
			if(dt != null || dt.Rows.Count > 0)
			{
				foreach (TUYAQUEDB.MovilizateRow item in dt.Rows)
				{
					Actividades act = new Actividades();
					act.MovilizateID = item.MovilizateID;
					act.Nombre = item.Nombre;
					act.Lugar = item.Lugar;
					act.Descripcion = item.Descripcion;
					act.Fecha = item.Fecha.ToString("dd/MM/yyyy");
					act.UsuarioNombre = item.UsuarioNombre;
					act.UsuarioCorreo = item.UsuarioCorreo;
					act.UsuarioTelefono = item.UsuarioTelefono;
					lst.Add(act);
				}
			}
			return JsonConvert.SerializeObject(lst);
		}

		[WebMethod]
		public static string ListaDetalle(decimal MovilizateID)
		{
			List<Actividades> lst = new List<Actividades>();
			string vMsg = string.Empty;
			TUYAQUEDB.MovilizateDataTable dt = DataAccess.Datos.MovilizateObtener(out vMsg, MovilizateID);
			if (dt != null || dt.Rows.Count > 0)
			{
				foreach (TUYAQUEDB.MovilizateRow item in dt.Rows)
				{
					Actividades act = new Actividades();
					act.MovilizateID = item.MovilizateID;
					act.Nombre = item.Nombre;
					act.Lugar = item.Lugar;
					act.Descripcion = item.Descripcion;
					act.Fecha = item.Fecha.ToString("dd/MM/yyyy");
					act.UsuarioNombre = item.UsuarioNombre;
					act.UsuarioCorreo = item.UsuarioCorreo;
					act.UsuarioTelefono = item.UsuarioTelefono;
					lst.Add(act);
				}
			}
			return JsonConvert.SerializeObject(lst);
		}

		[WebMethod]
		public static string Agregar(
			string Fecha,
			string Nombre,
			string Lugar,
			string Descripcion,
			string UsuarioNombre, string UsuarioCorreo, string UsuarioTelefono
		)
		{
			Respuesta rp = new Respuesta();
			DateTime vFecha;
			if(!DateTime.TryParseExact(
					Fecha, "dd/MM/yyyy", null, 
					System.Globalization.DateTimeStyles.None, out vFecha)
				)
			{
				rp.ConError = true;
				rp.Mensaje = "Error, formato de fecha inválida!";
				return JsonConvert.SerializeObject(rp);
			}
			if(vFecha <= DateTime.Now.Date)
			{
				rp.ConError = true;
				rp.Mensaje = "La fecha debe ser mayor al día actual!";
				return JsonConvert.SerializeObject(rp);
			}

			string vMsg;
			bool bien =
				DataAccess.Datos.MovilizateAgregar(
					out vMsg, vFecha, Nombre, Lugar, Descripcion,
					UsuarioNombre, UsuarioCorreo, UsuarioTelefono
				);
			if (bien)
			{
				rp.Mensaje = "Actividad Guardada";
				return JsonConvert.SerializeObject(rp);
			}
			if (!String.IsNullOrEmpty(vMsg))
			{
				rp.ConError = true;
				rp.Mensaje = "Error: " + vMsg;
				return JsonConvert.SerializeObject(rp);
			}
			rp.ConError = true;
			rp.Mensaje = "La Actividad no pudo guardarse";
			return JsonConvert.SerializeObject(rp);
		}

	}
}