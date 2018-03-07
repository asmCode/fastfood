using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableInteractiveElement : BaseInteractiveElement
{
    public override void DoAction()
    {
        Cook.Get().GrabRightHand(gameObject);
    }
}
