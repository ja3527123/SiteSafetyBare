using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Photograph : MonoBehaviour {

	public Camera Ca;
	public Vector2Int ScreenSize;//場景的大小
	public int CaH = 1536;//攝影機的高度係數
	
	void Update () {
		//unity的攝影機機制很不人性而且只抓比例不抓大小 他會先以上下為基準 在調整寬度來變成合適的比例
		//所以在製作直板螢幕時很不直覺 首先要“利用攝影機縮放size的方式把上下邊對到想要的位置 而不是調整高度”
		
		Ca.orthographicSize = ((float)CaH / ScreenSize.y);//調整攝影機的size讓他的高度與高度係數一致
//		print (Screen.height);
		//Ca.pixelRect = new Rect (0,0, w, w);
	}

	public Texture2D GetCaIm(Rect rect ){
		float CaSize = Ca.orthographicSize;
		RenderTexture rt = new RenderTexture ((int)rect.width, (int)rect.height, 0);
		Ca.targetTexture = rt;
		Ca.Render ();

		RenderTexture.active = rt;
		Texture2D Re = new Texture2D ((int)(rect.width), (int)(rect.height), TextureFormat.RGB24, false);
		Re.ReadPixels (rect, 0, 0);
		//Re.ReadPixels (new Rect(testn,0,300,300), 0, 0);
		Re.Apply ();

		Ca.targetTexture = null;
		RenderTexture.active = null;
		GameObject.Destroy (rt);

		return Re;
	}
	//範例
	// public Rect TestRect;
	// public Texture2D TestTexture2D;
	// [ContextMenu ("test")]
	// public void TestGetCaIm () {
	// 	TestTexture2D = GetCaIm (TestRect);
	// }
}