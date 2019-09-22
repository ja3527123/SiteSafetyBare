using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceCon : ObjArray {
	static public SourceCon _;

	void Awake () {
		_ = this;
		
	}

	static public void Play (string Name, float Volume = 1, float Pitch = 1) {
		foreach (Obj i in _.AllObj) {
			if (i.obj.name == Name) {
				AudioSource AS = i.obj.GetComponent <AudioSource> ();
				AS.enabled = true;
				AS.volume = Volume;
				AS.pitch = Pitch;
				AS.Play ();
				return;
			}
		}
	}
	static public void SetSource (string Name, float Volume = 1, float Pitch = 1) {
		foreach (Obj i in _.AllObj) {
			if (i.obj.name == Name) {
				AudioSource AS = i.obj.GetComponent <AudioSource> ();
				AS.enabled = true;
				AS.volume = Volume;
				AS.pitch = Pitch;
				return;
			}
		}
	}
}
