using System;
using TMPro;
using UnityEngine;

public class MenuUiScript : MonoBehaviour
{
	[SerializeField] private GameObject menuUIPanel;
	[SerializeField] private TextMeshProUGUI buttonText;

	[SerializeField] private AppModeManager appManager;

	[SerializeField] private GameObject objectSpawner;

	private void Start()
	{
		appManager.AppModeChanged.AddListener(OnAppModeChanged);

		menuUIPanel.SetActive(false);

		if (objectSpawner == null)
		{
			Debug.LogWarning($"[{nameof(MenuUiScript)}] Object spawning mode can not be entered: {nameof(objectSpawner)} object is not provided to the script {nameof(MenuUiScript)}");
		}

		buttonText.text = "Switch to VR mode";
	}

	private void OnAppModeChanged(AppModeManager.AppMode appMode)
	{
		buttonText.text = appMode switch
		{
			AppModeManager.AppMode.MixedReality => "Switch to VR mode",
			AppModeManager.AppMode.VirtualReality => "Switch to MR mode",
			_ => throw new ArgumentOutOfRangeException(nameof(appMode), $"Not expected app mode value: {appMode}"),
		};
	}

	public void TogglePanelVisibility()
	{
		if (menuUIPanel == null)
		{
			return;
		}

		menuUIPanel.SetActive(!menuUIPanel.activeSelf);

		Debug.Log($"[{nameof(MenuUiScript)}] Menu UI panel is "
			+ (menuUIPanel.activeSelf ? "shown" : "hidden"));
	}

	public void EnterObjectSpawningMode()
	{
		if (objectSpawner == null)
		{
			return;
		}

		objectSpawner.SetActive(true);

		menuUIPanel.SetActive(false);
	}

	private void OnDestroy()
	{
		appManager.AppModeChanged.RemoveListener(OnAppModeChanged);
	}
}
