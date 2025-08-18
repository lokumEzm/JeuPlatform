using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int doorNumber;




    public void OpenDoor()
    {
        if (doorNumber == GameManager.Instance.currentGame.key)
            Debug.Log("Porte Ouverte");
    }

}
