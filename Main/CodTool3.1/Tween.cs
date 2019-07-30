using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour {
	public enum Tween_Type {One, Loop, Pingpong}
	public Tween_Type Type;

	public AnimationCurve animationCurve;
	public Void_FloatDel Del;
	public VoidDel End_Del;
	public float Time_Length = 10;
	public float f {
		get {
			return _f;
		}
		set {
			_f = Mathf.Clamp (value, 0, 1);
		}
	}
	public float _f;

	public int Mod;//-1:顛倒播 0:停止 1:正常播

	[ContextMenu ("On")]
	public void On () {
		Play (true);
	}
	[ContextMenu ("Off")]
	public void Off () {
		Play (false);
	}
	public IEnumerator IE_Play (bool b, float Delay = 0) {
		if (Type != Tween_Type.One) {
			print ("這個方法只給One用");
			yield break;
		} 
		Play (b, Delay);

		for (;;) {
			yield return null;
			if (Mod == 0) {
				yield break;
			}
		}
	}
	public void Play (bool b, float Delay = 0) {
		if (Mod == 0) {
			Start_Time = Time.time + Delay;
			f = b ? 0 : 1;
		}
		Mod = b ? 1 : -1;
		enabled = true;
	}

	public void SetF (float f) {
		this.f = f;
		if (Del != null) Del (animationCurve.Evaluate (f));
	}

	float Start_Time = 0;
	public virtual void Update () {
		if (Mod == 0) {
			enabled = false;
			return;
		}
		if (Start_Time > Time.time) {
			return;
		}
		switch (Type) {
			case Tween_Type.One :
				Update_One ();
				break;
			case Tween_Type.Loop :
				Update_Loop ();
				break;
			case Tween_Type.Pingpong :
				Update_Pingpong ();
				break;
			default :
				break;
		}
		if (Del != null) Del (animationCurve.Evaluate (f));
		
		if (Mod == 0) {
			if (End_Del != null) End_Del ();
		}
	}

	public void Update_One () {
		if (Mod > 0) {
			f += Time.deltaTime / Time_Length;
			if (f >= 1) Mod = 0;
		} else if (Mod < 0) {
			f -= Time.deltaTime / Time_Length;
			if (f <= 0) Mod = 0;
		}
	}
	public void Update_Loop () {
		if (Mod > 0) {
			f = (f + Time.deltaTime / Time_Length) % 1;
		} else if (Mod < 0) {
			f = (f - Time.deltaTime / Time_Length + 1) % 1;
		}
	}
	public void Update_Pingpong () {
		if (Mod > 0) {
			f += Time.deltaTime / Time_Length;
			if (f >= 1) Mod = -1;
		} else if (Mod < 0) {
			f -= Time.deltaTime / Time_Length;
			if (f <= 0) Mod = 1;
		}
	}
}
