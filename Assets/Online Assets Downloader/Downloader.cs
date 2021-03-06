﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Downloader : MonoBehaviour {

	public string URL;

	// Use this for initialization
	void Start () {
		StartCoroutine (Download());
	}
	
	// Update is called once per frame
	IEnumerator Download()
	{
		// Link to url from where to download data
		WWW www = new WWW (URL);
		//Checking if still downloading
		while (!www.isDone)
		{
			//logging the progress 
			Debug.Log ("Downloading Assets" + www.progress);
			yield return null;
		}

		//Getting the asset bundle from downloaded data
		AssetBundle AB = www.assetBundle;
		if (AB != null) {
			//Checking if Loaded data has some values
			//Load Objects here
			GameObject GO = AB.LoadAsset("Bit Gun") as GameObject;
			Instantiate (GO);
		} else 
		{
			Debug.Log ("Asset Does Not Found");
		}
		yield return null;
	}
}
