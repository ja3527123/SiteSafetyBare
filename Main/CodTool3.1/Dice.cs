using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dice<T> : MonoBehaviour {
	//產生隨機數字的工具
	public int[] AllInt = new int[]{1,1,1,1,1};//骰子每一面的機率

	public T[] AllT;//骰子每一面的內容

	public int GetAInt () {//<核心>抽出一個編號
		return GetAInt(AllInt);
	}
	static public int GetAInt (int[] Ns) {
		int Max = 0;//取得機率陣列的總和也就是參數最大值
		foreach (int i in Ns) {
			Max += i;
		}

		int r = Random.Range (0, Max);//從最大值中抽一個數字
		for (int i = 0; i < Ns.Length; i++) {
			if (r < Ns [i]) {//抽到的值服合嗎
				return i;
			} else {
				r -= Ns[i];
			}
		}
		return -1;
	}

	public int [] GetAInts (int Size) {//抽出複數編號（會重複）
		int[] r = new int [Size];
		for (int i = 0; i < r.Length; i++) {
			r [i] = GetAInt ();
		}
		return r;
	}

	public T GetAT ()//取得一個內容
	{
		return GetAT (GetAInt ());
	}
	public T GetAT (int n) {
		return AllT [n % AllT.Length];
	}

	public T [] GetATs (int Size) {//取得複數Ｔ（會重複）
		return GetATs (GetAInts (Size));
	}
	
	public T [] GetATs (int[] Ints) {
		List<T> r = new List<T> ();
		for (int i = 0; i < Ints.Length; i++) {
			r.Add (GetAT (Ints [i]));
		}
		return r.ToArray ();
	}
	public T [] GetATs_NotRepeating () {
		return GetATs (GetNotRepeatingInts (AllInt.Length));
	}
	
	public int [] GetNotRepeatingInts (int Size) {//取得串不重複的結果陣列
		return GetNotRepeatingInts (Size, AllInt);
	}
	static public int [] GetNotRepeatingInts (int Size,int[] thisAllInt) {
		int[] r = new int[Size];
		for (int i = 0; i < Size; i++) {
			int n = GetAInt(thisAllInt);
			r[i] = n;
			thisAllInt [n] = 0;//把它歸零這樣下回合就不會抽到他了
		}
		return r;
	}

	public void ResetInt () {//讓所有結果發生機率平均
		AllInt = new int [AllT.Length];
		for (int i = 0; i < AllInt.Length; i++) {
			AllInt [i] = 1;
		}
	}

	public void GetIntsPrint (int n) {
		for (int i = 0; i < n; i++) {
			int o = GetAInt ();
			print (o + ":" + GetAT(o));
		}
	}

	[ContextMenu ("CreateAllint")]
	public void CreateAllint () {
		AllInt = new int[AllT.Length];
		for (int i = 0; i < AllInt.Length; i++) {
			AllInt [i] = 1;
		}
	}
}
