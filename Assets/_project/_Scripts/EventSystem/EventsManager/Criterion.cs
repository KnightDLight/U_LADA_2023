using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Criterion", menuName = "Events/Create New Criterion")]
public class Criterion : ScriptableObject
{
    [SerializeField]
    Fact _factToCheck;
    [SerializeField]
    Operations _operation;
    [SerializeField]
    int _referenceValue;
    public bool PassesValue()
	{
		bool	result;
		int		valueToCheck;

		result = false;
		valueToCheck = _factToCheck.Value;
		switch (_operation)
		{
			case Operations.equals:
				result = valueToCheck == _referenceValue;
				break;
			case Operations.lessThan:
				result = valueToCheck < _referenceValue;
				break;
			case Operations.greaterThan:
				result = valueToCheck > _referenceValue;
				break;
			case Operations.differentThan:
				result = valueToCheck != _referenceValue;
				break;
		}
		return result;
	}
}
public enum Operations
{
    equals,
    lessThan,
    greaterThan,
    differentThan
}
