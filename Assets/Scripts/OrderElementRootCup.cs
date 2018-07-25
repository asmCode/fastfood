using UnityEngine;

public class OrderElementRootCup : OrderElementRoot
{
    public override OrderElement GetOrderElement()
    {
        var cup = GetComponent<Cup>();
        if (cup == null)
            return null;

        return cup.GetOrderElement();
    }
}
