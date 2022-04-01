using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritedTrackableEventHandler : DefaultTrackableEventHandler
{
    public static bool isTracking;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        if (mTrackableBehaviour)
        {
            isTracking = true;
        }
    }
}
