using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenActiveEvent : MonoBehaviour {

	/// <summary>フリック処理用（始点）</summary>
	private Vector3 touchStartPos;

	/// <summary>フリック処理用（終点）</summary>
	private Vector3 touchEndPos;

	/// <summary>スワイプの方向</summary>
	string Direction;

	/// <summary>
	/// 機能：フリック機能（メイン処理）
	/// 備考：位置情報からフリックされたか判定
	/// </summary>
	void Flick()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			touchStartPos = new Vector3(Input.mousePosition.x,
										Input.mousePosition.y,
										Input.mousePosition.z);
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x,
									  Input.mousePosition.y,
									  Input.mousePosition.z);
			Button_Flick_GetDirection();
		}
	}

	/// <summary>
	/// 機能：フリック機能（方向取得）
	/// </summary>
	void Flick_GetDirection()
	{
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;

		if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
		{
			if (30 < directionX)
			{
				//右向きにフリック
				Direction = "right";
			}
			else if (-30 > directionX)
			{
				//左向きにフリック
				Direction = "left";
			}
		}
		else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
		{
			if (30 < directionY)
			{
				//上向きにフリック
				Direction = "up";
			}
			else if (-30 > directionY)
			{
				//下向きのフリック
				Direction = "down";
			}
			else
			{
				//タッチを検出
				Direction = "touch";
			}
		}
	}

	/// <summary>
	/// 機能：フリック機能（スワイプ方向ごとの処理）
	/// 備考：処理部分は使用する時に埋める
	/// </summary>
	/// <param name="Direction"></param> //自動生成された。意味は？
	void Button_Flick_Switch(string Direction)
	{
		switch (Direction)
		{
			case "up":
				//処理
				break;

			case "down":
				//処理
				break;

			case "right":
				//処理
				break;

			case "left":
				//処理
				break;

			case "touch":
				//処理
				break;
		}
	}
}
