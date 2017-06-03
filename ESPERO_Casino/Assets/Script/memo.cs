using UnityEngine;
using System.Collections;

public class memo : MonoBehaviour {

	/* 作業メモ
	背景は"1DAE2400"

	◆コンポーネントの種類
	AudioClip
	PlayerStatusControl
	DisplayMessage

	■コンポーネント取得手法
	【コンポーネント型の変数】 = gameObject.GetComponent<【コンポーネント名】>();
	【コンポーネント型の変数】 = GameObject.Find("【指定するオブジェクト名】").GetComponent<【コンポーネント名】>();

	transform.SetParent(GameObject.Find("【指定するオブジェクト名】").transform);     


	◆コンポーネントに紐づくメソッド
	SetActive(false);
	PlayerStatusControl(3);


	◆Unityの独自機能
	■Collider

	■Coroutine
	コルーチンも変数で扱う事ができる。

	・コルーチン使い方（例）
	public IEnumerator 関数名(【引数】) {
		【変数】 = StartCoroutine( 【引数】 );

		while (true) {
			if (【条件】) {
				yield break;
			}
			yield return null;
		}
	}

	◆その他機能
	■複製
	Instantiate

	■色の設定
	・Unityが用意したカラーネームを使う
	Color.red

	・RGBAで設定
		private Color cRed;
		cRed = new Color(230f/255f, 50f/255f, 60f/255f, 1);
		GetComponent<Text>().color = cRed;

		//GetComponent<Text>().text = 【オブジェクト名】.ToString();
		//GetComponent<Animation>().Play("【オブジェクト名】");
	・ランダムな色 Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f );

	■オブジェクト削除（メモリ解放）
	Destroy(gameObject);

	■移動速度
	※Update関数に記述すると移動する。
	Vector3 pos = new Vector3(0, -1.0f, 0);
	transform.position -= pos;

	■透過設定
	※Update関数に記述するとフレームごとに処理される
	private float fAlphaSpeed = 1;     // 透過速度
	private float fAlphaKeepTime = 8;  // 透過維持時間
	private int nFrame= 0;             // フレーム数
	//ゲージ増減関数内の処理
	nFrame++;
	if (nFrame > fAlphaKeepTime) {
		cRed.a -= fAlphaSpeed * (nFrame-fAlphaKeepTime) / 1000f;
	}

	■セットアップエラー回避
	例）
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(BoxCollider2D))]
	[RequireComponent(typeof(Animation))]
	[RequireComponent(typeof(AudioSource))]

	■Resourcesフォルダ内のAssetの呼び出し
	例）
	Effect = (GameObject)Resources.Load ("Prefab/Effect");

	■デバッグログ
	例）
	Debug.Log ("チェックID：" + nCheckNoteID + "、検知時間：" + Time.realtimeSinceStartup);

	■構造体（位置情報）
		public struct ButtonPos             // ボタン位置情報構造体
		{
			public float[] fPosX;	            // ボタン位置情報X
			public float[] fPosY;	            // ボタン位置情報Y
			public void Reset() {               // 位置初期化
				this.fPosX = new float[3] {290.0f, 210.0f, 130.0f};
				this.fPosY = new float[3] {-50.0f, -70.0f, -110.0f};    
			}
		};

	■スプライト操作
	例）
		public Sprite light;

		void Start () {
			// オブジェクト生成
			GameObject Light = (GameObject)Resources.Load ("Prefab/Light");

			for (int i=0; i<6; i++) {
				GameObject Light = (GameObject)Instantiate(Light);
				Light.transform.SetParent(transform);
				Light.transform.localPosition = transform.position;
				Light.transform.localScale = new Vector2(1.0f, 1.0f);
				Sprite image = light;
				switch (i)
				{
					case 0: image = light; break;
					case 1: image != light; break;
				}
				motionLight.GetComponent<Image>().sprite = image;
			}
		}

	■ファイル操作
		// ファイルの読込
		// @param : 
		// @return: int nRet 結果（n:データ数 -1:エラー）
		private int ReadPlayFiles(){

			// 結果情報
			int nRet = 0;

			// タイミングデータをリソースから読み込み
			string stageName = GameControl.GetStageName();
			Level gamelevel = GameControl.GetGameLevel ();
			string tmNameFile = TimingPath + stageName + "_T" + gamelevel;

			if (!File.Exists (tmNameFile)) {
				Debug.Log ("タイミングファイルありません。 ファイル名：" + tmNameFile);
				nRet = -1;
				return nRet;
			}

			// 対応するタイミングファイルを読込
			FileInfo fi = new FileInfo (tmNameFile);
			try {
				// ファイル読込
				Stream stmTiming = fi.OpenRead ();
				// シークポインタを先頭にセット
				stmTiming.Seek (0, System.IO.SeekOrigin.Begin);
				// ファイル読込
				StreamReader sr = new StreamReader(stmTiming, Encoding.UTF8);
				int nPDCnt = 0;
				while( sr.Peek() >= 0 ){
					string strRData = sr.ReadLine();
					if( strRData == "END" ){
						break;
					}else{
						// カンマ区切りで分割して配列に格納する
						string[] sArrayData = strRData.Split(',');
						// 開始からの経過時間（ミリ秒）
						PData[nPDCnt].nSendTime   = int.Parse(sArrayData[0]);
						// タイプ
						PData[nPDCnt].nType       = int.Parse(sArrayData[1]);
						// 送出ライン番号（1～6）
						PData[nPDCnt].nSendPos    = int.Parse(sArrayData[2]);
						// 判定ライン番号（1～6）
						PData[nPDCnt].nChkPos     = int.Parse(sArrayData[3]);
						// 長さ（※長押しタイプのみ有効）
						PData[nPDCnt].nPushLength = int.Parse(sArrayData[4]);
						// 押下回数（※連打タイプのみ有効）
						PData[nPDCnt].nPushCount  = int.Parse(sArrayData[5]);
						// 行数カウンタ更新
						nPDCnt++;
					}
				}
				nRet = nPDCnt;
				// ファイルクローズ
				sr.Close();
				// プレイデータの調整を実施。
				AdjustPlayData(nRet);
			} catch (Exception e) {
				Debug.Log ("タイミングファイルのデータ読込でエラー発生 ファイル名：" + tmNameFile + "、エラー内容：" + e.TargetSite);
				// エラーセット


	*/


}
