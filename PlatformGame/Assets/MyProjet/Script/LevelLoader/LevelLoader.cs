using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelSelector levelSelector;
   

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        levelSelector.levelLoader = true;
    }

    void OnTriggerExit(Collider other)
    {
         if(other.CompareTag("Player"))
         levelSelector.levelLoader = false;
    }
}
