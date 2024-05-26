using System.Collections.Generic;

//Este script define un método de extensión AddItem para un SerializableDictionary 
//cuyo valor es una lista. Si la clave ya existe, añade el valor a la lista correspondiente;
//si no, crea una nueva entrada con una lista que contiene el valor proporcionado.

namespace DS.Utilities
{
    public static class CollectionUtility
    {
        public static void AddItem<T, K>(this SerializableDictionary<T, List<K>> serializableDictionary, T key, K value)
        {
            if (serializableDictionary.ContainsKey(key))
            {
                serializableDictionary[key].Add(value);

                return;
            }

            serializableDictionary.Add(key, new List<K>() { value });
        }
    }
}