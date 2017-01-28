using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerosAndGoblins.Utils
{
    class LocationUtils
    {
        public static Random random = new Random();
        public static Rectangle GetMovementLocation(Rectangle c, Form form)
        {
            if(c.X + c.Width < 0)
            {
                c.X = form.Width;
            }
            if (c.Y + (c.Height) < 0)
            {
                c.Y = form.Height - c.Height;
            }
            if (c.X > form.Width)
            {
                c.X = 0-c.Width;
            }
            if (c.Y > form.Height)
            {
                c.Y = 0-c.Height;
            }
            return c;
        }

        internal static Rectangle GetRandomLocationGoblin(Form form)
        {
            int randomX = random.Next(form.Width);
            int randomY = random.Next(form.Height);
            return new Rectangle(randomX, randomY, 100, 100);
        }
    }
}
