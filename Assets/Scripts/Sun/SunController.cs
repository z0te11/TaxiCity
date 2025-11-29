using UnityEngine;

public class SunController : MonoBehaviour
{
    [Header("Sun Settings")]
    
    [Header("Rotation Settings")]
    [SerializeField] private float startRotationX = -90f;
    [SerializeField] private float endRotationX = 270f;

    private Quaternion targetRotation;
    private float currentNormalizedTime;

    private void Update()
    {
        if (TimeSystem.Instance != null)
        {
            UpdateSunRotation(TimeSystem.Instance.currentTime);
        }   
    }

    private void UpdateSunRotation(TimeData timeData)
    {
        currentNormalizedTime = CalculateNormalizedTime(timeData.hour, timeData.minute);
        
        float sunAngle = CalculateSunAngle(currentNormalizedTime);

        targetRotation = Quaternion.Euler(sunAngle, 170f, 0f);

        transform.rotation = targetRotation;
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
