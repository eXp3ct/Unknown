using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PickUpable : MonoBehaviour
{
    public bool Picked = false;
    private Rigidbody _rigidBody;
    private Transform _transform;
    [HideInInspector] public Transform PickUp { private get; set; }
    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        if (Picked)
            _transform.position = PickUp.position;
        else
            _rigidBody.velocity = Physics.gravity * .5f;
    }
    
}