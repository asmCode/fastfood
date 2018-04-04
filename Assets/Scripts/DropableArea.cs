using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableArea : BaseInteractiveElement
{
    public override void DoAction()
    {
        var cook = Cook.Get();

        if (transform.childCount > 0)
        {
            var interactiveElement = transform.GetChild(0).GetComponent<BaseInteractiveElement>();
            if (interactiveElement != null)
                interactiveElement.DoAction();
        }
        else if (!cook.Inventory.IsRightHandFree && transform.childCount == 0)
        {
            var rightHandGameObject = cook.Inventory.RightHand;

            cook.DropRightHand(transform);
        }
    }
}
