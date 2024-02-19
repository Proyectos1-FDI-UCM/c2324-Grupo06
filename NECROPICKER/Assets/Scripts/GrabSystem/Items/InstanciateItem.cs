using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateItem : MonoBehaviour, IItem
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed = 10f;
    public ItemData ItemData { get; }
    public bool Use(ItemHandler handler)
    {
        GameObject instanciatedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = instanciatedBullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
        return true;
    }
}
