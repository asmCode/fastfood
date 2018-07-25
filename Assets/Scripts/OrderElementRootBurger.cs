using UnityEngine;

public class OrderElementRootBurger : OrderElementRoot
{
    public override OrderElement GetOrderElement()
    {
        var burger = GetComponent<Burger>();
        if (burger == null)
            return null;

        return burger.GetOrderElement();
    }
}
