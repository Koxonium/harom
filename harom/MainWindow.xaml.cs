using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace harom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int fullprice;
        int onePrice = 200;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            fullprice = 0;

            quantityBox.GotFocus += ClearTextBox;
            quantityBox.LostFocus += WriteBackTag;

            pastatypeBox.GotFocus += ClearTextBox;
            pastatypeBox.LostFocus += WriteBackTag;

            fillingBox.GotFocus += ClearTextBox;
            fillingBox.LostFocus += WriteBackTag;

            AddButton.Click += addEvent;

            CancelButton.Click += CBUttonEvent;

            OrderButton.Click += OrderEvent;
        }

        void ClearTextBox(object s, EventArgs e)
        {
            TextBox box = s as TextBox;
            if (box.Text == box.Tag.ToString())
            {
                box.Clear();
            }
        }

        void WriteBackTag(object s, EventArgs e)
        {
            TextBox box = s as TextBox;
            if (box.Text == "")
            {
                box.Text = box.Tag.ToString();
            }
        }

        void CBUttonEvent(object s, EventArgs e)
        {
            quantityBox.Text = quantityBox.Tag.ToString();
            pastatypeBox.Text = pastatypeBox.Tag.ToString();
            fillingBox.Text = fillingBox.Tag.ToString();
        }

        void addEvent(object s, EventArgs e)
        {
            try
            {
                int quantity = int.Parse(quantityBox.Text);
                if (int.TryParse(quantityBox.Text, out quantity))
                {
                    fullprice += onePrice * quantity;
                    panel.Children.Add(new Label() { Margin = new Thickness(0, 20, 0, -20), Content = $"{fillingBox.Text} palacsinta\n{pastatypeBox.Text} tészta\n{quantityBox.Text} darab" });
                    priceBox.Content = $"Összesen: {fullprice} Ft";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        void OrderEvent(object s, EventArgs e)
        {
            panel.Children.Clear();
            fullprice = 0;
            priceBox.Content = "Összesen: ";
        }
    }
}
