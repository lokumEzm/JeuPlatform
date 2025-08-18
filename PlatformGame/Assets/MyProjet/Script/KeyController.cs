using UnityEngine;

public class KeyController : MonoBehaviour,ICollectable
{
    public int keyValue = 1;

    public void OnCollect()
    {
        Debug.Log("Clé collecté");
          GameManager.Instance.currentGame.key++;
          GameManager.Instance.Refresh.Invoke();
        Destroy(gameObject);
    }
}
