using UnityEngine;

public class ForgeVFX : OutlineManager, IHighlightable
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

    public void Highlight()
    {
        Highlight(Outline.Mode.OutlineVisible);
    }

    public void RemoveHightlight()
    {
        RemoveHighlight();
    }
}
