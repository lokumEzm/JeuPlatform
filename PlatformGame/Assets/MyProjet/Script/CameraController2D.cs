using System.Collections;
using System.Threading;
using UnityEngine;

public class CameraController2D : MonoBehaviour
{
	public GameObject cam;
	public Transform directionCamera;
	public GameObject player;
	public Vector3 cameraOffset;
	public PlayerController2DNew playerController2DNew;

	public Transform trackStart;
	public TimerScript timerScript;
	public GameObject flag;

	public bool playerAssigned = false;

	void Start()
	{
		timerScript = GetComponent<TimerScript>();
		cam.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameManager.Instance.inLevel = true;
			timerScript.StartTimer();
			timerScript.ChronoImage.SetActive(true);
			MusicManager.Instance.PlayMusic("PlayMusic");

			if (!playerAssigned) AssignPlayer(true);
			trackStart.gameObject.SetActive(true);
			player.transform.position = trackStart.position;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameManager.Instance.inLevel = false;
			timerScript.ChronoImage.SetActive(false);
			MusicManager.Instance.PlayMusic("MapMusic");
			if (playerAssigned) AssignPlayer(false);
			trackStart.gameObject.SetActive(false);
		}

	}
	void AssignPlayer(bool value)
	{
		playerAssigned = value;

		playerController2DNew.moveDirectionContraints = directionCamera.right;


		player.GetComponent<PlayerController3D>().enabled = !value;
		player.GetComponent<PlayerController2DNew>().enabled = value;

		cam.SetActive(value);

	}


	public void LateUpdate()
	{
		cam.transform.position = player.transform.position + cameraOffset;

	}





}
