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
            case HintType.Tree:
                _text.text = TreeHint;
                break;
        }
    }
    public void ClearText()
    {
        _text.text = string.Empty;
    }
}
