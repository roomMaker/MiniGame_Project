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
    /// ���� �¾��� ��
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
    /// ��� ��Ȱ��ȭ
    /// </summary>
    private void BreakBlock()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Block�� UI�� ����
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
