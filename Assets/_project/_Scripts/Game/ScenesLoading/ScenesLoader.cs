using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : StringEventListener
{
	public override void OnEventRaised(object eventData)
	{
		LoadSceneAdditive(eventData.ToString());
	}

	private void LoadSceneAdditive(string sceneName)
	{
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);	
	}
}