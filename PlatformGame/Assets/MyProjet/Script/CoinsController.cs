using UnityEngine;

public class CoinsController : MonoBehaviour, ICollectable
{
	public CoinsSpawner.CoinInfo coinInfo;
	public MeshRenderer meshRenderer;
	public Camera cameraPos;

	void Awake()
	{
		cameraPos = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	public void Init(CoinsSpawner.CoinInfo coinInfo)
	{
		this.coinInfo = coinInfo;
		meshRenderer.material = coinInfo.material;
	}

	public void OnCollect()
	{

		GameManager.Instance._activeLevel.collectedCoinsCount += coinInfo.value;


		GameManager.Instance.onCoinCollected.Invoke();

		IHM.instance.RefreshUI();
		SoundManager.Instance.PlaySound3D("CoinsCollect", cameraPos.transform.position); // On joue un son quand on touche la piece
		Destroy(gameObject);  // on detruit l 'objext
	}
}