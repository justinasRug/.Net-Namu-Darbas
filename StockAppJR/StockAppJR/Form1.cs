using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiReceive;


namespace StockAppJR
{
    public partial class Form1 : Form
    {
        int index;
        string stock;

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            stock = textStok.Text;
            //int numb = Convert.ToInt32(textBox5.Text);
            try
            {
                var items = await GetApiItems.getItems(stock);
                for (int i = 0; i < items.Count; i++)
                    DataComboBox1.Items.Add(items[i].Date);

            }
            catch (Exception except)
            {
                MessageBox.Show("Incorect abbreviation");
            }

            /* textBox2.Text = items[numb].Date.ToString();
             textBox1.Text = items[numb].Open.ToString();
             textBox3.Text = items[numb].High.ToString();
             textBox4.Text = items[numb].Low.ToString();
             textBox6.Text = items[numb].Close.ToString();
             textBox7.Text = items[numb].Volume.ToString();
 */
        }

        private void textStok_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = DataComboBox1.SelectedIndex;
            //textBox1.Text = index.ToString();

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var items = await GetApiItems.getItems(stock);
                textBox1.Text = items[index].Open.ToString();
                textBox2.Text = items[index].High.ToString();
                textBox3.Text = items[index].Low.ToString();
                textBox4.Text = items[index].Close.ToString();
                textBox6.Text = items[index].Volume.ToString();

            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }
    }
}
