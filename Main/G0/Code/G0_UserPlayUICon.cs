using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G0_UserPlayUICon : ObjArray {
	[Serializable]
	public struct _UI {
		public Tween_Color Tween_Color;
		public Image [] Images;
		public Tween_Rotation Tween_Rotation;
		public Tween MoveTw;
		public ColliderDetect ColliderDetect;
	}
	public _UI UI;

	public int Lv;
	public int Tu;//0:空手 1:搬貨
	public int Mod;//0:正常 1:不適

	public float Speed {
		get {
			return Play_Mod.Speed;
		}
	}

	public G0_Play_Mod Play_Mod;

	void Awake () {
		Play_Mod = G0_MainUI._.UI.Play.GetComponent <G0_Play_Mod> ();
	}

	void Start () {
		UI.Tween_Color.Del += (f) => {
			for (int i = 0; i < UI.Images.Length; i++) {
				UI.Images [i].color = UI.Tween_Color.NowColor;
			}
		};
		UI.ColliderDetect.EnterDel += Eat;
		UI.ColliderDetect.ExitDel += Lose;

		Play_Mod.HPDel += (b) => {
			SetMod (b ? 0 : 1);
		};

		UI.MoveTw.Del += (float f) => {
			GetComponent <RectTransform> ().pivot = new Vector2 (0.5f, f * 0.2f);
		};
	}

	void Update () {
		Move (G0_MainUI._.UI.Play.Now_TPot);
	}

	public void Move (Vector3 TPot) {
		Vector3 V3 = (TPot - transform.localPosition);
		if (
			(V3.x > -50 && V3.x < 50) &&
			(V3.y > -50 && V3.y < 50)
		) {
			UI.MoveTw.enabled = false;
			// UI.Tween_Rotation.enabled = false;
		} else {
			transform.localScale = new Vector3 (V3.x > 0? 1 : -1 , 1 , 1);
			if (Mod == 0) {
				transform.localPosition += V3.normalized * Speed;
				UI.MoveTw.Time_Length = 2f / Speed;
			} else {
				transform.localPosition += V3.normalized * 10;
				UI.MoveTw.Time_Length = 2f / 10f;
			}
			UI.MoveTw.enabled = true;
			// UI.Tween_Rotation.enabled = true;
		}
	}

	//偵測碰撞
	public void Eat (GameObject g) {
		if (g == null) return;

		if (g.tag == "Box") {
			if (Play_Mod.Eat_Box ()) {
				g.GetComponent <G0_Box> ().End ();
				SetTu (1);
			}
		} else if (g.tag == "LvUp") {
			if (g.name == "LvUp_0") {
				Play_Mod.Eat_LvUp (1);
			} else if (g.name == "LvUp_1") {
				Play_Mod.Eat_LvUp (2);
			}
			g.GetComponent <G0_LvUp> ().End ();
			SetLv (Play_Mod.LV);
		} else if (g.tag == "End") {
			Play_Mod.Lose_Box (g.name);
			
			if (Play_Mod.BoxN <= 0) {
				SetTu (0);
			}
		} else if (g.tag == "Reset") {
			Play_Mod.IsReset = true;
		}
	}
	public void Lose (GameObject g) {
		if (g.tag == "Reset") {
			Play_Mod.IsReset = false;
		}
	}

	public void SetLv (int N_Lv) {
		Lv = N_Lv;
		Reset ();
	}

	public void SetTu (int N_Tu) {
		Tu = N_Tu;
		Reset ();
	}

	public void SetMod (int N_Mod) {
		Mod = N_Mod;
		Reset ();
	}

	[ContextMenu ("Reset")]
	public void Reset () {
		ObjArray LvObj = GetObjT <ObjArray> (Lv);
		ObjArray TuObj = LvObj.GetObjT <ObjArray> (Tu);
		OnOnlyObjs (Lv);
		LvObj.OnOnlyObjs (Tu);
		TuObj.OnOnlyObjs (Mod);

		UI.Images =  GetComponentsInChildren <Image> ();
		if (Mod != 1) {
			UI.Tween_Color.Mod = 0;
			for (int i = 0; i < UI.Images.Length; i++) {
				UI.Images [i].color = Color.white;
			}
		} else {
			UI.Tween_Color.Play (true);
		}
	}
}
