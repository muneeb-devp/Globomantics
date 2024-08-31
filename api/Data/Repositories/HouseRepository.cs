using Globomantics.Data.DTO;
using Globomantics.Models;
using Microsoft.EntityFrameworkCore;

namespace Globomantics.Data.Repositories;

public interface IHouseRepository
{
  public Task<List<HouseDTO>> GetAll();
  public Task<HouseDetailDTO> Get(int id);
  public Task<HouseDetailDTO> Add(HouseDetailDTO house);
  public Task<HouseDetailDTO> Update(HouseDetailDTO house);
  public Task Delete(int houseId);
}

public class HouseRepository : IHouseRepository
{
  private HouseDbContext context { get; init; }

  public HouseRepository(HouseDbContext ctx) => context = ctx;

  public async Task<List<HouseDTO>> GetAll() => await context.Houses.Select(
    h => new HouseDTO(h.Id, h.Address, h.Country, h.Price)
  ).ToListAsync();

  public async Task<HouseDetailDTO> Get(int id)
  {
    var house = await context.Houses.FirstOrDefaultAsync(h => h.Id == id);

    if (house == null) return null;

    return new HouseDetailDTO(
      house.Id,
      house.Address,
      house.Country,
      house.Price,
      house.Description,
      house.Photo
    );
  }

  public async Task<HouseDetailDTO> Add(HouseDetailDTO houseDto)
  {
    var newHouse = new House();
    DtoToEntity(houseDto, newHouse);

    await context.Houses.AddAsync(newHouse);
    await context.SaveChangesAsync();

    return EntityToDto(newHouse);
  }

  public async Task<HouseDetailDTO> Update(HouseDetailDTO dto)
  {
    var entity = await context.Houses.FindAsync(dto.Id);

    if (entity == null) throw new ArgumentException($"Error updating house with id ({dto.Id})");

    DtoToEntity(dto, entity);

    context.Entry(entity).State = EntityState.Modified;
    await context.SaveChangesAsync();

    return EntityToDto(entity);
  }

  public async Task Delete(int houseId)
  {
    var houseEntity = await context.Houses.FindAsync(houseId);

    if (houseEntity == null) throw new ArgumentException($"Error deleting house with id ({houseId})");

    context.Houses.Remove(houseEntity);
    await context.SaveChangesAsync();
  }

  private static void DtoToEntity(HouseDetailDTO dto, House house)
  {
    house.Address = dto.Address;
    house.Country = dto.Country;
    house.Description = dto.Description;
    house.Price = dto.Price;
    house.Photo = dto.Photo;
  }

  private static HouseDetailDTO EntityToDto(House house)
  {
    return new HouseDetailDTO
    (
      house.Id,
      house.Address,
      house.Country,
      house.Price,
      house.Description,
      house.Photo
    );
  }
}