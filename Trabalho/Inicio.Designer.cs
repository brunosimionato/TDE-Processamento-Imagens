namespace Trabalho
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.imgA = new System.Windows.Forms.PictureBox();
            this.imgB = new System.Windows.Forms.PictureBox();
            this.btAbrirA = new System.Windows.Forms.Button();
            this.imgResultado = new System.Windows.Forms.PictureBox();
            this.btAbrirB = new System.Windows.Forms.Button();
            this.negativarBT = new System.Windows.Forms.Button();
            this.cinzaBT = new System.Windows.Forms.Button();
            this.somaBT = new System.Windows.Forms.Button();
            this.gpA = new System.Windows.Forms.GroupBox();
            this.gpB = new System.Windows.Forms.GroupBox();
            this.gpResultado = new System.Windows.Forms.GroupBox();
            this.btSalavar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).BeginInit();
            this.gpA.SuspendLayout();
            this.gpB.SuspendLayout();
            this.gpResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgA
            // 
            this.imgA.Location = new System.Drawing.Point(11, 24);
            this.imgA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgA.Name = "imgA";
            this.imgA.Size = new System.Drawing.Size(292, 290);
            this.imgA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgA.TabIndex = 0;
            this.imgA.TabStop = false;
            // 
            // imgB
            // 
            this.imgB.Location = new System.Drawing.Point(12, 24);
            this.imgB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgB.Name = "imgB";
            this.imgB.Size = new System.Drawing.Size(292, 290);
            this.imgB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgB.TabIndex = 1;
            this.imgB.TabStop = false;
            // 
            // btAbrirA
            // 
            this.btAbrirA.Location = new System.Drawing.Point(11, 329);
            this.btAbrirA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAbrirA.Name = "btAbrirA";
            this.btAbrirA.Size = new System.Drawing.Size(292, 35);
            this.btAbrirA.TabIndex = 2;
            this.btAbrirA.Text = "Abrir A";
            this.btAbrirA.UseVisualStyleBackColor = true;
            this.btAbrirA.Click += new System.EventHandler(this.abrirBT1_Click);
            // 
            // imgResultado
            // 
            this.imgResultado.Location = new System.Drawing.Point(11, 16);
            this.imgResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgResultado.Name = "imgResultado";
            this.imgResultado.Size = new System.Drawing.Size(292, 290);
            this.imgResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgResultado.TabIndex = 3;
            this.imgResultado.TabStop = false;
            // 
            // btAbrirB
            // 
            this.btAbrirB.Location = new System.Drawing.Point(12, 329);
            this.btAbrirB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAbrirB.Name = "btAbrirB";
            this.btAbrirB.Size = new System.Drawing.Size(292, 35);
            this.btAbrirB.TabIndex = 4;
            this.btAbrirB.Text = "Abrir B";
            this.btAbrirB.UseVisualStyleBackColor = true;
            this.btAbrirB.Click += new System.EventHandler(this.abrir2BT_Click);
            // 
            // negativarBT
            // 
            this.negativarBT.Location = new System.Drawing.Point(712, 105);
            this.negativarBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.negativarBT.Name = "negativarBT";
            this.negativarBT.Size = new System.Drawing.Size(94, 35);
            this.negativarBT.TabIndex = 5;
            this.negativarBT.Text = "Negativar";
            this.negativarBT.UseVisualStyleBackColor = true;
            this.negativarBT.Click += new System.EventHandler(this.negativarBT_Click);
            // 
            // cinzaBT
            // 
            this.cinzaBT.Location = new System.Drawing.Point(712, 219);
            this.cinzaBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cinzaBT.Name = "cinzaBT";
            this.cinzaBT.Size = new System.Drawing.Size(94, 35);
            this.cinzaBT.TabIndex = 6;
            this.cinzaBT.Text = "Escala de Cinza";
            this.cinzaBT.UseVisualStyleBackColor = true;
            this.cinzaBT.Click += new System.EventHandler(this.cinzaBT_Click);
            // 
            // somaBT
            // 
            this.somaBT.Location = new System.Drawing.Point(712, 284);
            this.somaBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.somaBT.Name = "somaBT";
            this.somaBT.Size = new System.Drawing.Size(94, 35);
            this.somaBT.TabIndex = 7;
            this.somaBT.Text = "A + B";
            this.somaBT.UseVisualStyleBackColor = true;
            this.somaBT.Click += new System.EventHandler(this.somaBT_Click);
            // 
            // gpA
            // 
            this.gpA.Controls.Add(this.btAbrirA);
            this.gpA.Controls.Add(this.imgA);
            this.gpA.Location = new System.Drawing.Point(21, 28);
            this.gpA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpA.Name = "gpA";
            this.gpA.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpA.Size = new System.Drawing.Size(314, 375);
            this.gpA.TabIndex = 8;
            this.gpA.TabStop = false;
            this.gpA.Text = "Imagem A";
            this.gpA.Enter += new System.EventHandler(this.gpA_Enter);
            // 
            // gpB
            // 
            this.gpB.Controls.Add(this.btAbrirB);
            this.gpB.Controls.Add(this.imgB);
            this.gpB.Location = new System.Drawing.Point(361, 28);
            this.gpB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpB.Name = "gpB";
            this.gpB.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpB.Size = new System.Drawing.Size(314, 375);
            this.gpB.TabIndex = 9;
            this.gpB.TabStop = false;
            this.gpB.Text = "Imagem B";
            // 
            // gpResultado
            // 
            this.gpResultado.Controls.Add(this.btSalavar);
            this.gpResultado.Controls.Add(this.imgResultado);
            this.gpResultado.Location = new System.Drawing.Point(1085, 28);
            this.gpResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpResultado.Name = "gpResultado";
            this.gpResultado.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpResultado.Size = new System.Drawing.Size(314, 375);
            this.gpResultado.TabIndex = 10;
            this.gpResultado.TabStop = false;
            this.gpResultado.Text = "Resultado Final";
            // 
            // btSalavar
            // 
            this.btSalavar.Location = new System.Drawing.Point(11, 325);
            this.btSalavar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btSalavar.Name = "btSalavar";
            this.btSalavar.Size = new System.Drawing.Size(292, 35);
            this.btSalavar.TabIndex = 5;
            this.btSalavar.Text = "Salvar";
            this.btSalavar.UseVisualStyleBackColor = true;
            this.btSalavar.Click += new System.EventHandler(this.btSalavar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 839);
            this.Controls.Add(this.gpResultado);
            this.Controls.Add(this.gpB);
            this.Controls.Add(this.gpA);
            this.Controls.Add(this.somaBT);
            this.Controls.Add(this.cinzaBT);
            this.Controls.Add(this.negativarBT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de Imagens";
            ((System.ComponentModel.ISupportInitialize)(this.imgA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).EndInit();
            this.gpA.ResumeLayout(false);
            this.gpB.ResumeLayout(false);
            this.gpResultado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgA;
        private System.Windows.Forms.PictureBox imgB;
        private System.Windows.Forms.Button btAbrirA;
        private System.Windows.Forms.PictureBox imgResultado;
        private System.Windows.Forms.Button btAbrirB;
        private System.Windows.Forms.Button negativarBT;
        private System.Windows.Forms.Button cinzaBT;
        private System.Windows.Forms.Button somaBT;
        private System.Windows.Forms.GroupBox gpA;
        private System.Windows.Forms.GroupBox gpB;
        private System.Windows.Forms.GroupBox gpResultado;
        private System.Windows.Forms.Button btSalavar;
    }
}

