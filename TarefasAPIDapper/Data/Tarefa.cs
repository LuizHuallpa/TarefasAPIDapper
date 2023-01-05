using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasAPIDapper.Data;

    [Table("Tarefas")]
    public record Tarefa(int Id, string Atividade, string Status);


