using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData;
    public ItemData ItemData => itemData;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float damage = 2f;
    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public bool Use(ItemHandler handler)
    {
        SetLineWidht(1.5f);
        DrawRay();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20, targetLayer);

        if(hit == false) return false;

        if(hit.transform.TryGetComponent(out HealthHandler healthHandler))
        {
            healthHandler.TakeDamage(damage);
        }
        
        return true;
    }

    public void SetLineWidht(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    public void DrawRay()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.up * 100);
    }

    private void Update()
    {
        SetLineWidht(Mathf.Lerp(lineRenderer.startWidth, 0.1f, Time.deltaTime * 3));
        DrawRay();
    }
}
