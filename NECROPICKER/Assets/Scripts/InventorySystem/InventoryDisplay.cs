using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public Image[] slots = new Image[5];
    public  TextMeshProUGUI[] nobjects = new TextMeshProUGUI[5];
    [SerializeField] GameObject slotPointer;
    [SerializeField] Sprite defaultImage;

    private void Start()
    {
        UpdateInventory(null);
        inventory.OnItemChanged.AddListener(UpdateInventory);
        inventory.UpdateInventory();
    }
    /// <summary>
    /// Tiene toda la lógica asociada al inventario en pantalla. Activa y desactiva las imagenes y el numero de items
    /// </summary>
  
    void UpdateInventory(ItemData itemData)
    {
        slotPointer.transform.position = slots[inventory.SelectedItemIndex].transform.position;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Length && inventory.items[i].item.icon != null)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].sprite = inventory.items[i].item.icon;
                if (inventory.items[i].amount >= 2)
                {
                    nobjects[i].gameObject.SetActive(true);
                    nobjects[i].text = inventory.items[i].amount.ToString();
                }
                else nobjects[i].gameObject.SetActive(false);
            }
            else 
            {
                if (defaultImage == null) slots[i].gameObject.SetActive(false);
                else
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].sprite = defaultImage;
                }
            }
        }
    }
}