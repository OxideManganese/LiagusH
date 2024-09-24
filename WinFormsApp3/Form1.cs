using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        // ���������� ��� �������� ��������� �������
        private bool isKvak = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isKvak = true;
            pictureBox1.Image = Image.FromFile("H:\\��\\k.jpg"); // �������� �� ���� � ��������� �������
            SaveFrogStateToRegistry();
            MessageBox.Show("���-���!");
        }

        private void button2_Click(object sender, EventArgs e) // ���������� ������� ��� "������"
        {
            isKvak = false;
            pictureBox1.Image = Image.FromFile("H:\\��\\m.jpg"); // �������� �� ���� � �������� �������
            SaveFrogStateToRegistry();
        }

        private void SaveFrogStateToRegistry()
        {
            // ���������� ��������� � ������
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinFormsApp3\\FrogState");
            key.SetValue("IsKvak", isKvak);
            key.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ��������� ��������� �� �������
            LoadFrogStateFromRegistry();
        }

        private void LoadFrogStateFromRegistry()
        {
            // ��������� ��������� �� �������
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinFormsApp3\\FrogState");
            if (key != null)
            {
                object value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\WinFormsApp3\\FrogState", "IsKvak", null);
                if (value != null)
                {
                    bool.TryParse(value.ToString(), out isKvak);
                }
                key.Close();

                // ��������� ���������� �����������
                if (isKvak)
                {
                    pictureBox1.Image = Image.FromFile("H:\\��\\k.jpg");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("H:\\��\\m.jpg");
                }
            }
        }
    }
}
