using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGameManager : MonoBehaviour
{
    public static StartGameManager instance;



    public Image blackScreen;
    public float fadeSpeed = 2f;
    public bool fadeToBlack, fadeFromBlack;

    public GameObject pauseScreen, optionsScreen;







    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        MusicManager.Instance.PlayMusic("StartGame");

        if (!PlayerPrefs.HasKey("LevelRecord1")) //Si record n'existe pas ou n'a jamais ete enregistré
        {
            PlayerPrefs.SetFloat("LevelRecord1", 999);
        }
        else
        {
            PlayerPrefs.GetFloat("LevelRecord1");
        }
        
         if (!PlayerPrefs.HasKey("LevelRecord2")) //Si record n'existe pas ou n'a jamais ete enregistré
        {
            PlayerPrefs.SetFloat("LevelRecord2", 999);
        }
        else
        {
            PlayerPrefs.GetFloat("LevelRecord2");
        }
    }

    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void Resume()
    {
        GameManager.Instance.PauseUnpause();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }


    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
}
