using UnityEngine;

public class DataPrecistent : MonoBehaviour
{
    public static DataPrecistent instance;
    


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
