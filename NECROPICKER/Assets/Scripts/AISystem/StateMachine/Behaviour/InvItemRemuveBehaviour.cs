using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este comportamiento se utiliza para eliminar elementos del inventario.
public class InvItemRemuveBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemData itemData;
    [SerializeField] ItemData necromicon;
    public void ExecuteBehaviour()
    {
        for (int i = 0; i < itemData.Recipe.Ingredients.Length; i++)
        {
            int ingremove = itemData.Recipe.Ingredients[i].amount;
            bool control = false;
            int j = 0;
            while (j < inventory.items.Length && !control)
            {
                if (inventory.items[j].item.itemName == itemData.Recipe.Ingredients[i].ingredientName)
                {
                    if (inventory.items[j].amount < itemData.Recipe.Ingredients[i].amount)
                    {
                        ingremove -= inventory.items[j].amount;
                        inventory.RemoveItemUpgrades(j);
                    }
                    else if (inventory.items[j].amount > itemData.Recipe.Ingredients[i].amount)
                    {
                        inventory.items[j].amount -= ingremove;
                        inventory.UpdateInventory();
                        control = true;
                    }
                    else
                    {
                        inventory.RemoveItemUpgrades(j);
                        control = true;
                    }
                }
                j++;


            }
        }

    }
}
