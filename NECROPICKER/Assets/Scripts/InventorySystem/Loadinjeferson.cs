using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loadinjeferson : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] jeferson = new Sprite[3];
    [SerializeField] Image image;
    int i = 0;
    private void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
       
            image.sprite = jeferson[i];
            if (i == 3 - 1) i++;
            else i = 0;
       
     
    }
}
