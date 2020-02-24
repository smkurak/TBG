/*
*	Serg Kurak
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//текст с отображением оставшегося здоровья, проверка на изменение что бы постоянно не вызывать "тяжелый" текст.
public class HealthIndicator : MonoBehaviour
{
	public TextMeshProUGUI textField;
	Health health;
	float displayedHealth;

	void Start()
    {
		health = GetComponent<Health>();
		displayedHealth = health.current - 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
		float value = health.current;
		if (Mathf.Abs(displayedHealth - value) >= 0.00001f)
		{
			displayedHealth = value;
			textField.text = $"{value}";
		}
    }

}
