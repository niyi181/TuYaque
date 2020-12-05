

$(function () {

	$("#ReportarBtnEnviar").click(function () {
		alert("Llego");
		$.ajax({
			type: "POST",
			url: "Reporta.aspx/Obtener",
			contentType: "application/json;charset=utf-8",
			/*data: '{name:"' + $("#txtName").val() + '"}',*/
			dataType: "json",
			success: function (data) {
				alert(data.d);
			},
			error: function (errordata) {
				console.log(errordata);
			}
		});
		return false;
	});

});
