using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public GameObject BallShooter;
    public Transform FirstGroundedBallTransform;

    public Text CurrentRoundText;

    public GameObject GameOverUI;

    public bool IsReadyToShoot;
    public bool IsFirstGroundedBall;

    public int RoundCount;

    public int CurrentHaveBallCount;
    public int GroundedBallCount;

    [SerializeField]
    private BlockManager _blockManager;

    private void Start()
    {
        GameOverUI.SetActive(false);
    }

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
        SetRoundText();
    }

    /// <summary>
    /// �� ������ ȹ�� �� ȣ��Ǵ� �� �߰� �Լ�
    /// </summary>
    public void AddBallInBallShooter()
    {
        BallShooter.GetComponent<BallShooter>().AddBall();
        GroundedBallCount++;
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        IsReadyToShoot = false;
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void SetRoundText()
    {
        CurrentRoundText.text = $"���� ���� : {RoundCount}";
    }
}
