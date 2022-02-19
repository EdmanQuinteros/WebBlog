using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.AccesoDatos.Data.Inicializador
{
    public interface IInicializadorDB
    {
        //esto sirve para cuando subamos nuestro proyecto a un hosting tenga almenos un usuario admin//
        //ya que lo que hemos creado mientras creamo el proyecto se eliminan al subir al hosting//
        void Inicializar();
    }
}
