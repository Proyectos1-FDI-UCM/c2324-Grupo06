using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Este script mueve un objeto entre dos límites (_up y _down) aplicando fuerzas en dirección contraria cuando alcanza
// un límite, utilizando la fuerza y la distancia especificadas para cambiar de dirección.

public class MovementUpDown : MonoBehaviour
{
    [SerializeField]
    private Transform _up, _down,//limites del movimiento
        _parentTransform; 

    private Transform _myTransform;
    private Rigidbody2D _myRigidBody;


    [SerializeField]
    private float distance = 0.5f, force = 1f, inicialForce = 50f; //distancia para cambiar de direccion
    Vector3 up, down;//posicion de los limites
    void Start()
    {
        _myTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
        distance = Mathf.Abs(distance);
        force = Mathf.Abs(force);

        _myRigidBody.AddForce((_down.position - _up.position) * -force);
        up = _up.position; down = _down.position;

        if (up.y < down.y) (up.y, down.y) = (down.y, up.y); //normalizacion de y
        if (up.x < down.x) (up.x, down.x) = (down.x, up.x); //normalizacion de x

        Debug.Log(up +" > "+ down );
    }

    void LateUpdate()
    {
        
        
        //comprueba si nos acercamos al punto de arriba o al de abajo
        if (_myTransform.position.y + distance >= up.y && _myTransform.position.x + distance >= up.x)
        {
            _myRigidBody.AddForce((up - down) * -force);
            Debug.Log("posicion x: " + _myTransform.position.x + "\nposicion y: " + _myTransform.position.y+"\narriba x: "+ up.x + "\narriba y: "+ up.y);
        }
        else if (_myTransform.position.y - distance <= down.y && _myTransform.position.x - distance <= down.x)
        {
            _myRigidBody.AddForce((up - down) * force);
            Debug.Log("posicion x: " + _myTransform.position.x + "\nposicion y: " + _myTransform.position.y + "\nabajo x: " + down.x + "\nabajo y: " + down.y);
        }

    }
}
