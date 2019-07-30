using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MyCalculate : MonoBehaviour {
	
	static public Vector2 GetTuchV2 (Camera Cam) {//取得滑鼠點擊場景的座標
		Vector2 r = Cam.ScreenToWorldPoint (Input.mousePosition);
		return r;
	}

	/// <summary>
	/// 生產物件
	/// </summary>
	static public GameObject SpObj (GameObject obj,Transform parent,Vector3 Position,string objName = "") {//生產物件（太常用了乾脆這邊弄一個）
		GameObject a = Instantiate (obj);
		a.transform.SetParent (parent);
		a.transform.localPosition = Position;
		a.transform.localScale = obj.transform.localScale;
		if (objName != "") a.name = objName;
		return a;
	}

	/// <summary>
	/// gamesalad的那種％ (a%b)
	/// </summary>
	/// <returns>The mod.</returns>
	static public int SaladModInt (int a, int b) {
		if (a >= 0) {
			return a%b;
		}else{
			return (b+a%b)%b;
		}
	}

	/// <summary>
	/// gamesalad的那種％ (a%b)
	/// </summary>
	/// <returns>The mod.</returns>
	static public float SaladMod(float a,int b){
		if (a >= 0) {
			return a%b;
		}else{
			return (b+a%b)%b;
		}
	}

	static public Vector2 CosSin(float m,float r){
		return new Vector2 (Mathf.Cos(r*Mathf.Deg2Rad),Mathf.Sin(r*Mathf.Deg2Rad))*m;
	}

	static public string[][] TxtToString(string a){//表格格式轉換
		string[][] Arr;
		
		//string[] c = a.Split ("\n"[0]);
		string [] c = _TxtToString(a);
		Arr = new string[c.Length][];
		for (int i=0; i<c.Length; i++) {
			Arr[i]=c[i].Split('	');
		}
		return Arr;
	}

	static public string[] _TxtToString(string a){
		bool b = false;
		int  j = 0;
		List<int> bb = new List<int>();

		bb.Add(j);
		for(int i=0;i<a.Length;i++){
			if(a[i]=='"'){b = !b;}
			else{
				if(!b&a[i]=="\n"[0]){
					bb.Add(j+1);
				}
				j++;
			}
		}

//		print (a);
		a = a.Replace("\"","");
//		print (a);
//		print (bb[0]+"--"+bb[1]+"--"+bb[2]);
		string[] aa = new string[bb.Count];
		for(int i=0;i<aa.Length;i++){
//			print ("-----------------");
			int x = (i!=aa.Length-1) ? bb[i+1]-bb[i]-1:a.Length-bb[bb.Count-1];
//			print (bb[i]+"-"+x);
			aa[i] = a.Substring(bb[i],x);
//			print (aa[i]);
		}
		return aa;
	}

	static public string UTxtToString(string[][]alltext,char f='	'){
		string t = "";
		for (int i = 0 ;i < alltext.Length; i++) {
			for (int j = 0; j < alltext [i].Length; j++) {
				t += alltext [i] [j];
				if (j < alltext [i].Length - 1)
					t += f;
			}
			if (i < alltext.Length - 1)
				t += "\n"[0];
		}
		return t;
	}

	static public float[][] TxtToFloat(string a){
		float[][] Arr;
		
		string[] c = a.Split ("\n"[0]);
		Arr = new float [c.Length][];
		
		for (int i=0; i<c.Length; i++) {
			
			string[] d = c[i].Split('	');
			float[] _d = new float[d.Length];
			
			for(int j = 0;j<d.Length;j++){
				_d[j] = float.Parse(d[j]);
			}
			Arr[i] = _d;
		}
		return Arr;
	}

	static public string[][][] TxtToString(string[] a) {
		string[][][] Arr;
		Arr = new string[a.Length][][];
		for(int i=0;i<a.Length;i++){
			Arr[i]=TxtToString(a[i]);
		}
		return Arr;
	}

	static public string[][] RemoveRow(string[][] text ,int n ){
		return RemoveRow (UTxtToString (text), n);
	}

	static public string[][] RemoveRow(string text ,int n ){
		string[] texts = text.Split ("\n" [0]);
		text = "";
		for(int i = 0 ;i<texts.Length ;i++ ) {
			if (i != n) {
				text += texts [i]+"\n";
			}
		}
		if(text!="")
			text = text.Substring (0, text.Length - 1);
		return TxtToString (text);
	}
	
	static public string StringWelding(string[] Strings,string g){
		string r = Strings[0];
		for(int i = 1; i<Strings.Length;i++){
			r += g + Strings[i];
		}
		return r;
	}
	static public string NomberToString (int n) {
		string r = _NomberToString(n);
//		print ("r="+r);
		if (r.Substring(0,Mathf.Min(r.Length,2))=="一十"){
			return r.Substring(1);
		}else{
			return r;
		}
	}

	static string _NomberToString (int n) {
		string r;
		if (n<10) {
			string b = "零一二三四五六七八九十";
			r = n==0? "" : ""+b[n];
		}else if (n<100) {
			r = _NomberToString(n/10)+"十"+_NomberToString(n%10);
		}else if (n<1000) {
			r = _NomberToString(n/100)+"百"+_NomberToString(n%100);
		}else if (n<10000) {
			r = _NomberToString(n/1000)+"千"+_NomberToString(n%1000);
		}else if (n<100000000) {
			r = _NomberToString(n/10000)+"萬"+_NomberToString(n%10000);
		}else {
			r = _NomberToString(n/100000000)+"億"+_NomberToString(n%100000000);
		}

		return r;
	}	
}
