using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject _log;
    private const int _logsInTree = 3;
    private PlayerCollision _player;
    [SerializeField] private TreeUI _treeUI;
    private bool _canCutDown = false;
    private void Start()
    {
        _player = FindObjectOfType<PlayerCollision>();
    }
    private void Update()
    {
        if (_canCutDown)
            return;
        if (gameObject.NearTo(_player.gameObject.transform))
        {
            _canCutDown = true;
            StartCoroutine(_treeUI.CutDown());
        }
            
    }
    public void Fall()
    {
        for (int i = 0; i < _logsInTree; i++)
            Instantiate(_log, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 30f)));
        Destroy(gameObject);
    }

    
}
