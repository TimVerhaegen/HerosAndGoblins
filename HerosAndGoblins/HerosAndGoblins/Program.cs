using HerosAndGoblins.AI;
using HerosAndGoblins.Properties;
using HerosAndGoblins.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

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
        ResourceManager manager;
        private EntityCharacter _character;
        Bitmap[] images;
        private bool _shouldUpdate;

        public Game(MainForm form)
        {
            this.form = form;
        }

        public void InitGame()
        {
            System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 1;
            mainTimer.Enabled = true;
            mainTimer.Tick += new EventHandler(OnTick);

            System.Timers.Timer aiTimer = new System.Timers.Timer();
            aiTimer.Enabled = true;
            aiTimer.AutoReset = true;
            aiTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnAITimerElapsed);

            System.Windows.Forms.Timer units = new System.Windows.Forms.Timer();
            units.Interval = 5000;
            units.Enabled = true;
            units.Tick += new EventHandler(SpawnUnit);

            manager = new ResourceManager(typeof(MainForm));
            Bitmap[] imagesHero =
            {
                (Bitmap) manager.GetObject("hero"),
                (Bitmap) manager.GetObject("hero"),
                (Bitmap) manager.GetObject("hero"),
                (Bitmap) manager.GetObject("hero")
            };

            Bitmap[] images =
            {
                (Bitmap)manager.GetObject("goblin_left"),
                (Bitmap)manager.GetObject("goblin_up"),
                (Bitmap)manager.GetObject("goblin_right"),
                (Bitmap)manager.GetObject("goblin_down")
            };
            this.images = images;
            _character = new EntityCharacter(new Rectangle(50, 50, 100, 100), imagesHero);
            form.AddEntity(_character);
            _shouldUpdate = true;
        }

        private void OnAITimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_shouldUpdate)
            {
                List<Entity> entities = form.Entities;
                foreach (Entity ent in entities)
                {
                    if (ent is EntityGoblin && ent is AIBase)
                        ((AIBase)ent).ExecuteTick(_character, form);
                }
            }
        }

        private void SpawnUnit(object sender, EventArgs e)
        {
            if(_shouldUpdate) form.AddEntity(new EntityGoblin(LocationUtils.GetRandomLocationGoblin(form), images));
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (_shouldUpdate)
            {
                form.Invalidate();
                form.Score++;
                form.SetScore();

                if (form.CheckCollision())
                {
                    _shouldUpdate = false;
                    if (MessageBox.Show("You lost with a score of: " + form.Score, "You lost!",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        form.Score = 0;
                        form.Entities = new List<Entity>();
                        form.Entities.Add(_character);
                        _shouldUpdate = true;
                    }
                }
            }
        }
    }
}
