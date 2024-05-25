using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class RandomInstancerOnGridArea : MonoBehaviour //Script encargado de pintar paredes encima de las puertas si no detecta sala pr�xima
{
    Tilemap tilemap; 
    Grid grid;
    [SerializeField] Vector2Int size; //Tama�o de la casilla a pintar
    [SerializeField] InstanceWithProbability[] instances; 
    [SerializeField] bool _instanceOnAwake = true;

    private void OnDrawGizmos() //M�todo encargado de dibujar los Gizmos
    {
        grid = GetComponentInParent<Grid>(); //Toma el componente del padre
        if(grid == null) return;//Si no lo tiene rompe   
        Gizmos.color = Color.blue; //Se asigna el color del gizmo
        Gizmos.DrawWireCube(transform.position,new Vector3(size.x * grid.cellSize.x, size.y * grid.cellSize.y, 0)); //Dibuja el Gizmos en la posici�n correspondiente y con su respectivo tama�o
    }

    private void Awake()
    {
        tilemap = GetComponentInParent<Tilemap>();
        grid = GetComponentInParent<Grid>();
        if(_instanceOnAwake) InstanceRandom();
    }
    public void InstanceRandom()
    {
        foreach(InstanceWithProbability instance in instances) //Para cada componenete del struct que se encuentre en instances
        {
            if(Random.value < instance.Probability) //Si el valor del n�mero aleatorio es menor que la probabilidad 
            {
                for(int i = 0; i < instance.Amount; i++) //Recorre para la cantidad de instance
                {
                    Vector3 randomOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0); //Se crea el rango
                    Vector3 randomPosition = transform.position + randomOffset; //Se crea la posici�n en funci�n del rango

                    int numberOfTries = 0;//Creaci�n de una variable que cuenta el n�mero de intentos
                    while(Physics2D.OverlapBox(randomPosition, new Vector2(0.5f, 0.5f), 0) != null) //Bucle que se sigue ejecutando hasta que se encuentre un valor null o la variable de arriba supere los 100 intentos
                    {
                        randomOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0); //Se modifica el random offset
                        randomPosition = transform.position + randomOffset; //Se modifica la posici�n
                        numberOfTries++; //Se suma +1 a los intentos
                        if(numberOfTries > 100) break; //Si llega a 100 rompe flujo
                    }

                    Instantiate(instance.Prefab, randomPosition, Quaternion.identity); //Instancia la instance con su posici�n y rotaci�n 
                }
            }
        }
    }
    public void InstanceRandomExclusive() 
    {
        foreach(InstanceWithProbability instance in instances) //Para cada componenete del struct que se encuentre en instances
        {
            float sumOfProbabilities = 0; //Variable encargada de almacenar el total de probabilidades
            sumOfProbabilities += instance.Probability; //Se asigna el valor en funci�n de las probabilidades de instance
            if (Random.value < sumOfProbabilities) //Si el valor del n�meri aleatorio es menor que el de la suma de probabilidades
            {
                Vector3 randomOffset = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0); // Se crea el rango
                Vector3 randomPosition = transform.position + randomOffset; //Se crea la posici�n en funci�n del rango
                Instantiate(instance.Prefab, randomPosition, Quaternion.identity); //Instancia la instance con su posici�n y rotaci�n 
                return;
            }
        }
    }
}

[System.Serializable]
struct InstanceWithProbability
{
    [SerializeField] GameObject prefab; 
    public GameObject Prefab => prefab;

    [Range(0, 1)]
    [SerializeField] float probability;
    public float Probability => probability;

    [SerializeField] int amount;
    public int Amount => amount;

    public InstanceWithProbability(GameObject prefab, float probability, int amount) //Constructora
    {
        this.prefab = prefab;
        this.probability = probability;
        this.amount = amount;
    }
}