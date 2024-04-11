using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = FindObjectOfType<InputManager>().transform;
    }

    public void LookAtPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
