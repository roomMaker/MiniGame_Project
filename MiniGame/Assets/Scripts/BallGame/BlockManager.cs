using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<List<GameObject>> _blockAndItem = new List<List<GameObject>>(7);

    private int _roundIndex = 0;
    private bool _isBlockIn = false;

    private int randItemIndex = 0;
    private int randBlockIndex = 0;

    [SerializeField]
    private Block _block;
    [SerializeField]
    private Item _item;

    private void Awake()
    {
        
    }

    private void InitBlocks()
    {
        foreach(var objects in _blockAndItem)
        {
            randItemIndex = Random.Range(0, 5);

            for (int i = 0; i < objects.Count; ++i)
            {
                if(i == randItemIndex)
                {
                    objects.Add(_item.gameObject);
                    continue;
                }

                randBlockIndex = Random.Range(0, 2);

                if (randBlockIndex != 0)
                {
                    objects.Add(_block.gameObject);
                }
            }
        }
    }

}
