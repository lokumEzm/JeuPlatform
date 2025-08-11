using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputDir = Vector3.zero;
    public float _speed = 5;
    public float _jumpSpeed = 10;

    private PlayerInputController _playerInputController;
    private GroundController _groundController;
    private Rigidbody _rigidbody;
    private bool _jumpTriggered;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
        _groundController = GetComponent<GroundController>();
        _playerInputController.OnJumpButtonPressed += JumpButtonPressed;
    }


    void FixedUpdate()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        Vector3 velocity = new Vector3(_playerInputController.MovementInputVector.x, 0, _playerInputController.MovementInputVector.y) * _speed;

        velocity.y = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = velocity;

        // 
        if (gameObject.transform.position.y <= -10)
        {
            gameObject.transform.position = new Vector3(-11.45f, 1, 0.5f);
        }
    }

    public void Jump()
    {
        Vector3 velocity = _rigidbody.linearVelocity;

        if (_jumpTriggered)
        {
            velocity.y = _jumpSpeed;
            _jumpTriggered = false;
        }
        _rigidbody.linearVelocity = velocity;
    }

    void JumpButtonPressed()
    {
        if (_groundController.IsGrounded)
        {
            _jumpTriggered = true;
        }
    }
}
