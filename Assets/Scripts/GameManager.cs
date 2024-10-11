using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerTurn;
    public bool opponentTurn;

    private void Start()
    {
        int allHexagons = FindObjectsOfType<Hexagon>().Length;
        print("All Hexagons: " + allHexagons);
    }

    public int RollDice()
    {
        int dice = Random.Range(1, 7);
        print("Dice number: " + dice);

        return dice;
    }
}
