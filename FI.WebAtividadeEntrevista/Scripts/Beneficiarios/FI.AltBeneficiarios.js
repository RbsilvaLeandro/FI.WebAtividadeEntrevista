$(document).ready(function () {

    $(".navbar").remove();
    $("hr").remove();
    $("footer").remove();
    $("#CPFBeneficiario").mask("###.###.###-##");

    if (obj) {
        $('#formCadastroBeneficiario #NomeBeneficiario').val(obj.Nome);
        $('#formCadastroBeneficiario #CPFBeneficiario').val(obj.CPF);                   
    }

    $('#formCadastroBeneficiario').submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#NomeBeneficiario").val(),
                "CPF": $(this).find("#CPFBeneficiario").val()                
            },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r)
                    $("#formCadastroBeneficiario")[0].reset();
                    Redirect('GET',urlRetorno);
                }
        });
    })  
})


function Redirect(Method, url) {

    $.ajax({
        type: Method,
        url: url,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            debugger;
            $('#Content').html(data);
        },
        error: function () {
            alert("Houve uma falha realizar esta operação.");
        }
    });
}

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog modal-sm">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}
