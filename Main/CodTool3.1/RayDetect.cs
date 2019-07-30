using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class RayDetect : MonoBehaviour {//放出一條射從f出發指導碰到阻擋點若碰到阻擋點的tag是指定的就啟動

	public UnityEvent StartEvent;
	public UnityEvent ExitEvent;
	public UnityEvent UpdateEvent;
	
	public string ToTag;

	public GameObject f;
	public Vector2 direction = Vector2.left;

	public bool Open {
		get {
			return _Open;
		}
		set {
			if (value == _Open) {
				if (value) {
					StartEvent.Invoke ();
				} else {
					ExitEvent.Invoke ();
				}
				UpdateEvent.Invoke ();
			}
		}
	}
	public bool _Open;
	public float Leng;

	void FixedUpdate ()
	{
		RaycastHit2D Hit = Physics2D.Raycast (f.transform.position, direction);
		if (Hit.collider != null && Hit.collider.tag == ToTag) {
			Open = true;
			Leng = Hit.fraction/transform.lossyScale.x;
		} else {
			Open = false;
		}
	}
}
