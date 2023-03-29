using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Ball ball;

    private List<Ball> balls = new List<Ball>();

    private Vector2 _ballMoveVector;

    private Vector3 _mouseDirection;

    private RaycastHit2D _ballHit;
    private RaycastHit2D _gameOverHit;

    private LineRenderer _lineRenderer;
    private Camera _camera;

    private int _layerMask;

    private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
    }
    private void Start()
    {
        _layerMask = (-1) - (1 << LayerMask.NameToLayer("Ball"));
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
        _camera = Camera.main;

        AddBall();

        GameManager.Instance.IsReadyToShoot = true;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsReadyToShoot)
        {
            _lineRenderer.enabled = false;
            return;
        }



        _mouseDirection = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        DrawLine();

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.GroundedBallCount = 0;
            GameManager.Instance.IsReadyToShoot = false;
            _ballMoveVector = _mouseDirection;
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
    /// �� ���� ����� ����� �� �Ѱ����� ������ �Լ�
    /// </summary>
    public void SetBallsPosition()
    {
        foreach(Ball ball in balls)
        {
            ball.transform.position = GameManager.Instance.FirstGroundedBallTransform.position;
        }
        SetPositionBallShooter();
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
            balls[index].IsShootedBall = true;
            balls[index].MoveVector = _ballMoveVector;
            index++;
            yield return _waitForFixedUpdate;
        }
    }


    /// <summary>
    /// ó������ ������ ��ġ�� ������ġ �̵�
    /// </summary>
    /// <param name="transform"></param>
    private void SetPositionBallShooter()
    {
        transform.position = GameManager.Instance.FirstGroundedBallTransform.position;
    }

    /// <summary>
    /// ���� �׷��ִ� �Լ�
    /// </summary>
    private void DrawLine()
    {
        if (_lineRenderer.enabled == false)
        {
            _lineRenderer.enabled = true;
        }

        _ballHit = Physics2D.Raycast(transform.position, _mouseDirection, 1000f, _layerMask);

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _ballHit.point);
    }
}
