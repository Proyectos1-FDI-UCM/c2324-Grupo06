using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHandler : MonoBehaviour // Clase que se encarga de manejar los items que se seleccionan en el inventario y ponerlos en la mano de quien lo usa
{
    [SerializeField] ItemData _default; // Item por defecto que se asignará al itemHandler cuando no haya ningún item seleccionado
    public ItemData defaultItem 
    {
        get => _default;
        set => _default = value;
    }

    [SerializeField] ItemData _initialItem; // Item con el que se empieza en el itemHandler
    public ItemData initialItem => _initialItem;

    public IItem selectedItem; // Item seleccionado en el itemHandler desde el inventario
    UnityEvent onItemDrop = new UnityEvent();
    public UnityEvent OnItemDrop => onItemDrop;

    UnityEvent onItemUse = new UnityEvent();
    public UnityEvent OnItemUse => onItemUse;

    private void Awake() {
        if(initialItem != null) SetUpItem(initialItem); // Si hay un item inicial, se asigna al itemHandler
    }

    public void UseItem()
    {
        // Si hay un item seleccionado, se usa
        if (selectedItem != null)
        {
            selectedItem.Use(this);
            onItemUse?.Invoke();
        }
    }

    public void OnItemChanged(ItemData newItem)
    {
        // Si el item al que se quiere cambiar es nulo, se destruye el item seleccionado actualmente y se asigna null
        if (newItem == null)
        {
            if(selectedItem != null) Destroy(selectedItem.gameObject);
            selectedItem = null;
            return;
        }
        // Si no, se destruye el item seleccionado actualmente y se asigna el nuevo item
        if (selectedItem != null) Destroy(selectedItem.gameObject);

        SetUpItem(newItem);
    }

    void SetUpItem(ItemData newItem)
    {
        // Se instancia el nuevo item y se asigna al itemHandler para que aparezca en la mano del usuario con la rotación y posición correctas
        GameObject item = Instantiate(newItem.prefab, transform);
        item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        selectedItem = item.GetComponent<IItem>();
        item.GetComponent<Rigidbody2D>().isKinematic = true;
        item.GetComponent<Rigidbody2D>().drag = 0;
        item.layer = 1;
    }

    public void DropItem()
    {
        // Si el item seleccionado no es el item por defecto, se suelta sin usarlo
        if (selectedItem.ItemData != _default)
        {
            // Para ello, se le asigna la capa de item recogible, se hace kinemático y se desvincula del itemHandler
            selectedItem.gameObject.layer = LayerMask.NameToLayer("Item");
            Rigidbody2D rb = selectedItem.gameObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            selectedItem.gameObject.transform.SetParent(null);
            selectedItem = null;
            onItemDrop?.Invoke();
        }
    }
}
