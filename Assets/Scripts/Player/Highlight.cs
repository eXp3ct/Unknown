using Extensions;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField] private Transform _orientation;
    private RaycastHit _raycastHit;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        Ray ray = new(_transform.position, _orientation.forward);
        Physics.Raycast(ray, out _raycastHit);
        GameObject hittedObject = _raycastHit.collider.gameObject;
        if (_raycastHit.collider == null)
            return;
        if (hittedObject.TryGetComponent<IHighlightable>(out IHighlightable highlightable))
        {
            if (gameObject.NearTo(hittedObject.transform))
            {
                //Debug.Log("Highlight");
                highlightable.Highlight();
            }
            else
                highlightable.RemoveHightlight();
        }
    }
}
