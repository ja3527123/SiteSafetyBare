using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PauseCon : MonoBehaviour {//離開軟體時會啟動某些事件的腳本

	public UnityEvent OpenPause;
	public UnityEvent ClosePause;
	/// <summary>
	/// 只要此數值非“”那就不會啟動事件
	/// </summary>
	static public string Pass;
	
	void OnApplicationPause (bool isPause)
	{
		if (isPause) {
			Time.timeScale = 0;
			OpenPause.Invoke ();
		} else {
			if (Pass == "") {
				ClosePause.Invoke ();
			} else {
				Pass = "";
			}
			Time.timeScale = 1;
		}
	}
}
