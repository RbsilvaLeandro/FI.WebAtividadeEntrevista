
$(document).ready(function () {   
    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable({
            paging: true, //Enable paging           
            pageSize: 5, //Set page size (default: 10)           
            sorting: true, //Enable sorting
            defaultSorting: 'Nome ASC', //Set default sorting            

            actions: {
                listAction: urlBeneficiarioList,
            },
            fields: {
                CPF: {
                    title: 'CPF',
                    width: '15%'
                },
                Nome: {
                    title: 'Nome',
                    width: '65%'
                },
                Alterar: {
                    title: 'Ações',
                    width: '20%',
                    display: function (data) {
                        return '<button onclick="AlterarBeneficiario(\'' + urlAlteracao + '/' + data.record.Id + '\');" class="btn btn-primary btn-sm">Alterar</button> ' +
                            '<button  onclick="ExcluirBeneficiario(\'' + urlDelete + '/' + data.record.Id + '\');" class="btn btn-primary btn-sm" id="BntExcBeneficiario">Excluir</button> ';
                    }
                }
            }
        });

    //Load student list from server
    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable('load');  
   
})