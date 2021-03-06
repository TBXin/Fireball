﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Fireball.Core;

namespace Fireball.Editor
{
    public partial class TextPreview : Form
    {
        private Font font;
        public String Content { get { return tText.Text; } }

        public TextPreview()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public TextPreview(Font font, CultureInfo locale) : this()
        {
            Thread.CurrentThread.CurrentUICulture = locale;
            ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            Localizer.ApplyResourceToControl(resources, this, locale);

            Text = resources.GetString("$this.Text", locale);
            this.font = font;
            tText.Font = this.font;
        }

        private void bFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog() { Font = font })
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Settings.Instance.TextFont = tText.Font = fd.Font;
                    tText.Focus();
                }
            }
        }
    }
}
