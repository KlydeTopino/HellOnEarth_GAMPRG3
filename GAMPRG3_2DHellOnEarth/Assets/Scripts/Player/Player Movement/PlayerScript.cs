using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float CollisionOffset = 0.05f;

    public ContactFilter2D MovementFilter;
    
    public Vector2 MovementInput;
    Rigidbody2D rb;
    MovementAnimation movementAnimationScript;

    List<RaycastHit2D> CastCollision = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementAnimationScript = gameObject.GetComponent<MovementAnimation>();
    }

    private void FixedUpdate()
    {
        if(MovementInput != Vector2.zero)
        {
            bool success = TryMove(MovementInput);

            if (!success)
            {
                success = TryMove(new Vector2(MovementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(MovementInput.y, 0));
                }
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(direction, MovementFilter, CastCollision, MoveSpeed * Time.fixedDeltaTime + CollisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * MoveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }

    }

    void OnMove(InputValue MovementValue)
    {
        MovementInput = MovementValue.Get<Vector2>();
    }
}
