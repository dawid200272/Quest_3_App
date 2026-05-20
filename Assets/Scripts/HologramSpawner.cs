using Meta.XR;
using UnityEngine;

public class HologramSpawner : MonoBehaviour
{
	[SerializeField] private Transform rayStartPoint;
	[SerializeField] private float rayLength;
	[SerializeField] private EnvironmentRaycastManager envRayManager;
	[SerializeField] private GameObject hologramPrefab;
	[SerializeField] private GameObject hologramPreviewPrefab;
	[SerializeField] private OVRInput.Button button = OVRInput.Button.SecondaryIndexTrigger;
	[SerializeField] private Transform playerPosition;

	private GameObject currentPreview;

	private void Start() => currentPreview = Instantiate(hologramPreviewPrefab);

	void Update()
	{
		Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

		bool hasHit = envRayManager.Raycast(ray, out var hit, rayLength);

		if (hasHit)
		{
			currentPreview.SetActive(true);

			currentPreview.transform.position = hit.point;
			currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			currentPreview.transform.LookAt(playerPosition);

			if (OVRInput.GetDown(button))
			{
				//Instantiate(hologramPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

				hologramPrefab.transform.position = hit.point;
				hologramPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
				hologramPrefab.transform.LookAt(playerPosition);

				hologramPrefab.SetActive(true);

				currentPreview.SetActive(false);

				gameObject.SetActive(false);
			}
		}
	}
}
