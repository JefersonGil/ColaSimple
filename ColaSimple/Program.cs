using System;

namespace ColaSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            //pequena interfas para probar el funcionamiento
            Cola MiCola = new Cola();
            Inicio:
            Console.WriteLine("1 para leer cola, 2 para agregar a cola, 3 para eliminar primer elemento de la cola");
            int Opcion = int.Parse(Console.ReadLine());
            if (Opcion == 1)
            {
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();
            }
            else if (Opcion == 2)
            {
                Console.WriteLine("Escriba su elemento: ");
                int Elemento = int.Parse(Console.ReadLine());
                MiCola.InsertarElementos(Elemento);
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();              
            }
            else if (Opcion == 3)
            {
                MiCola.ExtraerElementos();
                Console.Clear();
                MiCola.LeerLista();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }
            goto Inicio;
        }
    }
    class Cola
    {
        public class Nodo //Clase nodo
        {
            public int Informacion; //identifica un elemento en la cola
            public Nodo Siguiente; //Conoce su siguiente nodo en la cola
        }

        private Nodo InicioCola, FinCola; //Donde empieza la cola y donde acaba

        public Cola() //Constructor de la clase cola
        {
            InicioCola = null;
            FinCola = null;
        }

        public bool ColaVacia() //Comprueba si hay elementos en la cola
        {
            if (InicioCola == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertarElementos(int Elemento) //Este metodo recible como parametro el elemento a insertar a la cola
        {
            Nodo unNodo = new Nodo(); //Crea un nodo y hace su siguiente nodo null para poder identificar este nodo como el ultimo creado
            unNodo.Informacion = Elemento;
            unNodo.Siguiente = null;

            if (ColaVacia()) //Si la cola esta vacia, este nodo sera el inicio de la cola y tambien el ultimo elemento
            {
                InicioCola = unNodo;
                FinCola = unNodo;
            }
            else //Si hay elementos en la cola, el soguiente al ultimo elemento sera el nuevo ultimo elemento
            {
                FinCola.Siguiente = unNodo;
                FinCola = unNodo;
            }
        }
        public void ExtraerElementos() //Metodo para eliminar elementos de la cola
        {
            if (!ColaVacia()) //En caso que la cola no este vacia
            {
                int PrimerElemento = InicioCola.Informacion; //Elemento que almacena el inicio de la cola
                if (InicioCola == FinCola) //En caso de que solo haya un elemento en la cola, se hacen tanto el inicio como el fin de la cola null
                {
                    InicioCola = null;
                    FinCola = null;
                }
                else //En caso contrario, se asigna el elemento que succede al inicio como inicio
                {
                    InicioCola = InicioCola.Siguiente;
                }
            }
        }
        public void LeerLista() //Metodo para escribir en pantalla la cola completa
        {
            Nodo miCola = InicioCola;
            Console.WriteLine("Elementos de la cola");
            while (miCola != null)
            {
                Console.WriteLine(miCola.Informacion);
                miCola = miCola.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
