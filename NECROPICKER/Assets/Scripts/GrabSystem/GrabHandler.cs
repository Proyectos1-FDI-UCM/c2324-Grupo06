using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabHandler : MonoBehaviour
{
    LayerMask itemLayer; // Capa de los items
    [SerializeField] float grabRadius = 2f; // Radio de alcance para agarrar items
    [SerializeField] float grabOffset = 1f; // Offset para el radio de alcance
    [SerializeField] Inventory _inventory; // Inventario al que se añadirán los items
    IItem takeAbleItem; // Item a agarrar
    IItem TakeAbleItem
    {
        set // Si se agarra un item, se deselecciona el item anterior y se selecciona el nuevo
        {
            if(takeAbleItem != value)
            {
                if (takeAbleItem != null) onItemDeselected.Invoke(takeAbleItem.gameObject);

                if(value != null) onItemSelected.Invoke(value.gameObject);

                takeAbleItem = value;
            }
        }
    }

    #region Events
    UnityEvent<GameObject> onItemSelected = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> OnItemSelected => onItemSelected;

    UnityEvent<GameObject> onItemDeselected = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> OnItemDeselected => onItemDeselected;

    [SerializeField] UnityEvent onFullInventory = new UnityEvent();

    UnityEvent onItemTaken = new UnityEvent();
    public UnityEvent OnItemTaken => onItemTaken;
    #endregion

    private void Awake()
    {
        itemLayer = LayerMask.GetMask("Item");
    }

    // Si hay un item en el radio de alcance, se selecciona como item a agarrar
    private void Update() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.up * grabOffset, grabRadius, itemLayer);

        if(hit == null)
        {
            TakeAbleItem = null;
            return;
        }

        if(hit.TryGetComponent(out IItem item))
        {
            TakeAbleItem = item;
        }
    }

    // Si se presiona el botón de agarrar, se añade el item a agarrar al inventario, solo si hay espacio, y se destruye el item en el mundo
    public void TakeItem()
    {
        if(takeAbleItem != null) 
        {
            if(_inventory.AddItem(takeAbleItem.ItemData))
            {
                _inventory.UpdateInventory();
                Destroy(takeAbleItem.gameObject);
                TakeAbleItem = null;
                onItemTaken.Invoke();
            }
            else
            {
                onFullInventory.Invoke();
            }
        }
    }
    // Dibuja el radio de alcance en el editor
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * grabOffset, grabRadius);
    }
}
