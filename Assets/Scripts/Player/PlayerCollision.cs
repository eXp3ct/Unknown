using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Transform _pickUp;
    private bool _isPicking;
    private PickUpable _pickedItem;
    private void Update()
    {
        if (GetInput.PressedSpace)
            DropItem(_pickedItem);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PickUpable>(out PickUpable pickUpable))
        {
            if (!_isPicking)
            {
                _pickedItem = pickUpable;
                PickUp(pickUpable);
            }
        }
    }
    private void PickUp(PickUpable pickUpable)
    {
        _isPicking = true;
        pickUpable.Picked = true;
        pickUpable.PickUp = _pickUp;
    }
    private void DropItem(PickUpable pickUpable)
    {
        _isPicking = false;
        pickUpable.Picked = false;
    }
}
