using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

/// <summary>
/// Creates a clone of this game object when the item is grabbed using near interaction
/// </summary>
public class CloneOnGrab : MonoBehaviour
{
    private void Start()
    {
        // Make sure we can be grabbed via near interaction
        gameObject.EnsureComponent<NearInteractionGrabbable>();
        var ph = gameObject.AddComponent<PointerHandler>();
        ph.OnPointerDown.AddListener(OnPointerDown);
    }

    private bool IsDirectGrab(IMixedRealityPointer p)
    {
        return p is SpherePointer;
    }

    void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        if (IsDirectGrab(eventData.Pointer))
        {
            if (eventData.Pointer is MonoBehaviour monobehaviorPointer)
            {
                // Create a copy and reparent to the pointer for easy dragging
                var spawned = GameObject.Instantiate(gameObject);
                spawned.transform.position = transform.position;
                spawned.transform.parent = monobehaviorPointer.transform;

                // Make sure we drop the object once we release
                // by receiving all pointer events and dropping the object 
                // if the pointer grabbing us invoked on pointer up.
                var releaseOnUpHandler = spawned.AddComponent<PointerHandler>();
                CoreServices.InputSystem.RegisterHandler<IMixedRealityPointerHandler>(releaseOnUpHandler);
                releaseOnUpHandler.OnPointerUp.AddListener((e) =>
                {
                    if (e.Pointer is MonoBehaviour monobehaviorPointer2
                        && spawned.transform.parent == monobehaviorPointer2.transform)
                    {
                        spawned.transform.parent = null;
                        CoreServices.InputSystem.UnregisterHandler<IMixedRealityPointerHandler>(releaseOnUpHandler);
                    }
                });
            }
            else
            {
                Debug.Log($"{gameObject.name} is being grabbed by pointer that is not monobehaviour, cannot clone and drag it out.");
            }
        }
    }
}
