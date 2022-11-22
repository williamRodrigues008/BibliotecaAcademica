$("#enderecoImagem").change(function () {
    if($(this).val()){
        var imagemPerfil = this.files[0];
        var leitorDaImagem = new FileReader();
        leitorDaImagem.onload = function(resultado){
            $(".capa").html(`<img src='${resultado.target.result}' class='imagemDeCapa'/>`)
        }
        leitorDaImagem.readAsDataURL(imagemPerfil);
    }
})
