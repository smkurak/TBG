using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Character[] playerCharacters;
    public Character[] enemyCharacters;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    void PlayerWon()
    {
        Debug.Log("Player won");
    }

    void EnemyWon()
    {
        Debug.Log("Enemy won");
    }



    bool CheckEndGame()
    {
        return false;
    }

    IEnumerator GameLoop()
    {
        while (!CheckEndGame())
        {
            yield return null;
        }

    }
	
}
