using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Id
{
    private static int m_id = 1;

    public static int NextId()
    {
        int id = m_id;
        m_id++;
        return id;
    }
}
