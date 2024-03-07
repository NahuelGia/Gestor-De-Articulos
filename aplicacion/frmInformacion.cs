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
        private Helper helper = new Helper();

        public frmInformacion()
        {
            InitializeComponent();
            btnAgregarImagen.Visible = true;
            btnAgregar.Visible = true;
            habilitarTxtbox();

        }

        private void habilitarTxtbox()
        {
            // hay que hacer q se habiliten todos los txt box.
        }

        public frmInformacion(Articulo articulo)
        {
            InitializeComponent();
            btnEliminar.Visible = true;
            btnModificar.Visible = true;
            cargar(articulo);
        }

        private void cargar(Articulo articulo)
        {
            txtNombre.Text = articulo.Nombre;
            txtPrecio.Text = articulo.Precio.ToString("N2");
            txtCodigo.Text = articulo.Codigo;
            txtDescripcion.Text = articulo.Descripcion;
            helper.cargarImagen(pbArticulo, articulo.RutaImagen);
            txtImagen.Text = articulo.RutaImagen;

            cbCategoria.Items.Add(articulo.Categoria);
            cbCategoria.SelectedIndex = 0;
            cbMarca.Items.Add(articulo.Marca);
            cbMarca.SelectedIndex = 0;

            //CategoriaNegocio categoriaNegocio = new CategoriaNegocio();  
            //cbCategoria.DataSource = categoriaNegocio.listar();

            //MarcaNegocio marcaNegocio = new MarcaNegocio();
            //cbMarca.DataSource = marcaNegocio.listar();

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog exploradorArchivos = new OpenFileDialog();
            exploradorArchivos.Filter = "Archivos de imagen|*.png;*.jpg|Todos los archivos|*.*";
            exploradorArchivos.Multiselect = false;

            if (exploradorArchivos.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = exploradorArchivos.FileName;
            }

        }

    }
}
