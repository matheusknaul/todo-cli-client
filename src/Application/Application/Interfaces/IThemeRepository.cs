using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Repository to manage themes in app.
/// User can create an theme or use a existent theme.
/// </summary>
public interface IThemeRepository
{
    #region App
    /// <summary>
    /// Get All Public themes registered in database
    /// </summary>
    Task<List<Theme>> GetPublicThemes();
    #endregion

    #region Crud - User
    /// <summary>
    /// Get All themes registered by user.
    /// </summary>
    Task<List<Theme>> GetThemesByUser(Guid userId);
    /// <summary>
    /// Get theme by id.
    /// </summary>
    Task<Theme> GetThemeById(int id);
    /// <summary>
    /// Create Theme
    /// </summary>
    Task CreateTheme(Theme theme);
    /// <summary>
    /// Update Theme
    /// </summary>
    Task UpdateTheme(Theme theme);
    /// <summary>
    /// Delete Theme
    /// </summary>
    Task DeleteTheme(int themeId);
    #endregion
}