using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Ball ball;

    private List<Ball> balls = new List<Ball>();

    private Vector2 _ballMoveVector;

    private Camera _camera;

    private bool _isReadyToShoot = false;

    private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start()
    {
        _camera = Camera.main;

        balls.Add(GameObject.Instantiate(ball));

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

    private IEnumerator ShootBalls()
    {
        int index = 0;

        while (index < balls.Count)
        {
            Debug.Log("¹ß½Î");
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
}
