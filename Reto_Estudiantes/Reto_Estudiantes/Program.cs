using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace Reto_Estudiantes
{
    class Program
    {
        static List<Estudiante> ListaEstudiantes = new List<Estudiante>();
        static Validaciones Vericar = new Validaciones();
        static void Main(string[] args)
        {

            LeerArchivoXml();
           int OpcMen;

            string temporal;

            do
            {
                bool EntradaValida = false;
                Console.Clear();
                gui.Marco(1, 110, 1, 25);
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 5); Console.Write("* Menu Principal * ");
                Console.WriteLine("Hello World!");

                gui.Linea(40, 80, 6);
                Console.SetCursorPosition(40, 7); Console.Write("1. Insertar Estudiante");
                Console.SetCursorPosition(40, 8); Console.Write("2. Listar Estudiante");
                Console.SetCursorPosition(40, 9); Console.Write("3. Buscar Estudiante");
                Console.SetCursorPosition(40, 10); Console.Write("4. Borrar Estudiante");
                Console.SetCursorPosition(40, 11); Console.Write("5. Editar Datos del Estudiante");
                Console.SetCursorPosition(40, 12); Console.Write("6. Quienes Somos");
                Console.SetCursorPosition(40, 13); Console.Write("0. Salir");

                do
                {
                    gui.BorrarLinea(40, 15, 80);
                    Console.SetCursorPosition(40, 15); Console.Write("Escoja Opcion: ");
                    temporal = Console.ReadLine();
                    if (!Vericar.Vacio(temporal))
                        if (Vericar.TipoNumero(temporal))
                            EntradaValida = true;
                } while (!EntradaValida);

                OpcMen = Convert.ToInt32(temporal);

                switch (OpcMen)
                {
                    case 1:
                        InsertarNombre();
                        break;
                    case 2:
                        ListarNombres();
                        break;
                    case 3:
                        BuscarNombre();
                        break;
                    case 4:
                        EliminarEstudiante();
                        //  LeerArchivoXml();
                        break;
                    case 5:
                        EditaEstudiante();
                        //  EscrirArchivoXml();
                        break;
                    case 6:
                        QuienesSomos();
                        break;
                    case 0:
                        {
                            gui.BorrarLinea(40, 22, 80);
                            Console.SetCursorPosition(40, 22); Console.Write(" ... Gracias por usar el programa");
                            EscrirArchivoXml();
                        }
                        break;
                    default:
                        {
                            gui.BorrarLinea(40, 22, 80);
                            Console.SetCursorPosition(40, 22); Console.Write(" Opcion Invalida");
                        }
                        break;

                }
                gui.BorrarLinea(40, 23, 80);
                Console.SetCursorPosition(40, 23); Console.Write("presione cualquier tecla para continuar");
                Console.ReadKey();
            } while (OpcMen > 0);


        }


        static void QuienesSomos()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 2); Console.Write(" Quienes Somos  ");
            int altura = 6;
            gui.Linea(3, 107, 3);


           
            Console.SetCursorPosition(40, altura); Console.Write("Willian Lamprea  ");

        }
        static void InsertarNombre()
        {
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaNota1 = false;
            bool EntradaValidaNota2 = false;
            bool EntradaValidaNota3 = false;

            String nombre;
            String codigo;
            String nota1;
            String nota2;
            String nota3;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Insertado estudiante");
            gui.Linea(40, 6, 30);

            // .................................... ..validaciones
            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiante: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (!Existe(Convert.ToInt32(codigo)))
            {  // inicia el if del existe

                do // pedir el nombre
                {
                    gui.BorrarLinea(33, 9, 64);
                    Console.SetCursorPosition(10, 9); Console.Write("Digite Nombre Estudiante:");
                    nombre = Console.ReadLine();
                    if (!Vericar.Vacio(nombre))
                        if (Vericar.TipoTexto(nombre))
                            EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);

                do // pedir el nota1
                {
                    gui.BorrarLinea(37, 10, 64);
                    Console.SetCursorPosition(10, 10); Console.Write("Digite la nota 1 del Estudiante: ");
                    nota1 = Console.ReadLine();
                    nota1 = nota1.Replace('.', ',');
                    if (!Vericar.Vacio(nota1))
                        if (Vericar.TipoNumero(nota1))
                            EntradaValidaNota1 = true;
                } while (!EntradaValidaNota1);

                do // pedir el nota2
                {
                    gui.BorrarLinea(37, 11, 64);
                    Console.SetCursorPosition(10, 11); Console.Write("Digite la nota 2 del Estudiante: ");
                    nota2 = Console.ReadLine();
                    nota2 = nota2.Replace('.', ',');
                    if (!Vericar.Vacio(nota2))
                        if (Vericar.TipoNumero(nota2))
                            EntradaValidaNota2 = true;
                } while (!EntradaValidaNota2);

                do // pedir el nota3
                {
                    gui.BorrarLinea(37, 12, 64);
                    Console.SetCursorPosition(10, 12); Console.Write("Digite la nota 3 del Estudiante: ");
                    nota3 = Console.ReadLine();
                    nota3 = nota3.Replace('.', ',');
                    if (!Vericar.Vacio(nota3))
                        if (Vericar.TipoNumero(nota3))
                            EntradaValidaNota3 = true;
                } while (!EntradaValidaNota3);

                Estudiante elestudiante = new Estudiante();
                elestudiante.Codigo = Convert.ToInt32(codigo);
                elestudiante.Nombre = nombre;
                elestudiante.Nota1 = Convert.ToDouble(nota1);
                elestudiante.Nota2 = Convert.ToDouble(nota2);
                elestudiante.Nota3 = Convert.ToDouble(nota3);

                ListaEstudiantes.Add(elestudiante);

            }
            else
                Console.WriteLine("     El usuario con el codigo " + codigo + " Ya Existe en el sistema");
        }

        static void ListarNombres()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 2); Console.Write(" Cantidad de Estudiantes: " + ListaEstudiantes.Count);
            int altura = 6;
            gui.Linea(3, 107, 3);

            Console.SetCursorPosition(5, 5); Console.Write("CODIGO");
            Console.SetCursorPosition(15, 5); Console.Write("NOMBRE");
            Console.SetCursorPosition(30, 5); Console.Write("NOTA 1");
            Console.SetCursorPosition(42, 5); Console.Write("NOTA 2");
            Console.SetCursorPosition(52, 5); Console.Write("NOTA 3");
            Console.SetCursorPosition(62, 5); Console.Write("DEFINITIVA");

            foreach (Estudiante ObjetoEstudiante in ListaEstudiantes)
            {


                Console.SetCursorPosition(5, altura); Console.Write(ObjetoEstudiante.Codigo);
                Console.SetCursorPosition(15, altura); Console.Write(ObjetoEstudiante.Nombre);
                Console.SetCursorPosition(30, altura); Console.Write(ObjetoEstudiante.Nota1);
                Console.SetCursorPosition(42, altura); Console.Write(ObjetoEstudiante.Nota2);
                Console.SetCursorPosition(52, altura); Console.Write(ObjetoEstudiante.Nota3);
                Console.SetCursorPosition(62, altura); notafinal(ObjetoEstudiante.Nota1, ObjetoEstudiante.Nota2, ObjetoEstudiante.Nota3, altura);

                altura++;
            }

        }

        static void BuscarNombre()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Insertardo estudiante");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo del Estudiante");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);


            if (Existe(Convert.ToInt32(codigo)))
            {
                Estudiante elestudiante  = ObtenerDatos(Convert.ToInt32(codigo));

                int altura = 11;
                gui.Linea(3, 107, 9);
                gui.Linea(3, 107, 12);

                Console.SetCursorPosition(2, 10); Console.Write("CODIGO");
                Console.SetCursorPosition(10, 10); Console.Write("NOMBRE");
                Console.SetCursorPosition(30, 10); Console.Write("NOTA 1");
                Console.SetCursorPosition(42, 10); Console.Write("NOTA 2");
                Console.SetCursorPosition(52, 10); Console.Write("NOTA 3");
                Console.SetCursorPosition(62, 10); Console.Write("NOTA FINAL");

                Console.SetCursorPosition(2, altura); Console.Write(elestudiante.Codigo);
                Console.SetCursorPosition(10, altura); Console.Write(elestudiante.Nombre);
                Console.SetCursorPosition(30, altura); Console.Write(elestudiante.Nota1);
                Console.SetCursorPosition(42, altura); Console.Write(elestudiante.Nota2);
                Console.SetCursorPosition(52, altura); Console.Write(elestudiante.Nota3);
                notafinal(elestudiante.Nota1, elestudiante.Nota2, elestudiante.Nota3, altura);
            }
            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" Aun el estudiante del codigo " + codigo + " No existe");
            }
        }



        static void EliminarEstudiante()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Elimniar estudiante");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiante a elimniar");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {

                Estudiante elestudiante  = ObtenerDatos(Convert.ToInt32(codigo));

                string confirmar = "n";
                Console.SetCursorPosition(10, 8); Console.WriteLine($" Esta seguro de borrar los datos de {elestudiante.Nombre}  s/n ");
                Console.SetCursorPosition(10, 9); confirmar = Console.ReadLine();
                if (confirmar == "s" || confirmar == "S")
                {
                    ListaEstudiantes.Remove(elestudiante);
                    Console.SetCursorPosition(10, 8); Console.WriteLine("   Borrado datos del Estudiante con exito ");

                }




            }
            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }





        }



        static void EditaEstudiante()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Ediar Datos  Estudiante");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Estudiante Editar");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {

                Estudiante elestudiante = ObtenerDatos(Convert.ToInt32(codigo));
                // ******************************
                Console.SetCursorPosition(5, 12); Console.Write("Codigo: ");
                Console.SetCursorPosition(5, 13); Console.Write("Nombre:");
                Console.SetCursorPosition(5, 14); Console.Write("Nota 1: ");
                Console.SetCursorPosition(5, 15); Console.Write("Nota 2");
                Console.SetCursorPosition(5, 16); Console.Write("Nota 3");

                Console.SetCursorPosition(15, 12); Console.Write(elestudiante.Codigo);
                Console.SetCursorPosition(15, 13); Console.Write(elestudiante.Nombre);
                Console.SetCursorPosition(15, 14); Console.Write(elestudiante.Nota1);
                Console.SetCursorPosition(15, 15); Console.Write(elestudiante.Nota2);
                Console.SetCursorPosition(15, 16); Console.Write(elestudiante.Nota3);

                //------  leer datos 
                string nombre, nota1, nota2, nota3;
                bool EntradaValidaNombre = false;
                bool EntradaValidaNota1 = false;
                bool EntradaValidaNota2 = false;
                bool EntradaValidaNota3 = false;

                do // pedir el nombre
                {
                    gui.BorrarLinea(25, 13, 64);
                    Console.SetCursorPosition(25, 13); ;
                    nombre = Console.ReadLine();

                    if (Vericar.TipoTexto(nombre))
                        EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);

                do // pedir el nota 1
                {
                    gui.BorrarLinea(25, 14, 64);
                    Console.SetCursorPosition(25, 14);
                    nota1 = Console.ReadLine();
                    if (Vericar.Vacio(nota1))
                    {
                        EntradaValidaNota1 = true;
                        gui.BorrarLinea(10, 22, 100);
                    }
                    else

                     if (Vericar.TipoNumero(nota1))
                        EntradaValidaNota1 = true;

                } while (!EntradaValidaNota1);

                do // pedir el nota 2
                {
                    gui.BorrarLinea(25, 15, 64);
                    Console.SetCursorPosition(25, 15);
                    nota2 = Console.ReadLine();

                    if (Vericar.Vacio(nota2))
                    {
                        EntradaValidaNota2 = true;
                        gui.BorrarLinea(10, 22, 100);
                    }
                    else
                      if (Vericar.TipoNumero(nota2))
                        EntradaValidaNota2 = true;
                } while (!EntradaValidaNota2);

                do // pedir el nota 3
                {
                    gui.BorrarLinea(25, 15, 64);
                    Console.SetCursorPosition(25, 16);
                    nota3 = Console.ReadLine();

                    if (Vericar.Vacio(nota3))
                    {
                        EntradaValidaNota3 = true;
                        gui.BorrarLinea(10, 22, 100);
                    }
                    else
                      if (Vericar.TipoNumero(nota3))
                        EntradaValidaNota3 = true;
                } while (!EntradaValidaNota3);
                //..........................................

                // editar los datos 
                if (!Vericar.Vacio(nombre))
                {
                    gui.BorrarLinea(10, 22, 100);
                    elestudiante.Nombre = nombre;
                }


                if (!Vericar.Vacio(nota1))
                {
                    elestudiante.Nota1 = int.Parse(nota1);

                }

                if (!Vericar.Vacio(nota2))
                {
                    elestudiante.Nota2 = int.Parse(nota2);

                }

                if (!Vericar.Vacio(nota3))
                {
                    elestudiante.Nota3 = int.Parse(nota3);

                    gui.BorrarLinea(10, 22, 100);
                }

              

                //*******************************
            }
            else
            {
                gui.BorrarLinea(40, 22, 80);
                Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }





        }

        static bool Existe(int cod)
        {
            bool aux = false;

            foreach (Estudiante elestudiante in ListaEstudiantes)
            {
                if (elestudiante.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static Estudiante ObtenerDatos(int cod)
        {
            foreach (Estudiante elestudiante in ListaEstudiantes)
            {
                if (elestudiante.Codigo == cod)
                    return elestudiante;
            }
            return null;

        }


        static void EscrirArchivoXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
            TextWriter escribirXml = new StreamWriter("C:/Users/willi/source/repos/Reto_Estudiantes/datosEstud/ArchivoEstudiantes.xml ");
            codificador.Serialize(escribirXml, ListaEstudiantes);
            escribirXml.Close();

            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" Archivo guardado con exito .... ");
        }


        static void LeerArchivoXml()
        {
            if (File.Exists("C:/Users/willi/source/repos/Reto_Estudiantes/datosEstud/ArchivoEstudiantes.xml"))
            {
                ListaEstudiantes.Clear();
                XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
                FileStream leerXml = File.OpenRead("C:/Users/willi/source/repos/Reto_Estudiantes/datosEstud/ArchivoEstudiantes.xml");
                ListaEstudiantes = (List<Estudiante>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }


            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" Archivo guardado con exito .... ");
        }
        static void notafinal(double nota1, double nota2, double nota3, int altura)
        {
            Double notaf;

            //calculo
            notaf=(nota1+nota2+nota3)/ 3;
            Console.SetCursorPosition(62, altura); Console.Write(notaf.ToString("#.##"));
        }
    } 

}
