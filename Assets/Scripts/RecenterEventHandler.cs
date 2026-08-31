using UnityEngine;
using UnityEngine.Events;

public class RecenterEventHandler : MonoBehaviour
{
	[SerializeField] private Transform _cameraRig;
	[SerializeField] private GameObject _bodyModel;

	private OVRDisplay _display;

	public UnityEvent OnUserPoseRecentered;

	//private int _lastRecenterCount = 0;

	private void Start()
	{
		_display = OVRManager.display;

		_display.RecenteredPose += OnRecenteredPose;

		//OnUserPoseRecentered.AddListener(OnRecenteredPose);

		//OVRManager.InputFocusAcquired += OnInputFocusAcquired;

		Debug.Log($"[{nameof(RecenterEventHandler)}]: Is Ready");
	}

	private void OnInputFocusAcquired()
	{
		Debug.Log($"[{nameof(RecenterEventHandler)}]:Fokus wróci³. Prawdopodobny recenter lub powrót z menu.");
	}

	private void Update()
	{
		//var recenterCount = OVRPlugin.GetLocalTrackingSpaceRecenterCount();

		////if (recenterCount - _lastRecenterCount != 0)
		//{
		//	OnUserPoseRecentered.Invoke();

		//	Debug.Log($"[{nameof(RecenterEventHandler)}]: Recenter Count = {recenterCount}");
		//}
	}

	private void OnRecenteredPose()
	{
		// Wymuszenie synchronizacji pozycji modelu z CameraRig po resecie 
		Debug.Log($"[{nameof(RecenterEventHandler)}]: Tracking Resetted - Synchronizujê model body trackingu.");

		// Resetowanie lokalnej pozycji root modelu wzglêdem rig-u 
		_bodyModel.transform.localPosition = Vector3.zero;
		_bodyModel.transform.localRotation = Quaternion.identity;

		OnUserPoseRecentered.Invoke();
		Debug.Log($"[{nameof(RecenterEventHandler)}]: System pose recentered event detected");
	}

	private void OnDestroy()
	{
		_display.RecenteredPose -= OnRecenteredPose;

		//OnUserPoseRecentered.RemoveListener(OnRecenteredPose);

		//OVRManager.InputFocusAcquired -= OnInputFocusAcquired;
	}
}
