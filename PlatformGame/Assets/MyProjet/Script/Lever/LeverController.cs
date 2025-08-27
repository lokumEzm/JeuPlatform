using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class LeverController : MonoBehaviour
{
    private Animator animator;
    public GameObject cameraControll;
   public GameObject cam;

     public UnityEvent Actions;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void UpdateLeverPosition()  //position Levier
    {
        StartCoroutine(ActiveLever());
    }

    IEnumerator ActiveLever()
    {

        animator.SetTrigger("Active"); // on Active le Trigger  "Active"
        yield return new WaitForSeconds(3);
        cameraControll.SetActive(true);
        yield return new WaitForSeconds(2);
                 SoundManager.Instance.PlaySound3D("Teleport", cam.transform.position);

        Actions.Invoke();
    }
}
