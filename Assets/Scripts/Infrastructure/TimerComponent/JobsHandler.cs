using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.GameEvents;
using UnityEngine;

public class JobsHandler : MonoBehaviour
{
    [SerializeField] private JobsFactory _jobsFactory;
    private List<JobComponent> _scheduledJobs = new();
    
    private void OnEnable()
    {
        GameEvents.JobEvents.ScheduleJob.Register(OnJobScheduleRequested);
        GameEvents.JobEvents.TerminateJob.Register(OnJobTerminationRequested);
    }

    private void OnDisable()
    {
        GameEvents.JobEvents.ScheduleJob.UnRegister(OnJobScheduleRequested);
        GameEvents.JobEvents.TerminateJob.UnRegister(OnJobTerminationRequested);

    }

    private void OnJobScheduleRequested(JobMetaData jobMetaData)
    {
        JobComponent job = _jobsFactory.CreateJob(jobMetaData.Mode);
        job.StartJob((jobMetaData));
        _scheduledJobs.Add(job);
    }

    private void OnJobTerminationRequested(Guid guid)
    {
        JobComponent jobComponent = _scheduledJobs.Find(j => j.ID.Equals(guid));
        if (jobComponent == null)
        {
            Debug.LogWarning("Job is either not scheduled or terminated.");
            return;
        }

        StopJobInternal(jobComponent);
    }

    private void StopJobInternal(JobComponent jobComponent)
    {
        _scheduledJobs.Remove(jobComponent);
        jobComponent.Stop();
        
        Destroy(jobComponent.gameObject);
    }
}
