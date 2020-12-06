$(function () {

	$('#reportarForm').submit(function (event) {
		event.preventDefault();
		if ($('#reportarForm')[0].checkValidity() === false) {
			event.stopPropagation();
		} else {

			// get values from FORM
			//var file1 = $("#evidencia1")[0].files[0];
			//var file2 = $("#evidencia2")[0].files[0];

			var problema = $("#txtproblema").val();
			var ubicacion_lat = $("#maphf_lat").val();
			var ubicacion_lon = $("#maphf_lon").val();
			var nombre = $("#txtname").val();
			var correo = $("#txtemail").val();
			var ubicacion = ubicacion_lat + "," + ubicacion_lon;
			/*if (problema == "") {
				alert("Debe completar la Descripción del Problema");
				$("#txtproblema").focus();
				return false;
			}
			if (nombre == "") {
				alert("Debe completar el Nombre");
				$("#txtname").focus();
				return false;
			}
			if (correo == "") {
				alert("Debe completar el Correo");
				$("#txtemail").focus();
				return false;
			}*/
			if (ubicacion_lat == "" || ubicacion_lon == "") {
				alert("Debe seleccionar el punto en el Mapa");
				return false;
			}

			//var formData = new FormData();
			//formData.append("problema", problema);
			//formData.append("ubicacion", ubicacion);
			//formData.append("usuarion_nombre", nombre);
			//formData.append("usuarion_correo", correo);
			//formData.append("archivo1", file1);
			//formData.append("archivo2", file2);

			$.ajax({
				type: "POST",
				url: "Servicios/Reporta.aspx/Agregar",
				async: false,
				contentType: "application/json;charset=utf-8",
				data: JSON.stringify({
					Problema: problema,
					Ubicacion: ubicacion,
					UsuarioNombre: nombre,
					UsuarioCorreo: correo
				}),
				dataType: "json",
				success: function (data) {
					//we need to parse it to JSON 
					dataL = $.parseJSON(data.d);
					alert(dataL.Mensaje);
					if (dataL.ConError == false) {
						//Limpiar Campos
						$("#txtproblema").val("");
						$("#maphf_lat").val("");
						$("#maphf_lon").val("");
						$("#txtname").val("");
						$("#txtemail").val("");
						//Cerrar Popup
						$('#portfolioModal1').modal('hide');
					}
				},
				error: function (errordata) {
					console.log(errordata);
				}
			});
			return false;

		}
		//$('your-form-id').addClass('was-validated');
	});
	$("#ReportarBtnEnviarXXX").click(function () {
		event.preventDefault(); // prevent default submit behaviour
	});

});