using System.Collections;
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

    public void Move(Transform moveObject, Transform parent, Vector3 localPosition, System.Action<Move> moveCompleted = null)
    {
        var m = m_moves.Find((t) =>
        {
            return t.MovingObject == moveObject;
        });
        if (m != null)
            m_moves.Remove(m);

        moveObject.SetParent(parent, true);

        var move = new Move(localPosition, Quaternion.identity, moveObject, moveCompleted);
        m_moves.Add(move);
    }

    public void Move(Transform moveObject, Transform parent, System.Action<Move> moveCompleted = null)
    {
        Move(moveObject, parent, Vector3.zero, moveCompleted);
    }

    private void Update()
    {
        foreach (var move in m_moves)
        {
            move.Update();
            if (move.Finished)
                move.NotifyMoveFinished();
        }

        m_moves.RemoveAll((t) =>
        {
            return t.Finished;
        });

        m_movesCount = m_moves.Count;
    }
}
