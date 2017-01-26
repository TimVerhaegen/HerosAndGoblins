using HerosAndGoblins.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerosAndGoblins
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            
            Game game = new Game(form);
            game.InitGame();
            Application.Run(form);
        }


    }
    class Game
    {
        private MainForm form;

        public Game(MainForm form)
        {
            this.form = form;
        }

        public void InitGame()
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTick);
            ResourceManager manager = new ResourceManager(typeof(MainForm));
            Bitmap[] images =
            {
                (Bitmap) manager.GetObject("goblin_left"),
                (Bitmap) manager.GetObject("goblin_up"),
                (Bitmap) manager.GetObject("goblin_right"),
                (Bitmap) manager.GetObject("goblin_down")
            };
            form.AddEntity(new EntityCharacter(new Rectangle(50, 50, 100, 100), images));
        }
        private void OnTick(object sender, EventArgs e)
        {
            form.Invalidate();
        }
    }
}
