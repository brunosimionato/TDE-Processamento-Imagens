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




        // BOTÃO ABRIR IMAGEM A --------------------------------------------------------------------------------------------------------------
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




        // BOTÃO ABRIR IMAGEM B --------------------------------------------------------------------------------------------------------------
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




        // BOTÃO SALVAR IMAGEM --------------------------------------------------------------------------------------------------------------
        private void btSalavar_Click(object sender, EventArgs e)
        {
            // Verifica se tem uma imagem nA PictureBox imgResultado
            if (imgResultado.Image == null)
            {
                MessageBox.Show("Não há nenhuma imagem para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abre a caixa de dialogo para salvamento
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Salvar Imagem";
            saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os arquivos|*.*";
            saveFileDialog.DefaultExt = "jpg"; // FORMATO PADRÃO
            saveFileDialog.AddExtension = true;

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




        // BOTÃO DE ADIÇÃO --------------------------------------------------------------------------------------------------------------
        private void somaBT_Click(object sender, EventArgs e)
        { 
            // Exibe um aviso caso nenhuma opção no campo "Escolha de Imagens" for marcada
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione uma opção no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica tamanho e formato
                if (image1.Width != image2.Width || image1.Height != image2.Height || image1.PixelFormat != image2.PixelFormat)
                {
                    MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        // Obtém os valores dos pixels das duas imagens
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        Color color2 = ((Bitmap)image2).GetPixel(x, y);

                        // Soma os componentes RGB dos pixels
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
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Intera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Soma os componentes RGB do pixel com ele mesmo
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

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image1 = imgB.Image;

                if (image1 == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Intera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        // Soma os componentes RGB do pixel com ele mesmo
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




        // BOTÃO SUBTRAIR --------------------------------------------------------------------------------------------------------------
        private void subtracaoBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso nenhuma imagens for escolhida para ser processada
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione uma opção no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica tamanho e formato
                if (image1.Width != image2.Width || image1.Height != image2.Height || image1.PixelFormat != image2.PixelFormat)
                {
                    MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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




        // BOTÃO NEGATIVO --------------------------------------------------------------------------------------------------------------
        private void negativarBT_Click(object sender, EventArgs e)
        {

            // Exibe um aviso caso a opção "Ambas as Imagens" estiver selecionda
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso nenhuma imagens for estiver selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image = imgA.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image = imgB.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                imgResultado.Image = imagemResultado;
            }
        }




        // BOTÃO FLIPAR HORIZONTAL
        private void FlipBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso a opção "Ambas as Imagens" estiver selecionda
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso nenhuma imagens for estiver selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image = imgA.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todas as linhas da imagem
                for (int y = 0; y < image.Height; y++)
                {
                    // Itera sobre todos os pixels da linha, da direita para a esquerda
                    for (int x = image.Width - 1; x >= 0; x--)
                    {
                        // Obtém a cor do pixel na posição original
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Define o pixel na posição invertida na imagem resultado
                        imagemResultado.SetPixel(image.Width - 1 - x, y, color);
                    }
                }

                imgResultado.Image = imagemResultado;
            }

            // VERIFICA SE A "IMAGEM B" ESTÁ SELECIONADA
            if (rbB.Checked)
            {
                Image image = imgB.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todas as linhas da imagem
                for (int y = 0; y < image.Height; y++)
                {
                    // Itera sobre todos os pixels da linha, da direita para a esquerda
                    for (int x = image.Width - 1; x >= 0; x--)
                    {
                        // Obtém a cor do pixel na posição original
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Define o pixel na posição invertida na imagem resultado
                        imagemResultado.SetPixel(image.Width - 1 - x, y, color);
                    }
                }

                imgResultado.Image = imagemResultado;
            }
        }





        // BOTÃO FLIPAR VERTICAL
        private void FlipUDBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso a opção "Ambas as Imagens" estiver selecionda
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso nenhuma imagens for estiver selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image = imgA.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todas as colunas da imagem
                for (int x = 0; x < image.Width; x++)
                {
                    // Itera sobre todos os pixels da coluna, de baixo para cima
                    for (int y = image.Height - 1; y >= 0; y--)
                    {
                        // Obtém a cor do pixel na posição original
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Define o pixel na posição invertida na imagem resultado
                        imagemResultado.SetPixel(x, image.Height - 1 - y, color);
                    }
                }

                // Exibe a imagem com o flip vertical no PictureBox
                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image = imgB.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

                // Itera sobre todas as colunas da imagem
                for (int x = 0; x < image.Width; x++)
                {
                    // Itera sobre todos os pixels da coluna, de baixo para cima
                    for (int y = image.Height - 1; y >= 0; y--)
                    {
                        // Obtém a cor do pixel na posição original
                        Color color = ((Bitmap)image).GetPixel(x, y);

                        // Define o pixel na posição invertida na imagem resultado
                        imagemResultado.SetPixel(x, image.Height - 1 - y, color);
                    }
                }

                imgResultado.Image = imagemResultado;
            }
        }




        // BOTÃO ESCALA DE CINZA
        private void cinzaBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso a opção "Ambas as Imagens" estiver selecionda
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso nenhuma imagens for estiver selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                Image image = imgA.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Converte a imagem para escala de cinza
                Bitmap imagemCinza = ConverterParaEscalaDeCinza(new Bitmap(image));

                imgResultado.Image = imagemCinza;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image = imgB.Image;

                if (image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Converte a imagem para escala de cinza
                Bitmap imagemCinza = ConverterParaEscalaDeCinza(new Bitmap(image));

                imgResultado.Image = imagemCinza;
            }
        }

        // FUNÇÃO ESCALA DE CINZA
        private Bitmap ConverterParaEscalaDeCinza(Bitmap imagemColorida)
        {
            Bitmap imagemCinza = new Bitmap(imagemColorida.Width, imagemColorida.Height);

            for (int x = 0; x < imagemColorida.Width; x++)
            {
                for (int y = 0; y < imagemColorida.Height; y++)
                {
                    Color pixel = imagemColorida.GetPixel(x, y);

                    // Calcula a média dos canais de cor 
                    int tomCinza = (int)((pixel.R + pixel.G + pixel.B) / 3.0);
                    Color novoPixel = Color.FromArgb(tomCinza, tomCinza, tomCinza);

                    imagemCinza.SetPixel(x, y, novoPixel);
                }
            }

            return imagemCinza;
        }




        // BOTÃO CONCATENAR
        private void concatenarBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso a opção "Ambas as Imagens" não estiver selecionda
            if (!rbDuas.Checked)
            {
                MessageBox.Show("Escolha 'Ambas as Imagens' para concatenar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso a "Imagem A" ou "Imagem B" não estiverem carregadas
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap imagemA = new Bitmap(imgA.Image);
            Bitmap imagemB = new Bitmap(imgB.Image);

            // Verifica as dimensões das imagens
            if (imagemA.Width != imagemB.Width || imagemA.Height != imagemB.Height)
            {
                MessageBox.Show("As imagens precisam ter o mesmo tamanho e formato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria uma nova imagem com o dobro da largura
            Bitmap imagemResultado = new Bitmap(imagemA.Width * 2, imagemA.Height);


            // Desenha a imagem A na posição inicial (0, 0)
            using (Graphics g = Graphics.FromImage(imagemResultado))
            {
                g.DrawImage(imagemA, 0, 0);
            }

            // Desenha a imagem B ao lado de A
            using (Graphics g = Graphics.FromImage(imagemResultado))
            {
                g.DrawImage(imagemB, imagemA.Width, 0);
            }

            imgResultado.Image = imagemResultado;
        }









        private void btnRecortar_Click(object sender, EventArgs e)
        {
            // Verifica a opção selecionada no Radio Button
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' para cortar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                if (imgA.Image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                if (imgB.Image == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Verifica se os valores de corte foram inseridos
            if (string.IsNullOrEmpty(widthTB.Text) || string.IsNullOrEmpty(heightTB.Text))
            {
                MessageBox.Show("Insira os valores de largura e altura para o recorte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Converte os valores de largura e altura para inteiros
            if (!int.TryParse(widthTB.Text, out int width) || !int.TryParse(heightTB.Text, out int height))
            {
                MessageBox.Show("Valores de largura e altura devem ser números inteiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se os valores de largura e altura são maiores que zero
            if (width <= 0 || height <= 0)
            {
                MessageBox.Show("Valores de largura e altura devem ser maiores que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica qual imagem está selecionada
            PictureBox pictureBox = rbA.Checked ? imgA : imgB;

            // Converte a imagem selecionada em uma matriz
            Bitmap originalImage = new Bitmap(pictureBox.Image);
            int[,] imageMatrix = ConvertToMatrix(originalImage);

            // Realiza o recorte na matriz
            int[,] croppedImageMatrix = CropImage(imageMatrix, width, height);

            // Se a matriz recortada for nula, significa que ocorreu um erro durante o recorte
            if (croppedImageMatrix == null)
            {
                MessageBox.Show("Ocorreu um erro ao recortar a imagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Converte a matriz recortada de volta para uma imagem
            Bitmap croppedImage = ConvertToBitmap(croppedImageMatrix);

            // Exibe o resultado na imagem de destino
            imgResultado.Image = croppedImage;
        }

        private int[,] ConvertToMatrix(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            int[,] matrix = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[y, x] = image.GetPixel(x, y).ToArgb();
                }
            }

            return matrix;
        }

        private int[,] CropImage(int[,] imageMatrix, int width, int height)
        {
            // Obtenha as dimensões da imagem original
            int originalWidth = imageMatrix.GetLength(1);
            int originalHeight = imageMatrix.GetLength(0);

            // Verifique se as dimensões de corte estão dentro dos limites da imagem original
            if (width > originalWidth || height > originalHeight)
            {
                MessageBox.Show("As dimensões de corte excedem as dimensões da imagem original.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retorna null para indicar um erro
            }

            // Calcule as coordenadas do canto superior esquerdo do retângulo de corte
            int startX = (originalWidth - width) / 2;
            int startY = (originalHeight - height) / 2;

            // Crie uma nova matriz para armazenar a imagem recortada
            int[,] croppedImage = new int[height, width];

            // Copie os pixels da região recortada da imagem original para a nova matriz
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    croppedImage[y, x] = imageMatrix[startY + y, startX + x];
                }
            }

            return croppedImage; // Retorne a imagem recortada
        }

        private Bitmap ConvertToBitmap(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            Bitmap image = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    image.SetPixel(x, y, Color.FromArgb(matrix[y, x]));
                }
            }

            return image;
        }

        private void limparBT_Click(object sender, EventArgs e)
        {
            // Limpar as imagens
            imgA.Image = null;
            imgB.Image = null;
            imgResultado.Image = null;

            // Limpar os campos de texto
            widthTB.Text = "";
            heightTB.Text = "";
        }

    }
}

