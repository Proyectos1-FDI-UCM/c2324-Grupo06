using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Una condición que se cumple solo una vez.
public class PlayOnceCondition : MonoBehaviour, ICondition
{
    bool playedonce = false;
    bool check = true;

    public bool CheckCondition()
    {
        if (playedonce) check = false;
        if (!playedonce) playedonce = true;
        return check;
    }

    private void OnValidate()
    {
        name = "Play once";
    }
}
