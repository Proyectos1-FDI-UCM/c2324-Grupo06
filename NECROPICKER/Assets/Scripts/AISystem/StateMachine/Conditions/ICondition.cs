using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz que deben implementar las condiciones.
//Define un método que devuelve verdadero si se cumple la condición.
public interface ICondition
{
    bool CheckCondition();
}
