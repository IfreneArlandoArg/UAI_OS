using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace CLI
{
    internal class Program
    {

        

        static void Main(string[] args)
        {
			try
			{

                do 
                {
                    Console.Title = $"UAIOS  😎🍻  {DateTime.Now.ToString("yyyy-MMMM-dd")}";

                    BLLUsuario bllUsuario = new BLLUsuario();

                  string cmd;
                  int count = 0;

                    

                  gestorUsuario_Componentes gestor = new gestorUsuario_Componentes();



                  BEUsuario tmpUser = null;
                  bool registrado = false;

                
                  

                  while (!registrado)
                  {

                     Console.WriteLine($"Intento : {count + 1}\nSe cierra el CLI después de 3 intentos fallidos. \n\n");

                     Console.WriteLine("Ingresar Usuario :");
                     string Nombre = Console.ReadLine();
                     Console.WriteLine("Ingresé contraseña :");
                     string Password = Console.ReadLine();


                     registrado = bllUsuario.UserRegistered(Nombre, Password, out tmpUser);




                     count++;

                     if (count == 3)
                         throw new Exception("Error Intentos...");


                    
                     Console.Clear();

                      

                     if (!registrado) 
                     {
                        Console.Beep();
          
                        Console.WriteLine("Credenciales inválidas. Intente nuevamente.\n");
                     }
                       

                  }



                    

                tmpUser.DirectorioActual.Nombre = $"{tmpUser.Nombre}/";
                    tmpUser.DirectorioActual.IdPadre = 0;


                    LoginSession.Instancia.Login(tmpUser);


                    LoginSession.Instancia.UsuarioActual.DirectorioActual.directorioConsola += $"{LoginSession.Instancia.UsuarioActual.DirectorioActual.Nombre}";


                    string nombreComponete = string.Empty;
                int tamaño = 0;
                bool tamañoOK = false;

                do
                {
                    

                    Console.WriteLine($"{LoginSession.Instancia.UsuarioActual.DirectorioActual.directorioConsola}");
                    cmd = Console.ReadLine();

                    string[] x = cmd.Split(' ');

                    if (x.Length > 1)
                    {
                    
                        cmd = x[0];
                        nombreComponete = x[1];
                        if (x.Length > 2)
                        tamañoOK = int.TryParse(x[2].Trim('(').Trim(')'), out tamaño);

                    }

                    cmd = cmd.ToUpper();

                    switch (cmd)
                    {
                       
                        case "MD":
                            if (nombreComponete == string.Empty)
                            {
                                Console.WriteLine("El directorio tiene qué tener un nombre...");
                                break;
                            }

                            Console.WriteLine($"Creando directorio : {nombreComponete}");
                            Console.WriteLine( gestor.Alta(new BEDirectorio(nombreComponete, LoginSession.Instancia.UsuarioActual.Id.ToString(), LoginSession.Instancia.UsuarioActual.DirectorioActual.Id)));

                            break;

                        case "CD":
                            if (nombreComponete == string.Empty)
                            {
                                Console.WriteLine("El directorio tiene qué tener un nombre...");
                                break;
                            }
                            Console.WriteLine($"Cambiando a directorio : {nombreComponete}");

                                Console.WriteLine( gestor.CambiarDirectorio(nombreComponete) );

                            break;

                        case "MF":
                            string[] tmpX = nombreComponete.Split('(');

                            if (!tamañoOK)
                            {
                                Console.WriteLine("Tiene qué proveer tamaño numerico para crear archivo.\nEjemplo: MF libro (10)");
                                break;
                            }


                            Console.WriteLine($"{nombreComponete}, {tamaño}");

                            Console.WriteLine( gestor.Alta(new BEArchivo(nombreComponete, tamaño.ToString(), LoginSession.Instancia.UsuarioActual.DirectorioActual.Id.ToString() )) );


                            break;

                        case "LS":

                            Console.WriteLine(gestor.ListarDirectoriosUsuario(LoginSession.Instancia.UsuarioActual));
                            
                            break;

                        case "DI":
                            Console.WriteLine("Desconectando....");
                            LoginSession.Instancia.Logout();
                            break;

                        default:
                            Console.WriteLine("Comando no implementado...");
                            break;

                    }


                }
                while (cmd != "DI");




                    Console.Clear();

                }
                while(true);

            }
            catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
        }
    }
}
