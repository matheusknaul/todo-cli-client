using Application.Interfaces;
using Domain.Entities;
using Refit;

namespace Infrastructure.Persistence
{
    public class ThemeRepository : IThemeRepository
    {


        public Task CreateTheme(Theme theme)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTheme(int theme)
        {
            throw new NotImplementedException();
        }

        public Task<List<Theme>> GetPublicThemes()
        {
            throw new NotImplementedException();
        }

        public Task<Theme> GetThemeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Theme>> GetThemesByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTheme(Theme theme)
        {
            throw new NotImplementedException();
        }
    }
}
