using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SceneEvent : MonoBehaviour  {
	
	/**
     **  機能：シーンの遷移（引数はUIから入力）
     **  備考１："public void"でないとUIからOnClick関数を呼び出せない
     **  備考２：LoadScene関数のインデックスは、"BuildSetting"の"Scene In Build"の設定と連動している
	 **/
	public void OnClick(int SceneIdx){

		SceneManager.LoadScene(SceneIdx);  //引数はSceneのインデックス番号

	}
}
