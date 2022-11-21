using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{
    public bool IsBacking = false;

    [SerializeField] private int BakingTime = 1;
    [SerializeField] private Mesh _newMesh;
    [SerializeField] private Transform _output;
    [SerializeField] private Transform _buffer;
    [SerializeField] private ForgeUI _forgeUI;
    [SerializeField] private ForgeVFX _forgeVFX;

    public void Bake(PickUpable item)
    {
        if (item.MeshFilter.mesh == _newMesh)
            return;
        if (IsBacking == true)
            return;

        item.Picked = false;
        item.transform.position = _buffer.position;

        StartFX(item);

        item.MeshFilter.mesh = _newMesh;

        Destroy(item.GetComponent<Collider>());
        item.AddComponent<CapsuleCollider>();
        
    }

    public void ThrowBaked(PickUpable item)
    {
        item.transform.position = _output.position + new Vector3(0f, item.transform.localScale.y, 0f);
        Destroy(item.GetComponent<Wood>());
        item.AddComponent<Charcoal>();
        StopFX();
        IsBacking = false;
    }

    private void StartFX(PickUpable item)
    {
        StartCoroutine(_forgeUI.StartBake(item, BakingTime));
        _forgeVFX.StartFX();
    }
    private void StopFX()
    {
        _forgeVFX.StopFX();
    }
}
