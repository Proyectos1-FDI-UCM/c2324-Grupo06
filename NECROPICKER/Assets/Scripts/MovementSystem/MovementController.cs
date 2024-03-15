using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool isPlayer = false;
    public Rigidbody2D Rb => rb;
    [SerializeField] float _speed = 10f;
    //No deberiamos tener que checkear si es un jugador puesto que se trata de código reutilizable
    private float _OriginalSpeed;
    public float speed => _speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _OriginalSpeed = _speed;
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }
    private void Update()
    {
        if (isPlayer) { Move(rb.velocity.normalized); }
    }
    //Nos podemos ahorrar este Update, en este caso es mejor que cada vez que se actualice _speed se actualice el valor de rb.velocity.
    
    //Para ello utiliza un accesor de la variable _speed y en el set de dicho accesor actualiza el valor de rb.velocity, puede ser
    //algo como "rb.velocity = rb.velocity.normalized * value", de esa forma no la dirección pero si la velocidad.

    //De todas formas esto tampoco está mal, pero si se puede evitar un Update mejor. Y sobre todo evitar la
    //comprobación de si es un jugador o no. BUEN TRABAJO :D!!
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
    public void ReturnOriginalSpeed()
    {
        _speed = _OriginalSpeed;
    }
}
