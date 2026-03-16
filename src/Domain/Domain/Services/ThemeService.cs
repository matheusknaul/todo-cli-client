using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using Domain.Exceptions;

namespace Domain.Services;

public class ThemeService
{
    public Theme CreateTheme(Guid userId)
    {
        return new Theme(userId);
    }

    public void EditTheme(Theme theme, Guid userId, string font, int fontSize, Color titleColor,
        Color backgroundColor, bool isPublic)
    {
        if (theme.OwnerId != userId)
            throw new DomainException("Você não é dono deste tema, por isso não poderá editá-lo!");

        theme.Edit(font, fontSize, titleColor, backgroundColor, isPublic);
    }
}