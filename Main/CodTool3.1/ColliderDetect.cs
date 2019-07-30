using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColliderDetect : MonoBehaviour {
	//碰撞點偵測器 只要碰撞點進入另一個碰撞點 就會把它納入AllCollider中
	public List<Collider2D> AllCollider = new List<Collider2D> ();
	public Collider2D  LastCollider {
		get {
			if (AllCollider.Count > 0) {
				return AllCollider [AllCollider.Count - 1];
			} else {
				return null;
			}
		}
	}

	public string ToTag;

	public Void_GameObject EnterDel;
	public Void_GameObject ExitDel;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (EnterDel != null) EnterDel (other.gameObject);
		if (other.tag == ToTag || string.IsNullOrEmpty (ToTag)) {
			AllCollider.Add (other);
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (ExitDel != null) ExitDel (other.gameObject);
		AllCollider.Remove (other);
	}

	//把狀態回到初始值
	public void Reset (string tag = "null") {
		AllCollider = new List<Collider2D> ();
		if (tag != "null") {
			ToTag = tag;
		}
	}

	//收尋某物件是否在清單內
	public bool FindObj (GameObject Obj) {
		foreach (Collider2D i in AllCollider) {
			if (i.gameObject == Obj) {
				return true;
			}
		}
		return false;
	}
}