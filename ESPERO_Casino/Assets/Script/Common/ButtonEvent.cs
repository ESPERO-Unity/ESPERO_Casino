using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

    private Button button;   //Buttonコンポーネント
    private Vector3 touchStartPos; //フリック処理用（始点）
	private Vector3 touchEndPos;   //フリック処理用（終点）
	string Direction; //スワイプの方向
    
    
	/**
     **  機能：Buttonコンポーネントのセット
	 **/
	private void SetButton(){
		button = gameObject.GetComponent<Button>();
	}
	
	/**
     **  機能：ボタンタップを有効化
	 **/
	public void Button_TapOn{
		SetButton();
		button.interactable = true;
	}

	/**
     **  機能：ボタンタップを無効化
	 **/
	public void Button_TapOff{
		SetButton();
		button.interactable = false;
	}

	/**
     **  機能：フリック機能（メイン処理）
     **  備考：位置情報からフリックされたか判定
	 **/
	void Button_Flick(){
		if (Input.GetKeyDown(KeyCode.Mouse0)){
			touchStartPos = new Vector3(Input.mousePosition.x,
										Input.mousePosition.y,
										Input.mousePosition.z);
    	}
		if (Input.GetKeyUp(KeyCode.Mouse0)){
			touchEndPos = new Vector3(Input.mousePosition.x,
									  Input.mousePosition.y,
									  Input.mousePosition.z);
			Button_Flick_GetDirection();
		}
	}
	
	/**
     **  機能：フリック機能（方向取得）
	 **/

	void Button_Flick_GetDirection(){
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;

		if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
			if (30 < directionX){
				//右向きにフリック
				Direction = "right";
			}
			else if (-30 > directionX){
				//左向きにフリック
				Direction = "left";
			}
		}
		else if (Mathf.Abs(directionX)<Mathf.Abs(directionY){
			if (30 < directionY){
				//上向きにフリック
				Direction = "up";
			}
			else if (-30 > directionY){
				//下向きのフリック
				Direction = "down";
			}
			else{
				//タッチを検出
				Direction = "touch";
			}
		}
	}

	/**
     **  機能：フリック機能（スワイプ方向ごとの処理）
     **  備考：処理部分は使用する時に埋める
	 **/
	Button_Flick_Switch (string Direction){
		switch (Direction){
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
