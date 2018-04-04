﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int m_movesCount = 0;

    private static Mover m_instance;
    private List<Move> m_moves = new List<Move>();

    public static Mover Get()
    {
        if (m_instance == null)
            m_instance = GameObject.Find("Mover").GetComponent<Mover>();

        return m_instance;
    }

    public void Move(Transform moveObject, Transform parent, Vector3 localPosition)
    {
        moveObject.SetParent(parent, true);

        var move = new Move(localPosition, Quaternion.identity, moveObject);
        m_moves.Add(move);
    }

    public void Move(Transform moveObject, Transform parent)
    {
        Move(moveObject, parent, Vector3.zero);
    }

    private void Update()
    {
        foreach (var move in m_moves)
            move.Update();

        m_moves.RemoveAll((t) =>
        {
            return t.Finished;
        });

        m_movesCount = m_moves.Count;
    }
}