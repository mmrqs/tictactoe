using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManage : MonoBehaviour
{
    public string[] matrix = new string[9];
    public List<int> choice = new List<int>();
    public GameObject GameOver;

    void Start()
    {
        // We randomly select which player must begin
        if (UnityEngine.Random.Range(0, 2) == 0)
            ComputerPlay();
    }
    
    public void ComputerPlay()
    {
        MajChoice();
        //The computer chooses randomly an available spot to play
        int nr = choice[UnityEngine.Random.Range(0, choice.Count)];
        GameObject.Find(nr.ToString()).transform.Find("Text").GetComponent<Text>().text = "O";
        matrix[nr] = "O";
        //We disable the button where the computer had played
        GameObject.Find(nr.ToString()).GetComponent<Button>().interactable = false;

        if (verification("O"))
            ShowPanel("O");
        else
            MajChoice();
    }

    void MajChoice()
    {
        choice.Clear();

        foreach (string i in matrix)
            if (i == "")
                choice.Add(Array.IndexOf(matrix, i));

        if (choice.Count == 0)
        {
            GameOver.SetActive(true);
            GameOver.transform.Find("Panel").transform.Find("Text").GetComponent<Text>().text = "Draw";
            return;
        }
    }

    public bool verification(string player)
    {
        return matrix[0] == player && matrix[1] == player && matrix[2] == player ||
            matrix[3] == player && matrix[4] == player && matrix[5] == player ||
            matrix[6] == player && matrix[7] == player && matrix[8] == player ||

            matrix[0] == player && matrix[4] == player && matrix[8] == player ||
            matrix[2] == player && matrix[4] == player && matrix[6] == player ||

            matrix[0] == player && matrix[3] == player && matrix[6] == player ||
            matrix[1] == player && matrix[4] == player && matrix[7] == player ||
            matrix[2] == player && matrix[5] == player && matrix[8] == player;
    }

    public void ShowPanel(string winner)
    {
        GameOver.SetActive(true);
        GameOver.transform.Find("Panel")
            .transform.Find("Text")
            .GetComponent<Text>().text = winner + " won this game";
    }
}
