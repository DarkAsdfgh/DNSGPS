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
        
        public void CalcularRuta()
        {
            ScriptEngine engine = Python.CreateEngine();
            dynamic scope = engine.CreateScope();
            
        }
    }
