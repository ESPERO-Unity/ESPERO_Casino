using UnityEngine;
using System.Collections;


/*動作確認は未実施*/


public class AudioEvent : MonoBehaviour {

	/// <summary>AudioSourceコンポーネント</summary>
	private AudioSource audioSource;

	/// <summary>
	/// 機能：AudioSourceコンポーネントのセット
	/// 備考１："gameObject"は、そのスクリプトが属しているオブジェクトを指す。
    ///          データ型の"GameObject"とは異なるので注意。
    /// 備考２：AudioSourceコンポーネントの派生メソッドはこのスクリプト内で定義するので、
    ///         この関数は"private"としている。
	/// </summary>
	private void SetAudio(){
	    audioSource = gameObject.GetComponent<AudioSource>();
	}

	/// <summary>
	/// 機能：音量コントローラ
	/// 備考：音量を調整する場合は、設定値を変更する。
	/// </summary>
	public void Audio_Volume(){
		SetAudio();
		audioSource.volume = 1.0f;
	}

	/// <summary>
	/// 機能：オーディオ再生
	/// </summary>
	public void Audio_Play(){
		SetAudio();
		audioSource.Play();
	}

	/// <summary>
	/// 機能：オーディオ一時停止
	/// </summary>
	public void Audio_Pause(){
		SetAudio();
		audioSource.Pause();
	}

	/// <summary>
	/// 機能：オーディオ完全停止
	/// </summary>
	public void Audio_Stop(){
		SetAudio();
		audioSource.Stop();
	}
}
