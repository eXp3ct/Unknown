using System;
using UnityEngine;
using UnityEngine.Events;
using Extensions;

[RequireComponent(typeof(TreeVFX))]
public class Tree : MonoBehaviour
{
    private const int _logsInTree = 3;

    [SerializeField] private GameObject _log;
    [SerializeField] private TreeUI _treeUI;
    private TreeVFX _treeVFX;
    private PlayerCollision _player;
    private MainHint _mainHint;
    private bool _canCutDown = false;

    private Action _startVFX;
    private Action _stopVFX;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCollision>();
        _mainHint = FindObjectOfType<MainHint>();
        _treeVFX = GetComponent<TreeVFX>();
    }
    private void OnEnable()
    {
        _startVFX += () => _treeVFX.Highlight();
        _startVFX += () => _mainHint.SetText(HintType.Tree);

        _stopVFX += () => _treeVFX.RemoveHightlight();
    }
    private void OnDisable()
    {
        _startVFX -= () => _treeVFX.Highlight();
        _startVFX -= () => _mainHint.SetText(HintType.Tree);

        _stopVFX -= () => _treeVFX.RemoveHightlight();
    }
    private void Update()
    {
        if (_canCutDown)
            return;
        if (gameObject.NearTo(_player.transform))
        {
            //_startVFX?.Invoke();
            if (GetInput.PressedE)
                InitializeCutDown();
        }
        else
        {
            //_stopVFX?.Invoke();
        }
    }
    public void Fall()
    {
        for (int i = 0; i < _logsInTree; i++)
            Instantiate(_log, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 30f)));
        Destroy(gameObject);
    }
    private void InitializeCutDown()
    {
        _canCutDown = true;
        PlayerMovement.Busy = true;
        StartCoroutine(_treeUI.CutDown());
    }
    
}
