using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedJob : JobComponent
{
   private WaitForSeconds _timeDelay;

   public override void StartJob(JobMetaData jobMetaData,Action<JobComponent> onJobCompleted)
   {
      _timeDelay = new WaitForSeconds(jobMetaData.StepDelay);
      base.StartJob(jobMetaData, onJobCompleted);
   }

   protected override IEnumerator JobRoutine()
   {
      while (CanRun)
      {
         yield return _timeDelay;
         ExecuteJob();
         DeductDuration();
      }
   }
}
