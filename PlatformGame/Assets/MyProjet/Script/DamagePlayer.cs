using System.Collections;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Material materialOnDamage;
    public Material materialNormal;
    public Camera cameraPos;

    public void Start()
    {
        cameraPos = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDamaged()
    {
        GetComponent<SkinnedMeshRenderer>().material = materialOnDamage;
        SoundManager.Instance.PlaySound3D("PlayerDamage", cameraPos.transform.position);
        StartCoroutine(TimerWait());
        GameManager.Instance.Refresh.Invoke();

    }

    IEnumerator TimerWait()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SkinnedMeshRenderer>().material = materialNormal;

    }
}
