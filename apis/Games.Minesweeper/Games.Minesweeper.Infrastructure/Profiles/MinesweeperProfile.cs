using AutoMapper;
using Games.Minesweeper.Infrastructure.Dtos;
using Games.Minesweeper.Domain.Models;

namespace Games.Minesweeper.Infrastructure.Profiles
{
  public class MinesweeperProfile : Profile
  {
    public MinesweeperProfile()
    {
      CreateMap<GameDto, Game>().ReverseMap();
    } 
  }
}
