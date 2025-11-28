using UnityEngine;
using System;

public class TimeSystem : MonoBehaviour
{
    public static TimeSystem Instance { get; private set; }
    
    [Header("Settings")]
    public float timeScale = 1f;
    public float realSecondsPerGameMinute = 2.5f;
    
    [Header("Current Time")]
    public TimeData currentTime = new TimeData(2025, 0, 1, 6, 1);
    
    // События
    public static Action<TimeData> OnMinuteChanged;
    public static Action<TimeData> OnHourChanged; 
    public static Action<TimeData> OnDayChanged;
    public static Action<TimeData> OnSeasonChanged;
    public static Action<TimeData> OnYearChanged;
    
    private float minuteTimer = 0f;
    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isPaused) return;
        
        minuteTimer += Time.deltaTime * timeScale;
        
        if (minuteTimer >= realSecondsPerGameMinute)
        {
            minuteTimer = 0f;
            AddMinute(1);
        }
    }
    
    public void AddMinute(int minutes)
    {
        currentTime.minute += minutes;
        
        while (currentTime.minute >= 60)
        {
            currentTime.minute -= 60;
            AddHour(1);
        }
        
        OnMinuteChanged?.Invoke(currentTime);
    }
    
    public void AddHour(int hours)
    {
        int oldHour = currentTime.hour;
        currentTime.hour += hours;
        
        while (currentTime.hour >= 24)
        {
            currentTime.hour -= 24;
            AddDay(1);
        }
        
        OnHourChanged?.Invoke(currentTime);
        
        // Проверяем смену времени суток
        if ((oldHour < 6 && currentTime.hour >= 6) || 
            (oldHour < 18 && currentTime.hour >= 18))
        {
            // Смена утра/дня/вечера/ночи
        }
    }
    
    public void AddDay(int days)
    {
        currentTime.day += days;
        
        while (currentTime.day > 30) // 30 дней в сезоне
        {
            currentTime.day -= 30;
            AddSeason(1);
        }
        
        OnDayChanged?.Invoke(currentTime);
    }
    
    public void AddSeason(int seasons)
    {
        currentTime.season += seasons;
        
        while (currentTime.season >= 4)
        {
            currentTime.season -= 4;
            AddYear(1);
        }
        
        OnSeasonChanged?.Invoke(currentTime);
    }
    
    public void AddYear(int years)
    {
        currentTime.year += years;
        OnYearChanged?.Invoke(currentTime);
    }
    
    public void SetTime(int hour, int minute)
    {
        currentTime.hour = hour;
        currentTime.minute = minute;
        OnTimeChanged();
    }
    
    private void OnTimeChanged()
    {
        OnMinuteChanged?.Invoke(currentTime);
        OnHourChanged?.Invoke(currentTime);
    }
    
    // Методы управления временем
    public void Pause() => isPaused = true;
    public void Resume() => isPaused = false;
    public void SetTimeScale(float scale) => timeScale = Mathf.Max(0, scale);
    
    public bool IsDayTime() => currentTime.hour >= 6 && currentTime.hour < 18;
    public bool IsNightTime() => currentTime.hour >= 18 || currentTime.hour < 6;
    
    public string GetFormattedTime()
    {
        return $"{currentTime.GetSeasonName()} {currentTime.day}, Year {currentTime.year} - {currentTime.hour:00}:{currentTime.minute:00}";
    }

    public float GetNormalizedTime()
    {
    // Преобразуем часы и минуты в нормализованное значение [0, 1]
    // 0.0f = 00:00 (полночь)
    // 0.5f = 12:00 (полдень) 
    // 1.0f = 24:00 (следующая полночь)
    
    float totalMinutes = (currentTime.hour * 60f) + currentTime.minute;
    return totalMinutes / (24f * 60f);
    }

}
