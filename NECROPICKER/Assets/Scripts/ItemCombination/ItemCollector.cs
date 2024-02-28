using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    ItemCombiner itemCombiner;
    GameObject item;

    private void Awake() => itemCombiner = GetComponentInParent<ItemCombiner>();
    private void Start() => itemCombiner.OnItemCombined.AddListener(onItemCombined);
    private void OnDestroy() => itemCombiner.OnItemCombined.RemoveListener(onItemCombined);

    void onItemCombined() => Destroy(item);

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

    private void OnTriggerExit2D(Collider2D other) {
            
            if(item == null) return;
    
            if(other.gameObject == item)
            {
                itemCombiner.RemoveItem(item.GetComponent<IItem>().ItemData);
                item = null;
            }
    }
}