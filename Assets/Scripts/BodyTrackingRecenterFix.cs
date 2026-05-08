using UnityEngine;

public class BodyTrackingRecenterFix : MonoBehaviour
{
	[SerializeField] private Transform _cameraRig;
	[SerializeField] private GameObject _bodyModel;

	private void OnEnable()
	{
		// subskrypcja zdarzenia resetu pozycji
		OVRManager.TrackingOriginChangePending += OnTrackingResetted;
	}

	private void OnDisable()
	{
		OVRManager.TrackingOriginChangePending -= OnTrackingResetted;
	}

	private void OnTrackingResetted(OVRManager.TrackingOrigin origin, OVRPose? nullable)
	{
		// wymuszenie synchronizacji pozycji modelu z CameraRig po resecie
		Debug.Log($"[{nameof(BodyTrackingRecenterFix)}] Tracking Resetted - Syncing body tracking model");

		// resetowanie lokalnej pozycji root modelu wzglêdem CameraRig-u
		_bodyModel.transform.localPosition = Vector3.zero;
		_bodyModel.transform.localRotation = Quaternion.identity;
	}
}