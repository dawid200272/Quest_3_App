using Meta.XR;
using UnityEngine;

public class RaycastObjectSpawner : MonoBehaviour
{
	[SerializeField] private Transform rayStartPoint;
	[SerializeField] private float rayLength;
	[SerializeField] private EnvironmentRaycastManager envRayManager;
	[SerializeField] private GameObject prefabToSpawn;
	[SerializeField] private GameObject previewPrefab;
	[SerializeField] private OVRInput.Button button = OVRInput.Button.SecondaryIndexTrigger;

	private GameObject currentPreview;

	private void Start() => currentPreview = Instantiate(previewPrefab);

    void Update()
    {
		Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

		bool hasHit = envRayManager.Raycast(ray, out var hit, rayLength);

		if (hasHit)
		{
			currentPreview.transform.position = hit.point;
			currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

			if (OVRInput.GetDown(button))
			{
				Instantiate(prefabToSpawn, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}

			//GameObject spawnedObject = Instantiate(prefabToSpawn);

			//Vector3 hitPoint = hit.point;
			//Vector3 hitNormal = hit.normal;

			//spawnedObject.transform.position = hitPoint;
			//spawnedObject.transform.rotation = Quaternion.LookRotation(-hitNormal);
		}
	}
}
