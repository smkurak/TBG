using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLosePage : MonoBehaviour
{
	public GameObject visualPart;
	public Text textPole;
	public Button mainMenuButton;
	public string battleScnName;

	public void Awake()
	{
		visualPart.SetActive(false);
		mainMenuButton.onClick.AddListener(returnToMainMenu);
	}

	private void returnToMainMenu()
	{
		battleScnName = "StartMenu";
		SceneManager.LoadScene(battleScnName);
	}

	public void typeMessage(string message)
	{
		visualPart.SetActive(true);
		textPole.text = message;
	}
}
