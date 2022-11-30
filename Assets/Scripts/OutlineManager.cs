using UnityEngine;
[RequireComponent(typeof(Outline))]
public abstract class OutlineManager : MonoBehaviour
{
    private enum OutlineWidth
    {
        None = 0,
        Highlighted = 10
    }
    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = (float)OutlineWidth.None;
    }
    protected void Highlight(Outline.Mode outlineMode)
    {
        _outline.OutlineWidth = (float)OutlineWidth.Highlighted;
        _outline.OutlineMode = outlineMode;
    }
    protected void RemoveHighlight()
    {
        _outline.OutlineWidth = (float)OutlineWidth.None;
    }
}