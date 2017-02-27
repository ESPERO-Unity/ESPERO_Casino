using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneEvent : MonoBehaviour  {

	/**
     **  機能：シーンの遷移：Aパターン（引数はUIから入力）
     **  備考１："public void"でないとUIからOnClick関数を呼び出せない
     **  備考２：LoadScene関数のインデックスは、"BuildSetting"の"Scene In Build"の設定と連動している
	 **/
	public void OnClick_A(int SceneIdx){
		SceneManager.LoadScene(SceneIdx);  //引数はSceneのインデックス番号
	}


	/**
     **  機能：シーンの遷移：Bパターン（待ち時間を作りたい場合）
     **  備考：基本的には使用しないが、ロード時間を操作したい時に使用
	 **/
	public void OnClick_B(int SceneIdx){
		StartCoroutine(WaitTime(SceneIdx));
	}
	
	// シーン遷移コルーチン開始
	IEnumerator WaitTime(int SceneIdx) {
		yield return new WaitForSeconds(2f);	// 2秒間待つ
		SceneManager.LoadScene(SceneIdx);
	}

}
