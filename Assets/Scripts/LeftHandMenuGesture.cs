using UnityEngine;
using UnityEngine.Events;

public class LeftHandMenuGesture : MonoBehaviour
{
    private OVRHand leftHand;
    public UnityEvent onSystemGestureDetected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftHand = GetComponent<OVRHand>();
        
        if (leftHand == null)
        {
            Debug.LogError("OVRHand component not found on this GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHand != null && leftHand.IsSystemGestureInProgress)
        {
            // System gesture detected
            onSystemGestureDetected.Invoke();
            Debug.Log("Left hand system gesture performed");
        }
    }
}
