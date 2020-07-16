using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    
    [Range(0, 1)][SerializeField] private float CurrentTime;
    [SerializeField] private float DayDuration;
    [SerializeField] private AnimationCurve SunCurve;
    [SerializeField] private float SunIntensity;
    [Header("Light Source")]
    [SerializeField] private Light Sun;
    // Start is called before the first frame update
    void Start()
    {
        SunIntensity = Sun.intensity;   
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime / DayDuration;
        if (CurrentTime >= 1)
            CurrentTime -= 1;
        Sun.transform.localRotation = Quaternion.Euler(CurrentTime * 360f, 180, 0);
        Sun.intensity = SunIntensity * SunCurve.Evaluate(CurrentTime);
    }
}
