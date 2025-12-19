using UniRx;
using System;

public class Timer : IDisposable
{
    private readonly CompositeDisposable _disposables = new CompositeDisposable();
    private readonly ReactiveProperty<float> _currentTime;
    private readonly ReactiveProperty<bool> _isRunning = new ReactiveProperty<bool>();
    private readonly ReactiveProperty<bool> _isPaused = new ReactiveProperty<bool>();
    
    private float _duration;
    private bool _autoReset;

    // Public properties for external access
    public IReadOnlyReactiveProperty<float> CurrentTime => _currentTime;
    public IReadOnlyReactiveProperty<bool> IsRunning => _isRunning;
    public IReadOnlyReactiveProperty<bool> IsPaused => _isPaused;
    public IObservable<Unit> OnTimerStart => _isRunning.Where(running => running).AsUnitObservable();
    public IObservable<Unit> OnTimerStop => _isRunning.Where(running => !running && !_isPaused.Value).AsUnitObservable();
    public IObservable<Unit> OnTimerComplete => _currentTime.Where(time => time <= 0).AsUnitObservable();
    public IObservable<float> OnTimeChanged => _currentTime;

    public Timer(float duration, bool autoReset = false)
    {
        _duration = duration;
        _autoReset = autoReset;
        _currentTime = new ReactiveProperty<float>(duration);
    }

    public void Start()
    {
        if (_isRunning.Value) return;
        
        _isRunning.Value = true;
        _isPaused.Value = false;

        Observable.EveryUpdate()
            .Subscribe(_ => UpdateTimer())
            .AddTo(_disposables);
    }

    public void Stop()
    {
        if (!_isRunning.Value) return;
        
        _isRunning.Value = false;
        _isPaused.Value = false;
        _disposables.Clear();
    }

    public void Pause()
    {
        if (!_isRunning.Value || _isPaused.Value) return;
        
        _isPaused.Value = true;
        _disposables.Clear(); // Останавливаем все подписки, включая таймер
    }

    public void Resume()
    {
        if (!_isRunning.Value || !_isPaused.Value) return;
        
        _isPaused.Value = false;
        
        Observable.EveryUpdate()
            .Subscribe(_ => UpdateTimer())
            .AddTo(_disposables);
    }

    public void Reset()
    {
        Stop();
        _currentTime.Value = _duration;
    }

    public void Reset(float newDuration)
    {
        _duration = newDuration;
        Reset();
    }

    public void AddTime(float seconds)
    {
        _currentTime.Value += seconds;
    }

    private void UpdateTimer()
    {
        _currentTime.Value -= UnityEngine.Time.deltaTime;
        
        if (_currentTime.Value <= 0f)
        {
            _currentTime.Value = 0f;
            HandleTimerComplete();
        }
    }

    private void HandleTimerComplete()
    {
        Stop();
        
        if (_autoReset)
        {
            // Используем NextFrame вместо Timer для немедленного рестарта
            Observable.NextFrame()
                .Subscribe(_ => {
                    Reset();
                    Start();
                })
                .AddTo(_disposables);
        }
    }

    public float GetProgress()
    {
        if (_duration <= 0) return 1f;
        return 1f - (_currentTime.Value / _duration);
    }

    public float GetRemainingTime() => _currentTime.Value;

    public void Dispose()
    {
        _disposables?.Dispose();
    }
}