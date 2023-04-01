using System.Collections;
using UnityEngine;

public class InteractionsHighLighter
{
	public void Highlight(GameObject target)
	{
		IInteractionHighLightEffect highLightEffect;

		highLightEffect = target.GetComponent<IInteractionHighLightEffect>();
		if (highLightEffect == null)
			return;
		highLightEffect.Activate();
	}
	public  void UnHighLight(GameObject target)
	{
		IInteractionHighLightEffect highLightEffect;

		highLightEffect = target.GetComponent<IInteractionHighLightEffect>();
		if (highLightEffect == null)
			return;
		highLightEffect.Deactivate();
	}
}