using Globomantics.Data.DTO;
using Globomantics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;

namespace Globomantics.Extensions;

public static class WebAppBidExtensions
{
  public static void MapBidEndpoints(this WebApplication app)
  {
    app.MapGet("/houses/{houseId:int}/bids", async (int houseId, IHouseRepository houseRepo, IBidRepository bidRepo) =>
      {
        if (await houseRepo.Get(houseId) == null) return Results.Problem($"Unable to find house with Id ({houseId})", statusCode: StatusCodes.Status404NotFound);

        var bids = await bidRepo.Get(houseId);

        return Results.Ok(bids);
      }
    ).ProducesProblem(StatusCodes.Status404NotFound)
     .Produces(StatusCodes.Status200OK);

    app.MapPost("/houses/{houseId:int}/bids", async (int houseId, [FromBody] BidDTO bid, IBidRepository repo) =>
    {
      if (bid.HouseId != houseId) return Results.Problem($"No match!", statusCode: StatusCodes.Status400BadRequest);
      if (!MiniValidator.TryValidate(bid, out var errors)) return Results.ValidationProblem(errors);

      var newBid = await repo.Add(bid);

      return Results.Created($"/houses/{newBid.HouseId}/bids", newBid);
    }
    ).ProducesProblem(StatusCodes.Status400BadRequest)
     .Produces<BidDTO>(StatusCodes.Status201Created)
     .ProducesValidationProblem();
  }
}