using UnityEngine;
public class TreeVFX : OutlineManager
{
    public void StartVFX() => Highlight(Outline.Mode.OutlineVisible);
    public void StopVFX() => RemoveHighlight();
}
