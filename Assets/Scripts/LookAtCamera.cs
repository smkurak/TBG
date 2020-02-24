/*
*	Serg Kurak
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//поворачиваем объект лицом к главной камере. аккуратнее с её копированием и переименованием!
public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
		transform.LookAt(Camera.main.transform);
    }
}
