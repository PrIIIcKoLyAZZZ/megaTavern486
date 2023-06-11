using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float _horizontal;
    private float _speed = 8f;
    private float _jumpForce = 10f;
    private bool _isFacingRigth = true;
    private bool _isMoving = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(_horizontal * _speed, rigidbody.velocity.y);

        if (!_isFacingRigth && _horizontal > 0f)
        {
            _flip();
        }
        else if (_isFacingRigth && _horizontal < 0f)
        {
            _flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    { 
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jumpForce);
        }

        if (context.canceled && rigidbody.velocity.y > 0f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        }
    }

    private void _flip()
    {
        _isFacingRigth = !_isFacingRigth;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    
    private bool _isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
}
