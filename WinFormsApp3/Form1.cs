using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        // Переменная для хранения состояния лягушки
        private bool isKvak = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isKvak = true;
            pictureBox1.Image = Image.FromFile("H:\\УП\\k.jpg"); // Замените на путь к квакающей лягушке
            SaveFrogStateToRegistry();
            MessageBox.Show("Ква-ква!");
        }

        private void button2_Click(object sender, EventArgs e) // Обработчик события для "Сидеть"
        {
            isKvak = false;
            pictureBox1.Image = Image.FromFile("H:\\УП\\m.jpg"); // Замените на путь к молчащей лягушке
            SaveFrogStateToRegistry();
        }

        private void SaveFrogStateToRegistry()
        {
            // Записываем состояние в реестр
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinFormsApp3\\FrogState");
            key.SetValue("IsKvak", isKvak);
            key.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Загружаем состояние из реестра
            LoadFrogStateFromRegistry();
        }

        private void LoadFrogStateFromRegistry()
        {
            // Загружаем состояние из реестра
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinFormsApp3\\FrogState");
            if (key != null)
            {
                object value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\WinFormsApp3\\FrogState", "IsKvak", null);
                if (value != null)
                {
                    bool.TryParse(value.ToString(), out isKvak);
                }
                key.Close();

                // Загружаем подходящее изображение
                if (isKvak)
                {
                    pictureBox1.Image = Image.FromFile("H:\\УП\\k.jpg");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("H:\\УП\\m.jpg");
                }
            }
        }
    }
}
