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
    [SerializeField] private Image _progressBar;

    public void Bake(PickUpable item)
    {
        if (item.MeshFilter.mesh == _newMesh)
            return;
        if (IsBacking == true)
            return;

        item.Picked = false;
        item.transform.position = _buffer.position;

        StartCoroutine(StartBake(item, BakingTime));
        
        item.MeshFilter.mesh = _newMesh;

        
        Destroy(item.GetComponent<BoxCollider>());
        item.AddComponent<CapsuleCollider>();
        
    }

    private void ThrowBaked(PickUpable item)
    {
        item.transform.position = _output.position + new Vector3(0f, item.transform.localScale.y, 0f);
        Destroy(item.GetComponent<Wood>());
        item.AddComponent<Charcoal>();
        ResetForge();
    }
    //Убрать из этого скрипта (Отрисовка != поведению)
    private IEnumerator StartBake(PickUpable item, int bakingTime)
    {
        while(_progressBar.fillAmount != 1)
        {
            _progressBar.fillAmount += .25f;
            yield return new WaitForSeconds(bakingTime);
        }
        ThrowBaked(item);
    }
    private void ResetForge()
    {
        _progressBar.fillAmount = 0;
        IsBacking = false;
    }
}
