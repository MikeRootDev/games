using AutoMapper;
using Games.Minesweeper.Domain.Models;
using Games.Minesweeper.API.Responses;

namespace Games.Minesweeper.API.Profiles
{
  public class ResponseProfiles : Profile
  {
    public ResponseProfiles()
    {
      CreateMap<Game, GetGamesResponse>().ReverseMap();
    }
  }
}
