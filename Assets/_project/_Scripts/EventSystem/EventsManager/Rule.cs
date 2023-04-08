using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : ScriptableObject
{
	[SerializeField]
	protected List<Criterion> _criterions;
	protected abstract void Execute(); 
	public virtual bool Passes()
	{
		bool result;

		result = true;
		foreach(Criterion crit in _criterions)
		{
			if (!crit.PassesValue())
			{
				result = false;
				break;
			}
		}
		return result;
	}
}