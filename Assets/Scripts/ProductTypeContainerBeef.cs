using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductTypeContainerBeef : ProductTypeContainerBase
{
    public override ProductType GetProductType()
    {
        var beef = GetComponent<Beef>();
        return beef.BeefType == BeefType.Raw ? ProductType.BeefRaw : ProductType.BeefFried;
    }
}
