using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTaker : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField] Transform spawnPoint;
    //Busca el ObjectPooler, si no lo hay, se autodestruye. Si no hay punto de spawneo, establece su posici�n como punto de spawneo
    private void Awake() {
        objectPooler = FindObjectOfType<ObjectPooler>(true);

        if(objectPooler == null)
        {
            Debug.LogWarning("ObjectPooler not found");
            Destroy(this);
        }

        if(spawnPoint == null)
        {
            spawnPoint = transform;
        }
    }
    // Llama al m�todo SpawnFromPool que va a comprobar si el objeto est� en el diccionario y, si lo est�, lo va a posicionar en el spawn y lo va a activar
    public void TakeFromPool(GameObject prefab)
    {
        objectPooler.SpawnFromPool(spawnPoint.position, spawnPoint.rotation, prefab);
    }
    //Establece la posici�n de spawn a la posici�n del transform que se le pasa
    public void SetSpawnPoint(Transform transform) => spawnPoint = transform;
}
