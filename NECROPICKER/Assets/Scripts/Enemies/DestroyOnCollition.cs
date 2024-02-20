using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollition : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(m_gameObject);
    }

}
