using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedJob : JobComponent
{
   private WaitForSeconds _timeDelay;

   public override void StartJob(JobMetaData jobMetaData)
   {
      _timeDelay = new WaitForSeconds(jobMetaData.StepDelay);
      base.StartJob(jobMetaData);
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
