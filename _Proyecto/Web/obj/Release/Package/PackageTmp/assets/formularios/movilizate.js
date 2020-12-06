$(function () {

	$('#movilizateForm').submit(function (event) {
		event.preventDefault();
		if ($('#movilizateForm')[0].checkValidity() === false) {
			event.stopPropagation();
		} else {

			//Campos
			var movfecha = $("#frmmov_fecha").val();
			var movnombre = $("#frmmov_nombre").val();
			var movlugar = $("#frmmov_lugar").val();
			var movdescripcion = $("#frmmov_descripcion").val();
			var movusuario_nombre = $("#frmmov_usuario_nombre").val();
			var movusuario_correo = $("#frmmov_usuario_correo").val();
			var movusuario_telefono = $("#frmmov_usuario_telefono").val();

			if (movfecha == "" || movnombre == "" || movlugar == "" || movdescripcion == "") {
				alert("Falta información sobre la Actividad por completar");
				return false;
			}
			if (movusuario_nombre == "" || movusuario_correo == "" || movusuario_telefono == "") {
				alert("Falta información de contacto por completar");
				return false;
			}

			//Procesar
			$.ajax({
				type: "POST",
				url: "Servicios/Movilizate.aspx/Agregar",
				async: false,
				contentType: "application/json;charset=utf-8",
				data: JSON.stringify({
					Fecha: movfecha,
					Nombre: movnombre,
					Lugar: movlugar,
					Descripcion: movdescripcion,
					UsuarioNombre: movusuario_nombre,
					UsuarioCorreo: movusuario_correo,
					UsuarioTelefono: movusuario_telefono
				}),
				dataType: "json",
				success: function (data) {
					//we need to parse it to JSON 
					dataL = $.parseJSON(data.d);
					alert(dataL.Mensaje);
					if (dataL.ConError == false) {
						//Limpiar
						//$("#movilizateForm").trigger("reset");
						$("#frmmov_fecha").val("");
						$("#frmmov_nombre").val("");
						$("#frmmov_lugar").val("");
						$("#frmmov_descripcion").val("");
						$("#frmmov_usuario_nombre").val("");
						$("#frmmov_usuario_correo").val("");
						$("#frmmov_usuario_telefono").val("");
						//Cerrar Popup
						$('#portfolioModal4').modal('hide');
					}
				},
				error: function (errordata) {
					console.log(errordata);
				}

			});
			return false;

		}
	});

	$("#MovilizateBtnEnviarXXX").click(function (evt) {
		evt.preventDefault();
	});

});

function Movilizate_ListaEventos(obj) {

	var myHtml =
		'<div class="table-responsive-sm">' +
		'<table class="table table-striped table-dark">' +
		'<thead class="thead-light">' +
		'	<tr>' +
		'		<th scope="col">#</th>' +
		'		<th scope="col">Actividad</th>' +
		'		<th scope="col">Fecha</th>' +
		'		<th scope="col"></th>' +
		'	</tr>' +
		'</thead>' +
		'<tbody>';

	$.ajax({
		type: "POST",
		url: "Servicios/Movilizate.aspx/Lista",
		async: true,
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			//we need to parse it to JSON 
			dataL = $.parseJSON(data.d);
			for (let i = 0; i < dataL.length; i++) {
				//data - target=".movilizateEvento"
				myHtml +=
					'<tr>' +
					'	<th scope="row">' + dataL[i].MovilizateID + '</th>' +
					'	<td>' + dataL[i].Nombre + '</td>' +
					'	<td>' + dataL[i].Fecha + '</td>' +
					'	<td><a href="#" onclick="Movilizate_ListaEventosDetalle(' + dataL[i].MovilizateID + '); return false;">Más Detalle</a></td>' +
					'</tr>';
			}
			myHtml += '</div>';
			$(obj).html(myHtml);
		},
		error: function (errordata) {
			console.log(errordata);
		}
	});
}
function Movilizate_ListaEventosDetalle(id) {
	$.ajax({
		type: "POST",
		url: "Servicios/Movilizate.aspx/ListaDetalle",
		data: JSON.stringify({ MovilizateID: id }),
		async: true,
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			//we need to parse it to JSON 
			dataL = $.parseJSON(data.d);
			if (dataL.length > 0) {
				$("#movilizateEventoDetalleNombre").val(dataL[0].Nombre);
				$("#movilizateEventoDetalleDescripcion").val(dataL[0].Descripcion);
				$("#movilizateEventoDetalleLugar").val(dataL[0].Lugar);
				$("#movilizateEventoDetalleUsuarioNombre").val(dataL[0].UsuarioNombre);
				$("#movilizateEventoDetalleCorreo").val(dataL[0].UsuarioCorreo);
				$("#movilizateEventoDetalleTelefono").val(dataL[0].UsuarioTelefono);
				$('#movilizateEventoDetallePopup').modal('show');
			}
		},
		error: function (errordata) {
			console.log(errordata);
		}
	});
}
