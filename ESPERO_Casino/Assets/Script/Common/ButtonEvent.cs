using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour{

	/// <summary>Buttonコンポーネント</summary>
	private Button button;

	/// <summary>
	/// 機能：Buttonコンポーネントのセット
	/// </summary>
	private void SetButton()
	{
		button = gameObject.GetComponent<Button>();
	}

	/// <summary>
	/// 機能：ボタンタップを有効化
	/// </summary>
	public void Button_TapOn()
	{
		SetButton();
		button.interactable = true;
	}

	/// <summary>
	/// 機能：ボタンタップを無効化
	/// </summary>
	public void Button_TapOff()
	{
		SetButton();
		button.interactable = false;
	}
}