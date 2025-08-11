using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private PlayerInputController _playerInputController;

    Vector3 inputDir = Vector3.zero;
    public float _speed = 5;
    public float strafSpeed = 3;
    public float _jumpSpeed = 10;
    public Vector3 moveDirectionContraints;

    // public Rigidbody rb;

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
        if (inputDir.x != 0)
            Move();
        //Jump();
    }

    void Update()
    {
        inputDir.x = Input.GetAxis("Horizontal");
    }

    public void Move()
    {
        Vector3 direction = moveDirectionContraints * inputDir.x * _speed * Time.deltaTime;

        _rigidbody.MovePosition(transform.position + direction);

        if (gameObject.transform.position.y <= -10)
        {
            gameObject.transform.position = new Vector3(-11.45f, 1, 0.5f);
        }
    }



    public void Jump()
    {

        Debug.Log(_jumpTriggered);

        if (_jumpTriggered)
        {
            _rigidbody.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
            _jumpTriggered = false;

        }
    }


    void JumpButtonPressed()
    {
        if (_groundController.IsGrounded)
        {
            _jumpTriggered = true;
        }
    }
}
