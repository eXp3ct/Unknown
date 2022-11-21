
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Storage : MonoBehaviour
{
    [SerializeField] private const int MaxItems = 10;
    private BoxCollider _boxCollider;
    private int _width;
    private int _length;
    protected List<PickUpable> _items = new(MaxItems);
    private Vector3 zeroCoor;
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _width = (int)_boxCollider.size.x;
        _length = (int)_boxCollider.size.z;

        zeroCoor = transform.TransformPoint(new Vector3(2.5f, 2f, 5.5f));
    }
    private void FixedUpdate()
    {
        if (_items.Count != 0)
        {
            foreach (var item in _items)
            {
                if (item.Picked == true)
                    _items.Remove(item);
            } 
        }
    }
    protected void AddToStorage(PickUpable pickUpable)
    {
        if (_items.Contains(pickUpable))
            return;
        _items.Add(pickUpable);
        pickUpable.transform.position = zeroCoor;
        pickUpable.transform.rotation = GetComponentInParent<Transform>().rotation;
        if (zeroCoor.z >= _length - 1)
            zeroCoor.z -= pickUpable.gameObject.transform.localScale.z;
        else
            zeroCoor.x += pickUpable.gameObject.transform.localScale.x;
    }
}
