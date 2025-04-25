using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobComponent : MonoBehaviour
{
    private Guid _guid;
    private Coroutine _jobRoutine;
    
    private Action _actionOverTime;
    private Action _actionOnCompleted;
    private Action<JobComponent> _onJobCompleted;
    private Action<float> _onProgress;
    
    private float _duration;
    private bool _isRunning;
    private bool _isIndefinite;
    protected float _stepDelay;
    
    public Guid ID => _guid;
    protected bool CanRun => _isRunning && (_duration > 0 || _isIndefinite);

    public virtual void StartJob(JobMetaData jobMetaData,Action<JobComponent> onJobCompleted)
    {
        _actionOverTime = jobMetaData.JobAction;
        _actionOnCompleted = jobMetaData.OnJobCompleted;
        _onJobCompleted = onJobCompleted;

        _onProgress = jobMetaData.OnProgress;
        _stepDelay = jobMetaData.StepDelay;
        _duration = jobMetaData.Duration;
        _isIndefinite = _duration < 0;

        if (jobMetaData.JobId != Guid.Empty)
            _guid = jobMetaData.JobId;
        
        _isRunning = true;
        _jobRoutine = StartCoroutine(JobRoutine());
    }

    public virtual void Stop()
    {
        _isRunning = false;
        _actionOnCompleted?.Invoke();
        _actionOverTime = null;
        StopCoroutine(_jobRoutine);
    }

    private void StopInternal()
    {
        _onJobCompleted?.Invoke(this);
        Stop();
    }

    protected abstract IEnumerator JobRoutine();
    
    protected void ExecuteJob()
    {
        _actionOverTime?.Invoke();
    }

    protected void DeductDuration()
    {
        if (_isIndefinite) 
            return;

        _duration -= _stepDelay;
        _onProgress?.Invoke(_duration);
        if(!CanRun)
            StopInternal();
    }
}
