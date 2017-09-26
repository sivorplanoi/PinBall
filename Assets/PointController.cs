using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	// 合計ポイント変数
	private int points = 0;

	// 合計ポイントを表示するtext
	private GameObject pointsText;

	// Use this for initialization
	void Start () {
		// シーン中のPointsTextオブジェクト取得
		this.pointsText = GameObject.Find ("PointsText");
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
