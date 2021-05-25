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
using System.IO;

public static class Webscrapping
    {
        public static void EjecutarCoordenadas()
        {
            string pythonFile="";
            foreach (string nameFile in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if (nameFile.Contains("coords.py"))
                {
                    pythonFile = nameFile;
                }
            }    

            ScriptRuntime py = Python.CreateRuntime();
            dynamic pyProgram = py.UseFile(pythonFile);          
        }

        public static void EjecutarTiempo()
        {
            string pathPy = @"..\weather.py";
            ScriptRuntime py = Python.CreateRuntime();
            dynamic pyProgram = py.UseFile(pathPy);
            
        }
        
    }
