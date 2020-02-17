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

	Character FirstAliveCharacter(Character[] characters)
	{
		foreach (var character in characters)
		{
			if (!character.IsDead())
				return character;
		}
		return null;
	}

    bool CheckEndGame()
    {
		if (FirstAliveCharacter(playerCharacters) == null)
		{
			EnemyWon();
			return true;
		}
		if (FirstAliveCharacter(enemyCharacters) == null)
		{
			PlayerWon();
			return true;
		}

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
