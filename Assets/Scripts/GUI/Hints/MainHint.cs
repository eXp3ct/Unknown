using UnityEngine;
using TMPro;
public class MainHint : MonoBehaviour
{
    private readonly string TreeHint = "Press E to cut down tree";

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }
    public void SetText(HintType hintType)
    {
        switch(hintType)
        {
            case HintType.None:
                _text.text = string.Empty;
                break;
            case HintType.Tree:
                _text.CrossFadeAlpha(1, 1f, false);
                _text.text = TreeHint;
                _text.CrossFadeAlpha(0, 1f, false);
                break;
        }
    }
}
