using Microsoft.AspNetCore.Mvc;

//Responsavel por criar a plicação - fica escutando o que o usuário quer acessar
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//-----------------------------------------------


//End Point
app.MapPost("/aluno", (Aluno aluno)=>{
    RepositorioAlunos.AddAluno(aluno);
});

app.MapGet("/aluno/{nome}", ([FromRoute] string nome)=>{
    var aluno = RepositorioAlunos.BuscarAluno(nome);
    return aluno;
});

//Inicia a aplicação
app.Run();

public class Aluno {
    public int matricula { get; set; }
    public string nome { get; set; }
}

public static class RepositorioAlunos {
    //Criando uma lista de alunos
    public static List<Aluno> Alunos { get; set; }

    //Método para adicionar aluno na lista
    public static void AddAluno(Aluno aluno){
        //Verifica se a lista está vazia
        if (Alunos == null) {
            //Inicializa a lista
            Alunos = new List<Aluno>();
        }
        //Adiciona aluno na lista
        Alunos.Add(aluno);
    }

    //Método para buscar aluno na lista
    public static Aluno BuscarAluno(string nome){
        return Alunos.FirstOrDefault(a => a.nome == nome);
    }
}
