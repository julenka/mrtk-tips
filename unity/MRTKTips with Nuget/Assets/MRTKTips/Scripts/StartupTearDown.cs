using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Events for running on startup and teardown
public class StartupTearDown : MonoBehaviour
{
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnDestroyEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        OnStart.Invoke();
    }

    void OnDestroy ()
    {
        OnDestroyEvent.Invoke();
    }
}
