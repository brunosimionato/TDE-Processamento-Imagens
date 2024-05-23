using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trabalho
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            LimparGraficos();


        }


        private void Inicio_Load(object sender, EventArgs e)
        {
            //NumericUpDown nulas quando inicializadas 
            adInputTB.ResetText();
            subInputTB.ResetText();
            RGBbinTB.ResetText();
            multiplicacaoTB.ResetText();
            divisaoTB.ResetText();
            blendingNTBNumericUpDown.ResetText();
            widthInicialTB.ResetText();
            heightInicialTB.ResetText();
            widthFinalTB.ResetText();
            heightFinalTB.ResetText();
            ordemTB.ResetText();
            gaussianaNTB.ResetText();
        }




        // Permite apenas números até 255 na adInputTB
        private void adInputTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {
                int newValue = Convert.ToInt32(adInputTB.Text + e.KeyChar);
                if (newValue > 255)
                {
                    adInputTB.Text = "255";
                    e.Handled = true;
                }
            }
        }


        // Permite apenas números até 255 na subInputTB
        private void subInputTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {
                int newValue = Convert.ToInt32(subInputTB.Text + e.KeyChar);
                if (newValue > 255)
                {
                    subInputTB.Text = "255";
                    e.Handled = true;
                }
            }
        }


        // Permite apenas números até 255 na multiplicacaoTB
        private void multiplicacaoTB_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {

                int newValue = Convert.ToInt32(multiplicacaoTB.Text + e.KeyChar);
                if (newValue > 255)
                {
                    multiplicacaoTB.Text = "255";
                    e.Handled = true;
                }
            }
        }


        // Permite apenas números até 255 na divisaoTB
        private void divisaoTB_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {

                int newValue = Convert.ToInt32(divisaoTB.Text + e.KeyChar);
                if (newValue > 255)
                {
                    divisaoTB.Text = "255";
                    e.Handled = true;
                }
            }
        }


        // Permite apenas números até 255 na RGBbinTB
        private void RGBbinTB_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {
                
                int newValue = Convert.ToInt32(RGBbinTB.Text + e.KeyChar);
                if (newValue > 255)
                {
                    RGBbinTB.Text = "255";
                    e.Handled = true;
                }
            }

        }


        // Permite apenas números até 10 na gaussianaNTB
        private void gaussianaNTB_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar))
            {

                int newValue = Convert.ToInt32(gaussianaNTB.Text + e.KeyChar);
                if (newValue > 10)
                {
                    gaussianaNTB.Text = "10";
                    e.Handled = true;
                }
            }
        }


        // Não permite o que o mouse seja tranformado em cursor de texto ao passar por cima dos NumericUpDown
        private void blendingNTBNumericUpDown_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            blendingNTBNumericUpDown.Cursor = Cursors.Default;
        }

        private void divisaoTB_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            divisaoTB.Cursor = Cursors.Default;
        }

        private void multiplicacaoTB_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            multiplicacaoTB.Cursor = Cursors.Default;

        }

        private void gaussianaNTB_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            gaussianaNTB.Cursor = Cursors.Default;
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
            // Exibe um aviso caso nenhuma imagens for escolhida para ser processada
            if (!rbA.Checked && !rbB.Checked && !rbDuas.Checked)
            {
                MessageBox.Show("Selecione uma opção no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                Image image1 = imgA.Image;
                Image image2 = imgB.Image;

                // Pede para selecionar duas imagens
                if (image1 == null || image2 == null)
                {
                    MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Exibe um aviso caso a adInputTB estiver nula
                if (string.IsNullOrEmpty(adInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Redimensiona as imagens para o mesmo tamanho, se necessário
                if (image1.Width != image2.Width || image1.Height != image2.Height)
                {
                    // Redimensiona a imagem 2 para o tamanho da imagem 1
                    image2 = RedimensionarImagem(image2, image1.Width, image1.Height);
                }

                AtualizarResultadoSoma(image1, image2);
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

                // Exibe um aviso caso a adInputTB estiver nula
                if (string.IsNullOrEmpty(adInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AtualizarResultadoImagem(image1);
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

                // Exibe um aviso caso a adInputTB estiver nula
                if (string.IsNullOrEmpty(adInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AtualizarResultadoImagem(image1);
            }
        }

        // Função para redimensionar uma imagem para um novo tamanho
        private Image RedimensionarImagem(Image image, int newWidth, int newHeight)
        {
            Bitmap novaImagem = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(novaImagem))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return novaImagem;
        }

        // Função para limitar um valor ao intervalo [0, 255]
        private int LimitarValor(int value)
        {
            return Math.Max(0, Math.Min(value, 255));
        }



        // Função para atualizar o resultado da soma das imagens
        private void AtualizarResultadoSoma(Image image1, Image image2)
        {
            int valorAdicao = Convert.ToInt32(adInputTB.Value);
            Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    // Obtém os valores dos pixels das duas imagens
                    Color color1 = ((Bitmap)image1).GetPixel(x, y);
                    Color color2 = ((Bitmap)image2).GetPixel(x, y);

                    // Soma os componentes RGB dos pixels
                    int r = LimitarValor(color1.R + color2.R + valorAdicao);
                    int g = LimitarValor(color1.G + color2.G + valorAdicao);
                    int b = LimitarValor(color1.B + color2.B + valorAdicao);

                    // Define o novo pixel na imagem resultado
                    imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            imgResultado.Image = imagemResultado;
        }

        // Função para atualizar o resultado da imagem com o valor de adição
        private void AtualizarResultadoImagem(Image image)
        {
            int valorAdicao = Convert.ToInt32(adInputTB.Value);
            Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

            // Intera os pixels da imagem
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color1 = ((Bitmap)image).GetPixel(x, y);

                    // Soma os componentes RGB do pixel com o valor digitado
                    int r = LimitarValor(color1.R + valorAdicao);
                    int g = LimitarValor(color1.G + valorAdicao);
                    int b = LimitarValor(color1.B + valorAdicao);

                    imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            imgResultado.Image = imagemResultado;
        }




        // BOTÃO SUBTRAIR --------------------------------------------------------------------------------------------------------------
        private void subtracaoBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso nenhuma imagem seja escolhida para ser processada
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

                // Exibe um aviso caso a subInputTB estiver nula
                if (string.IsNullOrEmpty(subInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Redimensiona as imagens para o mesmo tamanho, se necessário
                if (image1.Width != image2.Width || image1.Height != image2.Height)
                {
                    // Redimensiona a imagem 2 para o tamanho da imagem 1
                    image2 = RedimensionarImagem(image2, image1.Width, image1.Height);
                }

                AtualizarResultadoSubtracao(image1, image2);
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

                // Exibe um aviso caso a subInputTB estiver nula
                if (string.IsNullOrEmpty(subInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AtualizarResultadoImagemSubtracao(image1);
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

                // Exibe um aviso caso a subInputTB estiver nula
                if (string.IsNullOrEmpty(subInputTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AtualizarResultadoImagemSubtracao(image1);
            }
        }

        // Função para atualizar o resultado da subtração das imagens
        private void AtualizarResultadoSubtracao(Image image1, Image image2)
        {
            int valorSubtracao = Convert.ToInt32(subInputTB.Value);
            Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    // Obtém os valores dos pixels das duas imagens
                    Color color1 = ((Bitmap)image1).GetPixel(x, y);
                    Color color2 = ((Bitmap)image2).GetPixel(x, y);

                    // Subtrai as componentes RGB dos pixels
                    int r = LimitarValor(color1.R - color2.R - valorSubtracao);
                    int g = LimitarValor(color1.G - color2.G - valorSubtracao);
                    int b = LimitarValor(color1.B - color2.B - valorSubtracao);

                    // Define o novo pixel na imagem resultado
                    imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            imgResultado.Image = imagemResultado;
        }

        // Função para atualizar o resultado da imagem com o valor de subtração
        private void AtualizarResultadoImagemSubtracao(Image image)
        {
            int valorSubtracao = Convert.ToInt32(subInputTB.Value);
            Bitmap imagemResultado = new Bitmap(image.Width, image.Height);

            // Intera os pixels da imagem
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color1 = ((Bitmap)image).GetPixel(x, y);

                    // Subtrai as componentes RGB do pixel pelo valor digitado
                    int r = LimitarValor(color1.R - valorSubtracao);
                    int g = LimitarValor(color1.G - valorSubtracao);
                    int b = LimitarValor(color1.B - valorSubtracao);

                    imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            imgResultado.Image = imagemResultado;
        }




        // BOTÃO NEGATIVO --------------------------------------------------------------------------------------------------------------
        private void negativarBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS A" ESTIVER SELECIONADA
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




        // BOTÃO FLIPAR HORIZONTAL --------------------------------------------------------------------------------------------------------------
        private void FlipBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
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




        // BOTÃO FLIPAR VERTICAL --------------------------------------------------------------------------------------------------------------
        private void FlipUDBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
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




        // BOTÃO ESCALA DE CINZA --------------------------------------------------------------------------------------------------------------
        private void cinzaBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
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




        // BOTÃO CONCATENAR --------------------------------------------------------------------------------------------------------------
        private void concatenarBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" NÃO ESTIVER SELECIONADA
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




        // BOTÃO RECORTAR --------------------------------------------------------------------------------------------------------------
        private void btnRecortar_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
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
            if (string.IsNullOrEmpty(widthInicialTB.Text) || string.IsNullOrEmpty(widthFinalTB.Text) || string.IsNullOrEmpty(heightInicialTB.Text) || string.IsNullOrEmpty(heightFinalTB.Text))
            {
                MessageBox.Show("Insira as coordenadas de linha e\n coluna para o recorte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Converte os valores de largura e altura para inteiros
            if (!int.TryParse(widthInicialTB.Text, out int widthInicial) || !int.TryParse(widthFinalTB.Text, out int widthFinal) || !int.TryParse(heightInicialTB.Text, out int heightInicial) || !int.TryParse(heightFinalTB.Text, out int heightFinal))
            {
                MessageBox.Show("As coordenadas de linha e coluna\n devem ser números inteiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se os valores de largura e altura são maiores que zero
            if (widthInicial <= 0 || widthFinal <= 0 || heightInicial <= 0 || heightFinal <= 0)
            {
                MessageBox.Show("As coordenadas de linha e coluna\n devem ser maiores que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se os valores de largura e altura são maiores que zero
            if ((widthInicial > widthFinal) || (heightInicial > heightFinal))
            {
                MessageBox.Show("As coordenadas iniciais não podem ser maiores que as finais.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se os valores de iniciais e finais são iguais
            if ((widthInicial == widthFinal) || (heightInicial == heightFinal))
            {
                MessageBox.Show("As coordenadas iniciais e finais não podem ser iguais.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica qual imagem está selecionada
            PictureBox pictureBox = rbA.Checked ? imgA : imgB;

            // Converte a imagem selecionada em uma matriz
            Bitmap originalImage = new Bitmap(pictureBox.Image);
            int[,] imageMatrix = ConvertToMatrix(originalImage);

            // Realiza o recorte na matriz
            int[,] croppedImageMatrix = CropImage(imageMatrix, widthInicial, widthFinal, heightInicial, heightFinal);

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

        private int[,] CropImage(int[,] imageMatrix, int widthInicial, int widthFinal, int heightInicial, int heightFinal)
        {
            // Obtenha as dimensões da imagem original
            int originalWidth = imageMatrix.GetLength(1);
            int originalHeight = imageMatrix.GetLength(0);

            // Verifique se as dimensões de corte estão dentro dos limites da imagem original
            if (widthFinal > originalWidth || heightFinal > originalHeight)
            {
                MessageBox.Show("As dimensões de corte excedem as dimensões da imagem original.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retorna null para indicar um erro
            }

            // Calcule as dimensões do retângulo de corte
            int width = widthFinal - widthInicial;
            int height = heightFinal - heightInicial;

            // Crie uma nova matriz para armazenar a imagem recortada
            int[,] croppedImage = new int[height, width];

            // Copie os pixels da região recortada da imagem original para a nova matriz
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    croppedImage[y, x] = imageMatrix[heightInicial + y, widthInicial + x];
                }
            }

            return croppedImage;
        }

        //Converte uma matriz em Bitmap
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




        // BOTÃO LIMPAR IMAGENS --------------------------------------------------------------------------------------------------------------
        private void limparBT_Click(object sender, EventArgs e)
        {
            imgA.Image = null;
            imgB.Image = null;
            imgResultado.Image = null;

            adInputTB.ResetText();
            subInputTB.ResetText();
            RGBbinTB.ResetText();
            multiplicacaoTB.ResetText();
            divisaoTB.ResetText();
            blendingNTBNumericUpDown.ResetText();
            widthInicialTB.ResetText();
            heightInicialTB.ResetText();
            widthFinalTB.ResetText();
            heightFinalTB.ResetText();
            ordemTB.ResetText();

            rbA.Checked = false;
            rbB.Checked = false;
            rbDuas.Checked = false;

            LimparGraficos();
        }

        // Método para limpar os gráficos
        private void LimparGraficos()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
        }



        // RGB PARA BINÁRIO --------------------------------------------------------------------------------------------------------------
        private void RGBbinBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image imagemSelecionada = null;

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                imagemSelecionada = imgA.Image;

                if (imagemSelecionada == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(RGBbinTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                imagemSelecionada = imgB.Image;

                if (imagemSelecionada == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(RGBbinTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Converte o valor digitado para um número inteiro
            if (!int.TryParse(RGBbinTB.Text, out int mediaRGB))
            {
                MessageBox.Show("Digite um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Obtendo a largura e altura da imagem selecionada
            int width = imagemSelecionada.Width;
            int height = imagemSelecionada.Height;

            // Criando uma nova imagem binária
            Bitmap imagemBinaria = new Bitmap(width, height);

            // Percorrendo a imagem original pixel a pixel
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo o valor RGB do pixel atual
                    Color pixelColor = ((Bitmap)imagemSelecionada).GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    // Calculando a média dos componentes RGB
                    int mediaPixel = (red + green + blue) / 3;

                    // Definindo o valor binário do pixel na nova imagem
                    if (mediaPixel > mediaRGB)
                    {
                        imagemBinaria.SetPixel(x, y, Color.White); // Valor RGB médio maior que a média, define como branco (1)
                    }
                    else
                    {
                        imagemBinaria.SetPixel(x, y, Color.Black); // Valor RGB médio menor ou igual à média, define como preto (0)
                    }
                }
            }

            imgResultado.Image = imagemBinaria;
        }




        // EQUALIZAR HISTOGRAMA --------------------------------------------------------------------------------------------------------------
        private void equalizarBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CASO A OPÇÃO "IMAGEM A" ESTIVER SELECIONADA
            if (rbA.Checked)
            {
                // Carrega a imagem em escala de cinza
                Image imagemA = imgA.Image;

                if (imagemA == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem A'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Converte para escala de cinza
                Bitmap imagemCinza = ConverteParaEscalaDeCinza(imagemA);

                // Calcula o histograma
                int[] histograma = CalculaHistograma(imagemCinza);

                // Equaliza o histograma
                Bitmap imagemEqualizada = EqualizarHistograma(imagemCinza, histograma);

                // Exibe a imagem equalizada no imgResultado
                imgResultado.Image = imagemEqualizada;

                // Obtém o histograma da imagem equalizada
                int[] histogramaEqualizado = CalculaHistograma(imagemEqualizada);

                // Atualiza os gráficos
                AtualizaGraficosHistograma(histograma, histogramaEqualizado);
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                // Carrega a imagem em escala de cinza
                Image imagemB = imgB.Image;

                // Verifica se a imagem foi carregada corretamente
                if (imagemB == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Converte para escala de cinza
                Bitmap imagemCinza = ConverteParaEscalaDeCinza(imagemB);

                // Calcula o histograma 
                int[] histograma = CalculaHistograma(imagemCinza);

                // Equaliza o histograma
                Bitmap imagemEqualizada = EqualizarHistograma(imagemCinza, histograma);

                // Exibe a imagem equalizada no imgResultado
                imgResultado.Image = imagemEqualizada;

                // Obtém o histograma da imagem equalizada
                int[] histogramaEqualizado = CalculaHistograma(imagemEqualizada);

                // Atualiza os gráficos
                AtualizaGraficosHistograma(histograma, histogramaEqualizado);
            }
        }

        // Converter para escala de Cinza
        private Bitmap ConverteParaEscalaDeCinza(Image imagemColorida)
        {
            Bitmap imagemCinza = new Bitmap(imagemColorida.Width, imagemColorida.Height);

            for (int x = 0; x < imagemColorida.Width; x++)
            {
                for (int y = 0; y < imagemColorida.Height; y++)
                {
                    Color corOriginal = ((Bitmap)imagemColorida).GetPixel(x, y);
                    int mediaRGB = (corOriginal.R + corOriginal.G + corOriginal.B) / 3;
                    Color corCinza = Color.FromArgb(corOriginal.A, mediaRGB, mediaRGB, mediaRGB);
                    imagemCinza.SetPixel(x, y, corCinza);
                }
            }

            return imagemCinza;
        }

        // Calcular Histograma
        private int[] CalculaHistograma(Bitmap imagemCinza)
        {
            int[] histograma = new int[256];

            for (int x = 0; x < imagemCinza.Width; x++)
            {
                for (int y = 0; y < imagemCinza.Height; y++)
                {
                    Color cor = imagemCinza.GetPixel(x, y);
                    int tomDeCinza = (int)(cor.R * 0.299 + cor.G * 0.587 + cor.B * 0.114); // Converte para escala de cinza
                    histograma[tomDeCinza]++; // Incrementa o histograma
                }
            }

            return histograma;
        }

        // Equalizar Histograma
        private Bitmap EqualizarHistograma(Bitmap imagemCinza, int[] histograma)
        {
            int[] cdf = new int[256];
            int sum = 0;

            // Calcula a função de distribuição acumulada (CDF) do histograma
            for (int i = 0; i < 256; i++)
            {
                sum += histograma[i];
                cdf[i] = sum;
            }

            // Equaliza o histograma
            int pixels = imagemCinza.Width * imagemCinza.Height;
            for (int i = 0; i < 256; i++)
            {
                cdf[i] = (int)(255 * ((float)cdf[i] / pixels));
            }

            // Cria uma nova imagem equalizada
            Bitmap imagemEqualizada = new Bitmap(imagemCinza.Width, imagemCinza.Height);
            for (int x = 0; x < imagemCinza.Width; x++)
            {
                for (int y = 0; y < imagemCinza.Height; y++)
                {
                    Color cor = imagemCinza.GetPixel(x, y);
                    int tomDeCinza = (int)(cor.R * 0.299 + cor.G * 0.587 + cor.B * 0.114);
                    int novoTomDeCinza = cdf[tomDeCinza];
                    Color novaCor = Color.FromArgb(novoTomDeCinza, novoTomDeCinza, novoTomDeCinza);
                    imagemEqualizada.SetPixel(x, y, novaCor);
                }
            }

            return imagemEqualizada;
        }

        // GRÁFICOS
        private void AtualizaGraficosHistograma(int[] histogramaOriginal, int[] histogramaEqualizado)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            // Adiciona o histograma da imagem original ao primeiro gráfico
            chart1.Series.Add("Antes");
            chart1.Series["Antes"].ChartType = SeriesChartType.Column;
            chart1.Series["Antes"].Points.DataBindY(histogramaOriginal);
            chart1.ChartAreas[0].AxisY.Maximum = histogramaOriginal.Max() + 10;

            // Remove a legenda do primeiro gráfico
            chart1.Legends.Clear();

            // Adiciona o histograma da imagem equalizada ao segundo gráfico
            chart2.Series.Add("Depois");
            chart2.Series["Depois"].ChartType = SeriesChartType.Column;
            chart2.Series["Depois"].Points.DataBindY(histogramaEqualizado);
            chart2.ChartAreas[0].AxisY.Maximum = histogramaEqualizado.Max() + 10;

            // Remove a legenda do segundo gráfico
            chart2.Legends.Clear();
        }





        // BOTÃO AND --------------------------------------------------------------------------------------------------------------
        private void andBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" NÃO ESTIVER SELECIONADA
            if (!rbDuas.Checked)
            {
                MessageBox.Show("Escolha 'Ambas as Imagens' para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso a "Imagem A" ou "Imagem B" não estiverem carregadas
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image image1 = imgA.Image;
            Image image2 = imgB.Image;

            // Redimensiona as imagens para o mesmo tamanho, se necessário
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                // Redimensiona a imagem 2 para o tamanho da imagem 1
                image2 = RedimensionarImagem(image2, image1.Width, image1.Height);
            }

            Bitmap bitmap1 = new Bitmap(image1);
            Bitmap bitmap2 = new Bitmap(image2);

            Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

            // Converte as imagens para binário antes de realizar a operação AND
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    Color color1 = bitmap1.GetPixel(x, y);
                    Color color2 = bitmap2.GetPixel(x, y);

                    // Realiza a operação AND bit a bit nos componentes de cor
                    Color corResultado = Color.FromArgb(color1.R & color2.R, color1.G & color2.G, color1.B & color2.B);

                    // Define a cor resultante no bitmap de resultado
                    imagemResultado.SetPixel(x, y, corResultado);
                }
            }

            imgResultado.Image = imagemResultado;
        }




        // BOTÃO OR --------------------------------------------------------------------------------------------------------------
        private void orBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" NÃO ESTIVER SELECIONADA
            if (!rbDuas.Checked)
            {
                MessageBox.Show("Escolha 'Ambas as Imagens' para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso a "Imagem A" ou "Imagem B" não estiverem carregadas
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image image1 = imgA.Image;
            Image image2 = imgB.Image;

            // Redimensiona as imagens para o mesmo tamanho, se necessário
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                // Redimensiona a imagem 2 para o tamanho da imagem 1
                image2 = RedimensionarImagem(image2, image1.Width, image1.Height);
            }

            Bitmap bitmap1 = new Bitmap(image1);
            Bitmap bitmap2 = new Bitmap(image2);

            Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

            // Converte as imagens para binário antes de realizar a operação OR
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    Color color1 = bitmap1.GetPixel(x, y);
                    Color color2 = bitmap2.GetPixel(x, y);

                    // Realiza a operação OR bit a bit nos componentes de cor
                    Color corResultado = Color.FromArgb(color1.R | color2.R, color1.G | color2.G, color1.B | color2.B);

                    // Define a cor resultante no bitmap de resultado
                    imagemResultado.SetPixel(x, y, corResultado);
                }
            }

            imgResultado.Image = imagemResultado;
        }




        // BOTÃO XOR --------------------------------------------------------------------------------------------------------------
        private void xorBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" NÃO ESTIVER SELECIONADA
            if (!rbDuas.Checked)
            {
                MessageBox.Show("Escolha 'Ambas as Imagens' para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso a "Imagem A" ou "Imagem B" não estiverem carregadas
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image image1 = imgA.Image;
            Image image2 = imgB.Image;

            // Redimensiona as imagens para o mesmo tamanho, se necessário
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                // Redimensiona a imagem 2 para o tamanho da imagem 1
                image2 = RedimensionarImagem(image2, image1.Width, image1.Height);
            }

            Bitmap bitmap1 = new Bitmap(image1);
            Bitmap bitmap2 = new Bitmap(image2);

            Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

            // Converte as imagens para binário antes de realizar a operação XOR
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    Color color1 = bitmap1.GetPixel(x, y);
                    Color color2 = bitmap2.GetPixel(x, y);

                    // Realiza a operação XOR bit a bit nos componentes de cor
                    Color corResultado = Color.FromArgb(color1.R ^ color2.R, color1.G ^ color2.G, color1.B ^ color2.B);

                    // Define a cor resultante no bitmap de resultado
                    imagemResultado.SetPixel(x, y, corResultado);
                }
            }

            imgResultado.Image = imagemResultado;
        }




        // BOTÃO NOT -------------------------------------------------------------------------------------------------------------------
        private void notBT_Click(object sender, EventArgs e)
        {
            // Chamando a função para negativar ao clicar no botão NOT
            negativarBT_Click(sender, e);
        }




        // BOTÃO BLENDING --------------------------------------------------------------------------------------------------------------
        private void blendingBT_Click(object sender, EventArgs e)
        {
            // Exibe um aviso caso a opção "Ambas as Imagens" não estiver selecionada
            if (!rbDuas.Checked)
            {
                MessageBox.Show("Escolha 'Ambas as Imagens' para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe um aviso caso a "Imagem A" ou "Imagem B" não estiverem carregadas
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tenta converter o valor de blending
            if (!float.TryParse(blendingNTBNumericUpDown.Text.Replace(".", ","), out float valorBlending) || valorBlending < 0.01f || valorBlending > 1.00f)
            {
                // Limpa a NumericTextBox
                blendingNTBNumericUpDown.Text = "";


                // Exibe um aviso caso o blendingNTBNumericUpDown estiver nulo
                if (string.IsNullOrEmpty(blendingNTBNumericUpDown.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                Image image1 = imgA.Image;
                Image image2 = imgB.Image;

                if (image1 == null || image2 == null)
                {
                    MessageBox.Show("Abra duas Imagens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        Color color2 = ((Bitmap)image2).GetPixel(x, y);

                        // Calcula a cor resultante aplicando o valor de blending
                        int r = (int)(color1.R * (1 - valorBlending) + color2.R * valorBlending);
                        int g = (int)(color1.G * (1 - valorBlending) + color2.G * valorBlending);
                        int b = (int)(color1.B * (1 - valorBlending) + color2.B * valorBlending);

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

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.R + valorBlending * color1.R)));
                        int g = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.G + valorBlending * color1.G)));
                        int b = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.B + valorBlending * color1.B)));

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
                        int r = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.R + valorBlending * color1.R)));
                        int g = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.G + valorBlending * color1.G)));
                        int b = Math.Min(255, Math.Max(0, (int)Math.Round((1 - valorBlending) * color1.B + valorBlending * color1.B)));

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                imgResultado.Image = imagemResultado;
            }

        }




        // BOTÃO MÍNIMO ---------------------------------------------------------------------------------------------------------------------------------------
        private void minBT_Click(object sender, EventArgs e)
        {
            // // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);


                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                // Seleciona o tamanho da vizinhança
                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                // Filtra a imagem
                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {

                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        // Calcula o mínimo da vizinhança
                        int minimo = GetMinimo(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(minimo, minimo, minimo));
                    }
                }

                imgResultado.Image = imagemFiltrada;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int minimo = GetMinimo(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(minimo, minimo, minimo));
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR O MÍNIMO DE UMA VIZINHANÇA
        private int GetMinimo(int[,] matriz)
        {
            int minimo = int.MaxValue;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] < minimo)
                    {
                        minimo = matriz[i, j];
                    }
                }
            }

            return minimo;
        }




        // BOTÃO MÁXIMO ---------------------------------------------------------------------------------------------------------------------------------------
        private void maxBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color = ((Bitmap)image1).GetPixel(x, y);
                        int gray = (color.R + color.G + color.B) / 3;

                        Color novaCor = Color.FromArgb(color.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);
                    }
                }

                // Seleciona o tamanho da vizinhança
                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                // Filtra a imagem
                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        // Calcula o máximo da vizinhança
                        int maximo = GetMaximo(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(maximo, maximo, maximo));
                    }
                }

                imgResultado.Image = imagemFiltrada;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);
                    }
                }

                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int minimo = GetMinimo(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(minimo, minimo, minimo));
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR O MÁXIMO DE UMA VIZINHANÇA
        private int GetMaximo(int[,] vizinhanca)
        {
            int maximo = int.MinValue;
            for (int i = 0; i < vizinhanca.GetLength(0); i++)
            {
                for (int j = 0; j < vizinhanca.GetLength(1); j++)
                {
                    if (vizinhanca[i, j] > maximo)
                    {
                        maximo = vizinhanca[i, j];
                    }
                }
            }
            return maximo;
        }




        // BOTÃO MÉDIA --------------------------------------------------------------------------------------------------------------------------------------------
        private void medBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                // Seleciona o tamanho da vizinhança
                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                // Filtra a imagem
                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        // Calcula a média da vizinhança
                        int media = GetMedia(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(media, media, media));
                    }
                }

                imgResultado.Image = imagemFiltrada;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int media = GetMedia(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(media, media, media));
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR A MÉDIA DE UMA VIZINHANÇA
        private int GetMedia(int[,] matriz)
        {
            int soma = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    soma += matriz[i, j];
                }
            }

            int media = soma / (matriz.GetLength(0) * matriz.GetLength(1));
            return media;
        }




        // BOTÃO MEDIANA --------------------------------------------------------------------------------------------------------------------------------------------
        private void medianaBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                // Converte a imagem original para escala de cinza
                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                // Seleciona o tamanho da vizinhança
                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                // Filtra a imagem
                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {

                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int media = GetMediana(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(media, media, media));
                    }
                }

                imgResultado.Image = imagemFiltrada;
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

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                }

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int media = GetMediana(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(media, media, media));
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR A MEDIANA DE UMA VIZINHANÇA
        private int GetMediana(int[,] matriz)
        {
            int tamanho = matriz.GetLength(0) * matriz.GetLength(1);
            int[] elementos = new int[tamanho];

            int index = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    elementos[index] = matriz[i, j];
                    index++;
                }
            }

            Array.Sort(elementos);

            int mediana;
            if (tamanho % 2 == 0)
            {
                int meio = tamanho / 2;
                mediana = (elementos[meio - 1] + elementos[meio]) / 2;
            }
            else
            {
                int meio = tamanho / 2;
                mediana = elementos[meio];
            }

            return mediana;
        }




        // BOTÃO MEDIANA --------------------------------------------------------------------------------------------------------------------------------------------
        private void ordemBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                // Exibe um aviso caso a ordemTB estiver nula
                if (string.IsNullOrEmpty(ordemTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Converte a imagem original para escala de cinza
                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }


                // Seleciona o tamanho da vizinhança
                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                    ordemTB.Maximum = 8;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                    ordemTB.Maximum = 17;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                    ordemTB.Maximum = 35;
                }

                // Filtra a imagem
                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int ordem = GetOrdem(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(ordem, ordem, ordem));
                    }
                }

                imgResultado.Image = imagemFiltrada;
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

                // Exibe um aviso caso a ordemTB estiver nula
                if (string.IsNullOrEmpty(ordemTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);

                    }
                }

                int tamanhoVizinhanca = 0;
                if (!rb3.Checked && !rb5.Checked && !rb7.Checked)
                {
                    MessageBox.Show("Selecione o tamanho da vizinhança para filtrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rb3.Checked)
                {
                    tamanhoVizinhanca = 3;
                    ordemTB.Maximum = 8;
                }
                if (rb5.Checked)
                {
                    tamanhoVizinhanca = 5;
                    ordemTB.Maximum = 17;
                }
                if (rb7.Checked)
                {
                    tamanhoVizinhanca = 7;
                    ordemTB.Maximum = 35;
                }

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        int ordem = GetOrdem(vizinhanca);

                        imagemFiltrada.SetPixel(x, y, Color.FromArgb(ordem, ordem, ordem));
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR A ORDEM DE UMA VIZINHANÇA
        private int GetOrdem(int[,] matriz)
        {
            int tamanho = matriz.GetLength(0) * matriz.GetLength(1);
            int[] elementos = new int[tamanho];

            int index = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    elementos[index] = matriz[i, j];
                    index++;
                }
            }

            Array.Sort(elementos);

            int ordem;
            ordem = elementos[(int)ordemTB.Value];
            return ordem;
        }




        // BOTÃO MULTIPLICAÇÃO --------------------------------------------------------------------------------------------------------------------------------------------
        private void buttonmultiplicacaoBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                decimal multiplicacao = multiplicacaoTB.Value;

                // Exibe um aviso caso a multiplicacaoTB estiver nula
                if (string.IsNullOrEmpty(multiplicacaoTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Itera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        //Multiplica o RGB de cada pixel conforme o valor digitado e trunca os valores
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = (int)Math.Max(0, Math.Min(255, Math.Round(color1.R * multiplicacao)));
                        int g = (int)Math.Max(0, Math.Min(255, Math.Round(color1.G * multiplicacao)));
                        int b = (int)Math.Max(0, Math.Min(255, Math.Round(color1.B * multiplicacao)));

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

                // Obtem o valor do campo numérico para determinar quantas vezes a imagem será multiplicada
                decimal multiplicacao = multiplicacaoTB.Value;

                // Exibe um aviso caso a multiplicacaoTB estiver nula
                if (string.IsNullOrEmpty(multiplicacaoTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Itera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        //Multiplica o RGB de cada pixel conforme o valor digitado e trunca os valores
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = (int)Math.Max(0, Math.Min(255, Math.Round(color1.R * multiplicacao)));
                        int g = (int)Math.Max(0, Math.Min(255, Math.Round(color1.G * multiplicacao)));
                        int b = (int)Math.Max(0, Math.Min(255, Math.Round(color1.B * multiplicacao)));

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                imgResultado.Image = imagemResultado;
            }
        }




        // BOTÃO DIVISÃO --------------------------------------------------------------------------------------------------------------------------------------------
        private void divisaoBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                // Obtem o valor do campo numérico para determinar quantas vezes a imagem será dividida
                decimal divisao = divisaoTB.Value;

                // Exibe um aviso caso a divisaoTB estiver nula
                if (string.IsNullOrEmpty(divisaoTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Itera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        //Divide o RGB de cada pixel conforme o valor digitado e trunca os valores
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = (int)Math.Max(0, Math.Min(255, Math.Round(color1.R / divisao + color1.R / divisao)));
                        int g = (int)Math.Max(0, Math.Min(255, Math.Round(color1.G / divisao + color1.G / divisao)));
                        int b = (int)Math.Max(0, Math.Min(255, Math.Round(color1.B / divisao + color1.B / divisao)));

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                imgResultado.Image = imagemResultado;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                Image image1 = imgB.Image;

                // Pede para abrir uma imagem caso já não esteja aberta
                if (image1 == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtem o valor do campo numérico para determinar quantas vezes a imagem será multiplicada
                decimal divisao = divisaoTB.Value;

                // Exibe um aviso caso a divisaoTB estiver nula
                if (string.IsNullOrEmpty(divisaoTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap imagemResultado = new Bitmap(image1.Width, image1.Height);

                // Itera os pixels da imagem
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        //Divide o RGB de cada pixel conforme o valor digitado e trunca os valores
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = (int)Math.Max(0, Math.Min(255, Math.Round(color1.R / divisao + color1.R / divisao)));
                        int g = (int)Math.Max(0, Math.Min(255, Math.Round(color1.G / divisao + color1.G / divisao)));
                        int b = (int)Math.Max(0, Math.Min(255, Math.Round(color1.B / divisao + color1.B / divisao)));

                        imagemResultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                imgResultado.Image = imagemResultado;
            }
        }




        // FILTRAGEM GAUSSIANA --------------------------------------------------------------------------------------------------------------------------------------------
        private void gaussianoBT_Click(object sender, EventArgs e)
        {
            // CASO A OPÇÃO "AMBAS AS IMAGENS" ESTIVER SELECIONADA
            if (rbDuas.Checked)
            {
                MessageBox.Show("A operação é feita apenas com uma imagem de cada vez.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se nenhuma imagem está selecionada
            if (!rbA.Checked && !rbB.Checked)
            {
                MessageBox.Show("Selecione 'Imagem A' ou 'Imagem B' no campo 'Escolha de Imagens'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

                // Exibe um aviso caso a gaussianaNTB estiver nula
                if (string.IsNullOrEmpty(gaussianaNTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Exibe um aviso caso o valor da gaussianaNTB for igual 0
                if (string.IsNullOrWhiteSpace(gaussianaNTB.Text) || !double.TryParse(gaussianaNTB.Text, out double sigma) || sigma == 0)
                {
                    MessageBox.Show("Insira um valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mostrarKernel(sigma);

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);

                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;

                        int gray = (r + g + b) / 3;
                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);
                    }
                }

                // Tamanho da vizinhança = 5
                int tamanhoVizinhanca = 5;

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                // Itera sobre cada pixel da imagem em tons de cinza
                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        // Define uma matriz para armazenar a vizinhança atual
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                // Trata os casos em que xIndex e yIndex estão fora dos limites da imagem
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        // Aplica o filtro Gaussiano
                        double gaussian = GetGaussian(vizinhanca, sigma);

                        int pixelNovo = (int)Math.Round(gaussian);
                        if (pixelNovo < 0) pixelNovo = 0;
                        else if (pixelNovo > 255) pixelNovo = 255;
 
                        Color imagemNova = Color.FromArgb(pixelNovo, pixelNovo, pixelNovo);
                        imagemFiltrada.SetPixel(x, y, imagemNova);
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }

            // CASO A OPÇÃO "IMAGEM B" ESTIVER SELECIONADA
            if (rbB.Checked)
            {
                // Carrega a imagem
                Image image1 = imgB.Image;

                // Pede para abrir uma imagem caso já não esteja aberta
                if (image1 == null)
                {
                    MessageBox.Show("Abra uma imagem no campo 'Imagem B'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Exibe um aviso caso a ordemTB estiver nula
                if (string.IsNullOrEmpty(gaussianaNTB.Text))
                {
                    MessageBox.Show("Insira um valor para realizar a operação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Exibe um aviso caso o valor da gaussianaNTB for igual 0
                if (string.IsNullOrWhiteSpace(gaussianaNTB.Text) || !double.TryParse(gaussianaNTB.Text, out double sigma) || sigma == 0)
                {
                    MessageBox.Show("Insira um valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mostrarKernel(sigma);

                Bitmap imagemCinza = new Bitmap(image1.Width, image1.Height);

                // Converte a imagem original para escala de cinza
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color color1 = ((Bitmap)image1).GetPixel(x, y);
                        int r = color1.R;
                        int g = color1.G;
                        int b = color1.B;
                        int gray = (r + g + b) / 3;

                        Color novaCor = Color.FromArgb(color1.A, gray, gray, gray);
                        imagemCinza.SetPixel(x, y, novaCor);
                    }
                }

                // Tamanho da vizinhança = 5
                int tamanhoVizinhanca = 5;

                Bitmap imagemFiltrada = new Bitmap(imagemCinza.Width, imagemCinza.Height);

                // Itera sobre cada pixel da imagem em tons de cinza
                for (int x = 0; x < imagemCinza.Width; x++)
                {
                    for (int y = 0; y < imagemCinza.Height; y++)
                    {
                        // Define uma matriz para armazenar a vizinhança atual
                        int[,] vizinhanca = new int[tamanhoVizinhanca, tamanhoVizinhanca];
                        for (int i = 0; i < tamanhoVizinhanca; i++)
                        {
                            for (int j = 0; j < tamanhoVizinhanca; j++)
                            {
                                int xIndex = x + i - tamanhoVizinhanca / 2;
                                int yIndex = y + j - tamanhoVizinhanca / 2;

                                if (xIndex < 0)
                                {
                                    xIndex = 0;
                                }
                                if (xIndex >= imagemCinza.Width)
                                {
                                    xIndex = imagemCinza.Width - 1;
                                }
                                if (yIndex < 0)
                                {
                                    yIndex = 0;
                                }
                                if (yIndex >= imagemCinza.Height)
                                {
                                    yIndex = imagemCinza.Height - 1;
                                }

                                vizinhanca[i, j] = imagemCinza.GetPixel(xIndex, yIndex).R;
                            }
                        }

                        // Aplica o filtro Gaussiano
                        double gaussian = GetGaussian(vizinhanca, sigma);

                        int pixelNovo = (int)Math.Round(gaussian);
                        if (pixelNovo < 0) pixelNovo = 0;
                        else if (pixelNovo > 255) pixelNovo = 255;

                        Color imagemNova = Color.FromArgb(pixelNovo, pixelNovo, pixelNovo);
                        imagemFiltrada.SetPixel(x, y, imagemNova);
                    }
                }

                imgResultado.Image = imagemFiltrada;
            }
        }

        // FUNÇÃO PARA CALCULAR O FILTRO GAUSSIANO
        private double GetGaussian(int[,] vizi, double sigma)
        {
            double soma = 0;

            int size = vizi.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int valorPixel = vizi[i, j];
                    double exponente = -(i * i + j * j) / (2 * sigma * sigma);
                    double peso = Math.Exp(exponente) / (2 * Math.PI * sigma * sigma);
                    soma += valorPixel * peso;
                }
            }

            return soma;
        }

        // Gera os valores do Kernel
        private double[,] gerarKernel(int size, double sigma)
        {
            double[,] kernel = new double[size, size];
            double sum = 0;
            int mid = size / 2;
            double sigma2 = sigma * sigma;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    double dx = x - mid;
                    double dy = y - mid;
                    double exponent = -(dx * dx + dy * dy) / (2 * sigma2);
                    kernel[x, y] = Math.Exp(exponent) / (2 * Math.PI * sigma2);
                    sum += kernel[x, y];
                }
            }

            // Normaliza o Kernel
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    kernel[x, y] /= sum;
                }
            }

            return kernel;
        }

        // Converte o Kernel em bit map
        private Bitmap converterKernel(double[,] kernel)
        {
            int size = kernel.GetLength(0);
            Bitmap bitmap = new Bitmap(size, size);

            double max = kernel.Cast<double>().Max();
            double min = kernel.Cast<double>().Min();
            double range = max - min;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    int value = (int)((kernel[x, y] - min) / range * 255);
                    Color color = Color.FromArgb(value, value, value);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        // Função para mostrar o Kernel
        private void mostrarKernel(double sigma)
        {
            int size = 5;
            double[,] kernel = gerarKernel(size, sigma);
            Bitmap bitmap = converterKernel(kernel);

            kernelPictureBox.Image = bitmap;
        }



    }
}





