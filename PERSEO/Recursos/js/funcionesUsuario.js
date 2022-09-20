function usuario(){    
    $("#login-form").on('submit',function(e){    
        e.preventDefault();
        var datos = $(this).serialize();
        //console.log(datos)
        $.ajax({
            type:"post",
            url:"./Controlador/controladorUsuario.php",
            data: datos,
            dataType:"json"
          }).done(function( resultado ) {
            if(resultado.respuesta == "existe"){
                if(resultado.rol=="1"){
                location.href ="adminper.php";}
            }
            else{
                swal({
                    position: 'center',
                    type: 'error',
                    title: 'Usuario y/o Password incorrecto',
                    showConfirmButton: false,
                    timer: 1500
                }),
                function() {
                    $("#usuario").focus().select();
                };                
              }
        });
    })
}
