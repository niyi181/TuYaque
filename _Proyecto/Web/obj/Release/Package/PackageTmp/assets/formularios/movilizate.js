$(function () {

	/*
	$('form[id="movilizateForm"]').find('input,select,textarea').not('[type=submit]').jqBootstrapValidation({

		submitSuccess: function ($form, event) {
			event.preventDefault(); // prevent default submit behaviour
		},
		error: function (evt) {
			consol.log("Error");
		}

	});
	*/

	$("#MovilizateBtnEnviar").click(function (evt) {
		evt.preventDefault();
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
				alert(data.d);
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
			},
			error: function (errordata) {
				console.log(errordata);
			}

		});
		return false;
	});

});

