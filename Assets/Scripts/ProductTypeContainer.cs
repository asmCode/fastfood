using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductTypeContainer : ProductTypeContainerBase
{
    public ProductType m_productType;

    public override ProductType GetProductType()
    {
        return m_productType;
    }
}
