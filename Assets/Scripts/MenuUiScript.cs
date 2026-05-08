using System;
using TMPro;
using UnityEngine;

public class MenuUiScript : MonoBehaviour
{
	[SerializeField] private GameObject menuUIPanel;
	[SerializeField] private TextMeshProUGUI buttonText;

	[SerializeField] private AppModeManager appManager;

	private void Start()
	{
		appManager.AppModeChanged.AddListener(OnAppModeChanged);

		menuUIPanel.SetActive(false);
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

	private void OnDestroy()
	{
		appManager.AppModeChanged.RemoveListener(OnAppModeChanged);
	}
}
