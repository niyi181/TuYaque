using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;

namespace TuYaque
{
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