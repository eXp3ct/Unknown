using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TreeUI : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Tree _tree;
    private RectTransform _rectTransform;
    private ThirdPersonCam _playerOrientation;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _playerOrientation = FindObjectOfType<ThirdPersonCam>();
        _progressBar.fillAmount = 0;
    }
    private void Update()
    {
        _rectTransform.forward = _playerOrientation.Orientaion.forward;
    }
    public IEnumerator CutDown()
    {
        while (_progressBar.fillAmount != 1)
        {
            _progressBar.fillAmount += .25f;
            yield return new WaitForSeconds(1);
        }
        _tree.Fall();
    }
    public void ResetUI()
    {
        _progressBar.fillAmount = 0;
    }
}
