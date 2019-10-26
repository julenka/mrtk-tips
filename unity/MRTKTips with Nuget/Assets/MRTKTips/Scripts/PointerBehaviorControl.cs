using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class PointerBehaviorControl : MonoBehaviour
{
    public void DisableHandRays()
    {
        PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);
    }
}
