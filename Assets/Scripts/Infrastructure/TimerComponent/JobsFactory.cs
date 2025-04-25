using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsFactory : MonoBehaviour
{
    public JobComponent CreateJob(JobTimeMode jobMetaData)
    {
        GameObject jobObject = new GameObject();
        jobObject.transform.SetParent(transform);
        
        switch (jobMetaData)
        {
            case JobTimeMode.TIME:
                
                TimeBasedJob timeBasedJob = jobObject.AddComponent<TimeBasedJob>();
                return timeBasedJob;
            
            case JobTimeMode.FRAMES:
                
                FramesBasedJob framesBasedJob = jobObject.AddComponent<FramesBasedJob>();
                return framesBasedJob;
        }
        
        Debug.LogWarning("Subsequent job could not be created.");
        return null;
    }
}
