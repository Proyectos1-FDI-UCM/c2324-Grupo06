using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItemLayer : MonoBehaviour
{
    [SerializeField] LayerMask _staticLayer;
    [SerializeField] LayerMask _movementLayer;
    Rigidbody2D rb;
    //Si un objeto es lanzado este pasa a la capa bullet o disparado
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void ChangeLayerToBullet()
    {
        if (rb.velocity !=Vector2.zero) 
        {
            gameObject.layer = LayerMask.NameToLayer("bullet");
        }
       
    }
}
