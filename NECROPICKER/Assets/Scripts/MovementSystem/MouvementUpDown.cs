using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementUpDown : MonoBehaviour
{
    [SerializeField]
    private Transform _up, _down;

    private Transform _myTransform;
    private Rigidbody2D _myRigidBody;

    [SerializeField]
    private float distance = 0.5f, force = 1f, inicialForce = 50f; //distancia para cambiar de direccion

    void Start()
    {
        _myTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
        distance = Mathf.Abs(distance);
        force = Mathf.Abs(force);

        _myRigidBody.AddForce(new Vector2(0,inicialForce));
        
    }

    void LateUpdate()
    {
        //comprueba si nos acercamos al punto de arriba o al de abajo
        if (_myTransform.position.y + distance >= _up.position.y)
        {
            Debug.Log("baja");
            _myRigidBody.AddForce(new Vector2(0,-force));
        }
        else if(_myTransform.position.y - distance  <= _down.position.y)
        {
            Debug.Log("sube");
            _myRigidBody.AddForce(new Vector2(0, force));
        }
    }
}
