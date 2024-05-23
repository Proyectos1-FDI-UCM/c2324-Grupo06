using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateItem : MonoBehaviour, IItem
{
    [SerializeField]
    GameObject bullet; // Prefab de la bala que se instancia al usar el item
    [SerializeField]
    float bulletSpeed = 10f; // Velocidad de la bala
    public ItemData ItemData { get; }
    // Al usar el item, se instancia una bala en la posici�n y rotaci�n del objeto que contiene el item
    public bool Use(ItemHandler handler)
    {
        GameObject instanciatedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = instanciatedBullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed; // La bala se mueve en la direcci�n en la que mira el objeto que contiene el item
        return true;
    }
}
