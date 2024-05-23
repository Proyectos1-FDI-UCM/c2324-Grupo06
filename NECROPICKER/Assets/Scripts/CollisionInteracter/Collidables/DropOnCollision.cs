using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropComponent))]
public class DropOnCollision : MonoBehaviour, ICollidable
{
    DropComponent drop; // Componente que se encarga de soltar el item
    [SerializeField] LayerMask targetLayer; // Capa con la que se debe colisionar para que se dispare el evento
    [SerializeField] bool exclusiveDrop = false; // Si es true, solo se soltará un item; si es false, se soltarán varios
    int numOfInstances = 0; // Número de instancias que se han soltado
    [SerializeField] int maxNumOfInstances = 1; // Número máximo de instancias que se pueden soltar

    private void Awake()
    {
        drop = GetComponent<DropComponent>();
    }

    public void OnCollide(Collider2D other)
    {
        // Si la capa del objeto es la requerida y no se ha llegado al número máximo de instancias, se suelta el item
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)) && numOfInstances < maxNumOfInstances)
        {
            if (exclusiveDrop) drop.DropItemExclusive(); // Si es exclusivo, se suelta un item
            else drop.DropItem(); // Si no, se sueltan varios
        }
    }
}
