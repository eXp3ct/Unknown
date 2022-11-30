using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PickUpableVFX))]
public class PickUpable : MonoBehaviour
{
    public bool Picked = false;
    [HideInInspector] public Transform PickUp { private get; set; }
    [HideInInspector] public MeshFilter MeshFilter;
    [HideInInspector] public MeshRenderer MeshRenderer;
    [HideInInspector] public Rigidbody RigidBody;
    private PickUpableVFX _pickableVFX;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
        MeshFilter = GetComponent<MeshFilter>();
        RigidBody = GetComponent<Rigidbody>();
        _pickableVFX = GetComponent<PickUpableVFX>();
    }
    // Попробовать события и не проверять каждый кадр
    private void Update()
    {
        if (Picked)
        {
            _transform.position = PickUp.position;
            //_pickableVFX.StartVFX();
        }
        else
        {
            RigidBody.velocity = Physics.gravity * .5f;
            //_pickableVFX.StopVFX();
        }
           
    }
    
}