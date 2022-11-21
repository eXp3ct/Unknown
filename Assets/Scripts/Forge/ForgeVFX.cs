using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeVFX : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    public void StartFX()
    {
        _particleSystem.Play();
    }
    public void StopFX()
    {
        _particleSystem.Stop();
    }
}
