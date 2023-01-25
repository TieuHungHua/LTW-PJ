﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Photo_Editor.Function_Forms
{
    public partial class NewLayer : Form
    {
        public NewLayer()
        {
            InitializeComponent();
        }

        public void SetDefaultName(int n)
        {
            textBox1.Text = "Layer" + (n + 1);
        }

        public bool IsVisible
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        public string LayerName
        {
            get
            {
                return textBox1.Text;
            }
        }
    }
}
