﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Photo_Editor
{
    public partial class WorkSpace : UserControl
    {
        public History History { get; set; }
        public DrawSpace DrawSpace { get; set; }
        public LayerContainer LayerContainer { get; set; }
        public Rectangle Rect { get; set; }
        public Size BmpSize { get; set; }
        public System.Drawing.Imaging.PixelFormat BmpPixelFormat { get; set; }

        string filename;
        public string FileName
        {
            get => filename;
            set => filename = value;
        }

        string filepath;
        public string FilePath
        {
            get => filepath;
            set
            {
                filepath = value;
                if (value != "")
                {
                    string name = "";
                    foreach (char c in filepath)
                    {
                        if (c == '\\') name = "";
                        else name += c;
                    }
                    filename = name;
                }
            }
        }
        public bool Working { get; set; }
        public bool Saved { get; set; }
        public bool Stored { get; set; }

        public WorkSpace(DrawSpace ds, LayerContainer lc, History h)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            AutoScroll = true;
            DrawSpace = ds;
            LayerContainer = lc;
            History = h;
            Working = false;
            Saved = true;
            Stored = false;
            filepath = filename = "";
            this.Controls.Add(DrawSpace);
        }
    }
}
