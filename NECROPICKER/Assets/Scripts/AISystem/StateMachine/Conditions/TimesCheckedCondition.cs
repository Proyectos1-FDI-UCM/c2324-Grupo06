using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Devuelve verdadero si se ha comprobado al menos un número determinado de veces,
//en caso contrario devuelve falso.
public class TimesCheckedCondition : MonoBehaviour, ICondition
{
    int timesChecked = 0;
    [SerializeField] int timesToCheck = 5;

    public bool CheckCondition()
    {
        timesChecked++;

        if(timesChecked >= timesToCheck)
        {
            timesChecked = 0;
            return true;
        }
        return false;
    }

    private void OnValidate() {
        name = $"Check {timesToCheck} times";
    }
}
