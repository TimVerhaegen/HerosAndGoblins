using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerosAndGoblins
{
    public partial class MainForm : Form
    {
        List<Entity> entities;
        private EntityCharacter _player;
        private int _score;

        public List<Entity> Entities { get => entities; set => entities = value; }
        public int Score { get => _score; set => _score = value; }

        public MainForm()
        {
            InitializeComponent();
            _score = 0;
            entities = new List<Entity>();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
        }
        public void AddEntity(Entity e)
        {
            if (e is EntityCharacter) _player = (EntityCharacter) e;
            entities.Add(e);
        }

        internal bool CheckCollision()
        {
            foreach(Entity e in entities)
            {
                if (e is EntityGoblin)
                {
                    if(((EntityGoblin)e).Collides(_player)) return true;
                    
                }
            }
            return false;
        }

        internal void SetScore()
        {
            label1.Text = label1.Text.Substring(0, label1.Text.IndexOf('-') + 1) + Score;
        }
    }
}
