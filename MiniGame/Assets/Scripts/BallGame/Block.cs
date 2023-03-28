using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private int BlockCount;

    private TextMeshProUGUI BlockCountUIText;

    private void OnEnable()
    {
        BlockCountUIText = GetComponentInChildren<TextMeshProUGUI>();
        BlockCount = GameManager.Instance.RoundCount;
        SetBlockUI();
    }

    /// <summary>
    /// 공에 맞았을 때
    /// </summary>
    private void HitBall()
    {
        BlockCount--;
        SetBlockUI();

        if(BlockCount == 0)
        {
            BreakBlock();
        }
    }

    /// <summary>
    /// 블록 비활성화
    /// </summary>
    private void BreakBlock()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Block의 UI를 갱신
    /// </summary>
    private void SetBlockUI()
    {
        BlockCountUIText.text = BlockCount.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            HitBall();
        }
    }
}
