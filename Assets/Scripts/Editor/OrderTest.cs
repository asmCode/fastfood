using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class OrderTest
{
    [Test]
    public void SingleOrder()
    {
        Order order1 = new Order(0);
        Order order2 = new Order(0);

        Assert.That(Order.Compare(order1, order2));
        Assert.That(Order.Compare(order2, order1));

        var orderElement1 = new OrderElement("order1", 1.0f, 1.0f);
        order1.OrderElements.Add(orderElement1);

        var orderElement2 = new OrderElement("order2", 1.0f, 1.0f);
        order2.OrderElements.Add(orderElement2);

        Assert.That(Order.Compare(order1, order2));
        Assert.That(Order.Compare(order2, order1));

        // order1 = IceTea
        // order2 = 
        orderElement1.Add(ProductType.IceTea);
        Assert.That(!Order.Compare(order1, order2));

        // order1 = IceTea
        // order2 = BeefRaw
        orderElement2.Add(ProductType.BeefRaw);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        // order1 = IceTea, BeefRaw
        // order2 = BeefRaw
        orderElement1.Add(ProductType.BeefRaw);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        // order1 = IceTea, BeefRaw
        // order2 = BeefRaw, IceTea
        orderElement2.Add(ProductType.IceTea);
        Assert.That(Order.Compare(order1, order2));
        Assert.That(Order.Compare(order2, order1));

        // order1 = IceTea, BeefRaw, BeefRaw
        // order2 = BeefRaw, IceTea, BeefRaw
        orderElement1.Add(ProductType.BeefRaw);
        orderElement2.Add(ProductType.BeefRaw);
        Assert.That(Order.Compare(order1, order2));
        Assert.That(Order.Compare(order2, order1));

        // order1 = IceTea, BeefRaw, BeefRaw
        // order2 = BeefRaw, IceTea, BeefRaw, BeefRaw
        orderElement2.Add(ProductType.BeefRaw);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));
    }

    [Test]
    public void ElementsInOrder()
    {
        Order order1 = new Order(0);
        Order order2 = new Order(0);

        order1.OrderElements.Add(new OrderElement("element1", 1.0f, 1.0f));
        order1.OrderElements.Add(new OrderElement("element2", 1.0f, 1.0f));
        order2.OrderElements.Add(new OrderElement("element3", 1.0f, 1.0f));

        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        order1.OrderElements[0].Add(ProductType.IceTea);
        order1.OrderElements[1].Add(ProductType.BeefFried);
        order1.OrderElements[1].Add(ProductType.BanBottom);
        order1.OrderElements[1].Add(ProductType.BanBottom);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        order2.OrderElements[0].Add(ProductType.BanBottom);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        order2.OrderElements[0].Add(ProductType.BanBottom);
        order2.OrderElements[0].Add(ProductType.BeefFried);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        order2.OrderElements.Add(new OrderElement("element4", 1.0f, 1.0f));
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));

        order2.OrderElements[1].Add(ProductType.IceTea);
        Assert.That(Order.Compare(order1, order2));
        Assert.That(Order.Compare(order2, order1));

        order2.OrderElements[1].Add(ProductType.IceTea);
        Assert.That(!Order.Compare(order1, order2));
        Assert.That(!Order.Compare(order2, order1));
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator OrderTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
