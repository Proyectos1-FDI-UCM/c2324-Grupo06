using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(Obsoleto) Devuelve verdadero si el objeto se mueve en una dirección determinada.
public class DirectionCondition : MonoBehaviour, ICondition
{
    MovementController movementController;
    [SerializeField]
    Vector2 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        movementController = GetComponentInParent<MovementController>();
    }
    public bool CheckCondition()
    {
        if(movementController.Rb.velocity == Vector2.zero) return false;

        return GreatestVector(movementController.Rb.velocity) == GreatestVector(direction);
    }

    Vector2 GreatestVector(Vector2 vector)
    {
        if(XIsGreater(vector.x, vector.y))
        {
            return new Vector2(Mathf.Sign(vector.x), 0);
        }
        else
        {
            return new Vector2(0, Mathf.Sign(vector.y));
        }
    }
    bool XIsGreater(float x,  float y)
    {
        if (Mathf.Abs(x) > Mathf.Abs(y)) return true;
        else return false;
    }

    private void OnValidate()
    {
        name = "Vector2:(" + direction.x + ", " + direction.y +  ")";
    }
}