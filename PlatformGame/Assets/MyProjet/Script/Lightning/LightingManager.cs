using UnityEngine;


public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightningScriptable preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;

    bool night;
    bool day;

    void Start()
    {
        night = GameManager.Instance.night;
        day = GameManager.Instance.day;
        timeOfDay = 12f;
         UpdateLighting(timeOfDay / 23f);
    }

    void Update()
    {
        if (preset == null)
            return;
        if (night)
        {
            
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 23f);

            if (timeOfDay >= 23f)
            {
                timeOfDay = 23;
            }
        }

          if (day)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24f);

            if (timeOfDay >= 13f)
            {
                timeOfDay = 13;
            }
        }
        CheckNightOrDay();

    }

    void CheckNightOrDay()
    {
         night = GameManager.Instance.night;
        day = GameManager.Instance.day;
    }



    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360) - 90f, 170, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
