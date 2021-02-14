using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    GameManage gmScript;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("Canvas").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {

        transform.Find("Text").GetComponent<Text>().text = "X";
        GetComponent<Button>().interactable = false;
        int index = int.Parse(gameObject.name);

        GameObject.Find("Canvas").GetComponent<GameManage>().matrix[index] = "X";

        gmScript.matrix[index] = "X";

        if (gmScript.verification("X"))
            gmScript.ShowPanel("X");
        else
            gmScript.ComputerPlay();
    }
}
