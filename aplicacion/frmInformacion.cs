using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace aplicacion
{
    public partial class frmInformacion : Form
    {
        public frmInformacion()
        {
            InitializeComponent();
        }

        public frmInformacion(Articulo articulo)
        {
            InitializeComponent();
            cargar(articulo);
        }

        private void cargar(Articulo articulo)
        {
            txtNombre.Text = articulo.Nombre;
            txtPrecio.Text = articulo.Precio.ToString("N2");
            txtCodigo.Text = articulo.Codigo;
            txtDescripcion.Text = articulo.Descripcion;

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();  
            cbCategoria.DataSource = categoriaNegocio.listar();

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbMarca.DataSource = marcaNegocio.listar();

        }
       
    }
}
