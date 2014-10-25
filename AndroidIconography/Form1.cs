﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidIconography {
    public partial class Form1 : Form {

        private string res_path = "res";
        private string drawable = "drawable";
        private string ldpi_36 = "-ldpi";
        private string mdpi_48 = "-mdpi";
        private string tvdpi_64 = "-tvdpi";
        private string hdpi_72 = "-hdpi";
        private string xhdpi_96 = "-xhdpi";
        private string xxhdpi_144 = "-xxhdpi";
        private string xxxhdpi_192 = "-xxxhdpi";
        private string ic_launcher = "ic_launcher";

        Bitmap bitmap;

        public Form1 () {
            InitializeComponent();

            this.Icon = global::AndroidIconography.Properties.Resources.android_Iconagraphy_icon;

        }

        private void cbSelectAll_CheckedChanged ( object sender, EventArgs e ) {
            if ( ( sender as CheckBox ).Checked ) {
                cb192_xxxhdpi.Checked = true;
                cb144_xxhdpi.Checked = true;
                cb96_xhdpi.Checked = true;
                cb72_hdpi.Checked = true;
                cb64_tvdpi.Checked = true;
                cb48_mdpi.Checked = true;
                cb36_ldpi.Checked = true;

            } else {
                cb192_xxxhdpi.Checked = false;
                cb144_xxhdpi.Checked = false;
                cb96_xhdpi.Checked = false;
                cb72_hdpi.Checked = false;
                cb64_tvdpi.Checked = false;
                cb48_mdpi.Checked = false;
                cb36_ldpi.Checked = false;

            }

        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );

        }

        private void pb512_PlayStore_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = GetImageFilter();

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                bitmap = new Bitmap( ofd.FileName );
                pb512_PlayStore.Image = ( Bitmap ) bitmap.Clone();

                bitmap = new Bitmap( bitmap, new Size( 192, 192 ) );
                pb192_xxxhdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 144, 144 ) );
                pb144_xxhdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 96, 96 ) );
                pb96_xhdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 72, 72 ) );
                pb72_hdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 64, 64 ) );
                pb64_tvdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 48, 48 ) );
                pb48_mdpi.Image = bitmap;
                bitmap = new Bitmap( bitmap, new Size( 32, 32 ) );
                pb36_ldpi.Image = bitmap;
                
            }

        }

        public string GetImageFilter () {
            StringBuilder allImageExtensions = new StringBuilder();
            string separator = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            Dictionary<string, string> images = new Dictionary<string, string>();
            foreach ( ImageCodecInfo codec in codecs ) {
                allImageExtensions.Append( separator );
                allImageExtensions.Append( codec.FilenameExtension );
                separator = ";";
                images.Add( string.Format( "{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension ),
                           codec.FilenameExtension );
            }
            StringBuilder sb = new StringBuilder();
            if ( allImageExtensions.Length > 0 ) {
                sb.AppendFormat( "{0}|{1}", "All Images", allImageExtensions.ToString() );
            }
            images.Add( "All Files", "*.*" );
            foreach ( KeyValuePair<string, string> image in images ) {
                sb.AppendFormat( "|{0}|{1}", image.Key, image.Value );
            }
            return sb.ToString();
        }

        private void btnCreate_Click ( object sender, EventArgs e ) {
            if ( bitmap == null ) {
                MessageBox.Show( "Open an Image first", "No Image" );
                return;

            }

            Directory.CreateDirectory( res_path );

            if ( cb192_xxxhdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + xxxhdpi_192 );
                pb192_xxxhdpi.Image.Save( Path.Combine( res_path, drawable + xxxhdpi_192 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );
            }

            if ( cb144_xxhdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + xxhdpi_144 );
                pb144_xxhdpi.Image.Save( Path.Combine( res_path, drawable + xxhdpi_144 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            if ( cb96_xhdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + xhdpi_96 );
                pb96_xhdpi.Image.Save( Path.Combine( res_path, drawable + xhdpi_96 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            if ( cb72_hdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + hdpi_72 );
                pb72_hdpi.Image.Save( Path.Combine( res_path, drawable + hdpi_72 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            if ( cb64_tvdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + tvdpi_64 );
                pb64_tvdpi.Image.Save( Path.Combine( res_path, drawable + tvdpi_64 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            if ( cb48_mdpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + mdpi_48 );
                pb48_mdpi.Image.Save( Path.Combine( res_path, drawable + mdpi_48 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            if ( cb36_ldpi.Checked ) {
                Directory.CreateDirectory( res_path + @"\" + drawable + ldpi_36 );
                pb36_ldpi.Image.Save( Path.Combine( res_path, drawable + ldpi_36 ) + "\\" + ic_launcher + ".png", ImageFormat.Png );

            }

            Process.Start( Environment.CurrentDirectory );


        }


    }
}