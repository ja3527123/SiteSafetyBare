using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_UserUI : MonoBehaviour {

	public ObjArray Sex;
	public GameObject Head;
	public GameObject Hand;
	public GameObject Foot;
	public GameObject Joint;
	public GameObject Body;

	public void SetIm (string ImName, bool b) {
		if (ImName == "Sex") {
			Sex.OnOnlyObjs (b ? 1 : 0);
		} else if (ImName == "Head") {
			Head.SetActive (b);
		} else if (ImName == "Hand") {
			Hand.SetActive (b);
		} else if (ImName == "Foot") {
			Foot.SetActive (b);
		} else if (ImName == "Joint") {
			Joint.SetActive (b);
		} else if (ImName == "Body") {
			Body.SetActive (b);
		}
	}
	public void SetIm (string ImName) {
		bool b;
		if (ImName == "Sex") {
			b = !Sex.AllObj [0].Open;
			Sex.OnOnlyObjs (b ? 1 : 0);
		} else if (ImName == "Head") {
			b = !Head.activeSelf;
			Head.SetActive (b);
		} else if (ImName == "Head") {
			b = !Hand.activeSelf;
			Hand.SetActive (b);
		} else if (ImName == "Foot") {
			b = !Foot.activeSelf;
			Foot.SetActive (b);
		} else if (ImName == "Joint") {
			b = !Joint.activeSelf;
			Joint.SetActive (b);
		} else if (ImName == "Body") {
			b = !Body.activeSelf;
			Body.SetActive (b);
		}
	}
}
