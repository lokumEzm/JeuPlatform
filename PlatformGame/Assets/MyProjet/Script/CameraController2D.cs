using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    public GameObject cam;
    public Transform directionCamera;
    public GameObject player;
    public Vector3 cameraOffset;
    public PlayerController2D playerController2D;

    void Start()
    {
        playerController2D.moveDirectionContraints = directionCamera.right;
        player.transform.position = directionCamera.position;
    }


    public void LateUpdate()
    {
        cam.transform.position = player.transform.position + cameraOffset;

    }
    
    

}
