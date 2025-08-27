using UnityEngine;
using UnityEngine.Events;
using System.Collections;



public class HelicoFly : MonoBehaviour
{
    private Animator animator;
    public GameObject cameraControll;
    public GameObject cam;

    public UnityEvent Actions;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void UpdateFlyer()  //position Levier
    {
        StartCoroutine(ActiveLever());
    }

    IEnumerator ActiveLever()
    {

        animator.SetTrigger("Fly"); // on Active le Trigger  "Active"
        //SoundManager.Instance.PlaySound3D("Fly", cam.transform.position);
        yield return new WaitForSeconds(8);
        cameraControll.SetActive(false);

        Destroy(gameObject);  // on Detruit l'object

    }
}
