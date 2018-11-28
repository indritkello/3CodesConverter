using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeConverter
{
  public partial class Form1 : Form
  {

    public enum HapDekodimi
    {
     KodiGray,
     KodiPlus3,
     KodiHamming

    };
    public List<HapDekodimi> hapat{ get; set; }
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
      int grayToBinary(int num)
    {
      int temp = num ^ (num >> 8);
      temp ^= (temp >> 4);
      temp ^= (temp >> 2);
      temp ^= (temp >> 1);
      return temp;
    }
    int binaryToGray(int num)
    {
      return (num >> 1) ^ num;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //Use this if input is Integer
      //string binary = Convert.ToString(Convert.ToInt32(textBox1.Text),toBase: 2);
      hapat = new List<HapDekodimi>();
      string binary = textBox1.Text;
      int binaryInt = 0;
      try
      {
        binaryInt = Convert.ToInt32(binary,2);
      }
      catch (Exception)
      {
        label4.Text = "Nuk keni shkruar nje numer binar! Provojeni serisht!";
      }
      hapat.Add((HapDekodimi)Enum.Parse(typeof(HapDekodimi), comboBox3.Text));
      hapat.Add((HapDekodimi)Enum.Parse(typeof(HapDekodimi), comboBox2.Text));
      hapat.Add((HapDekodimi)Enum.Parse(typeof(HapDekodimi), comboBox1.Text));
      if (hapat.Distinct().Count() < 3)
      {
        label4.Text += "3 vlerat e zgjedhura duhet te jene te ndryshme!";
        return;
      }
      textBox2.Text = DekodoVlerat(binary, hapat);
    }
    public string DekodoKodinGray(string binary)
    {
      try
      {
        int num = Convert.ToInt32(binary,2);
        int temp = num ^ (num >> 8);
        temp ^= (temp >> 4);
        temp ^= (temp >> 2);
        temp ^= (temp >> 1);

        return Convert.ToString(temp, 2);
      }
      catch(System.FormatException ex)
      {
        label4.Text += ex.Message;
      }
      
        return "";
      
    }
    public string DekodoKodin3Plus(string binary)
    {
      int num = Convert.ToInt32(binary,2);
      int temp = num ^ (num >> 8);
      temp ^= (temp >> 4);
      temp ^= (temp >> 2);
      temp ^= (temp >> 1);
      return Convert.ToString(temp, 2);
    }
    public string DekodoVlerat(string binary, List<HapDekodimi> hapatEDekodimit)
    {
      if (hapatEDekodimit.Count() == 0)
      {
        return binary;
      }
      switch (hapatEDekodimit[0])
      {  case HapDekodimi.KodiGray:
              binary = DekodoKodinGray(binary);
          break;
        case HapDekodimi.KodiPlus3:
          binary = DekodoKodin3Plus(binary);
          break;
        case HapDekodimi.KodiHamming:
          
          break;

      }
      hapatEDekodimit.RemoveAt(0);
      binary = DekodoVlerat(binary, hapatEDekodimit);
      return binary;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
