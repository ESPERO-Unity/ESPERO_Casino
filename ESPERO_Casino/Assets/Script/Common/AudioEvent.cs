using UnityEngine;
using System.Collections;


/*動作確認は未実施*/


public class AudioEvent : MonoBehaviour {

    private AudioSource audioSource;   //AudioSourceコンポーネント
    
	/**
     **  機能：AudioSourceコンポーネントのセット
     **  備考１："gameObject"は、そのスクリプトが属しているオブジェクトを指す。
     **           データ型の"GameObject"とは異なるので注意。
     **  備考２：AudioSourceコンポーネントの派生メソッドはこのスクリプト内で定義するので、
     **          この関数は"private"としている。
	 **/
	private void SetAudio(){
	    audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	/**
     **  機能：音量コントローラ
     **  備考：音量を調整する場合は、設定値を変更する。
	 **/
	public void Audio_Volume(){
		SetAudio();
		audioSource.volume = 1.0f;
	}

	/**
     **  機能：オーディオ再生
	 **/
	public void Audio_Play(){
		SetAudio();
		audioSource.Play();
	}

	/**
     **  機能：オーディオ一時停止
	 **/
	public void Audio_Pause(){
		SetAudio();
		audioSource.Pause();
	}

	/**
     **  機能：オーディオ完全停止
	 **/
	public void Audio_Stop(){
		SetAudio();
		audioSource.Stop();
	}

}
