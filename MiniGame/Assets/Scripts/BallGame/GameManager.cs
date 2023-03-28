using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public GameObject BallShooter;
    public Transform FirstGroundedBallTransform;

    public bool IsReadyToShoot;
    public bool IsFirstGroundedBall;

    public int RoundCount;

    public int CurrentHaveBallCount;
    public int GroundedBallCount;

    [SerializeField]
    private BlockManager _blockManager;

    /// <summary>
    /// ���� �ʱ�ȭ
    /// </summary>
    /// <param name="BallTransform"></param>
    public void InitRound(Transform BallTransform)
    {
        BallShooter.GetComponent<BallShooter>().SetBallsPosition();
        UpdateRound();
    }

    /// <summary>
    /// ���� ������Ʈ
    /// </summary>
    public void UpdateRound()
    {
        RoundCount++;
        _blockManager.GetComponent<BlockManager>().UpdateBlock();
    }

    /// <summary>
    /// �� ������ ȹ�� �� ȣ��Ǵ� �� �߰� �Լ�
    /// </summary>
    public void AddBallInBallShooter()
    {
        BallShooter.GetComponent<BallShooter>().AddBall();
        GroundedBallCount++;
    }
}
