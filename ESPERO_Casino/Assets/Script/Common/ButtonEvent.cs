using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

    private Button button;   //Buttonコンポーネント
    
	/**
     **  機能：Buttonコンポーネントのセット
	 **/
	private void SetButton(){
		button = gameObject.GetComponent<Button>();
	}
	
	}
