using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeCollision : MonoBehaviour
{
    [SerializeField] private Forge _forge;
    private PlayerCollision _playerCollision;
    private void Start()
    {
        _playerCollision = FindObjectOfType<PlayerCollision>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Wood>(out Wood item))
        {
            _forge.Bake(item);
            _playerCollision.IsPicking = false;
            _forge.IsBacking = true;
        }
            
    }
}
