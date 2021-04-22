using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Usuarios
    {
        public struct User{
            public User(string n, string p) {
                nombre = n;
                password = p;
            }

            public string nombre;
            public string password;

        }

        public List<User> usuarios = new List<User>();



        public Usuarios()
        {
            this.usuarios.Add(new User("Gonzalo", "prueba"));
        }
        public Usuarios(string nu, string pu) {

            bool YaExiste = false;
            foreach (User u in usuarios)
            {
                if (u.nombre == nu)
                {
                    YaExiste = true;
                }
            }

            if (!YaExiste)
            {
                usuarios.Add(new User(nu, pu));
            }
        }
 
    }
}
