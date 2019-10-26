using UnityEngine;

public class EnableRenderers : MonoBehaviour
{
    void Start()
    {
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
        }
    }
}
