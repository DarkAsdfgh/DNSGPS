using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.Collections.Specialized;

public class Ruta
    {
        public void EjecutarCoordenadas()
        {
            string pathPy = @"..\coords.py"
            ScriptRutime py = Python.CreateRuntime();
            dynamic pyProgram = py.Userfile(pathPy);
            
        }

        public void EjecutarTiempo()
        {
            string pathPy = @"..\weather.py"
            ScriptRutime py = Python.CreateRuntime();
            dynamic pyProgram = py.Userfile(pathPy);
            
        }
        
        static void Main(string[] args)
        {
            EjecutaCoordenadas();
            EjecutarTiempo();
        
        }
        
    }
