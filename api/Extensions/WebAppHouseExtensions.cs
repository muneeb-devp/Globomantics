using Globomantics.Data.DTO;
using Globomantics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;

namespace Globomantics.Extensions;

public static class WebAppHouseExtensions
{
  public static void MapHouseEndpoints(this WebApplication app)
  {
    app.MapGet("/houses", (IHouseRepository repo) => repo.GetAll())
    .Produces<HouseDTO>(StatusCodes.Status200OK);


    app.MapGet("/houses/{id}", async (int id, IHouseRepository repo) =>
        {
          var house = await repo.Get(id);

          if (house == null) return Results.Problem($"House with id({id}) not found", statusCode: 404);

          return Results.Ok(house);
        }
    ).ProducesProblem(StatusCodes.Status404NotFound)
     .Produces<HouseDetailDTO>(StatusCodes.Status200OK);

    app.MapPost("/houses", async ([FromBody] HouseDetailDTO house, IHouseRepository repo) =>
        {
          if (!MiniValidator.TryValidate(house, out var errors)) return Results.ValidationProblem(errors);

          var newHouse = repo.Add(house);
          return Results.Created($"/house/{house.Id}", newHouse);
        }
    ).Produces<HouseDetailDTO>(StatusCodes.Status201Created)
     .ProducesValidationProblem();

    app.MapPut("/houses", async ([FromBody] HouseDetailDTO house, IHouseRepository repo) =>
        {
          if (!MiniValidator.TryValidate(house, out var errors)) return Results.ValidationProblem(errors);

          if (repo.Get(house.Id) == null) return Results.Problem($"Unable to find house with id ({house.Id})", statusCode: 404);

          var updatedHouse = repo.Update(house);
          return Results.Created($"/house/{updatedHouse.Id}", updatedHouse);
        }
    ).ProducesProblem(StatusCodes.Status404NotFound)
     .Produces<HouseDetailDTO>(StatusCodes.Status200OK)
     .ProducesValidationProblem();

    app.MapDelete("/houses/{id:int}", async (int id, IHouseRepository repo) =>
        {
          if (await repo.Get(id) == null) return Results.NotFound($"Unable to find house with id ({id})");

          await repo.Delete(id);
          return Results.Ok();
        }
    ).ProducesProblem(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status200OK);
  }
}