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

    [SerializeField] float pointWidth = 0.1f;
    [SerializeField] float laserWidth = 1.5f;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        SetLineWidht(pointWidth);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * 20);
    }

    public bool Use(ItemHandler handler)
    {
        SetLineWidht(laserWidth);
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
        SetLineWidht(Mathf.Lerp(lineRenderer.startWidth, pointWidth, Time.deltaTime * 5));
        DrawRay();
    }
}
