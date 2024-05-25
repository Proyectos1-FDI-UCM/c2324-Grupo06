using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(GrabHandler))]
public class ChangeItemMaterial : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material newMaterial;

    //Suscripción del script a los eventos OnItemSelected y OnItemDeselected
    private void Awake()
    {
        GetComponent<GrabHandler>().OnItemSelected.AddListener(ChangeToSelectedMaterial);
        GetComponent<GrabHandler>().OnItemDeselected.AddListener(ChangeToDefaultMaterial);
    }
    //Cuando un item se selecciona, el material del item cambia a uno nuevo que se le da al método
    void ChangeMaterial(GameObject item, Material material)
    { 
        SpriteRenderer spriteRenderer = item.GetComponentInChildren<SpriteRenderer>();
        if(spriteRenderer != null) spriteRenderer.material = material;
    }
    //Llama al método anteior con un material nuevo
    void ChangeToSelectedMaterial(GameObject item) => ChangeMaterial(item, newMaterial);
    //Llama al método anterior con el material default
    void ChangeToDefaultMaterial(GameObject item) => ChangeMaterial(item, defaultMaterial);
}
