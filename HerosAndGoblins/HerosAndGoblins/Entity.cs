using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndGoblins
{
    public class Entity : IDrawable
    {
        private Bitmap _currentBitMap;
        private Image _currentImage;
        private Image[] _image;
        private Rectangle _rect;
        private Bitmap[] _bitMap;
        private Direction _direction;

        public Image Texture { get => _currentImage; set => _currentImage = value; }
        public Rectangle Bounds { get => _rect; set => _rect = value; }
        public Direction Direction {
            get => _direction;
            set
            {
                _currentImage = _image[(int)value];
                _direction = value;
            }
        }
        public Entity(Rectangle r, Image[] i)
        {
            _currentImage = i[0];
            _currentBitMap = new Bitmap(i[0]);
            _rect = r;
            _bitMap = new Bitmap[i.Length];
            for (int ind = 0; ind < i.Length; ind++) _bitMap[ind] = new Bitmap(i[ind]);
            _image = i;
        }

        

        public Boolean Collides(Entity e)
        {
            Image img = e._currentImage;
            int baseX = e.Bounds.X;
            int baseY = e.Bounds.Y;
            for (int x = baseX; x < baseX + img.Width; x++)
            {
                for (int y = baseY; y < baseY + img.Height; y++)
                {
                    Color c = _currentBitMap.GetPixel(x, y);
                    if (c.A == 0 && e.Bounds.IntersectsWith(new Rectangle(x, y, 1, 1))) return true;
                }
            }
            return false;
        }
    }

    public class EntityCharacter : Entity
    {
        public EntityCharacter(Rectangle r, Image[] i) : base(r, i)
        {
        }

    }

    public interface IDrawable
    {
        Image Texture
        {
            get;
            set;
        }
            
        Rectangle Bounds
        {
            get;
            set;
        }
    }
}
