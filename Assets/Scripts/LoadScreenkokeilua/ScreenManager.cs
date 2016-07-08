
using UnityEngine;
using System.Collections;


public class ScreenManager : MonoBehaviour
{

    public static ScreenManager instance;
    public FadeSprite m_blackScreenCover;
    public float m_minDuration = 0f;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartCoroutine(LoadSceneAsync("GameScreen"));
        //}
    }


    public IEnumerator LoadSceneAsync(string sceneName)
    {
     
            // Fade to black
            yield return StartCoroutine(m_blackScreenCover.FadeIn());

            // Load loading screen
            yield return Application.LoadLevelAsync("LoadingScreen");

            // !!! unload old screen (automatic)

            // Fade to loading screen
            yield return StartCoroutine(m_blackScreenCover.FadeOut());

            float endTime = Time.time + m_minDuration;

            // Load level async
            yield return Application.LoadLevelAdditiveAsync(sceneName);

            while (Time.time < endTime)
                yield return null;

            // Play music or perform other misc tasks

            // Fade to black
            yield return StartCoroutine(m_blackScreenCover.FadeIn());

            // !!! unload loading screen
            LoadingSceneManager.UnloadLoadingScene();
        //Application.UnloadLevel("LoadingScreen");
            // Fade to new screen
            yield return StartCoroutine(m_blackScreenCover.FadeOut());
        
    }


}
