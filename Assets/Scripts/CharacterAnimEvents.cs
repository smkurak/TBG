using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimEvents : MonoBehaviour
{
    Character character;
    
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    void AttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
		
	}

    void FistEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
    }

    void ShootEnd()
    {
        character.SetState(Character.State.Idle);
    }

}
