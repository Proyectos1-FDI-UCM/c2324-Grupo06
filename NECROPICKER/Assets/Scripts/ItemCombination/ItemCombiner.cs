using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemCombiner : MonoBehaviour
{
    UnityEvent onItemCombined = new UnityEvent();
    public UnityEvent OnItemCombined => onItemCombined;
    
    [SerializeField] ItemData[] itemsCombinations;
    List<ItemData> itemsToCombine = new List<ItemData>();
    //Añade el item a la lista
    public void AddItem(ItemData item) => itemsToCombine.Add(item);
    //elimina el item de la lista
    public void RemoveItem(ItemData item) => itemsToCombine.Remove(item);
    //Si los items a combinar no son dos o más, no se ejecuta (no se puede combinar un solo item). Crea una lista de ingredientes y para cada item data de la lista de items que combinar y cada ingrediente en data, añade en ingrediente a la lista de ingredientes. Crea un array a partir de la lista de ingredientes. Si check ingredients es true, entonces se instancia el item adecuado y se invoca ItemCombined, que destruye el game object.
    public void GenerateItem()
    {
        if(itemsToCombine.Count < 2) return;

        List<Ingredient> ingredientList = new List<Ingredient>();

        foreach(ItemData data in itemsToCombine)
        {
            foreach(Ingredient ingredient in data.Ingredients)
            {
                ingredientList.Add(ingredient);
            }
        }

        Ingredient[] ingredients = ingredientList.ToArray();

        foreach(ItemData itemData in itemsCombinations)
        {
            if(CheckIngredients(itemData.Recipe.Ingredients, ingredients))
            {
                for(int i = 0; i < itemData.Recipe.Amount; i++)
                {
                    Instantiate(itemData.prefab, transform.position, Quaternion.identity);
                }

                onItemCombined?.Invoke();
                return;
            }
        }
    }
    //Si los contenidos de la receta no son iguales a los que se proporcionan, devuelve falso, si no, comprueba que todos los ingredientes son los adecuados y devuelve verdadero o falso dependiendo de esto
    bool CheckIngredients(Ingredient[] recipe, Ingredient[] ingredients)
    {
        if(recipe.Length > ingredients.Length) return false;

        Dictionary<string, int> ingredientCounts = new Dictionary<string, int>();

        foreach(Ingredient ingredient in ingredients)
        {
            if(ingredientCounts.ContainsKey(ingredient.ingredientName))
            {
                ingredientCounts[ingredient.ingredientName] += ingredient.amount;
            }
            else
            {
                ingredientCounts.Add(ingredient.ingredientName, ingredient.amount);
            }
        }

        foreach(Ingredient item in recipe)
        {
            if(!ingredientCounts.ContainsKey(item.ingredientName))
            {
                return false;
            } 
            else if(ingredientCounts[item.ingredientName] < item.amount)
            {
                return false;
            }
        }

        return true;
    }
}

        // if(recipe.Length != ingredients.Length) return false;

        // for(int i = 0; i < recipe.Length; i++)
        // {
        //     int a = 0;
        //     while(a < ingredients.Length)
        //     {
        //         if(recipe[i].ingredientName == ingredients[a].ingredientName)
        //         {
        //             if(recipe[i].amount > ingredients[a].amount) return false;
        //             break;
        //         }

        //         if(a == ingredients.Length - 1) return false;
        //     }
        // }

        // return true;