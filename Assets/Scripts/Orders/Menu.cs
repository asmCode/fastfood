using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    private static Menu m_instance;
    private List<OrderElement> m_drinks = new List<OrderElement>();
    private List<OrderElement> m_burgers = new List<OrderElement>();

    public static Menu Get()
    {
        if (m_instance == null)
        {
            m_instance = new Menu();
            m_instance.Initialize();
        }

        return m_instance;
    }

    private static System.Random random = new System.Random();

    public Order GetRandomOrder()
    {
        var order = new Order(Id.NextId());

        var randomDrink = m_drinks[random.Next(0, m_drinks.Count)];
        order.OrderElements.Add(randomDrink);

        var randomBurger = m_burgers[random.Next(0, m_burgers.Count)];
        order.OrderElements.Add(randomBurger);

        return order;
    }

    private void Initialize()
    {
        var coke = new OrderElement("Coke", 2.49f, 20.0f);
        coke.Add(ProductType.Cup);
        coke.Add(ProductType.Ice);
        coke.Add(ProductType.Coke);
        coke.Add(ProductType.Lid);
        coke.Add(ProductType.Straw);
        m_drinks.Add(coke);

        var cokeNoIce = coke.Clone();
        cokeNoIce.Remove(ProductType.Ice);
        m_drinks.Add(cokeNoIce);

        var orangeJuice = new OrderElement("Orange Juice", 1.49f, 20.0f);
        orangeJuice.Add(ProductType.Cup);
        orangeJuice.Add(ProductType.Ice);
        orangeJuice.Add(ProductType.OrangeJuice);
        orangeJuice.Add(ProductType.Lid);
        orangeJuice.Add(ProductType.Straw);
        m_drinks.Add(orangeJuice);

        var orangeJuiceNoIce = orangeJuice.Clone();
        orangeJuiceNoIce.Time -= 2.0f;
        orangeJuiceNoIce.Name += " (No Ice)";
        orangeJuiceNoIce.Remove(ProductType.Ice);
        m_drinks.Add(orangeJuiceNoIce);

        // Burgers
        var burger = new OrderElement("Burger", 4.99f, 40.0f);
        burger.Add(ProductType.BurgerBox);
        burger.Add(ProductType.BanBottom);
        burger.Add(ProductType.BeefFried);
        burger.Add(ProductType.Ketchup);
        burger.Add(ProductType.BanTop);
        m_burgers.Add(burger);

        var cheeseburger = new OrderElement("Cheeseburger", 5.49f, 50.0f);
        cheeseburger.Add(ProductType.BurgerBox);
        cheeseburger.Add(ProductType.BanBottom);
        cheeseburger.Add(ProductType.BeefFried);
        cheeseburger.Add(ProductType.Cheese);
        cheeseburger.Add(ProductType.Ketchup);
        cheeseburger.Add(ProductType.BanTop);
        m_burgers.Add(cheeseburger);

        var doubleCheeseburger = new OrderElement("Double Cheeseburger", 8.99f, 60.0f);
        doubleCheeseburger.Add(ProductType.BurgerBox);
        doubleCheeseburger.Add(ProductType.BanBottom);
        doubleCheeseburger.Add(ProductType.BeefFried);
        doubleCheeseburger.Add(ProductType.Cheese);
        doubleCheeseburger.Add(ProductType.BeefFried);
        doubleCheeseburger.Add(ProductType.Cheese);
        doubleCheeseburger.Add(ProductType.Ketchup);
        doubleCheeseburger.Add(ProductType.BanTop);
        m_burgers.Add(doubleCheeseburger);
    }
}
