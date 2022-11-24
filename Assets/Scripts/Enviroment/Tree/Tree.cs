using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    private const int _logsInTree = 3;
    [SerializeField] private GameObject _log;

    ///<summary>
    ///Спавнит бревна и удаляет дерево
    ///</summary>
    public void Fall()
    {
        for (int i = 0; i < _logsInTree; i++)
            Instantiate(_log, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 30f)));
        Destroy(gameObject);
    }
}
