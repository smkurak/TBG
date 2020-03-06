using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InBattle : MonoBehaviour
{
	public GameController gameController;

	public Button switchButton;
	public Button attackButton;
	public Button pauseButton;
	public Button mainMenuButton;
	public Button returnButton;
	public Button reloadButton;

	public string battleScnName;


	public void Awake()
	{
		attackButton.onClick.AddListener(OnAttackButtonClick);
		switchButton.onClick.AddListener(() => gameController.SwitchCharacter());
		mainMenuButton.onClick.AddListener(returnToMainMenu);
		reloadButton.onClick.AddListener(reloadLevel);
	}

	private void returnToMainMenu()
	{
		battleScnName = "StartMenu";
		SceneManager.LoadScene(battleScnName);
	}

	private void reloadLevel()
	{
		SceneManager.LoadScene(battleScnName);
	}


	private void OnAttackButtonClick()
	{
		gameController.PlayerMove();
	}





}
