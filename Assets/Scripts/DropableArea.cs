using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableArea : BaseInteractiveElement
{
    public override void DoAction()
    {
        var cook = Cook.Get();

        if (cook.Inventory.IsRightHandFree && transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<BaseInteractiveElement>().DoAction();
        }
        else if (!cook.Inventory.IsRightHandFree && transform.childCount == 0)
        {
            var rightHandGameObject = cook.Inventory.RightHand;

            cook.DropRightHand();

            rightHandGameObject.transform.SetParent(transform);
            rightHandGameObject.transform.localPosition = Vector3.zero;
            rightHandGameObject.transform.localRotation = Quaternion.identity;
            rightHandGameObject.transform.localScale = Vector3.one;
        }
    }
}
