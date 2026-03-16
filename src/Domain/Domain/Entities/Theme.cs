using Domain.ValueObjects;

namespace Domain.Entities;

    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Font { get; set; }
        public int FontSize { get; set; }
        public bool IsPrivate { get; set; }
        public Color TitleColor { get; set; }
        public Color BackgroundColor { get; set; }
        public int UseCount { get; set; }
        public Guid OwnerId { get; set; }

        public Theme(Guid ownerId)
        {
            
        }

        public void Edit(string font,int fontSize,Color title,Color background,bool isPublic)
        {
            Font = font;
            FontSize = fontSize;
            TitleColor = title;
            BackgroundColor = background;
            IsPrivate = isPublic;
        }
    }

