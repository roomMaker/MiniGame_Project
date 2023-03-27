using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Transform BallShooter;

    public bool IsReadyToShoot;

    public int RoundCount = 1;

    public void UpdateRound()
    {
        RoundCount++;
    }

    public void SetPositionBallShooter(Transform transform)
    {
        BallShooter.position = transform.position;
    }


}
