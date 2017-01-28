using HerosAndGoblins.AI;
using HerosAndGoblins.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            for (int x = 0; x < _currentBitMap.Width; x++)
            {
                for (int y = 0; y < _currentBitMap.Height; y++)
                {
                    Color c = _currentBitMap.GetPixel(x, y);
                    if (c.A != 255 && Bounds.IntersectsWith(new Rectangle(x + baseX, y + baseY, 1, 1))) return true;
                }
            }
            return false;
        }

        internal virtual void Move(int x, int y, Direction dir, Form form)
        {
            Rectangle r = Bounds;
            Direction = dir;
            for (int i = 0; i < 4; i++)
            {
                r.X += x;
                r.Y += y;
                Bounds = LocationUtils.GetMovementLocation(r, form);
                
            }
        }
    }

    public class EntityCharacter : Entity
    {
        public EntityCharacter(Rectangle r, Image[] i) : base(r, i)
        {
        }

        internal override void Move(int x, int y, Direction dir, Form form)
        {
            base.Move(x*2, y*2, dir, form);
        }

    }

    public class EntityGoblin : Entity, AIBase
    {
        public EntityGoblin(Rectangle r, Image[] i) : base(r, i)
        {
        }

        public void Execute(EntityCharacter character, Form form)
        {
            //ADD FUNCTIONALITY TO SHOOT FIREBALL OR SOMETHING
        }

        public void ExecuteTick(EntityCharacter character, Form form)
        {
            int charX = character.Bounds.X;
            int charY = character.Bounds.Y;
            int entX = Bounds.X;
            int entY = Bounds.Y;
            int difX = charX - entX;
            int difY = charY - entY;

            int xToMove = Math.Abs(difX) > Math.Abs(difY) ? difX > 0 ? 1 : -1 : 0;
            int yToMove = Math.Abs(difY) > Math.Abs(difX) ? difY > 0 ? 1 : -1 : 0;

            Direction dir = xToMove == 1 ? Direction.RIGHT : yToMove == 1 ? Direction.DOWN : xToMove == -1 ? Direction.LEFT : Direction.UP;
            Move(xToMove, yToMove, dir, form);      
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
