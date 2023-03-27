using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Ball ball;

    private List<Ball> balls = new List<Ball>();

    private Vector2 _ballMoveVector;

    private Camera _camera;

    private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start()
    {
        _camera = Camera.main;

        AddBall();

        GameManager.Instance.IsReadyToShoot = true;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsReadyToShoot)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.IsReadyToShoot = false;
            _ballMoveVector = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            StartCoroutine(ShootBalls());
        }
    }

    /// <summary>
    /// ���� ����Ʈ�� �߰�
    /// </summary>
    public void AddBall()
    {
        balls.Add(GameObject.Instantiate(ball));
    }

    /// <summary>
    /// ����Ʈ�� �ִ� ���� ������ŭ ���� �߻��ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShootBalls()
    {
        int index = 0;

        while (index < balls.Count)
        {
            Debug.Log("�߽�");
            balls[index].IsShootedBall = true;
            balls[index].MoveVector = _ballMoveVector;

            if(index == balls.Count - 1)
            {
                balls[index].IsLastBall = true;
            }

            index++;
            yield return _waitForFixedUpdate;
        }
    }

    /// <summary>
    /// �� ���� ����� ����� �� �Ѱ����� ������ �Լ�
    /// </summary>
    public void SetBallsPosition()
    {
        foreach(Ball ball in balls)
        {
            ball.transform.position = balls[0].transform.position;
        }
    }
}
