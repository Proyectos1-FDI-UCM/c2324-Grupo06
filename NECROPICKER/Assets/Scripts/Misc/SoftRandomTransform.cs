using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftRandomTransform : MonoBehaviour
{
    [SerializeField] float duration = 1;
    [SerializeField] Vector2 directionRange;
    [SerializeField] Vector2 distanceRange = new Vector2(0.45f, 0.45f);

    private void OnEnable() 
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForEndOfFrame();
        float timer = 0;
        float rotValue = Random.Range(directionRange.x, directionRange.y);
        Vector2 direction = new Vector2(Mathf.Cos(rotValue * Mathf.Deg2Rad), Mathf.Sin(rotValue * Mathf.Deg2Rad));

        Vector2 targetPos = (Vector2)transform.position + direction * Random.Range(distanceRange.x, distanceRange.y);

        while(timer < duration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, timer / duration);
                                
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
