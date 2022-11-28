using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpableVFX : OutlineManager
{
    public void StartVFX() => Highlight();
    public void StopVFX() => RemoveHighlight();
}
