using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 MoveVector;
    public bool IsShootedBall = false;

    private CircleCollider2D circleCollider;

    private float _speed = 8f;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void FixedUpdate()
    {
        if (IsShootedBall)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance.IsFirstGroundedBall == false)
        {
            GameManager.Instance.FirstGroundedBallTransform = transform;
            GameManager.Instance.IsFirstGroundedBall = true;
        }
        // 공이 튕기는 처리
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Block"))
        {
            MoveVector = Vector2.Reflect(MoveVector, collision.contacts[0].normal);
        }

        if (collision.collider.CompareTag("Ground") && IsShootedBall == true)
        {
            MoveVector = Vector2.zero;
            IsShootedBall = false;
            GameManager.Instance.GroundedBallCount++;

            if (GameManager.Instance.CurrentHaveBallCount == GameManager.Instance.GroundedBallCount)
            {
                GameManager.Instance.InitRound(GameManager.Instance.FirstGroundedBallTransform);
                GameManager.Instance.GroundedBallCount = 0;
                GameManager.Instance.IsFirstGroundedBall = false;
            }
           
        }
    }

    /// <summary>
    /// 공 이동
    /// </summary>
    private void Move()
    {
        transform.Translate(MoveVector.normalized * _speed * Time.deltaTime);
    }

}
