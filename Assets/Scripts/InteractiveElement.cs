using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveElement : BaseInteractiveElement
{
    public UnityEvent OnAction;

    public override void DoAction()
    {
        OnAction.Invoke();
    }
}
