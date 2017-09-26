using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		//---------------------------------------------------↓キーボード操作
		// 左矢印キーを押したとき左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		// 右矢印キーを押したとき右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		// 左矢印キーが離されたとき左フリッパーを戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		// 右矢印キーが離されたとき右フリッパーを戻す
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//---------------------------------------------------↑キーボード操作

		//---------------------------------------------------↓タッチ操作
		foreach(Touch t in Input.touches)
		{
			//画面に指を触れた場合
			if (t.phase == TouchPhase.Began) {
				//画面中央より左側に触れたとき左フリッパーを動かす
				if (t.position.x > 0 && t.position.x <= (Screen.width / 2) && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);	
				}
				//画面中央より右側に触れたとき右フリッパーを動かす
				if (t.position.x > (Screen.width / 2) && t.position.x <= Screen.width && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);	
				}
			}
			//画面から指を離した場合
			if (t.phase == TouchPhase.Ended) {
				//画面中央より左側に触れたとき左フリッパーを戻す
				if (t.position.x > 0 && t.position.x <= (Screen.width / 2) && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);	
				}
				//画面中央より右側に触れたとき右フリッパーを戻す
				if (t.position.x > (Screen.width / 2) && t.position.x <= Screen.width && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);	
				}
			}

		}
		//---------------------------------------------------↑タッチ操作

	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle) {
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
