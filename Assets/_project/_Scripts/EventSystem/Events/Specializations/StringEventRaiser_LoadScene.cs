using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StringEventRaiser_LoadScene : MonoBehaviour
{
	[SerializeField]
	StringEvent _loadSceneEvent;
	[SerializeField]
	string _sceneName;

	public void Raise()
	{
		_loadSceneEvent.SetString(_sceneName);
		_loadSceneEvent.Raise();
	}
}
