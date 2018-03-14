using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBoxStackTop : ObjectStackTop
{
    public Transform m_stackTopPlaceholder;

    public override float GetWorldHeight()
    {
        return m_stackTopPlaceholder.position.y;
    }
}
