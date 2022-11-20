
using UnityEngine;

public class CatchResources : Storage
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PickUpable>(out PickUpable pickUpable))
        {
            AddToStorage(pickUpable);
        }
    }
}
