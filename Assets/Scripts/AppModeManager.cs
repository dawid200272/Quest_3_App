using Meta.XR.MRUtilityKit;
using System.Collections.Generic;
using UnityEngine;

public class AppModeManager : MonoBehaviour
{
	private enum AppMode
	{
		MixedReality,
		VirtualReality,
	}

	[SerializeField] private AnchorPrefabSpawner prefabSpawner;

	private List<GameObject> _spawnedPrefabs = new();
	private AppMode _mode;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
	    if (prefabSpawner == null)
	    {
			return;
	    }

	    MRUK.Instance.RegisterSceneLoadedCallback(() =>
	    {
		    Debug.Log($"[{nameof(AppModeManager)}] Spawned prefabs count: " + prefabSpawner.AnchorPrefabSpawnerObjects.Count, this);
	    });

		//   MRUK.Instance.RegisterSceneLoadedCallback(() =>
		//   {
		//	foreach (var keyValuePair in prefabSpawner.AnchorPrefabSpawnerObjects)
		//    {
		//	    _spawnedPrefabs.Add(keyValuePair.Value);
		//    }

		//    Debug.Log($"[{nameof(AppModeManager)}] Spawned prefabs count: " + _spawnedPrefabs.Count, this);
		//});
	}

	private void Initialize()
	{
		foreach (var keyValuePair in prefabSpawner.AnchorPrefabSpawnerObjects)
		{
			_spawnedPrefabs.Add(keyValuePair.Value);
		}

		Debug.Log($"[{nameof(AppModeManager)}] Spawned prefabs count: " + _spawnedPrefabs.Count, this);

		Debug.Log($"[{nameof(AppModeManager)}] Spawned prefabs (SpawnerObjects )count: " + prefabSpawner.AnchorPrefabSpawnerObjects.Count, this);
	}

	public void SwitchToVRMode()
	{
		//if (_mode == AppMode.VirtualReality)
		//{
		//	return;
		//}

		Debug.Log("Switching to VR Mode");

		ShowSpawnedPrefabs();

		_mode = AppMode.VirtualReality;
	}

	public void SwitchToMRMode()
	{
		//if (_mode == AppMode.MixedReality)
		//{
		//	return;
		//}

		Debug.Log("Switching to MR Mode");

		HideSpawnedPrefabs();

		_mode = AppMode.MixedReality;
	}

	private void ShowSpawnedPrefabs()
	{
		//foreach (var prefab in _spawnedPrefabs)
		//{
		//	Debug.Log($"Prefab: {prefab.name} is shown", prefab);

		//	prefab.SetActive(true);
		//}
		foreach (var keyValuePair in prefabSpawner.AnchorPrefabSpawnerObjects)
		{
			Debug.Log($"[{nameof(AppModeManager)}] Prefab: {keyValuePair.Value.name} is shown", keyValuePair.Value);

			keyValuePair.Value.SetActive(true);
		}

		Debug.Log("Spawned prefabs are now shown");
	}

	private void HideSpawnedPrefabs()
	{

		//foreach (var prefab in _spawnedPrefabs)
		//{
		//	Debug.Log($"Prefab: {prefab.name} is hidden", prefab);

		//	prefab.SetActive(false);
		//}
		foreach (var keyValuePair in prefabSpawner.AnchorPrefabSpawnerObjects)
		{
			Debug.Log($"[{nameof(AppModeManager)}] Prefab: {keyValuePair.Value.name} is hidden", keyValuePair.Value);

			keyValuePair.Value.SetActive(false);
		}

		Debug.Log("Spawned prefabs are now hidden");
	}

	private void OnDestroy()
	{
		if (MRUK.Instance is null)
		{
			return;
		}

		MRUK.Instance.SceneLoadedEvent.RemoveAllListeners();
	}
}
