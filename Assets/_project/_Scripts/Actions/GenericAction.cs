using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericAction : MonoBehaviour, IAction
{
	[SerializeField]
	protected ActionSO _actionData;
	public abstract void Do();
}
