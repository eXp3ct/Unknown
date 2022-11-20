using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Transform _pickUp;
    [HideInInspector] public bool IsPicking;
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
            if (!IsPicking)
            {
                _pickedItem = pickUpable;
                PickUp(pickUpable);
            }
        }
    }
    private void PickUp(PickUpable pickUpable)
    {
        IsPicking = true;
        pickUpable.Picked = true;
        pickUpable.PickUp = _pickUp;
    }
    private void DropItem(PickUpable pickUpable)
    {
        IsPicking = false;
        pickUpable.Picked = false;
    }
}
