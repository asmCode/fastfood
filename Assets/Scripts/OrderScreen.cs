using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderScreen : MonoBehaviour
{
    public Text m_totalRewardLabel;

    private void Update()
    {
        m_totalRewardLabel.text = string.Format("TOTAL REWARD: ${0:0.00}", GameState.Get().Currency);
    }
}
