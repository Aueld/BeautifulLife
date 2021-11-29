using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private static MainManager instance = null;

    public WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();

    public int m_TargetFrameRate = 60;
    public int endPoint = 0;
    public int endIndex = 0;
    public int HighStat = 0;
    public int doubleUp = 0;

    public bool dontClick = false;
    public bool dontMov = false;
    public bool stageChange = false;
    public bool gameOver = false;
    public bool gameStop = false;
    public bool playerAttack = false;
    public bool playerJump = false;
    public bool playerHit = false;

    public float speed = 0.04f; // 느림 0.02/ 약간 느림 0.03/ 보통 0.04/ 약간 빠름 0.06/ 빠름 0.08
    public float speedVal = 1f; // 0.5/ 0.75/ 1/ 1.5/ 2.0
    public float timetime = 0f;

    public string status = "";

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Application.targetFrameRate = m_TargetFrameRate;
    }

    public static MainManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void PauseGame()
    {
        instance.gameStop = true;
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        instance.gameStop = false;
        //speed = 0.08f;
        Time.timeScale = 1.5f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Stagechange()
    {
        StartCoroutine(StageCh());
    }

    private IEnumerator StageCh()
    {
        yield return new WaitForSeconds(2f);
        Instance.stageChange = false;
    }
}
