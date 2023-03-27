using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public GameObject BallShooter;

    public bool IsReadyToShoot;

    public int RoundCount = 1;

    /// <summary>
    /// 라운드 초기화
    /// </summary>
    /// <param name="BallTransform"></param>
    public void InitRound(Transform BallTransform)
    {
        SetPositionBallShooter(BallTransform);
        BallShooter.GetComponent<BallShooter>().SetBallsPosition();
        UpdateRound();
        IsReadyToShoot = true;
    }

    /// <summary>
    /// 라운드 업데이트
    /// </summary>
    public void UpdateRound()
    {
        RoundCount++;
    }

    public void AddBallInBallShooter()
    {
        BallShooter.GetComponent<BallShooter>().AddBall();
    }

    public void SetPositionBallShooter(Transform transform)
    {
        BallShooter.transform.position = transform.position;
    }
}
