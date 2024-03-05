using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> listaDeArticulos = new List<Articulo>();
            AccesoADatos accesoADatos = new AccesoADatos();

            try
            {
                accesoADatos.asignarConsulta("select A.Id, codigo, nombre, A.Descripcion , M.Descripcion Marca, M.Id IdMarca, C.Descripcion Categoria, C.Id IdCategoria, ImagenUrl, Precio from ARTICULOS A join MARCAS M on A.IdMarca = M.Id join CATEGORIAS C on A.IdCategoria = C.Id");
                accesoADatos.ejecutarLectura();
                while (accesoADatos.Lector.Read())
                {
                    Articulo nuevoArticulo = new Articulo();
                    Marca marcaDelArticulo = new Marca();
                    Categoria categoriaDelArticulo = new Categoria();

                    nuevoArticulo.Id = (int)accesoADatos.Lector["Id"];
                    nuevoArticulo.Codigo = (string)accesoADatos.Lector["codigo"];
                    nuevoArticulo.Nombre = (string)accesoADatos.Lector["nombre"];
                    nuevoArticulo.Descripcion = (string)accesoADatos.Lector["Descripcion"];
                    nuevoArticulo.Marca = marcaDelArticulo;
                    nuevoArticulo.Marca.Id = (int)accesoADatos.Lector["IdMarca"];
                    nuevoArticulo.Marca.Descripcion = (string)accesoADatos.Lector["Marca"];
                    nuevoArticulo.Categoria = categoriaDelArticulo;
                    nuevoArticulo.Categoria.Id = (int)accesoADatos.Lector["IdCategoria"];
                    nuevoArticulo.Categoria.Descripcion = (string)accesoADatos.Lector["Categoria"];
                    nuevoArticulo.UrlImagen = (string)accesoADatos.Lector["ImagenUrl"];
                    nuevoArticulo.Precio = (decimal)accesoADatos.Lector["Precio"];

                    listaDeArticulos.Add(nuevoArticulo);
                }
                return listaDeArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoADatos.cerrarConexion();
            }
        }

    }
}
