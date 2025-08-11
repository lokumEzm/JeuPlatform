using UnityEngine;

public class DemoAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           anim.SetBool("close",true);
            anim.SetBool("open",false);
        }

         if (Input.GetKeyDown(KeyCode.O))
        {
             anim.SetBool("close",false);
            anim.SetBool("open",true);
        }
    }
}
