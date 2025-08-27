using UnityEngine;

public class KeyController : MonoBehaviour, ICollectable
{
  DataPrecistentManager dataPrecistent;
  public int keyValue = 1;

  public Camera cameraPos;

  void Awake()
  {
    dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();

    cameraPos = GameObject.Find("Main Camera").GetComponent<Camera>();
  }

  public void OnCollect()
  {
    Debug.Log("Clé collecté");
    SoundManager.Instance.PlaySound3D("Key", cameraPos.transform.position);
    dataPrecistent.Key += keyValue;

     var inlvl = GameManager.Instance.inLevel;
        if(inlvl)       
    GameManager.Instance.currentGame.currentKey += keyValue;

    GameManager.Instance.Refresh.Invoke();
    Destroy(gameObject);
  }
}
