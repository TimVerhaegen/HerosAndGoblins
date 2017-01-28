using HerosAndGoblins.AI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HerosAndGoblins
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SCORE :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 462);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Heros and Goblins";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEntities);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Console.WriteLine(keyData);
            if (keyData == Keys.Left)
            {
                MoveCharacter(-1, 0, Direction.LEFT);
            }
            if (keyData == Keys.Up)
            {
                MoveCharacter(0, -1, Direction.UP);
            }
            if (keyData == Keys.Right)
            {
                MoveCharacter(1, 0, Direction.RIGHT);
            }
            if (keyData == Keys.Down)
            {
                MoveCharacter(0, 1, Direction.DOWN);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PaintEntities(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Entity ent in entities)
            {
                g.DrawImage(ent.Texture, ent.Bounds);
            }
        }

        

        public void MoveCharacter(int x, int y, Direction dir)
        {
            foreach(Entity ent in entities)
            {
                if(ent is EntityCharacter) ent.Move(x, y, dir, this);
            }
        }
        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
    }
}