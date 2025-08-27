using UnityEngine;


    public class BackgroundMusic : MonoBehaviour
    {
        private static BackgroundMusic instance;
        private AudioSource audioSource;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        private void Start()
        {
            var music = PlayerPrefs.GetInt("music_enabled");
            audioSource.mute = music == 0;
            audioSource.Play();
        }
    }
