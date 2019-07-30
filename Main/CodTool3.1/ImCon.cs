using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImCon : MonoBehaviour {
	//這個腳本專本控制2D圖片的融合或是增加某個顏色

	public Texture2D TestIm_0;
	public Texture2D TestIm_1;

	public Texture2D TestIm_2;

	[ContextMenu ("test")]
	public void Test () {
	// 	// TestIm_0 = GetColorIm (new Color (0, 0, 1, 1), new Vector2Int (500, 500));
	// 	// TestIm_0.Apply ();
	// 	// TestIm_1 = GetColorIm (new Color (1, 1, 1, 1), new Vector2Int (50, 50));
	// 	// TestIm_1.Apply ();
	// 	// return;
	// 	TestIm_2 = MaskIm (TestIm_0, TestIm_1, new RectInt (0, 0, 453, 349));
	// 	TestIm_2.Apply ();
		TestIm_2 = AddIm (TestIm_0, TestIm_1, new RectInt (0, 0, TestIm_0.width, TestIm_0.height));
		TestIm_2.Apply ();
		SaveIm (TestIm_2,Application.dataPath,"aaa");
	}

	/// <summary>
	/// 取得一個純色的圖片
	/// </summary>
	static public Texture2D GetColorIm (Color Color, Vector2Int Size) {
		Texture2D r = new Texture2D (Size.x, Size.y);
		for (int x = 0; x < Size.x; x++) {
			for (int y = 0; y < Size.y; y++) {
				r.SetPixel (x, y, Color);
			}
		}
		return r;
	}

	/// <summary>
	/// 改變圖片大小
	/// </summary>
	static public Texture2D SetImSize (Texture2D Im, Vector2Int Size) {
		if (Size.x == Im.width && Size.y == Im.height) return Im;
		Texture2D r = new Texture2D (Mathf.Abs (Size.x), Mathf.Abs (Size.y));

		List <int> Xs = new List<int> ();
		List <int> Ys = new List<int> ();
		if (Im.width != Size.x) {
			for (int x = 0; x < r.width;  x++) Xs.Add (Mathf.RoundToInt (x * ((float)Im.width  / r.width )));
		} else {
			for (int x = 0; x < r.width;  x++) Xs.Add (x);
		}
		if (Size.x < 0) Xs.Reverse ();

		if (Im.height != Size.y) {
			for (int y = 0; y < r.height; y++) Ys.Add (Mathf.RoundToInt (y * ((float)Im.height / r.height)));
		} else {
			for (int y = 0; y < r.height; y++) Ys.Add (y);
		}
		if (Size.y < 0) Ys.Reverse ();

		for (int x = 0; x < r.width; x++) {
			int _x = Xs [x];
			for (int y = 0; y < r.height; y++) {
				int _y = Ys [y];
				r.SetPixel (x, y, Im.GetPixel (_x, _y));
			}
		}
		return r;
	}

	/// <summary>
	/// 在Im上面貼上AddIm 能使用AddRect控制AddIm的尺寸跟位置
	/// </summary>
	static public Texture2D AddIm (Texture2D Im, Texture2D AddIm, RectInt AddRect) {
		AddIm = SetImSize (AddIm, new Vector2Int (AddRect.width, AddRect.height));
		AddRect.x += (Im.width -  AddIm.width ) / 2;
		AddRect.y += (Im.height - AddIm.height) / 2;

		Texture2D r = new Texture2D (Im.width, Im.height);
		for (int x = 0; x < Im.width; x++) {
			int _x = x - AddRect.x;
			for (int y = 0; y < Im.height; y++) {
				int _y = y - AddRect.y;
				if (_x < 0 || 
					_x >= AddIm.width ||
					_y < 0 ||
					_y >= AddIm.height
				) {
					r.SetPixel (x, y, Im.GetPixel (x, y));
				} else {
					Color ImC = Im.GetPixel (x, y);
					Color AddC = AddIm.GetPixel (_x, _y);
					Color RC = Color.Lerp (ImC, AddC, AddC.a);//這一格會是什麼顏色
					RC.a = ImC.a + AddC.a;
					r.SetPixel (x, y, RC);
				}
				
			}	
		}
		return r;
	}

	/// <summary>
	/// 在Im上創造一個Mask形狀的遮罩 能使用MaskRect控制MaskIm的尺寸跟位置
	/// </summary>
	static public Texture2D MaskIm (Texture2D Im, Texture2D MaskIm, RectInt MaskRect) {
		MaskIm = SetImSize (MaskIm, new Vector2Int (MaskIm.width, MaskIm.height));
		MaskRect.x += (Im.width -  MaskIm.width ) / 2;
		MaskRect.y += (Im.height - MaskIm.height) / 2;
		Texture2D r = new Texture2D (MaskIm.width, MaskIm.height);
		for (int x = 0; x < r.width; x++) {
			int _x = x + MaskRect.x;
			for (int y = 0; y < r.height; y++) {
				int _y = y + MaskRect.y;
				Color MaskC = MaskIm.GetPixel (x, y);
				if (
					MaskC.a <= 0 ||
					_x < 0 ||
					_x >= Im.width ||
					_y < 0 ||
					_y >= Im.width
				) {
					r.SetPixel (x, y, new Color (0, 0, 0, 0));
				} else {
					Color RC = Im.GetPixel (_x, _y);
					r.SetPixel (x, y, Color.Lerp (new Color (0,0,0,0), RC, MaskC.a));
				}
			}
		}
		return r;
	}

	/// <summary>
	/// 裁切Im 能使用MaskRect控制裁切的尺寸跟位置
	/// </summary>
	static public Texture2D MaskIm (Texture2D Im, RectInt MaskRect) {
		MaskRect.x += (Im.width -  MaskRect.width ) / 2;
		MaskRect.y += (Im.height - MaskRect.height) / 2;

		Texture2D r = new Texture2D (MaskRect.width, MaskRect.height);

		for (int x = 0; x < MaskRect.width; x++) {
			int _x = x + MaskRect.x;
			for (int y = 0; y < MaskRect.height; y++) {
				int _y = y + MaskRect.y;

				if (_x >= 0 && _x < Im.width && _y >= 0 && _y < Im.height) {
					r.SetPixel (x, y, Im.GetPixel (_x, _y));
				} else {
					r.SetPixel (x, y, new Color (0,0,0,0));
				}
			}
		}
		return r;
	}

	/// <summary>
	/// 把圖片賦予顏色
	/// </summary>
	static public Texture2D AddColor (Texture2D Im, Color color){
		Texture2D r = new Texture2D(Im.width,Im.height);
		for(int i = 0; i<r.width; i++){
			for(int j = 0; j<r.height; j++){
				Color c = Im.GetPixel(i,j);
				r.SetPixel(i, j, c * color);
			}
		}
		return r;
	}

	/// <summary>
	/// 將兩張圖片融合
	/// </summary>
	static public Texture2D CombineIm (Texture2D Im, Texture2D CombineIm, RectInt CombineRect) {
		CombineIm = SetImSize (CombineIm, new Vector2Int (CombineRect.width, CombineRect.height));
		CombineRect.x += (Im.width -  CombineRect.width ) / 2;
		CombineRect.y += (Im.height - CombineRect.height) / 2;
		Texture2D r = new Texture2D (Im.width, Im.height);

		for (int x = 0; x < Im.width; x++) {
			int _x = x - CombineRect.x;
			for (int y = 0; y < Im.height; y++) {
				int _y = y - CombineRect.y;
				if (
					_x < 0 ||
					_x >= CombineIm.width ||
					_y < 0 ||
					_y >= CombineIm.height
				) {
					r.SetPixel (x, y, Im.GetPixel (x, y));
				} else {
					Color ImColor = Im.GetPixel (x, y);
					Color CombineColor = CombineIm.GetPixel (_x, _y);
					r.SetPixel (x, y, ImColor * CombineColor);
				}
			}
		}
		return r;
	}

	/// <summary>
	/// Texture2D轉換成Sprite
	/// </summary>
	static public Sprite Texture2DToSprite (Texture2D t) {
		Sprite r = Sprite.Create (t, new Rect (0, 0, t.width, t.height), Vector2.zero);
		return r;
	}

	/// <summary>
	/// 圖片轉換成base64
	/// </summary>
	static public string Texture2DToBase64 (Texture2D Im) {
		byte [] b;
		if(Im != null) {
			b = Im.EncodeToJPG ();
		} else {
			b = new Texture2D (64, 64).EncodeToJPG ();
		}
		return Convert.ToBase64String (b);
	}
	/// <summary>
	/// Base64轉換成圖片
	/// </summary>
	static public Texture2D Base64ToTexture2D (string Base64){
		byte [] imb = Convert.FromBase64String (Base64);
		Texture2D r = new Texture2D (1, 1);
		r.LoadImage (imb);
		return r;
	}

	/// <summary>
	/// 把圖片存成.jpg到系統的某個地方
	/// </summary>
	static public void SaveIm (Texture2D Im, string Path, string FileName) {
		byte[] bytes = Im.EncodeToJPG ();  
    	System.IO.File.WriteAllBytes(Path + "/" + FileName + ".jpg", bytes);
	}
}
