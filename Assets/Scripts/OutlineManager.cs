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
    }
    protected void Highlight()
    {
        _outline.OutlineWidth = (float)OutlineWidth.Highlighted;
    }
    protected void RemoveHighlight()
    {
        _outline.OutlineWidth = (float)OutlineWidth.None;
    }
}