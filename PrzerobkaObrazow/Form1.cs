namespace PrzerobkaObrazow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        // Deklaracja do przechowywania obrazu i jego kopii
        private Bitmap? img;
        private Bitmap? copy;

        // Metoda obs³uguj¹ca klikniêcie przycisku do otwierania plików
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); // Wyœwietlenie okna dialogowego do wyboru pliku
            var file = openFileDialog1.FileName; // Pobranie nazwy wybranego pliku
            if (file != null)
            {
                img = new Bitmap(file); // Wczytanie obrazu z pliku
                copy = img; // Przypisanie kopii obrazu
                pictureBox1.Image = img; // Wyœwietlenie obrazu w PictureBox
            }
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku do konwersji obrazu na odcienie szaroœci
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentImg = new Bitmap(pictureBox1.Image); // Tworzenie kopii obecnego obrazu
                Bitmap grayImg = new Bitmap(currentImg.Width, currentImg.Height); // Tworzenie nowego obrazu o takich samych wymiarach

                // Pêtla przechodz¹ca przez wszystkie piksele obrazu
                for (int i = 0; i < currentImg.Width; i++)
                {
                    for (int j = 0; j < currentImg.Height; j++)
                    {
                        Color originalColor = currentImg.GetPixel(i, j); // Pobranie koloru piksela
                        // Obliczenie wartoœci szaroœci na podstawie wzoru
                        int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                        Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale); // Utworzenie koloru szarego
                        grayImg.SetPixel(i, j, grayColor); // Ustawienie piksela na obrazie wynikowym
                    }
                }

                pictureBox1.Image = grayImg; // Wyœwietlenie obrazu w odcieniach szaroœci
            }
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku do przywrócenia oryginalnego obrazu
        private void button3_Click(object sender, EventArgs e)
        {
            if (copy != null)
            {
                pictureBox1.Image = new Bitmap(copy); // Przywrócenie kopii obrazu jako nowy obiekt Bitmap
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Metoda obs³uguj¹ca klikniêcie przycisku do konwersji obrazu na negatyw
        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap currentImg = new Bitmap(pictureBox1.Image);
                    Bitmap negImg = new Bitmap(currentImg.Width, currentImg.Height);

                    // Pêtla przechodz¹ca przez wszystkie piksele obrazu
                    for (int i = 0; i < currentImg.Width; i++)
                    {
                        for (int j = 0; j < currentImg.Height; j++)
                        {
                            Color originalColor = currentImg.GetPixel(i, j); // Pobranie koloru piksela
                            // Obliczanie negatywu poprzez odjêcie wartoœci kolorów od 255
                            Color negColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                            negImg.SetPixel(i, j, negColor);
                        }
                    }

                    pictureBox1.Image = negImg; // Wyœwietlenie negatywu obrazu
                }
            }
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku do konwersji obrazu na czarno-bia³y
        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentImg = new Bitmap(pictureBox1.Image);
                Bitmap bwImg = new Bitmap(currentImg.Width, currentImg.Height);

                // Pêtla przechodz¹ca przez wszystkie piksele obrazu
                for (int i = 0; i < currentImg.Width; i++)
                {
                    for (int j = 0; j < currentImg.Height; j++)
                    {
                        Color originalColor = currentImg.GetPixel(i, j); // Pobranie koloru piksela
                        // Obliczanie jasnoœci piksela
                        int luminance = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                        // Ustawianie piksela na czarny lub bia³y na podstawie progu
                        Color bwColor = luminance < 150 ? Color.Black : Color.White;
                        bwImg.SetPixel(i, j, bwColor); // Ustawienie piksela na obrazie wynikowym
                    }
                }

                pictureBox1.Image = bwImg; // Wyœwietlenie obrazu w czerni i bieli
            }
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku, która zmienia obraz na jego czerwon¹ wersjê
        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentImg = new Bitmap(pictureBox1.Image);
                Bitmap redImg = new Bitmap(currentImg.Width, currentImg.Height);

                // Przechodzimy przez ka¿dy piksel obrazu
                for (int i = 0; i < currentImg.Width; i++)
                {
                    for (int j = 0; j < currentImg.Height; j++)
                    {
                        Color originalColor = currentImg.GetPixel(i, j); // Pobranie koloru piksela
                        // Zachowujemy wartoœæ kana³u czerwonego, a kana³y zielony i niebieski ustawiamy na 0
                        Color redColor = Color.FromArgb(originalColor.R, 0, 0);
                        redImg.SetPixel(i, j, redColor); // Ustawienie piksela na obrazie wynikowym
                    }
                }

                pictureBox1.Image = redImg; // Ustawiamy obraz w pictureBox1 na nowo utworzony obraz czerwony
            }
        }

        // Poni¿sze analogicznie
        private void button7_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentImg = new Bitmap(pictureBox1.Image);
                Bitmap greenImg = new Bitmap(currentImg.Width, currentImg.Height);

                for (int i = 0; i < currentImg.Width; i++)
                {
                    for (int j = 0; j < currentImg.Height; j++)
                    {
                        Color originalColor = currentImg.GetPixel(i, j);
                        // Zachowujemy wartoœæ kana³u zielonego, a kana³y czerwony i niebieski ustawiamy na 0
                        Color greenColor = Color.FromArgb(0, originalColor.G, 0);
                        greenImg.SetPixel(i, j, greenColor);
                    }
                }

                pictureBox1.Image = greenImg;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap currentImg = new Bitmap(pictureBox1.Image);
                Bitmap blueImg = new Bitmap(currentImg.Width, currentImg.Height);

                for (int i = 0; i < currentImg.Width; i++)
                {
                    for (int j = 0; j < currentImg.Height; j++)
                    {
                        Color originalColor = currentImg.GetPixel(i, j);
                        // Zachowujemy wartoœæ kana³u niebieskiego, a kana³y czerwony i zielony ustawiamy na 0
                        Color blueColor = Color.FromArgb(0, 0, originalColor.B);
                        blueImg.SetPixel(i, j, blueColor);
                    }
                }

                pictureBox1.Image = blueImg;
            }
        }


    }
}
