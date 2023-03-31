using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<List<GameObject>> _blockAndItem = new List<List<GameObject>>(7);
    private List<GameObject> _blockItem = new List<GameObject>();

    [SerializeField]
    private Transform[] _blockPosition;
    [SerializeField]
    private GameObject Blocks;

    private int randItemIndex = 0;
    private int randBlockIndex = 0;

    [SerializeField]
    private GameObject _block;
    [SerializeField]
    private GameObject _item;
    [SerializeField]
    private GameObject _emptyObject;

    private void Start()
    {
        UpdateBlock();
    }

    /// <summary>
    /// ���� ���� ���Խ� ȣ�� - ��� ���� �� ��ü ��� ������
    /// </summary>
    public void UpdateBlock()
    {
        MakeBlockLine();
        StartCoroutine(MoveDownBlocks());
    }

    /// <summary>
    /// ��� �� ���� ����
    /// </summary>
    private void MakeBlockLine()
    {
        randItemIndex = Random.Range(0, 5);

        for (int i = 0; i < _blockPosition.Length; ++i)
        {
            if (i == randItemIndex)
            {
                Instantiate(_item, _blockPosition[i].localPosition, Quaternion.identity, Blocks.transform);
                continue;
            }

            randBlockIndex = Random.Range(0, 2);

            if (randBlockIndex != 0)
            {
                Instantiate(_block, _blockPosition[i].localPosition, Quaternion.identity, Blocks.transform);
            }
            else
            {
                Instantiate(_emptyObject, _blockPosition[i].localPosition, Quaternion.identity, Blocks.transform);
            }
        }
    }

    /// <summary>
    /// ��ü ��� ������ �Լ�
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveDownBlocks()
    {
        int moveCount = 0;
        while (true)
        {
            if(moveCount >= 22)
            {
                break;
            }

            Blocks.transform.Translate(new Vector2(0, -0.03f));

            moveCount++;

            yield return new WaitForFixedUpdate();
        }
        GameManager.Instance.IsReadyToShoot = true;
    }

}
