using UnityEngine;

public class DoorController : MonoBehaviour
{
	[SerializeField] Animator animator;

	public void OpenDoor(bool value)
	{
		animator.SetBool("Bool", value);

	}

}
