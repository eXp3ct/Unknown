
public class WoodVFX : OutlineManager, IHighlightable
{
    public void Highlight()
    {
        base.Highlight(Outline.Mode.OutlineAll);
    }

    public void RemoveHightlight()
    {
        base.RemoveHighlight();
    }
}
