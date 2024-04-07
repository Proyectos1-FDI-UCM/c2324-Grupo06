using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItemRemuveBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemData itemData;
    [SerializeField] ItemData necromicon;
    public void ExecuteBehaviour()
    {
        for (int i = 0;i <itemData.Recipe.Ingredients.Length;i++)
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
                        inventory.items[j].item = necromicon;
                        inventory.items[j].amount = 1;
                        inventory.RemoveItem();
                        inventory.UpdateInventory();
                        //inventory.items[j].item = necromicon;
                    }
                    else if (inventory.items[j].amount > itemData.Recipe.Ingredients[i].amount)
                           {
                        inventory.items[j].amount -= ingremove;
                        inventory.UpdateInventory();
                        control = true;
                           }
                    else
                    {
                        inventory.items[j].item = necromicon;
                        inventory.items[j].amount = 1;
                        inventory.UpdateInventory();
                        inventory.RemoveItem();
                        
                        control = true;
                    }
                }
                j++;


            }
        }

    }

}