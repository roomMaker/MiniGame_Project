using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 MoveVector;
    public bool IsShootedBall = false;

    private CircleCollider2D circleCollider;

    private float _speed = 8f;

    public bool IsLastBall = false;

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
        if (collision.collider.CompareTag("Wall"))
        {
            MoveVector = Vector2.Reflect(MoveVector, collision.contacts[0].normal);
        }

        if (collision.collider.CompareTag("Ground") && IsShootedBall == true)
        {
            MoveVector = Vector2.zero;
            IsShootedBall = false;

            if (IsLastBall)
            {
                GameManager.Instance.SetPositionBallShooter(transform);
                GameManager.Instance.IsReadyToShoot = true;
                IsLastBall = false;
            }
           
        }
    }

    private void Move()
    {
        transform.Translate(MoveVector.normalized * _speed * Time.deltaTime);
    }


}
