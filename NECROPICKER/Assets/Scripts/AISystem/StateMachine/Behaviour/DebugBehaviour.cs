using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Imprime un mensaje en la consola.
//Se utiliza para depurar el comportamiento de la máquina de estados.
public class DebugBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] string debugMessage;
    public void ExecuteBehaviour() => print(debugMessage);

    private void OnValidate() => name = $"Debug: {debugMessage}";
}
