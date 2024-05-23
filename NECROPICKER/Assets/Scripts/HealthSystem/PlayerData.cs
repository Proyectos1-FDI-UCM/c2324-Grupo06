using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
 private void Start() => GetComponent<PoolTaker>().SetSpawnPoint(GameObject.FindAnyObjectByType<InputManager>().transform); //LLama al método de SetSpawnPoint y se le pasa al propio jugador
}
