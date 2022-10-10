using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class DistanceZones : MonoBehaviour
{
    public int zPos = 100;
    public int zonesGenerated = 0;

    private void Start()
    {
        GameAnalytics.Initialize();
    }
}
