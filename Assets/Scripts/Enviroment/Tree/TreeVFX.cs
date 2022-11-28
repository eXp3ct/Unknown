using UnityEngine;
public class TreeVFX : OutlineManager
{
    public void StartVFX() => Highlight();
    public void StopVFX() => RemoveHighlight();
}
