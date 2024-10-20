using System;

namespace programa
{
    public class Grafo
    {
        static void Main(string[] args)
        {
            GrafoAbs g = new GrafoAbs();
            g.insertarVertice(1);
            g.insertarVertice(2);
            g.insertarVertice(3);
            g.insertarVertice(4);
            g.insertarVertice(4);
            g.eliminarArtista(1,5);
            g.eliminarVertice(3);
            g.mostrarListaVertices();

        }

    }

}