using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wires : MonoBehaviour
{


    private static BombTimer bombTimer;
    static int solutionsFound = 0;
    GameObject[] wires;

    private bool grabbed;
    private string color;
    private bool willEndGame;

    public bool Grabbed { get => grabbed; set => grabbed = value; }
    public string Color { get => color; set => color = value; }
    public bool WillEndGame { get => willEndGame; set => willEndGame = value; }
    public int SolutionsFound { get => solutionsFound; }

    public void incrementSolutions()
    {
        solutionsFound++;
        Debug.Log("Solution found");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(name == "blue")
        {
            grabbed = false;
            color = "blue";
            willEndGame = true;
            Debug.Log("Instantiated blue wire script");
            bombTimer = GameObject.FindGameObjectWithTag("bomb").GetComponent<BombTimer>();
        }

        else
        {
            grabbed = false;
            color = "" + name;
            willEndGame = false;
            Debug.Log("Instantiated " + color + " wire script");
        }

    }

    public void loseGame()
    {

        bombTimer.TotalTime = 5f;

        wires = GameObject.FindGameObjectsWithTag("wire");

        for(int i = 0; i < wires.Length; i++)
        {
            wires[i].GetComponent<BoxCollider>().enabled = false;
        }

        
        Debug.Log("You lose");
    }


    public void winGame()
    {

        bombTimer.enabled = false;
        Debug.Log("You win");
    }
}
