using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float _speed;

    private float _horizontal;
    private float _vertical;
    private bool _isFacingRigth = true;

    void Start()
    {
        
    }
    
    void Update()
    {
        rigidbody.velocity = new Vector2(_horizontal * _speed, rigidbody.velocity.y);
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, _vertical * _speed);

        if (!_isFacingRigth && _horizontal > 0f)
        {
            _flip();
        }
        else if (_isFacingRigth && _horizontal < 0f)
        {
            _flip();
        }
    }

    public void HorizontalMove(InputAction.CallbackContext context)
    { 
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void VerticalMove(InputAction.CallbackContext context)
    {
        _vertical = context.ReadValue<Vector2>().y;
    }
    
    private void _flip()
    {
        _isFacingRigth = !_isFacingRigth;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
