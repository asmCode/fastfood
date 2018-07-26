using UnityEngine;

public class DrinkColor
{
    public static Color GetDrinkColor(ProductType productType)
    {
        Color color = Color.black;

        switch (productType)
        {
            case ProductType.OrangeJuice:
                color = new Color32(255, 165, 0, 1);
                break;

            case ProductType.IceTea:
                color = Color.yellow;
                break;

            case ProductType.Coke:
                color = Color.black;
                break;
        }

        return color;
    }
}
