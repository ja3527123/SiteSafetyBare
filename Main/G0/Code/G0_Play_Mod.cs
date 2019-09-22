using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_Play_Mod : MonoBehaviour {
	public G0_PalyUI PalyUI;

	// [Serializable]
	// public class _Game_P {
	// 	static public _Game_P _;
	// 	public int Max_Time;//開場時從幾秒開始倒數
	// 	public int [] Time_Up;//升級時回覆多少時間
	// 	public int Max_HP;//健康值
	// 	public int HP_Dom_Speed;//每秒會降低多少健康值
	// 	public int HP_Up_Speed;//每秒會回覆多少健康值
	// 	public int [] Speed;//玩家每個狀態的移動速度
	// }
	public G0_Game_P Game_P;

	public int Time;
	public int LV = 0;//玩家等級
	public int Game_LV = 0;//場上已經出現的最高等級升級物品
	public int HP {
		get {
			return _HP;
		}
		set {
			// int n = Game_P.Max_HP / 5;
			if (value <= 0 && _HP > 0) {
				SourceCon.Play ("L", 0.8f, 2f);
				if (HPDel != null) HPDel (false);
			} else if (value > 0 && _HP <= 0) {
				if (HPDel != null) HPDel (true);
			}
			_HP = value;
		}
	}
	public int _HP;
	public Void_BoolDel HPDel;
	public int Speed {
		get {
			return Game_P.Speed [LV];
		}
	}
	public bool [] Box;//搬貨狀態
	public DiceString BoxDice;//吃到箱子時會抽到哪個箱子的機率
	public bool IsReset;
	public int BoxN {
		get {
			int r = 0;
			for (int i = 0; i < Box.Length; i++) {
				if (Box [i]) r++;
			}
			return r;
		}
	}

	public int Sceore {
		get {
			return _Sceore;
		}
		set {
			SourceCon.Play ("Get", 0.5f, 2f);
			PalyUI.UI.Sceor_Bar.LoadInt (value);
			PalyUI.SpImNob (PalyUI.Now_User.transform.localPosition, LV, value - _Sceore);
			_Sceore = value;
		}
	}
	public int _Sceore;
	
	void Awake ()
	{
		string G0_P = PlayerPrefs.GetString ("G0_P", "");
		if (G0_P != "")
		{
			Game_P = JsonUtility.FromJson <G0_Game_P> (G0_P);
		}
		// if (G0_Game_P._ != null) {
		// 	Game_P = G0_Game_P._;
		// }
	}

	void Start ()
	{
		SetTime (Game_P.Max_Time);
		SetHP (Game_P.Max_HP);
		
		StartCoroutine (Time_Update ());
		HPDel += (b) => {
			PalyUI.UI.Reset.OnOffObj (0, !b);
		};
	}
//===============================================================================	
	public IEnumerator Time_Update () {
		for (;Time > 0;) {
			yield return new WaitForSeconds (1);
			SetTime (Time - 1);

			HP_C ();
			if (Time % 1 == 0) {
				SpBox ();
			}

			if (Time < 5 && Game_LV <= LV && Game_LV < 2) {
				PalyUI.UI.LVUpStart.OpenLvUp (Game_LV);
				Game_LV ++;
				print ("生產升級物件");
			}
		}
		SourceCon.Play ("End", 1f, 0.5f);
		G0_MainUI._.UI.Score.Open (Sceore);
		print ("時間到");
	}
	public void HP_C () {
		if (BoxN > 0) SetHP (HP - Game_P.HP_Dom_Speed);
		if (IsReset) {
			SetHP (HP + Game_P.HP_Up_Speed);
		}
	}

	public void SetTime (int n) {
		Time = n;
		PalyUI.UI.Time_Bar.End_F = (float)Time / Game_P.Max_Time;
	}
	public void SetHP (int n) {
		n = Mathf.Clamp (n , 0 , Game_P.Max_HP);
		
		HP = n;
		PalyUI.UI.HP_Bar.End_F = (float)HP / Game_P.Max_HP;
	}
//===============================================================================
	public void SpBox () {
		PalyUI.UI.BoxStart.OpenBox ();
	}

	public bool Eat_Box () {
		int _BoxN = BoxN;
		if (LV >= _BoxN) {
			if (_BoxN >= 3) return false;

			int n = BoxDice.GetAInt ();
			Set_Box (true, n);
		} else {
			print ("拿不動了");
			return false;
		}

		return true;
	}
	public bool Set_Box (bool b, int n) {
		BoxDice.AllInt [n] = b ? 0 : 1;
		if (Box [n] != b) {
			Box [n] = b;
			PalyUI.UI.BoxEnd.OnOffObj (n, b);
			return true;
		} else {
			return false;
		}
	}

	public void Lose_Box (string Nob) {
		int _Nob = "ABC".IndexOf (Nob);
		if (_Nob < 0)print ("你搬哪去了?");
		if (Set_Box (false, _Nob)) {
			Sceore += 5;
		}
		// Set_Box (false, _Nob);

	}
//===============================================================================
	public void Eat_LvUp (int n) {
		// print (LV);
		SourceCon.Play ("LvUp");
		SetTime (Time + Game_P.Time_Up [LV]);
		LV = n;
	}
}
