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

        public MainForm()
        {
            InitializeComponent();
            entities = new List<Entity>();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
        }
        public void AddEntity(Entity e)
        {
            entities.Add(e);
        }

    }
}
