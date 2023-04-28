using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartGameHandler : VoidEventListener
{
	[SerializeField]
	Fact _isNewGame;
	[SerializeField]
	GameObject _videoPlayerPrefab;
	[SerializeField]
	int _startOfGameSceneIndex;
	[SerializeField]
	int _sceneToUnLoad;

	GameObject _instantiatedVideoPlayer = null;
	public override void OnEventRaised(object eventData)
	{
		if (_instantiatedVideoPlayer != null)
			Destroy(_instantiatedVideoPlayer);
		_instantiatedVideoPlayer = null;
		if (_isNewGame.Value == 1)
		{
			_instantiatedVideoPlayer = Instantiate(_videoPlayerPrefab);
			StartCoroutine(WaitForVideoAndLoadFirstScene());
		}
	}
	private IEnumerator WaitForVideoAndLoadFirstScene()
	{
		var videoLoader = _instantiatedVideoPlayer.GetComponent<VideoPlayer>();
		yield return null;
		while (videoLoader.isPlaying)
		{
			yield return null;
		}
		LoadScene(_startOfGameSceneIndex);
	}

	private void LoadScene(int index)
	{
		SceneManager.LoadScene(index, LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync(_sceneToUnLoad);
	}
}
