using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLogicPage : MonoBehaviour
{
	public Slider loadingBar;

	public float fakeLoadTime = 1f;
	public GameObject visualPart;
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
		visualPart.SetActive(false);
	}

	public void LoadScene(string sceneName)
	{
		StartCoroutine(LoadGameScnCor(sceneName));
	}

	private IEnumerator LoadGameScnCor(string sceneName)
	{
		visualPart.SetActive(true);
		AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);
		asyncLoading.allowSceneActivation = false;

		float timer = 0;
		while (timer < fakeLoadTime || asyncLoading.progress < 0.8f)
		{
			timer += Time.deltaTime;
			SetLoadingBar(timer / fakeLoadTime);

			yield return null;
		}

		asyncLoading.allowSceneActivation = true;
		visualPart.SetActive(false);
	}
	private void SetLoadingBar(float progress)
	{
		loadingBar.value = progress;
	}
}
