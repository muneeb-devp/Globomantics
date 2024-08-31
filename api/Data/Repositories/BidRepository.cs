using Globomantics.Data.DTO;
using Globomantics.Models;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Data.Repositories;

public interface IBidRepository
{
  public Task<List<BidDTO>> Get(int houseId);
  public Task<BidDTO> Add(BidDTO bid);
}

public class BidRepository : IBidRepository
{
  private HouseDbContext context;

  public BidRepository(HouseDbContext ctx) => context = ctx;

  public async Task<List<BidDTO>> Get(int houseId)
  {
    return await context.Bids.Where(b => b.HouseId == houseId)
                             .Select(b => new BidDTO(b.Id, b.HouseId, b.Bidder, b.Amount))
                             .ToListAsync();
  }

  public async Task<BidDTO> Add(BidDTO bid)
  {
    var entity = new Bid
    {
      HouseId = bid.HouseId,
      Bidder = bid.Bidder,
      Amount = bid.Amount
    };

    await context.Bids.AddAsync(entity);
    await context.SaveChangesAsync();

    return new BidDTO(
      entity.Id,
      entity.HouseId,
      entity.Bidder,
      entity.Amount
    );
  }
}