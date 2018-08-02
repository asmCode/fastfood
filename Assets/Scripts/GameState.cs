using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public float Currency
    {
        get;
        set;
    }

    private static GameState m_instance;

    public static GameState Get()
    {
        if (m_instance == null)
            m_instance = new GameState();

        return m_instance;
    }
}
