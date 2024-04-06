using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCondition : MonoBehaviour, ICondition
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemData itemData;
    /// <summary>
    /// Esta condicion checkea los ingredientes de la receta del objeto y los compara con los del inventario, tambien esta preparado
    /// para evetar problemas como tener el numero de objetos requeridos en distintos huecos del inventario en vez de en el mismo.
    /// </summary>
    /// <returns></returns>
    public bool CheckCondition()
    { int ingridients = 0;
        int all_ingridients = itemData.Recipe.Ingredients.Length;
       // print(itemData.Recipe.Ingredients.Length);
        int i = 0;
        bool c = false;
      //  print("ENTRO");
        while (i<all_ingridients && !c)
        {
            int inginv = 0;
            bool control= false;
            int j = 0;
            while (j< inventory.items.Length&&!control) 
            {
               if (inventory.items[j].item.itemName == itemData.Recipe.Ingredients[i].ingredientName)
                {
                  //  print("primer condicinal");
                    if (inventory.items[j].amount < itemData.Recipe.Ingredients[i].amount) inginv += inventory.items[j].amount;
                    if (inventory.items[j].amount >= itemData.Recipe.Ingredients[i].amount || inginv >= itemData.Recipe.Ingredients[i].amount)
                    {
                        ingridients++;
                        control = true;
                    }
                }
                j++;
                

            }
            if (ingridients == all_ingridients) c = true;
            i++;
        }

       // print( c);
        return c;
    }

    private void OnValidate()
    {
        name = "Inventory Condition";
    }
}
