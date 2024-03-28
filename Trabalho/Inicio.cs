using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trabalho
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }



        // BOTÃO ABRIR IMAGEM 1 ------------------------------------------------------------------------------------------- //
        private void abrirBT1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Selecionar Imagem";
            openFileDialog1.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif|Todos os arquivos|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Exibe uma imagem no PictureBox
                    imgA.Image = new System.Drawing.Bitmap(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }



        // BOTÃO ABRIR IMAGEM 2 ------------------------------------------------------------------------------------------- //
        private void abrir2BT_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.Title = "Selecionar Imagem";
            openFileDialog2.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif|Todos os arquivos|*.*";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Exibe uma imagem no PictureBox
                    imgB.Image = new System.Drawing.Bitmap(openFileDialog2.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }



        // BOTÃO SALVAR IMAGEM ------------------------------------------------------------------------------------------- //
        private void btSalavar_Click(object sender, EventArgs e)
        {
            // Verifica se tem uma imagem no PictureBox
            if (imgResultado.Image == null)
            {
                MessageBox.Show("Não há imagem para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abre a caixa de dialogo para salvamento
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Salvar Imagem";
            saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os arquivos|*.*";
            saveFileDialog.DefaultExt = "jpg"; // FORMATO PADRÃO
            saveFileDialog.AddExtension = true;

            // Ao clicar em salvar dentro do dialogo, a imagem é salva 
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtém a imagem da PictureBox
                    Bitmap imagem = new Bitmap(imgResultado.Image);

                    // Salva a imagem no disco
                    imagem.Save(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // BOTÃO DE ADIÇÃO ------------------------------------------------------------------------------------------- //
        private void somaBT_Click(object sender, EventArgs e)
        { 
            // Verifica a opção selecionada no Radio Button
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione uma opção para processar uma imagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                // Carrega as imagens
                Image image1 = imgA.Image;
                Image image2 = imgB.Image;

                // Pede para selecionar duas imagens
                if (image1 == null || image2 == null)
                {
                    MessageBox.Show("Selecione uma opção para processar uma imagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica tamanho e formato
                if (image1.Width != image2.Width || image1.Height != image2.Height || image1.PixelFormat != image2.PixelFormat)
                {
                    MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato para serem somadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria um novo bitmap com a largura e altura da primeira imagem
                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        // Obtém os valores dos pixels das duas imagens
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        Color color2 = ((Bitmap)image2).GetPixel(x, y);

                        // Soma as componentes RGB dos pixels
                        int r = color1.R + color2.R;
                        int g = color1.G + color2.G;
                        int b = color1.B + color2.B;

                        // Trunca os valores para não ultrapassar 255
                        r = Math.Min(r, 255);
                        g = Math.Min(g, 255);
                        b = Math.Min(b, 255);

                        // Define o novo pixel na imagem resultado
                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image1 = imgA.Image;

                if (image1 == null)
                {
                    MessageBox.Show("Selecione uma imagem no campo A", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Intera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Soma as componentes RGB do pixel com ele mesmo
                        int r = color1.R + color1.R;
                        int g = color1.G + color1.G;
                        int b = color1.B + color1.B;

                        r = Math.Min(r, 255);
                        g = Math.Min(g, 255);
                        b = Math.Min(b, 255);

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM AB" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image1 = imgB.Image;

                if (image1 == null)
                {
                    MessageBox.Show("Selecione uma imagem no campo B", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Soma as componentes RGB do pixel com ele mesmo
                        int r = color1.R + color1.R;
                        int g = color1.G + color1.G;
                        int b = color1.B + color1.B;

                        r = Math.Min(r, 255);
                        g = Math.Min(g, 255);
                        b = Math.Min(b, 255);

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }
        }




        // BOTÃO SUBTRAIR ------------------------------------------------------------------------------------------- //
        private void subtracaoBT_Click(object sender, EventArgs e)
        {
            // Verifica a opção selecionada no Radio Button
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione uma opção para processar uma imagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                // Carrega as imagens
                Image image1 = imgA.Image;
                Image image2 = imgB.Image;

                // Pede para selecionar duas imagens
                if (image1 == null || image2 == null)
                {
                    MessageBox.Show("Selecione uma opção para processar uma imagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica tamanho e formato
                if (image1.Width != image2.Width || image1.Height != image2.Height || image1.PixelFormat != image2.PixelFormat)
                {
                    MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato para serem somadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria um novo bitmap com a largura e altura da primeira imagem
                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        // Obtém os valores dos pixels das duas imagens
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        Color color2 = ((Bitmap)image2).GetPixel(x, y);

                        // Subtrai as componentes RGB dos pixels
                        int r = color1.R - color2.R;
                        int g = color1.G - color2.G;
                        int b = color1.B - color2.B;

                        // Trunca os valores para não ultrapassar 255
                        r = Math.Max(r, 0);
                        g = Math.Max(g, 0);
                        b = Math.Max(b, 0);

                        // Define o novo pixel na imagem resultado
                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image1 = imgA.Image;

                if (image1 == null)
                {
                    MessageBox.Show("Selecione uma imagem no campo A", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Intera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Subtrai as componentes RGB do pixel pela metade
                        int r = color1.R / 2;
                        int g = color1.G / 2;
                        int b = color1.B / 2;

                        // Trunca os valores para não ultrapassar 255
                        r = Math.Max(r, 0);
                        g = Math.Max(g, 0);
                        b = Math.Max(b, 0);

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image1 = imgB.Image;

                if (image1 == null)
                {
                    MessageBox.Show("Selecione uma imagem no campo B", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Subtrai as componentes RGB do pixel pela metade
                        int r = color1.R / 2;
                        int g = color1.G / 2;
                        int b = color1.B / 2;

                        // Trunca os valores para não ultrapassar 255
                        r = Math.Max(r, 0);
                        g = Math.Max(g, 0);
                        b = Math.Max(b, 0);

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }
        }




        // BOTÃO NEGATIVO ------------------------------------------------------------------------------------------- //
        private void negativarBT_Click(object sender, EventArgs e)
        {
            // Verifica a opção selecionada no Radio Button
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Por favor, selecione uma imagem para aplicar o efeito negativo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se a imagem A está selecionada
            if (rbA.Checked)
            {
                Image image = imgA.Image;

                if (image == null)
                {
                    MessageBox.Show("Por favor, selecione uma imagem no campo Imagem A", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria um novo bitmap com as mesmas dimensões da imagem
                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todos os pixels da imagem
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        // Obtém a cor do pixel
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Calcula o complemento de cor
                        int r = 255 - color.R;
                        int g = 255 - color.G;
                        int b = 255 - color.B;

                        // Define o novo pixel na imagem resultado
                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                // Exibe a imagem negativa no PictureBox
                imgResultado.Image = imagemResultado;
            }

            // Verifica se a imagem B está selecionada
            if (rbB.Checked)
            {
                Image image = imgB.Image;

                if (image == null)
                {
                    MessageBox.Show("Por favor, selecione uma imagem no campo Imagem B", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria um novo bitmap com as mesmas dimensões da imagem
                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todos os pixels da imagem
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        // Obtém a cor do pixel
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Calcula o complemento de cor
                        int r = 255 - color.R;
                        int g = 255 - color.G;
                        int b = 255 - color.B;

                        // Define o novo pixel na imagem resultado
                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                // Exibe a imagem negativa no PictureBox
                imgResultado.Image = imagemResultado;
            }
        }



















    }
}
