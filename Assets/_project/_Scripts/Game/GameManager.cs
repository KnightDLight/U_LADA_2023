using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    BaseEvent _gameStartedEvent;

    private void Start()
    {
        _gameStartedEvent.Raise();
    }
}