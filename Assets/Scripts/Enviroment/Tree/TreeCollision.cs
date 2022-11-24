using UnityEngine;
[RequireComponent(typeof(Tree))]
public class TreeCollision : MonoBehaviour
{
    private Tree _tree;
    private void Start()
    {
        _tree = GetComponent<Tree>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.HasComponent<PlayerCollision>())
            _tree.Fall();
    }
}
