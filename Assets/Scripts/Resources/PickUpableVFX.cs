public class PickUpableVFX : OutlineManager
{
    public void StartVFX() => Highlight(Outline.Mode.OutlineAll);
    public void StopVFX() => RemoveHighlight();
}
