using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorStateController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Cursor locked here : " + transform.name);
    }

}
