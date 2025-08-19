using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AjController : MonoBehaviour
{

    [SerializeField] float speed = 1f, curSpeed, runSpeed=6f;
    [SerializeField] int rotationSpeed = 100, jumpForce=200;
    [SerializeField] AudioClip sfxJump, sfxLanding, sfxDead, sfxWin;
    [SerializeField] int mouseSensibility = 200;
    Animator anim;
    Rigidbody rb;
    Transform groundCheck;
    bool isGrounded;
    bool stop = false;
    AudioSource audioSourceAj;
    Camera cam;

    void Awake()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody>(); 
        audioSourceAj= GetComponent<AudioSource>(); 
        groundCheck= transform.Find("GroundCheck").GetComponent<Transform>();
        cam = Camera.main;
        curSpeed= speed;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
    }


    void Update()
    {
        if (stop) return;

        Move();
        Jump();
        MouseController();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool runKeyPressed = Input.GetButton("Fire1");
        anim.SetBool("Running", runKeyPressed);

        curSpeed = runKeyPressed && v>0 ? runSpeed : speed;

        transform.Translate(Vector3.forward * v * curSpeed * Time.deltaTime);
        
        if (v!=0f && isGrounded) 
            transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);

        anim.SetFloat("AxisV", v);

        anim.SetFloat("VelY", rb.linearVelocity.y);

        //Debug animations
        //if (Input.GetKeyDown(KeyCode.D)) Dead();
        //if (Input.GetKeyDown(KeyCode.S)) Win();
    }

    void Jump()
    {
        Collider[] col=  Physics.OverlapSphere(groundCheck.position, 0.2f, 3);
        isGrounded = col.Length > 0 ? true : false;

        anim.SetBool("IsGrounded", isGrounded);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("Jump");
            audioSourceAj.PlayOneShot(sfxJump);
        }
    }

    void MouseController()
    {
        //Player rotation
        if (Input.GetAxis("Vertical") != 0f && isGrounded)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime);    
        }

        //Camera rotate auround player 
        cam.transform.RotateAround(transform.position, Vector3.left,
            Input.GetAxis("Mouse Y") * 50 * Time.deltaTime);

        cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, 0, 0);
    }

    public void Dead()
    {
        anim.SetTrigger("Dying");
        stop = true;
        audioSourceAj.PlayOneShot(sfxDead);
    }

    public void Win()
    {
        anim.SetTrigger("Win");
        stop = true;
        audioSourceAj.clip = sfxWin;
        audioSourceAj.loop = true;
        audioSourceAj.Play();
    }

    public void PlaySoundLanding()
    {
        audioSourceAj.PlayOneShot(sfxLanding);
    }
}
