﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio
                datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@precio", nuevo.Precio);

                datos.ejecutarAccion();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio, @id
                //Le envio el Id del articulo seleccionado para que solo modifique las propiedades de ese articulo.
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio WHERE Id = @id");
                datos.setearParametros("@codigo", art.Codigo);
                datos.setearParametros("@nombre", art.Nombre);
                datos.setearParametros("@descripcion", art.Descripcion);
                datos.setearParametros("@idMarca", art.Marca.Id);
                datos.setearParametros("@idCategoria", art.Categoria.Id);
                datos.setearParametros("@imagenUrl", art.ImagenUrl);
                datos.setearParametros("@precio", art.Precio);
                datos.setearParametros("@id", art.Id);

                datos.ejecutarAccion();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametros("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //FAVORITOS
        //Recibe el Id del usuario logueado para mostrar su lista de favoritos.
        public List<Articulo> listarFavoritos(int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria  FROM ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F WHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id AND F.IdUser = @idUser AND A.Id = F.IdArticulo");
                datos.setearParametros("@idUser", idUser);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);
                }

                return lista;

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Recibe el Id del usuario logueado y del articulo seleccionado para agregarlo a su lista de favoritos.
        public void agregarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS(IdUser, IdArticulo) VALUES (" + idUser + "," + idArticulo + ")");

                datos.ejecutarAccion();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Recibe el Id del usuario logueado y del articulo seleccionado para eliminarlo de su lista de favoritos.
        public void eliminarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = " + idUser + " AND IdArticulo = " + idArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtro(string criterio, string filtro, string campo = "", bool isIndex = false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Articulo> lista = new List<Articulo>();

                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria \r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id AND ";

                if (isIndex)
                {
                    //Solo ejecuta por nombre si viene de pagina Index
                    if (criterio == "Nombre")
                        consulta += criterio + " like '%" + filtro + "%'";
                }
                else
                {
                    //Viene de listaArticulos (Admin)
                    if (campo == "Nombre")
                    {
                        switch (criterio)
                        {
                            case "Empieza con..":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con..":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                    }
                    else if (campo == "Codigo")
                    {
                        switch (criterio)
                        {
                            case "Empieza con..":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con..":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                    }
                    else if (campo == "Marca")
                    {
                        consulta += "A.IdMarca = " + criterio;
                    }
                    else if (campo == "Categoria")
                    {
                        consulta += "A.IdCategoria = " + criterio;
                    }
                    else
                    {
                        switch (criterio)
                        {
                            case "Mayor a..":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a..":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }

                        if (criterio == "Mas Barato")
                            consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria \r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id \r\nORDER BY Precio ASC";
                        else
                            consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria \r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id \r\nORDER BY Precio DESC";
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);
                }



                return lista;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtroFavoritos(int IdUser, string criterio, string filtro = "")
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Articulo> listaFav = new List<Articulo>();

                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria\r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id AND F.IdUser = @id AND A.Id = F.IdArticulo AND ";

                if (criterio == "Nombre")
                {
                    consulta += criterio + " like '%" + filtro + "%'";

                }
                else if (criterio == "Marca")
                {
                    consulta += "A.IdMarca = " + filtro;
                }
                else if (criterio == "Categoria")
                {
                    consulta += "A.IdCategoria = " + filtro;
                }
                else
                {

                    if (filtro == "Mas Caro")
                        consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria\r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id AND F.IdUser = @id AND A.Id = F.IdArticulo ORDER BY Precio DESC";
                    else
                        consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria\r\nFROM ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F \r\nWHERE  A.IdMarca = M.Id AND A.IdCategoria = C.Id AND F.IdUser = @id AND A.Id = F.IdArticulo ORDER BY Precio ASC";


                }

                datos.setearConsulta(consulta);
                datos.setearParametros("@id", IdUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    listaFav.Add(articulo);
                }



                return listaFav;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
