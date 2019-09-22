using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_MainUI : MonoBehaviour {

	static public G0_MainUI _;

	[Serializable]
	public struct _UI
	{
		public G0_UserSetUI UserSet;
		public G0_PalyUI Play;
		public G0_ScoreUICon Score;
	}
	public _UI UI;

	void Awake () {
		_ = this;
	}

	public void SetUI (int n) {
		if (n == 0) {
			UI.UserSet.gameObject.SetActive (true);
			UI.Play.gameObject.SetActive (false);
		} else {
			UI.UserSet.gameObject.SetActive (false);
			UI.Play.gameObject.SetActive (true);
		}
	}

	//==================================================================================
	[ContextMenu ("Reset")]
	void Reset () {
		SetUI (0);
	}
}
