using System;
using System.Data;

namespace DataAccess
{
	public class Datos
	{

		public static bool ReporteAgregar(
			out string Msg,
			string Problema,
			string Ubicacion,
			string UsuarioNombre, string UsuarioCorreo,
			string UbicacionManual,
			byte[] archivo1,
			byte[] archivo2
		)
		{
			Msg = string.Empty;
			try
			{
				TUYAQUEDBTableAdapters.ReportesUsuariosTableAdapter ta =
					new TUYAQUEDBTableAdapters.ReportesUsuariosTableAdapter();

				TUYAQUEDB.ReportesUsuariosDataTable dt =
					ta.Agregar(
						Problema, Ubicacion, UsuarioNombre, UsuarioCorreo,
						UbicacionManual
					);
				if (dt == null || dt.Rows.Count == 0) return false;

				TUYAQUEDB.ReportesUsuariosRow dr = (TUYAQUEDB.ReportesUsuariosRow)dt.Rows[0];
				decimal recid = dr.ReporteID;
				if (recid > 0)
				{
					// Guardar Archivos
					if (archivo1 != null && archivo1.Length > 0)
					{
						TUYAQUEDBTableAdapters.ReportesUsuariosEvidenciasTableAdapter tE =
							new TUYAQUEDBTableAdapters.ReportesUsuariosEvidenciasTableAdapter();
						tE.Insert(recid, archivo1);
					}
					if (archivo2 != null && archivo2.Length > 0)
					{
						TUYAQUEDBTableAdapters.ReportesUsuariosEvidenciasTableAdapter tE =
							new TUYAQUEDBTableAdapters.ReportesUsuariosEvidenciasTableAdapter();
						tE.Insert(recid, archivo1);
					}
				}
			}
			catch (Exception ex)
			{
				Msg = ex.Message;
				return false;
			}
			return true;
		}

		public static TUYAQUEDB.MovilizateDataTable MovilizateObtener(
			out string Msg,
			decimal MovilizateID = 0
		)
		{
			Msg = string.Empty;
			TUYAQUEDB.MovilizateDataTable dt = new TUYAQUEDB.MovilizateDataTable();
			try
			{
				TUYAQUEDBTableAdapters.MovilizateTableAdapter ta =
				new TUYAQUEDBTableAdapters.MovilizateTableAdapter();
				if(MovilizateID == 0)
				{
					ta.Fill(dt);
				}
				else
				{
					dt = ta.ObtenerDetalle(MovilizateID);
				}
			} catch (Exception ex)
			{
				Msg = ex.Message;
			}
			return dt;
		}

		public static bool MovilizateAgregar(
			out string Msg,
			DateTime Fecha,
			string Nombre,
			string Lugar,
			string Descripcion,
			string UsuarioNombre, string UsuarioCorreo, string UsuarioTelefono
		)
		{
			Msg = string.Empty;
			try
			{
				TUYAQUEDBTableAdapters.MovilizateTableAdapter ta =
					new TUYAQUEDBTableAdapters.MovilizateTableAdapter();
				decimal recid =
					ta.Insert(
						Nombre, Lugar, Fecha, Descripcion,
						UsuarioNombre, UsuarioCorreo, UsuarioTelefono,
						null, null
					);
				if (recid <= 0) return false;
			}
			catch (Exception ex)
			{
				Msg = ex.Message;
				return false;
			}
			return true;
		}

	}

}
