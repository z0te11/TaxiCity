using UnityEngine;
using Zenject;

public class SunController : MonoBehaviour
{
    [Header("Sun Settings")]
    
    [Header("Rotation Settings")]
    [SerializeField] private float startRotationX = -90f;
    [SerializeField] private float endRotationX = 270f;
    [SerializeField] private Light _light;

    private Quaternion targetRotation;
    private float currentNormalizedTime;
    private TimeSystem _timeSystem;

    [Inject]
    public void Construct(TimeSystem timeSystem)
    {
        _timeSystem = timeSystem;
    }

    private void Update()
    {
        if (_timeSystem == null) return;

        UpdateSunRotation(_timeSystem.currentTime);
    }

    private void UpdateSunRotation(TimeData timeData)
    {
        currentNormalizedTime = CalculateNormalizedTime(timeData.hour, timeData.minute);

        float sunAngle = CalculateSunAngle(currentNormalizedTime);

        targetRotation = Quaternion.Euler(sunAngle, 170f, 0f);

        if (sunAngle <= 10f || sunAngle >= 180f)
        {
        _light.enabled = false;
        }
        else
        {
        _light.enabled = true;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    private float CalculateNormalizedTime(int hour, int minute)
    {
        float totalMinutes = (hour * 60f) + minute;
        return totalMinutes / (24f * 60f);
    }

    private float CalculateSunAngle(float normalizedTime)
    {
        // Вычисляем угол солнца на основе времени суток
        // 0.0f = ночь (солнце под горизонтом)
        // 0.25f = восход (6:00)
        // 0.5f = полдень (12:00)
        // 0.75f = закат (18:00)
        // 1.0f = ночь
        
        return Mathf.Lerp(startRotationX, endRotationX, normalizedTime);
    }
}
