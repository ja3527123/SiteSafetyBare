using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileCon : MonoBehaviour {
	/// <summary>
	/// 路徑中是否有此檔案
	/// </summary>
	static public bool FileExists (string URL) {
		return File.Exists (URL);
	}
	/// <summary>
	/// 路徑中是否有此資料夾
	/// </summary>
	static public bool DirectoryExists (string URL) {
		return Directory.Exists (URL);
	}
	/// <summary>
	/// 取得路徑中所有的檔案名稱（含路徑）
	/// </summary>
	static public string [] GetFiles (string URL) {
		return Directory.GetFiles (URL);
	}
	/// <summary>
	/// 取得路徑中所有的資料夾名稱（含路徑）
	/// </summary>
	static public string [] GetDirectorys (string URL) {
		return Directory.GetDirectories (URL);
	}
	/// <summary>
	/// 把Form資料夾的所有內容複製到To資料夾中
	/// </summary>
	static public void CopyDirectory (string FormURL, string ToURL) {
		Directory.CreateDirectory (ToURL);
		string[] Files = GetFiles (FormURL);
		foreach (string i in Files) {
			File.Copy (i, ToURL + "/" + PathName (i));
		}
		string[] Directorys = GetDirectorys (FormURL);
		foreach (string i in Directorys) {
			CopyDirectory (i, ToURL + "/" + PathName (i));
		}
	}
	/// <summary>
	/// 把路徑分段
	/// </summary>
	static public string [] Get_Path (string FromPath) {
		return FromPath.Split ('\\', '/');
	}
	/// <summary>
	/// 擷取路徑中的檔名（或資料夾名）
	/// </summary>
	static public string PathName (string FormPath) {
		string [] _Path = Get_Path (FormPath);
		return _Path [_Path.Length - 1];
	}
}
