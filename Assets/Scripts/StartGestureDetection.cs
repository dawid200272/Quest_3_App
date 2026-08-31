using UnityEngine;
using UnityEngine.Events;

public class StartGestureDetection : MonoBehaviour
{	
	public UnityEvent onStartGestureDetected;

	private void Update()
	{
		// Left hand system gesture triggers Button.Start
		if (OVRInput.GetDown(OVRInput.Button.Start))
		{
			onStartGestureDetected.Invoke();
			Debug.Log($"[{nameof(StartGestureDetection)}]: System gesture (app menu) detected via Button.Start");
		}
	}
}
