function municipio(){
    $("#tabla").DataTable({
        	"ajax": "php/municipio/controladorMunicipio.php?accion=listar",
        	"columns": [
	            { "data": "muni_codi"} ,
	            { "data": "muni_nomb" },
	            { "data": "depa_nomb" },
                {
                    "data": "muni_codi",
                    render: function (data) {
                        return '<a href="#" data-codigo="'+ data + ' " class="btn btn-danger btn-sm borrar"> <i class="fa fa-trash"></i></a>' +
                               '<a href="#" data-codigo="'+ data + ' " class="btn btn-info btn-sm editar"> <i class="fa fa-edit"></i></a>';
                    }
                }
        	]
        })

    $("#contenido").on("click","a.editar",function(){
        $("#titulo").html("Editar Municipio");
        //Recupera datos del formulario
        var codigo = $(this).data("codigo");
        /*$.ajax({
            type:"post",
            url:"./php/comuna/editarComuna.php",
            data:"codigo=" + codigo,
            dataType:"html"
            }) .done(function( result ) {
                $("#contenido").html(result);
            });*/
    });
}
