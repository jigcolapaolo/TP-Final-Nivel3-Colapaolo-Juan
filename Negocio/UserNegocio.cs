using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UserNegocio
    {
        public bool Login(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, email, pass, nombre, apellido, urlImagenPerfil, admin FROM USERS WHERE email = @email AND pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Nombre = datos.Lector["nombre"] != DBNull.Value ? (string)datos.Lector["nombre"] : null;
                    usuario.Apellido = datos.Lector["apellido"] != DBNull.Value ? (string)datos.Lector["apellido"] : null;
                    usuario.UrlImagenPerfil = datos.Lector["urlImagenPerfil"] != DBNull.Value ? (string)datos.Lector["urlImagenPerfil"] : null;
                    usuario.Admin = datos.Lector["admin"] != DBNull.Value ? (bool)datos.Lector["admin"] : false;

                    return true;
                }

                return false;
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

        //Retorna el id del nuevo usuario creado para mantener la sesion abierta.
        public int nuevoUser(User nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USERS(email, pass, nombre, apellido, urlImagenPerfil, admin) output inserted.id values (@email, @pass, @nombre, @apellido, @urlImagenPerfil, 0)");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@apellido", nuevo.Apellido);
                datos.setearParametros("@urlImagenPerfil", nuevo.UrlImagenPerfil);

                return datos.ejecutarAccionScalar();
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

        public void actualizar(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE USERS SET email = @email, pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil WHERE Id = @id");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.setearParametros("@urlImagenPerfil", usuario.UrlImagenPerfil);
                datos.setearParametros("@id", usuario.Id);

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
    }
}
