using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesBasedJob : JobComponent
{
    private WaitForEndOfFrame _frameDelay = new();
    private float _frames;

    public override void StartJob(JobMetaData jobMetaData,Action<JobComponent> onJobCompleted)
    {
        _frames = jobMetaData.StepDelay;
        base.StartJob(jobMetaData, onJobCompleted);
    }

    protected override IEnumerator JobRoutine()
    {
        while (CanRun)
        {
            for (int i = 0; i < _frames; i++)
            {
                yield return _frameDelay;   
            }
            ExecuteJob();
            DeductDuration();
        }
    }
}
