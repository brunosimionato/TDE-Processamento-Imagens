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




        // BOTÃO ABRIR IMAGEM 1
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
                    // EXIBE A IMAGEM NO PICTURE BOX
                    imgA.Image = new System.Drawing.Bitmap(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    // MENSAGEM DE ERRO CASO A IMAGEM NÃO FOR CARREGADA
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }



        // BOTÃO ABRIR IMAGEM 2
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
                    // EXIBE A IMAGEM NO PICTURE BOX
                    imgB.Image = new System.Drawing.Bitmap(openFileDialog2.FileName);
                }
                catch (Exception ex)
                {
                    // MENSAGEM DE ERRO CASO A IMAGEM NÃO FOR CARREGADA
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }



        // BOTÃO SALVAR IMAGEM
        private void btSalavar_Click(object sender, EventArgs e)
        {
            // VERIFICA SE TEM UMA IMAGEM NO PICTURE BOX
            if (imgResultado.Image == null)
            {
                MessageBox.Show("Não há imagem para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ABRE DIALOGO PARA SALVAMENTO
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Salvar Imagem";
            saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os arquivos|*.*";
            saveFileDialog.DefaultExt = "jpg"; // FORMATO PADRÃO
            saveFileDialog.AddExtension = true;

            // AO CLICAR EM SALVAR DENTRO DO DIALOGO, A IMAGEM É SALVA
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // OBTÉM A IMAGEM DA PICTURE BOX
                    Bitmap imagem = new Bitmap(imgResultado.Image);

                    // SALVA A IMAGEM NO DISCO
                    imagem.Save(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }









        private void negativarBT_Click(object sender, EventArgs e)
        {
            // Verifica se há uma imagem no PictureBox original
            if (imgA.Image == null)
            {
                MessageBox.Show("Por favor, carregue uma imagem antes de negativar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria uma cópia da imagem original para negativar
            Bitmap imagemOriginal = new Bitmap(imgA.Image);

            // Itera sobre cada pixel na imagem e inverte suas cores
            for (int x = 0; x < imagemOriginal.Width; x++)
            {
                for (int y = 0; y < imagemOriginal.Height; y++)
                {
                    Color corOriginal = imagemOriginal.GetPixel(x, y);
                    Color corNegativa = Color.FromArgb(255 - corOriginal.R, 255 - corOriginal.G, 255 - corOriginal.B);
                    imagemOriginal.SetPixel(x, y, corNegativa);
                }
            }

            // Exibe a imagem negativada no PictureBoxResultado
            imgResultado.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste para exibição
            imgResultado.Image = imagemOriginal;
        }

        private void cinzaBT_Click(object sender, EventArgs e)
        {
            // Verifica se há uma imagem no PictureBox original
            if (imgA.Image == null)
            {
                MessageBox.Show("Por favor, carregue uma imagem antes de converter para escala de cinza.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria uma cópia da imagem original para converter para escala de cinza
            Bitmap imagemOriginal = new Bitmap(imgA.Image);

            // Itera sobre cada pixel na imagem e calcula a média dos valores de intensidade RGB
            for (int x = 0; x < imagemOriginal.Width; x++)
            {
                for (int y = 0; y < imagemOriginal.Height; y++)
                {
                    Color corOriginal = imagemOriginal.GetPixel(x, y);
                    int media = (corOriginal.R + corOriginal.G + corOriginal.B) / 3; // Calcula a média dos valores RGB
                    Color corCinza = Color.FromArgb(media, media, media); // Cria uma cor em escala de cinza com a média calculada
                    imagemOriginal.SetPixel(x, y, corCinza); // Define o pixel na imagem com a nova cor em escala de cinza
                }
            }

            // Exibe a imagem em escala de cinza no PictureBoxResultado
            imgResultado.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste para exibição
            imgResultado.Image = imagemOriginal;
        }




        private void somaBT_Click(object sender, EventArgs e)
        {
            // Verifica se há imagens nos PictureBoxes
            if (imgA.Image == null || imgB.Image == null)
            {
                MessageBox.Show("Por favor, carregue duas imagens antes de realizar a soma.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Normaliza as intensidades das imagens para [0, 1]
            Bitmap imagemA = NormalizarIntensidades(new Bitmap(imgA.Image));
            Bitmap imagemB = NormalizarIntensidades(new Bitmap(imgB.Image));

            // Realiza a soma das intensidades normalizadas
            Bitmap resultado = SomaImagens(imagemA, imagemB);

            // Exibe o resultado da soma no PictureBoxResultado
            imgResultado.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste para exibição
            imgResultado.Image = resultado;
        }

        private Bitmap NormalizarIntensidades(Bitmap imagem)
        {
            Bitmap imagemNormalizada = new Bitmap(imagem.Width, imagem.Height);

            for (int x = 0; x < imagem.Width; x++)
            {
                for (int y = 0; y < imagem.Height; y++)
                {
                    Color pixel = imagem.GetPixel(x, y);
                    double intensidade = (pixel.R + pixel.G + pixel.B) / 3.0; // Calcula a média das intensidades
                    double normalizado = intensidade / 255.0; // Normaliza para o intervalo [0, 1]
                    int valorNormalizado = (int)Math.Round(normalizado * 255); // Ajusta para o intervalo [0, 255]
                    Color novoPixel = Color.FromArgb(valorNormalizado, valorNormalizado, valorNormalizado);
                    imagemNormalizada.SetPixel(x, y, novoPixel);
                }
            }

            return imagemNormalizada;
        }

        private Bitmap SomaImagens(Bitmap imagemA, Bitmap imagemB)
        {
            int largura = Math.Min(imagemA.Width, imagemB.Width);
            int altura = Math.Min(imagemA.Height, imagemB.Height);

            Bitmap resultado = new Bitmap(largura, altura);

            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    Color pixelA = imagemA.GetPixel(x, y);
                    Color pixelB = imagemB.GetPixel(x, y);

                    // Soma as intensidades dos pixels normalizados
                    double soma = pixelA.R / 255.0 + pixelB.R / 255.0;

                    // Ajusta para o intervalo [0, 255]
                    int valorSoma = (int)Math.Round(soma * 255);

                    // Garante que o valor esteja dentro do intervalo válido
                    valorSoma = Math.Max(0, Math.Min(255, valorSoma));

                    Color novoPixel = Color.FromArgb(valorSoma, valorSoma, valorSoma);
                    resultado.SetPixel(x, y, novoPixel);
                }
            }

            return resultado;
        }

        private void gpA_Enter(object sender, EventArgs e)
        {

        }


    }
}
