using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	public LoadingLogicPage loadingLogic;
	public string battleScnName;
	public Button playButton;
	public Button switchLvl_1;
	public Button switchLvl_2;
	

	public void Awake()
	{
		switchLvl_1.onClick.AddListener(switchLVL1);
		switchLvl_2.onClick.AddListener(switchLVL2);
		playButton.onClick.AddListener(PlayGame);
	}

	private void switchLVL1()

	{
		battleScnName = "Battle_01";
		
	}

	private void switchLVL2()

	{
		battleScnName = "Battle_02";
		
	}

	private void PlayGame()

	{
		loadingLogic.LoadScene(battleScnName);
		//Debug.Log($"PlayGame");
	}

}
