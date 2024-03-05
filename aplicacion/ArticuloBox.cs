using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;


namespace aplicacion
{
    public partial class ArticuloBox : UserControl
    {
        private Articulo articulo;
        
        public ArticuloBox()
        {
            InitializeComponent();
        }

        public ArticuloBox(Articulo aCargar)
        {
            InitializeComponent();
            articulo = aCargar;
            cargarUrlImagen();
            lblNombre.Text = articulo.Nombre;
            lblMarca.Text = articulo.Marca.Descripcion;
        }

        private void cargarUrlImagen()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    byte[] imageData = webClient.DownloadData(articulo.UrlImagen);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbArticulo.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception)
                {
                    pbArticulo.Image = pbArticulo.ErrorImage;
                }
            }
        }

   

        //public Image Imagen
        //{
        //    get{ return pbArticulo.Image; }
        //    set { pbArticulo.Image = value;}
        //}

        //public string UrlImagen
        //{
        //    get { return pbArticulo.Text; }
        //    set { pbArticulo.Text = value;}
        //}
        
        public string nombre
        {
            get { return lblNombre.Text; }
            set { lblNombre.Text = value; }
        }

        public void imagenDefault()
        {
            pbArticulo.Image = pbArticulo.ErrorImage;
        }

        private void btnMasDetalles_Click(object sender, EventArgs e)
        {
            frmInformacion formulario = new frmInformacion(articulo);

            formulario.ShowDialog();
            

        }
    }
}
