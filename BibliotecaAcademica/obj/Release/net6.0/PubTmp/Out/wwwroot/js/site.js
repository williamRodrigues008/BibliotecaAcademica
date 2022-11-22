async function AbrirTelaAdiconarLivro() {
    $(document).ready(function () {
        $(".adicionarLivro").click(function () {
            $("#detalhesLivro").modal("show")
            $("#TituloDaTela").html("Adicionar Novo Livro")

        })
    })

    try {
        await $.ajax({
            type: 'GET',
            url: '/Home/AdicionarLivro',
            success: function (data) {
                $(".modal-body").html(data)
            },
            error(xhr, status, error) { }
        })


    } catch (error) {
        alert("Erro na requisição para abrir tela de cadastro de usuário", error)
    }
}

async function AbrirTelaDeDetalhes(id) {
    console.log(id)
    $(document).ready(function () {
        $(".telaDeAdicaoDeLivro").click(function () {
            $("#detalhesLivro").modal("show")
            $("#TituloDaTela").html("Detalhes do Livro")
        })
    })

    try {
        await $.ajax({
            type: 'Post',
            url: '/Home/DetalhesDoLivro',
            data: {id: id},
            success: function (data) {
                $(".modal-body").html(data)
            },
            error(xhr, status, error) { }
        })
    } catch (error) {
        alert("Erro na requisição para abrir tela de cadastro de usuário", error)
    }
}