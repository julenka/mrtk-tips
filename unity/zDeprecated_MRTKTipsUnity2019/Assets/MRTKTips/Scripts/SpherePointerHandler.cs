using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpherePointerHandler : MonoBehaviour
{
    public SpherePointer spherePointer;
    public UnityEvent OnSpherePointerEnabled = new UnityEvent();
    public UnityEvent OnSpherePointerDisabled = new UnityEvent();

    private bool isInteractionEnabled = false;
    public void Start()
    {
        isInteractionEnabled = spherePointer.IsInteractionEnabled;
        UpdateEnabled();
    }
    public void Update()
    {
        if (spherePointer.IsInteractionEnabled != isInteractionEnabled)
        {
            isInteractionEnabled = spherePointer.IsInteractionEnabled;
            UpdateEnabled();
        }
    }
    private void UpdateEnabled()
    {
        if (isInteractionEnabled)
        {
            OnSpherePointerEnabled.Invoke();
        }
        else
        {
            OnSpherePointerDisabled.Invoke();
        }
    }
}
