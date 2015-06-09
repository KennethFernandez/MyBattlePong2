﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public interface IEncriptacion
    {
        string encriptar(string contrasena);
        string desencriptar(string contrasena);
    }
}
