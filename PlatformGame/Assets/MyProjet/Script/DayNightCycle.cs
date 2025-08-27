using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float duration = 5f;

    [SerializeField] Gradient gradient;
    public Light _light;
    float _startTime;
    void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        var timeElapsed = Time.time - _startTime;
        var percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
        percentage = Mathf.Clamp01(percentage);

        _light.color = gradient.Evaluate(percentage);
    }
}