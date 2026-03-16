using Domain.Entities;
using Refit;

namespace Infrastructure.Integration;

public interface IThemeApi
{
    [Get("themes")]
    Task<List<ThemeDto>> GetThemes([Header("apikey")] string apiKey
    );

}