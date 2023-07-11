namespace SpaceFighter
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBgTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveRightTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveLeftTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveUpTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveDownTimer = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.MoveBulletTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnnemieTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveBulletEnnemieTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBgTimer
            // 
            this.MoveBgTimer.Enabled = true;
            this.MoveBgTimer.Interval = 10;
            this.MoveBgTimer.Tick += new System.EventHandler(this.MoveBgTimer_Tick);
            // 
            // MoveRightTimer
            // 
            this.MoveRightTimer.Interval = 5;
            this.MoveRightTimer.Tick += new System.EventHandler(this.MoveRightTimer_Tick);
            // 
            // MoveLeftTimer
            // 
            this.MoveLeftTimer.Interval = 5;
            this.MoveLeftTimer.Tick += new System.EventHandler(this.MoveLeftTimer_Tick);
            // 
            // MoveUpTimer
            // 
            this.MoveUpTimer.Interval = 5;
            this.MoveUpTimer.Tick += new System.EventHandler(this.MoveUpTimer_Tick);
            // 
            // MoveDownTimer
            // 
            this.MoveDownTimer.Interval = 5;
            this.MoveDownTimer.Tick += new System.EventHandler(this.MoveDownTimer_Tick);
            // 
            // Player
            // 
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(250, 375);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(80, 80);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // MoveBulletTimer
            // 
            this.MoveBulletTimer.Enabled = true;
            this.MoveBulletTimer.Interval = 20;
            this.MoveBulletTimer.Tick += new System.EventHandler(this.MoveBulletTimer_Tick);
            // 
            // MoveEnnemieTimer
            // 
            this.MoveEnnemieTimer.Enabled = true;
            this.MoveEnnemieTimer.Tick += new System.EventHandler(this.MoveEnnemieTimer_Tick);
            // 
            // MoveBulletEnnemieTimer
            // 
            this.MoveBulletEnnemieTimer.Enabled = true;
            this.MoveBulletEnnemieTimer.Tick += new System.EventHandler(this.MoveBulletEnnemieTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 42);
            this.label1.MinimumSize = new System.Drawing.Size(300, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 100);
            this.label1.TabIndex = 1;
            this.label1.Text = "Communism Fighter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(159, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(159, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Communism Fighter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Communism_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Communism_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        private System.Windows.Forms.Timer MoveRightTimer;
        private System.Windows.Forms.Timer MoveLeftTimer;
        private System.Windows.Forms.Timer MoveUpTimer;
        private System.Windows.Forms.Timer MoveDownTimer;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer MoveBulletTimer;
        private System.Windows.Forms.Timer MoveEnnemieTimer;
        private System.Windows.Forms.Timer MoveBulletEnnemieTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

