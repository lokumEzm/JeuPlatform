using System.Collections;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
	public GameObject cam;
	public Transform directionCamera;
	public GameObject player;
	public Vector3 cameraOffset;
	public PlayerController2D playerController2D;

	public Transform trackStart;

	public bool playerAssigned = false;

	void Start()
	{
		cam.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!playerAssigned) AssignPlayer(true);
	}

	private void OnTriggerExit(Collider other)
	{
		if (playerAssigned) AssignPlayer(false);

	}
	void AssignPlayer(bool value)
	{
		playerAssigned = value;

		playerController2D.moveDirectionContraints = directionCamera.right;

		player.transform.position = trackStart.position;
		player.GetComponent<PlayerController>().enabled = !value;
		player.GetComponent<PlayerController2D>().enabled = value;

		cam.SetActive(value);

	}


	public void LateUpdate()
	{
		cam.transform.position = player.transform.position + cameraOffset;

	}





}
