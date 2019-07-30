using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TxtCon : MonoBehaviour {//用來生成txt文件的腳本
	[System.Serializable]
	public struct PathObj {
		public string name;
		public string Path;
	}
	public PathObj [] PathObjs;

	public PathObj GetPath (string Pname) {
		foreach (PathObj i in PathObjs) {
			if (i.name == Pname) {
				return i;
			}
		}
		return new PathObj ();
	}

	//void Start () {
	//	print ("dataPath:"+Application.dataPath);
	//	print ("persistentDataPath:"+Application.persistentDataPath);
	//	print ("temporaryCachePath:"+Application.temporaryCachePath);
	//	print ("streamingAssetsPath:"+Application.streamingAssetsPath);
	//}
	
	public string GetTxt (PathObj HowPath) {//沒有檔名的話叫找資料夾中第一個看到的txt當目標
		if (!File.Exists (HowPath.Path)) {
			AddDirectory (HowPath);
		}
		foreach (string i in Directory.GetFiles (HowPath.Path)){
			if (i.EndsWith (".txt")) {
				return File.ReadAllText (i);
			}
		}
		return "";
	}
	public string GetTxt (string TxtName, PathObj HowPath) {
		print ("aaa");
		if (!File.Exists (HowPath.Path)) {
			AddDirectory (HowPath);
		}
		if (File.Exists (HowPath.Path + "/" + TxtName + ".txt")) {
			return File.ReadAllText (HowPath.Path + "/" + TxtName + ".txt");
		} else {
			return "";
		}
	}

	public void CreateTxt (string TxtName, string Text, PathObj HowPath){
		if (!File.Exists (HowPath.Path)){//資料夾是否存在
			AddDirectory (HowPath);
		}
		using (StreamWriter sw = File.CreateText (HowPath.Path + "/" + TxtName + ".txt")) {
			sw.WriteLine ("\"user\":" + Text);
		}
	}

	public void AddDirectory (PathObj HowPath) {//產生資料夾 如我資料夾已經存在不會傷害資料夾中的檔案
		Directory.CreateDirectory (HowPath.Path);
	}
	
	public void DeleteTxt (string TxtName,PathObj HowPath) {
		File.Delete (HowPath.Path + "/" + TxtName + ".txt");
	}
}
