create table Livros(
IdLivro int primary key identity,
Titulo Varchar(50) not null,
Autor varchar(50) null,
Lancamento datetime null,
Genero varchar(30) null
)