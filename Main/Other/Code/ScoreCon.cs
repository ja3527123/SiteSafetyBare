using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCon : MonoBehaviour {
	public string Key;

	[Serializable]
	public class JsonData {
		public List <float> Players;
	}
	public JsonData Data;

	public float Score;

	public enum _Order {Max_Min,Min_Max};
	public _Order Order;

	[ContextMenu ("LoadData")]
	public void LoadData () {
		string JsonString = PlayerPrefs.GetString (Key, "");
		// print ("讀取:" + JsonString);
		// print ("Key:" + Key);
		if (JsonString != "") {
			Data = JsonUtility.FromJson <JsonData> (JsonString);
		}
	}

	[ContextMenu ("SaveData")]
	public void SaveData () {
		string JsonString = JsonUtility.ToJson (Data);
		// print ("儲存:" + JsonString);
		// print ("Key:" + Key);
		PlayerPrefs.SetString (Key, JsonString);
	}

	[ContextMenu ("SetOredr")]
	public int SetOrder () {
		int  n = SetOrder (Score);
		// print (n);
		return n;
	}
	public int SetOrder (float Score) {
		for (int i = 0; i < Data.Players.Count; i++) {
			if (Score > Data.Players [i]) {
				Data.Players.Insert (i , Score);
				return i;
			}
		}
		Data.Players.Add (Score);
		return Data.Players.Count - 1;
	}

	public float [] SetOrder_Text () {
		int n = SetOrder ();
		// print ("n =" + n);
		float f = n / (float)Data.Players.Count;
		// print ("f =" + f);
		if (Order == _Order.Max_Min) {
			f = (1f - f) * 100;
		} else {
			f = f * 100;
		}
		// print (n);
		n = (Data.Players.Count - 1) - n;
		float [] r = new float [3];
		r [0] = Score;
		r [1] = n;
		r [2] = f;
		return r;
		// return "您的成績是\"" + Score + "\"在" + Data.Players.Count + "個人中你贏過" + f.ToString ("0") + "%的人";
		// return f.ToString ("0.00");
	}

	[ContextMenu ("Delete")]
	public void Delete_Data () {
		PlayerPrefs.DeleteKey (Key);
	}
}
