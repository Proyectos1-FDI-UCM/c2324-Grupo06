using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserItem : MonoBehaviour, IItem
{
    [SerializeField] ItemData itemData; // Datos del item
    public ItemData ItemData => itemData;
    [SerializeField] LayerMask targetLayer; // Capa de los objetos que pueden ser da�ados por el l�ser
    [SerializeField] float damage = 2f; // Da�o que hace el l�ser
    LineRenderer lineRenderer; // LineRenderer que dibuja el l�ser

    [SerializeField] float pointWidth = 0.1f; // Ancho del l�ser antes de ser usado
    [SerializeField] float laserWidth = 1.5f; // Ancho del l�ser despu�s de ser usado

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        SetLineWidht(pointWidth); // Hace una l�nea delgada antes de ser usada que indica la direcci�n del l�ser
    }
    // Dibuja un rayo en la direcci�n en la que mira el objeto que contiene el item
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * 20);
    }
    // Al usar el item, se eensancha el l�se y hace da�o a los objetos que est�n en la direcci�n del l�ser
    public bool Use(ItemHandler handler)
    {
        SetLineWidht(laserWidth);
        DrawRay();
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, laserWidth, transform.up, 100, targetLayer); // Raycast circular para detectar objetos en el ancho del l�ser

        if (hit == false) return false;

        if(hit.transform.TryGetComponent(out HealthHandler healthHandler)) // Por cada healthahndler que encuentre el raycast, le hace da�o
        {
            healthHandler.TakeDamage(damage);
        }
        
        return true;
    }
    // Establece el ancho de la l�nea del l�ser
    public void SetLineWidht(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
    // Dibuja el rayo del l�ser
    public void DrawRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100, targetLayer);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit ? hit.point : transform.position + transform.up * 100);
    }
    // Actualiza el ancho de la l�nea del l�ser cuando es necesario
    private void Update()
    {
        SetLineWidht(Mathf.Lerp(lineRenderer.startWidth, pointWidth, Time.deltaTime * 5));
        DrawRay();
    }
}
