using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JobMetaData
{
    public Action JobAction;
    public Action<float> OnProgress;
    public JobTimeMode Mode;
    public Action OnJobCompleted;
    public float StepDelay;
    public Guid JobId;
    public float Duration = -100;
}
