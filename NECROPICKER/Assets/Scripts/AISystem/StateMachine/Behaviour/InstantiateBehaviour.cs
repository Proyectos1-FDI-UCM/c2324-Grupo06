
using UnityEngine;

public class InstantiateBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float velocity = 0.0f, rotation=0.0f;
    [SerializeField] bool setAnimationOn;
    [SerializeField] string animation;
    public void ExecuteBehaviour()
    {
        Quaternion addRotation = Quaternion.Euler(0,0,rotation);
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity*addRotation*transform.rotation);
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * velocity;
        }
        if (setAnimationOn)
        {
            bullet.GetComponent<Animator>().Play(animation);
        }
    }

    private void OnValidate()
    {
        if(prefab != null)
            name = $"Instantiate {prefab.name}";
    }
}