using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetGoogleTab : MonoBehaviour {
	public string URL = "https://script.google.com/macros/s/AKfycbyZDoOsKbW173XDMb94zapHsOzPXn7JqhycxHKHjOJ7joUxb4w/exec";
	public string Id;
	public string TabName;

	[TextArea]
	public string StringDate = "100\n200\n50\n100";//當網路連線失敗時就會使用這個參數的預設值

//	public string[][] Date;
	public List<List<string>> mDate = new List<List<string>>();

	public IEnumerator GetTable ()
	{
		yield return StartCoroutine(GetTable(Id,TabName));
	}
	
	public IEnumerator GetTable (string Id, string TabName)
	{
		// TabName = WWW.EscapeURL (TabName);
		// WWW www = new WWW (URL + "?Id=" + Id + "&Name=" + TabName);
		// yield return www;

		// if (www.error == null) {//一切正常完全沒任何錯誤
		// 	StringDate = www.text;
		// }

		// string[] _mDate = StringDate.Split ("\"" [0]);
		// List<string> L0 = new List<string> ();
		// for (int i = 0; i < _mDate.Length; i++) {
		// 	if (_mDate [i] != "" && _mDate [i] != ",") {
		// 		if (_mDate [i] == "\n") {
		// 			mDate.Add(L0);
		// 			L0 = new List<string> ();
		// 		} else {
		// 			L0.Add(_mDate [i]);
		// 		}
		// 	}
		// }
		// mDate.Add(L0);

		yield return null;
	}
	

	[ContextMenu("print")]
	public void PrintTable ()
	{
		foreach (List<string> i in mDate) {
			foreach (string j in i) {
				print(j);
			}
			print("---------");
		}
	}
}
