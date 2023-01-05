using Dapper.Contrib.Extensions;
using TarefasAPIDapper.Data;
using static TarefasAPIDapper.Data.TarefaContext;

namespace TarefasAPIDapper.EndPoints
{
    public static class TarefasEndpoints
    {
        
        public static void MapTarefasEndpoints(this WebApplication app){
            app.MapGet("/", () => $"Bem vindo aTarefas API - { DateTime.Now}");

            app.MapGet("/tarefas", async(GetConnection connectionGetter) =>
            {
                using var connection = await connectionGetter();
                var tarefas = connection.GetAll<Tarefa>().ToList();
                if(tarefas is null)
                    return Results.NotFound();
                return Results.Ok(tarefas);
            });


            app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var connection = await connectionGetter();
                //var tarefas = connection.Get<Tarefa>(id);
                //if (tarefas is null)
                //    return Results.NotFound();
                //return Results.Ok(tarefas);

                return connection.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa)
                    : Results.NotFound();
            });

            app.MapPost("/tarefas", async(GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var connection = await connectionGetter();
                var id = connection.Insert(tarefa);
                return Results.Created($"/tarefas/{id}", tarefa);
            }
            );

            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var connection = await connectionGetter();
                var id = connection.Update(tarefa);
                return Results.Ok();
            }
            );
            app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var connection = await connectionGetter();
                var tarefas = connection.Get<Tarefa>(id);
                if (tarefas is null)
                    return Results.NotFound();
                connection.Delete(tarefas);
                return Results.Ok(tarefas);


            });
        }



    }
}
