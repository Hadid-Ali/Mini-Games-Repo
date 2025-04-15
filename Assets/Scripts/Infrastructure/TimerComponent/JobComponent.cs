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
    
    private float _duration;
    private bool _isRunning;
    private bool _isIndefinite;
    
    public Guid ID => _guid;
    protected bool CanRun => _isRunning && (_duration > 0 || _isIndefinite);

    //-100 means -> InDefinite Job
    public virtual void StartJob(JobMetaData jobMetaData)
    {
        _actionOverTime = jobMetaData.JobAction;
        _actionOnCompleted = jobMetaData.JobAction;
        
        _duration = jobMetaData.Duration;
        _isIndefinite = _duration < 0;

        _guid = jobMetaData.JobId;
        _isRunning = true;
        _jobRoutine = StartCoroutine(JobRoutine());
    }

    public virtual void Stop()
    {
        _actionOverTime = null;
        StopCoroutine(_jobRoutine);
        _isRunning = false;
    }

    protected abstract IEnumerator JobRoutine();
    
    protected void ExecuteJob()
    {
        _actionOverTime?.Invoke();
    }

    protected void DeductDuration()
    {
        if (!_isIndefinite)
            _duration--;   
    }
}
