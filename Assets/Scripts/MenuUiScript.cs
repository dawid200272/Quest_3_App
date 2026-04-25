using UnityEngine;

public class MenuUiScript : MonoBehaviour
{
	private GameObject menuUI;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		menuUI = gameObject;
	}

	//// Update is called once per frame
	//void Update()
	//{

	////}

	//public void ToggleVisibility(bool? visible)
	//{
	//	if (menuUI == null)
	//	{
	//		return;
	//	}

	//	if (visible.HasValue)
	//	{
	//		menuUI.SetActive(visible.Value);
	//	}
	//	else
	//	{
	//		menuUI.SetActive(!menuUI.activeSelf);
	//	}

	//	Debug.Log($"[{nameof(MenuUiScript)}] Menu UI panel is active: {menuUI.activeSelf}");
	//}
	public void ToggleVisibility()
	{
		if (menuUI == null)
		{
			return;
		}

		menuUI.SetActive(!menuUI.activeSelf);

		Debug.Log($"[{nameof(MenuUiScript)}] Menu UI panel is active: {menuUI.activeSelf}");
	}
}
