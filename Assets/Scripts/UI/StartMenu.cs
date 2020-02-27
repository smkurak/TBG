/*
*	Serg Kurak
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	public float fakeLoadTime = 1f;
	public string battleScnName;
	public Button playButton;
	public Button switchLvl_1;
	public Button switchLvl_2;
	public Slider loadingBar;

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
		LoadGameScene();
		//Debug.Log($"PlayGame");
	}

	private void LoadingBarChanging(float progress)

	{
		playButton.GetComponentInChildren<Text>().text = progress.ToString();
	}

	private void LoadGameScene()
	{

		StartCoroutine(LoadGameScnCor());
		
		//вызов по индексу сцены
		//SceneManager.LoadScene(1);

	}
	private IEnumerator LoadGameScnCor()
	{
		float timer = 0;
		while (timer < fakeLoadTime)
		{
			timer += Time.deltaTime;
			SetLoadingBar(timer / fakeLoadTime);

			yield return null;
		}


		SceneManager.LoadScene(battleScnName);
	}

	private void SetLoadingBar( float progress)
	{
		loadingBar.value = progress;
	}
}
