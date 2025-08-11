using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Vector3 inputDir = Vector3.zero;
	public float _speed = 5;
	public float _jumpSpeed = 10;
	float currentVelocity;
	float _smoothTime = 0.05f;
	public Camera _camera;
	private PlayerInputController _playerInputController;
	private GroundController _groundController;
	public Rigidbody _rigidbody;
	private bool _jumpTriggered;

	private void Awake()
	{
		_playerInputController = GetComponent<PlayerInputController>();
		_rigidbody = GetComponent<Rigidbody>();
		_groundController = GetComponent<GroundController>();
	}


	private void OnEnable()
	{
		_playerInputController.OnJumpButtonPressed += JumpButtonPressed;

	}


	private void OnDisable()
	{
		_playerInputController.OnJumpButtonPressed -= JumpButtonPressed;
	}


	void FixedUpdate()
	{
		Jump();
		Move();
	}

	public void Move()
	{
		Vector3 _inputDir = new Vector3(_playerInputController.MovementInputVector.x, 0, _playerInputController.MovementInputVector.y);

		//Forward Dir
		Vector3 _moveDir = transform.forward * _inputDir.z;
		_moveDir.Normalize();
		_moveDir *= _speed;

		//Strafe Dir
		Vector3 _strafeDir = Vector3.Cross(Vector3.up, transform.forward) * _inputDir.x; // Get the perpandicular from forward
		_strafeDir.Normalize();
		_strafeDir *= _speed;

		_moveDir += _strafeDir; // Combine to vectors

		_rigidbody.MovePosition(transform.position + (_moveDir * Time.deltaTime));

		//Rotate Player toward cam direction
		float _targetRotation = _camera.transform.eulerAngles.y;
		float _playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref currentVelocity, _smoothTime);
		transform.rotation = Quaternion.Euler(0f, _playerAngleDamp, 0f);
	}

	public void Jump()
	{

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
