using System.Drawing;

namespace Domain.Entities;

public class Profile
{
    public Guid UserId { get; private set; }

    public Guid? SelectedThemeId { get; private set; }

    public void SelectTheme(Guid themeId)
    {
        SelectedThemeId = themeId;
    }
}