using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    ItemCombiner itemCombiner;
    GameObject item;
    //Obtiene el componente ItemCombiner
    private void Awake() => itemCombiner = GetComponentInParent<ItemCombiner>();
    //Se suscribe al m�todo onItemCombined
    private void Start() => itemCombiner.OnItemCombined.AddListener(onItemCombined);
    //Se desuscribe al m�todo onItemCombined
    private void OnDestroy() => itemCombiner.OnItemCombined.RemoveListener(onItemCombined);
    //Destruye el item
    void onItemCombined() => Destroy(item);
    //Cuando entra a la zona del trigger, si contiene el iitem solicitado, se asigna item a iitem, se llama a AddItem, se establece la posici�n del collider y se establece la velocidad a cero para que no se mueva
    private void OnTriggerEnter2D(Collider2D other) {
        if(item != null) return;

        if(other.TryGetComponent(out IItem iitem))
        {
            item = iitem.gameObject;

            itemCombiner.AddItem(iitem.ItemData);
            other.transform.position = transform.position;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    //Cuando se sale de la zona del trigger, se verifica si el objeto que ha salido del Collider2D es el mismo objeto que est� actualmente asignado a item. Si lo es, se elimina el �tem del combinador. Se reinicia la variable item a null, indicando que no hay ning�n �tem actualmente recogido.
    private void OnTriggerExit2D(Collider2D other) {
            
            if(item == null) return;
    
            if(other.gameObject == item)
            {
                itemCombiner.RemoveItem(item.GetComponent<IItem>().ItemData);
                item = null;
            }
    }
}