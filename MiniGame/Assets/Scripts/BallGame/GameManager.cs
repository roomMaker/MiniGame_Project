using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public GameObject BallShooter;
    public Transform FirstGroundedBallTransform;

    public Text CurrentRoundText;

    public bool IsReadyToShoot;
    public bool IsFirstGroundedBall;

    public int RoundCount;

    public int CurrentHaveBallCount;
    public int GroundedBallCount;

    [SerializeField]
    private BlockManager _blockManager;

    /// <summary>
    /// 라운드 초기화
    /// </summary>
    /// <param name="BallTransform"></param>
    public void InitRound(Transform BallTransform)
    {
        BallShooter.GetComponent<BallShooter>().SetBallsPosition();
        UpdateRound();
    }

    /// <summary>
    /// 라운드 업데이트
    /// </summary>
    public void UpdateRound()
    {
        RoundCount++;
        _blockManager.GetComponent<BlockManager>().UpdateBlock();
        SetRoundText();
    }

    /// <summary>
    /// 공 아이템 획득 시 호출되는 공 추가 함수
    /// </summary>
    public void AddBallInBallShooter()
    {
        BallShooter.GetComponent<BallShooter>().AddBall();
        GroundedBallCount++;
    }

    private void SetRoundText()
    {
        CurrentRoundText.text = $"현재 라운드 : {RoundCount}";
    }
}
