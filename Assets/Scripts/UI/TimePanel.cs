using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private Text _textTime;

    private void OnEnable()
    {
        TimeSystem.OnMinuteChanged += GetTime;
    }

    private void GetTime(TimeData timeData)
    {
        string formatDataTime = $"{timeData.GetSeasonName()} {timeData.day}, Year {timeData.year} - {timeData.hour:00}:{timeData.minute:00}";
        string formatDataDayTime = $"{timeData.day}";
        ShowTextTime(formatDataTime);
    }
    private void ShowTextTime(string time)
    {
        _textTime.text = time;
    }


}
