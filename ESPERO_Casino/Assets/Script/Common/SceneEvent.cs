using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneEvent : MonoBehaviour  {

	public static string ReturnScene = "1_Select"; //設定画面からの遷移用


	/**
     **  機能：シーンの遷移：Aパターン（引数はUIから入力）
     **  備考１："public void"でないとUIからOnClick関数を呼び出せない
     **  備考２：LoadScene関数のインデックスは、"BuildSetting"の"Scene In Build"の設定と連動している
     **  備考３：設定画面から遷移する際に呼び出し元を知る必要があるのでシーン名をReturnSceneに保持する
	 **/
	public void OnClick_A(int SceneIdx){
		SceneManager.LoadScene(SceneIdx);  //引数はSceneのインデックス番号

		Scene scene = SceneManager.GetActiveScene();
		ReturnScene = scene.name;

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

	/**
     **  機能：シーンの遷移：Cパターン（引数はなし）
     **  備考１：シーンの移動先が固定ではなく、呼び出し元にいく
     **  備考２：OnClick_Aと合わせる感じでint型が良かったが、インデックを取得するメソッドが分からなかった
	 **/
	public void OnClick_C(){
		SceneManager.LoadScene(ReturnScene);  //引数はScene名

	}


}
