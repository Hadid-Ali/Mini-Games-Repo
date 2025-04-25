using System;
using Infrastructure.GameEvents;
using UnityEngine;

public class TestJobv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.JobEvents.ScheduleJob.Raise(new JobMetaData()
        {
            Duration = 20,
            Mode = JobTimeMode.FRAMES,
            StepDelay = 1,
            JobAction = () =>
            {
                Debug.Log("Job action");
            },
            JobId = System.Guid.NewGuid(),
            OnJobCompleted = () =>
            {
                Debug.Log("Job completed");
            }
        });
    }
}
