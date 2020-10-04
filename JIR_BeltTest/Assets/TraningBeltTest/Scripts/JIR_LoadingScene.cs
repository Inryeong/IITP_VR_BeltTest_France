using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class JIR_LoadingScene : MonoBehaviour
{
    private static JIR_LoadingScene instance;

    public static JIR_LoadingScene Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<JIR_LoadingScene>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Create();
                }
            }
            return instance;
        }
    }

    private static JIR_LoadingScene Create()
    {
        return Instantiate(Resources.Load<JIR_LoadingScene>("LoadingUI"));
    }

    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // loadingUI
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image loadingBar;

    // 불러올 씬 네임
    private string loadSceneName;

    /// <summary>
    /// 비활성화된 로딩씬 활성화 함수
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        // 씬의 로딩이 끝나는 엔진
        SceneManager.sceneLoaded += OnSceneLoaded;
        loadSceneName = sceneName;
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        loadingBar.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        // 비동기로 loadscene 해서 자동으로 씬로드 하지 않도록
        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)   // 씬로드가 끝나지 않았다면
        {
            yield return null;
            if(op.progress < 0.9f)  // 씬의 로드바
            {
                loadingBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(loadingBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation =true;
                    yield break;
                }
            }
        }
    }

    /// <summary>
    /// 씬의 로딩이 끝나면 등록해둔 씬을 로딩했다고 알려주는 함수
    /// </summary>
    /// <param name="arg0"></param>
    /// <param name="arg1"></param>
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    /// <summary>
    /// 씬 로딩 끝날때 자연스럽게 fadeIn fadeOut하도록
    /// </summary>
    /// <param name="isFadeIn"></param>
    /// <returns></returns>
    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
        }

        if(!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }
}
