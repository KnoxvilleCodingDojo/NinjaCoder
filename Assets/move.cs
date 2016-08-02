using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{
    private float _speed = 400;
    private Rigidbody2D _ninja;
    private SpriteRenderer _spriteRenderer;

    private bool isDancing = false;
    private int i = 0;

    void Start()
    {
        _ninja = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ninja.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _ninja.drag = 2;
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1); ArrowNavigation(0, 1); ArrowNavigation(0, 1);
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1);
        ArrowNavigation(0, 1); ArrowNavigation(0, 1);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ArrowNavigation(0, 1);
        }
        if (Input.GetKey(KeyCode.J))
        {
            ArrowNavigation(0, -1);
        }
        if (Input.GetKey(KeyCode.K))
        {
            ArrowNavigation(-1, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            ArrowNavigation(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _ninja.MoveRotation(180);
        }
        if (isDancing)
        {
            if (i % 10 == 0)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
            }

            i++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isDancing = !isDancing;

            if (isDancing)
            {
                _ninja.MoveRotation(180);
            }
            else
            {
                _ninja.MoveRotation(270);
            }
        }

        var pos = Camera.main.WorldToViewportPoint(_ninja.position);
        if (pos.x < 0)
        {
            pos.x += 1;
        }
        if (pos.x > 1)
        {
            pos.x -= 1;
        }
        if (pos.y < 0)
        {
            pos.y += 1;
        }
        if (pos.y > 1)
        {
            pos.y -= 1;
        }
        _ninja.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void ArrowNavigation(int x, int y)
    {
        _ninja.AddForce(new Vector2(x, y) * Time.deltaTime * _speed);
    }
}


