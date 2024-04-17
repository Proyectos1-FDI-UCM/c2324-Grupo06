using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrabHandler))]
public class ChangeItemMaterial : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material newMaterial;


    private void Awake()
    {
        GetComponent<GrabHandler>().OnItemSelected.AddListener(ChangeToSelectedMaterial);
        GetComponent<GrabHandler>().OnItemDeselected.AddListener(ChangeToDefaultMaterial);
    }

    void ChangeMaterial(GameObject item, Material material)
    { 
        SpriteRenderer spriteRenderer = item.GetComponentInChildren<SpriteRenderer>();
        if(spriteRenderer != null) spriteRenderer.material = material;
    }

    void ChangeToSelectedMaterial(GameObject item) => ChangeMaterial(item, newMaterial);

    void ChangeToDefaultMaterial(GameObject item) => ChangeMaterial(item, defaultMaterial);
}
