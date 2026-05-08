using Meta.XR;
using UnityEngine;

public class RaycastObjectSpawner : MonoBehaviour
{
	[SerializeField] private Transform rayStartPoint;
	[SerializeField] private float rayLength;
	[SerializeField] private EnvironmentRaycastManager envRayManager;
	[SerializeField] private GameObject prefabToSpawn;
	[SerializeField] private OVRInput.Button button = OVRInput.Button.PrimaryIndexTrigger;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    void Update()
    {
		if (OVRInput.GetDown(button))
		{
			Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

			bool hasHit = envRayManager.Raycast(ray, out var hit, rayLength);

			if (hasHit)
			{
				GameObject spawnedObject = Instantiate(prefabToSpawn);

				Vector3 hitPoint = hit.point;
				Vector3 hitNormal = hit.normal;

				spawnedObject.transform.position = hitPoint;
				spawnedObject.transform.rotation = Quaternion.LookRotation(-hitNormal);
			}
		}
	}
}
