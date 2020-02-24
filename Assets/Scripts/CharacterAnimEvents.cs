using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//события, происходящие по "events" в аниматоре, см. клипы анимации.
public class CharacterAnimEvents : MonoBehaviour
{
    Character character;
    
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

	void Attack()
	{
		character.DoDamageToTarget();
	}

	void AttackEnd()
	{
		character.SetState(Character.State.RunningFromEnemy);
	}

	void Shoot()
    {
        character.DoDamageToTarget();
	}

    void ShootEnd()
    {
        character.SetState(Character.State.Idle);
    }

}
