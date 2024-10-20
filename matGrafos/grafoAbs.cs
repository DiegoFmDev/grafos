using System;
using System.Data.Common;

namespace programa
{
    public class GrafoAbs
    {
        public Nodo[] lista_vertices;
        public int vertices;
        public int aritastas;

        public GrafoAbs()
        {
            vertices = 0;
            aritastas = 0;
            lista_vertices = new Nodo[100];
        }

        public void insertarVertice(int dato)
        {
            if (!existeVertice(dato))
            {
                Nodo nuevo = new Nodo(dato);
                lista_vertices[vertices] = nuevo;
                vertices++;
            }
        }

        public bool existeVertice(int dato)
        {
            int i = 0;
            while (i < vertices)
            {
                if (lista_vertices[i].dato == dato)
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public void mostrarListaVertices()
        {
            int i = 0;
            String lista = "";
            while (i < vertices)
            {
                lista += lista_vertices[i].dato + " - ";
                i++;
            }
            Console.WriteLine(lista);
        }

        public void mostrarVecinos(int vertice)
        {

            if (existeVertice(vertice))
            {
                //Recorre la lsita hasta encontrar el vertice
                int i = 0;
                Nodo actual = new Nodo(0);
                while (i < vertices)
                {
                    actual = lista_vertices[i];
                    if (actual.dato == vertice)
                    {
                        break;
                    }
                }


                // muestra la lista de vecinos del vertice
                string lista = "";
                i = 0;
                while (i < actual.dato)
                {
                    lista += actual.lista_de_adyacencia[i] + " - ";
                }

            }
        }

        public void insertaArista(int inicio, int final)
        {
            if (existeVertice(inicio) && existeVertice(final))
            {
                int i = 0;
                Nodo actual = new Nodo(0);
                while (i < vertices)
                {
                    actual = lista_vertices[i];
                    if (actual.dato == inicio)
                    {
                        break;
                    }
                }
                actual.lista_de_adyacencia[actual.numero_vecinos] = final;
                actual.numero_vecinos++;
                i = 0;
                while (i < vertices)
                {
                    if (lista_vertices[i].dato == actual.dato)
                    {
                        lista_vertices[i] = actual;
                    }
                }

            }
        }

        public void eliminarVertice(int vertice)
        {
            // Primero verificar si el vértice existe
            if (existeVertice(vertice))
            {
                // Encontramos la posición del vértice en el arreglo
                int index = -1;
                for (int i = 0; i < vertices; i++)
                {
                    if (lista_vertices[i].dato == vertice)
                    {
                        index = i;
                        break;
                    }
                }

                // Si el vértice está en la lista, lo eliminamos
                if (index != -1)
                {
                    // Eliminar aristas del vértice eliminado en los otros vértices
                    for (int i = 0; i < vertices; i++)
                    {
                        Nodo actual = lista_vertices[i];
                        for (int j = 0; j < actual.numero_vecinos; j++)
                        {
                            if (actual.lista_de_adyacencia[j] == vertice)
                            {
                                // Desplazar los elementos para eliminar la arista
                                for (int k = j; k < actual.numero_vecinos - 1; k++)
                                {
                                    actual.lista_de_adyacencia[k] = actual.lista_de_adyacencia[k + 1];
                                }
                                actual.numero_vecinos--;
                            }
                        }
                    }

                    // Desplazar los vértices para eliminar el vértice
                    for (int i = index; i < vertices - 1; i++)
                    {
                        lista_vertices[i] = lista_vertices[i + 1];
                    }
                    vertices--;
                }
            }
            else
            {
                Console.WriteLine("El vértice no existe.");
            }
        }
        public void eliminarArtista(int inicio, int final)
        {  // Verificar que ambos vértices existan
            if (existeVertice(inicio) && existeVertice(final))
            {
                // Encontrar el vértice de inicio
                int index = -1;
                for (int i = 0; i < vertices; i++)
                {
                    if (lista_vertices[i].dato == inicio)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    Nodo actual = lista_vertices[index];
                    // Buscar la arista que conecta el inicio con el final
                    for (int i = 0; i < actual.numero_vecinos; i++)
                    {
                        if (actual.lista_de_adyacencia[i] == final)
                        {
                            // Desplazar los elementos para eliminar la arista
                            for (int j = i; j < actual.numero_vecinos - 1; j++)
                            {
                                actual.lista_de_adyacencia[j] = actual.lista_de_adyacencia[j + 1];
                            }
                            actual.numero_vecinos--;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El vértice de inicio no existe.");
                }
            }
            else
            {
                Console.WriteLine("Uno o ambos vértices no existen.");
            }
        }
    }
}