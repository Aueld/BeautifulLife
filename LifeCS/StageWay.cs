using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWay : LoadExcelTable
{
    private static readonly WaitForSeconds wait_Menu = new WaitForSeconds(6f);

    private GameObject player;
    private PlayerMotor playerMotor;
    private Animator animator;
    private OpenStatus open;
    private MenuButton stop;

    private bool Stage2 = false;
    private bool Stage3 = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerIn");
        playerMotor = GetComponent<PlayerMotor>();
        animator = GetComponentInChildren<Animator>();
        timer = 0;
        index = 0;

        open = GameObject.Find("OpenStatus").GetComponent<OpenStatus>();
        stop = GameObject.Find("Stop").GetComponent<MenuButton>();

        StartCoroutine(Updater());
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.stageChange)
                yield return MainManager.Instance.waitFrame;
            else
            {
                if (!MainManager.Instance.playerHit)
                {
                    // 1스테이지 1분

                    // 2스테이지 2분
                    if(timer > 1600 && !Stage2) // 2300
                    {
                        MainManager.Instance.dontMov = true;
                    }
                    if (timer > 1650 && !Stage2)
                    {

                        animator.SetBool("Stage", true);

                        player.transform.localScale *= 1.3f; 

                        playerMotor.line = 0;
                        transform.position = new Vector3(0f, -2.643f, 0.38f);

                        
                        Stage2 = true;


                        MainManager.Instance.stageChange = true;
                        //MainManager.Instance.Stagechange();

                        yield return wait_Menu;

                        open.OnClickStatus();

                        yield return wait_Menu;


                        stop.OnclickPause();

                        stop.hr = true;

                        MainManager.Instance.dontMov = false;
                    }

                    // 3스테이지 2분
                    if (timer > 5400 && !Stage3) // 7100
                    {
                        MainManager.Instance.dontMov = true;
                    }
                    if (timer > 5450 && !Stage3) // 
                    {

                        animator.SetBool("Stage", true);

                        player.transform.localScale *= 1.2f;

                        playerMotor.line = 0;
                        transform.position = new Vector3(0f, -2.643f, 0.38f);


                        Stage3 = true;


                        MainManager.Instance.stageChange = true;
                        //MainManager.Instance.Stagechange();

                        yield return wait_Menu;

                        open.OnClickStatus();

                        yield return wait_Menu;


                        stop.OnclickPause();

                        stop.hr = true;

                        MainManager.Instance.dontMov = false;
                    }

                    // 엔딩
                    if (timer > 9050) // 5분 11850
                    {
                        timer = 0;
                        MainManager.Instance.gameOver = true;
                        MainManager.Instance.gameStop = true;
                    }

                    timer++;// int.Parse(Time.deltaTime.ToString());

                }
                if (MainManager.Instance.gameStop)
                    yield return new WaitForSeconds(0.01f);
                else
                    yield return MainManager.Instance.waitFrame;
            }
        }
    }
}
