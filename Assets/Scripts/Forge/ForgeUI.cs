using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUI : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Forge _forge;
    public IEnumerator StartBake(PickUpable item, int bakingTime)
    {
        while (_progressBar.fillAmount != 1)
        {
            _progressBar.fillAmount += .25f;
            yield return new WaitForSeconds(bakingTime);
        }
        _forge.ThrowBaked(item);
        _progressBar.fillAmount = 0;
    }

}
