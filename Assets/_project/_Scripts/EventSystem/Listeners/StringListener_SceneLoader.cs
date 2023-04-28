using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StringListener_SceneLoader : StringEventListener
{
	public override void OnEventRaised(object eventData)
	{
		string sceneName = (string)eventData;
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
	}
}
