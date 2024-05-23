using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState //Interfaz que define el comportamiento de un estado de la IA. (Innecesario)
{
    void OnStateEnter();
    void OnStateUpdate();
    void OnStateExit();
    IState GetNextState();
    Transform transform { get; }
}