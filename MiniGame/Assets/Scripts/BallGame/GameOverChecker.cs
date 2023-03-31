using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    private RaycastHit2D _hit;
    void Update()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.right);

        if (_hit.collider.CompareTag("Block"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
