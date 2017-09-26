using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	// 合計ポイント変数
	private int points = 0;

	// 合計ポイントを表示するtext
	private GameObject pointsText;

	// 合計ポイントの表示位置およびフォントサイズを画面サイズ変更に対応
	// displayの高さ
	private float displayHeight = Screen.height;
	// 合計ポイント表示フォントサイズ比率(画面サイズ縦640pxの時、フォントサイズ30)
	private float pointsfontsizeRatio = 30f / 640f;
	// 合計ポイント表示y軸位置について、画面上端から離す数値比率(画面サイズ高さ640pxの時、画面上端から60px下の位置に表示)
	private float pointsdisplay_yRatio = 60f / 640f;
	// 合計ポイント表示エリア幅比率(画面サイズ縦640pxの時、ポイント表示エリア幅300)
	private float pointsdisplayWidthRatio = 300f / 640f;

	// Use this for initialization
	void Start () {
		// シーン中のPointsTextオブジェクト取得
		this.pointsText = GameObject.Find ("PointsText");

		// ディスプレイサイズ高さに応じてフォントサイズを調整　最大44
		if ((pointsfontsizeRatio * displayHeight) > 44) {
			this.pointsText.GetComponent<Text> ().fontSize = 44;
		} else {
			this.pointsText.GetComponent<Text> ().fontSize = Mathf.RoundToInt (pointsfontsizeRatio * displayHeight);
		}

		// ディスプレイサイズ高さに応じてポイント表示する位置(高さ)を調整
		Vector3 pointsTextTransformPosition = this.pointsText.GetComponent<RectTransform> ().position;
		pointsTextTransformPosition.y = displayHeight - Mathf.RoundToInt(pointsdisplay_yRatio * displayHeight); // この構文でpositionを設定すると画面左下端から数値計算する(使用Unity2017.1.1f1)ようなのでそれに対応
		pointsTextTransformPosition.x = Screen.width / 2; // この構文でpositionを設定すると画面左下端から数値計算する(使用Unity2017.1.1f1)ようなのでそれに対応
		this.pointsText.GetComponent<RectTransform> ().position = pointsTextTransformPosition;

		// ディスプレイサイズ高さに応じてポイント表示エリア幅を設定(ゲームウィンドウ高さにゲームウィンドウ幅が比例するため)
		Vector2 pointsTextTransformArea = this.pointsText.GetComponent<RectTransform> ().sizeDelta;
		pointsTextTransformArea.x = Mathf.RoundToInt(displayHeight * pointsdisplayWidthRatio);
		this.pointsText.GetComponent<RectTransform> ().sizeDelta = pointsTextTransformArea;

		// 合計ポイント表示
		this.pointsText.GetComponent<Text> ().text = points + "points";
	}
	
	// Update is called once per frame
	void Update () {
		// 合計ポイント表示
		this.pointsText.GetComponent<Text> ().text = points + "points";
	}

	// 衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag") {
			points += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			points += 50;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			points += 30;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			points += 100;
		}
	}

}
