using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;

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
	public Transform attackTrigger;
	public float bounceForce = 8f;
	public Animator anim;
	private Vector3 _moveDir;

	private void Awake()
	{
		{
			Instance = this;
		}

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
		Vector3 _horizontal = Vector3.Cross(Vector3.up, transform.forward) * _inputDir.x; // Get the perpandicular from forward
		_horizontal.Normalize();
		_horizontal *= _speed;

		_moveDir += _horizontal; // Combine to vectors

		_rigidbody.MovePosition(transform.position + (_moveDir * Time.deltaTime));

if(_moveDir.x !=0 || _moveDir.y !=0) 
		transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation ( new Vector3 (_moveDir.x, 0, _moveDir.z)),0.15f);
		anim.SetFloat("AxisV", _inputDir.z);

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
			anim.SetTrigger("Jump");
			_jumpTriggered = false;

			
			

		}
	}

	void JumpButtonPressed()
	{
		if (_groundController.IsGrounded)
		{
			 anim.SetBool("IsGrounded", true);
			_jumpTriggered = true;
			 
		}
	}

	public void Bounce()
	{
		_jumpTriggered = true;
		_rigidbody.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
		_jumpTriggered = false;

	}
}
