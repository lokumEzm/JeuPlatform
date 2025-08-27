using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;

	Vector3 inputDir = Vector3.zero;
	public float runSpeed = 5;
	public int rotateSpeed = 100;
	public float jumpForce = 100;
	float currentVelocity;
	float _smoothTime = 0.05f;
	public Camera _camera;
	private PlayerInputController _playerInputController;
	private GroundController _groundController;
	public Rigidbody rb;
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
		rb = GetComponent<Rigidbody>();
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
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");




		transform.Translate(Vector3.forward * v * runSpeed * Time.deltaTime);

		transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);

		anim.SetFloat("AxisV", v);

		//Rotate Player toward cam direction
		float _targetRotation = _camera.transform.eulerAngles.y;
		float _playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref currentVelocity, _smoothTime);
		_camera.transform.rotation = Quaternion.Euler(0f, _playerAngleDamp, 0f);

	}

	public void Jump()
	{

		if (_jumpTriggered)
		{
			rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			anim.SetTrigger("Jump");
			_jumpTriggered = false;




		}
	}

	void JumpButtonPressed()
	{
		if (_groundController.IsGrounded)
		{
			_jumpTriggered = true;
			anim.SetBool("IsGrounded", _jumpTriggered);
		}
	}

	public void Bounce()
	{
		_jumpTriggered = true;
		rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
		_jumpTriggered = false;

	}
}
