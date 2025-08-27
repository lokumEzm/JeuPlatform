using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int doorNumber;




    public void OpenDoor()
    {
        if (doorNumber >= DataPrecistentManager.instance.LevelDataNeedKey)
            Debug.Log("Porte Ouverte");
    }

}
