using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XOManager : MonoBehaviour
{
    [SerializeField] private Button[] m_Buttons;
    [SerializeField] private TextMeshProUGUI m_Player;

    private string m_Turn;
    private int m_CurrentTurn;
    private string[] m_Tiles;
    private int m_MaxTurn;

    private void Start()
    {
        m_Player = GameObject.Find("Canvas").gameObject.transform.Find("Player").GetComponent<TextMeshProUGUI>();
        m_Buttons = GameObject.Find("Canvas").gameObject.transform.Find("Board").GetComponentsInChildren<Button>();
        m_Tiles = new string[m_Buttons.Length];

        for (int i = 0; i < m_Buttons.Length; i++)
        {
            int index = i;

            m_Tiles[index] = "-";
            m_Buttons[index].onClick.AddListener(delegate { OnSelect(index); });
            m_Buttons[index].interactable = true;
        }

        m_Turn = "X";
        m_Player.text = $"Player: {m_Turn}";
        m_MaxTurn = m_Buttons.Length;
    }

    private void OnSelect(int index)
    {
        m_Tiles[index] = m_Turn;
        m_Buttons[index].GetComponentInChildren<TextMeshProUGUI>().text = m_Turn;
        m_Buttons[index].interactable = false;

        CheckWinner();
    }

    private void CheckWinner()
    {
        m_CurrentTurn++;

        if(m_Tiles[0] == m_Turn && m_Tiles[1] == m_Turn && m_Tiles[2] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[3] == m_Turn && m_Tiles[4] == m_Turn && m_Tiles[5] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[6] == m_Turn && m_Tiles[7] == m_Turn && m_Tiles[8] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[0] == m_Turn && m_Tiles[3] == m_Turn && m_Tiles[6] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[1] == m_Turn && m_Tiles[4] == m_Turn && m_Tiles[7] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[2] == m_Turn && m_Tiles[5] == m_Turn && m_Tiles[8] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[0] == m_Turn && m_Tiles[4] == m_Turn && m_Tiles[8] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if (m_Tiles[2] == m_Turn && m_Tiles[4] == m_Turn && m_Tiles[6] == m_Turn)
        {
            Finish(m_Turn);
        }
        else if(m_CurrentTurn >= m_MaxTurn)
        {
            Finish("Draw");
        }
        else
        {
            m_Turn = m_Turn == "X" ? "O" : "X";
            m_Player.text = $"Player: {m_Turn}";
        }
    }

    private void Finish(string winner)
    {
        m_Player.text = $"WInner: {winner}";


        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].interactable = false;
        }
    }
}
