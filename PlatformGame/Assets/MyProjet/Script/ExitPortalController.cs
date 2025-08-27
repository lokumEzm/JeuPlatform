using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortalController : MonoBehaviour
{
    public int keyForExit;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.currentGame.currentKey >= keyForExit)
                SceneManager.LoadScene("FinalScene");
        }
        else
        {
             Debug.Log("Pas assez de clé");
        }
    }
}
