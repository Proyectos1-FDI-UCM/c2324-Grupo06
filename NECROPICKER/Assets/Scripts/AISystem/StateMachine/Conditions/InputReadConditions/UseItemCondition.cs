using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemCondition : MonoBehaviour, ICondition
{
    [SerializeField] ItemHandler itemHandlerToCheck;
    bool usedItem;

    private void Awake() 
    {
        if(itemHandlerToCheck == null)
        {
            itemHandlerToCheck = FindObjectOfType<ItemHandler>();
        }

        itemHandlerToCheck.OnItemUse.AddListener(() => usedItem = true);
    }

    public bool CheckCondition()
    {
        if(usedItem)
        {
            usedItem = false;
            return true;
        }
        
        return usedItem;
    }
}
