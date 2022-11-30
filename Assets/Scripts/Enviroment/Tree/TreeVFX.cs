public class TreeVFX : OutlineManager, IHighlightable
{
    public void Highlight()
    {
        base.Highlight(Outline.Mode.OutlineVisible);
    }

    public void RemoveHightlight()
    {
        base.RemoveHighlight();
    }
}
