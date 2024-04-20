namespace PrzetwarzanieObrazow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap? img;

        private void Neg(Bitmap? image)
        {
            Bitmap negImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j); // Pobranie koloru piksela
                                                                // Obliczanie negatywu poprzez odjêcie wartoœci kolorów od 255
                    Color negColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    negImage.SetPixel(i, image.Height - 1 - j, negColor);
                }
            }
            pictureBox1.Image = negImage;
        }

        private void Red(Bitmap? image)
        {
            Bitmap redImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j); // Pobranie koloru piksela
                    // Zachowujemy wartoœæ kana³u czerwonego, a kana³y zielony i niebieski ustawiamy na 0
                    Color redColor = Color.FromArgb(originalColor.R, 0, 0);
                    redImage.SetPixel(image.Width - 1 - i, j, redColor);
                }
            }
            pictureBox2.Image = redImage;
        }

        private void Gray(Bitmap? image)
        {
            Bitmap grayImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j); // Pobranie koloru piksela
                                                                // Obliczenie wartoœci szaroœci na podstawie wzoru
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale); // Utworzenie koloru szarego

                    grayImage.SetPixel(i, j, grayColor);
                }
            }
            pictureBox3.Image = grayImage;
        }

        private void BnW(Bitmap? image, int threshold)
        {
            Bitmap bwImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j);

                    int luminance = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    // Ustawianie piksela na czarny lub bia³y na podstawie progu
                    Color bwColor = luminance < 150 ? Color.Black : Color.White;

                    bwImage.SetPixel(image.Width - 1 - i, image.Height - 1 - j, bwColor);
                }
            }
            pictureBox4.Image = bwImage;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var file = openFileDialog1.FileName;
            if (file != null)
            {
                img = new Bitmap(file);
                pictureBoxLoad.Image = img;
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                int threadsNumber = 4;
                Thread[] threads = new Thread[threadsNumber];

                threads[0] = new Thread(() => Neg((Bitmap)img.Clone()));
                threads[1] = new Thread(() => Red((Bitmap)img.Clone()));
                threads[2] = new Thread(() => Gray((Bitmap)img.Clone()));
                threads[3] = new Thread(() => BnW((Bitmap)img.Clone(), 50));

                foreach (var thread in threads) thread.Start();
                foreach (var thread in threads) thread.Join();

            }
            else
            {
                MessageBox.Show("Wgraj zdjêcie!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
