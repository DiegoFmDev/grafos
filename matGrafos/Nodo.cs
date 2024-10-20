using System;
namespace programa{
    public class Nodo{
        public int dato;
        public int[] lista_de_adyacencia;
        public int numero_vecinos;    

        public Nodo(int numero){
            dato = numero;
            numero_vecinos = 0;
            lista_de_adyacencia = new int[100];   
        }
    }
}