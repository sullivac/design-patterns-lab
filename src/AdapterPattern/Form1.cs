using System;
using System.Windows.Forms;

namespace AdapterPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler OnDrawShapes
        {
            add { button1.Click += value; }
            remove { button1.Click -= value; }
        }
    }
}
