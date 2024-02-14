using UnityEngine;
using UnityEngine.UI;
public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public Image[] slots = new Image[5];
    [SerializeField] GameObject slotPointer;

    private void Start()
    {
        UpdateInventory(null);
        inventory.OnItemChanged.AddListener(UpdateInventory);
    }

    void UpdateInventory(ItemData itemData)
    {
        slotPointer.transform.position = slots[inventory.SelectedItemIndex].transform.position;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Length && inventory.items[i] != null)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].sprite = inventory.items[i].icon;
            }
            else 
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }
}