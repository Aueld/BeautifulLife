using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMotor : MonoBehaviour
{
    private static readonly WaitForSeconds wait_Seconds = new WaitForSeconds(0.001f);

    public int line = 0;
    public float speed = 3.0f;
    public float gravity = 12.0f;

    private CameraFollowing shake;
    private Animator animator;
    private Vector3 startPos;
    private Vector3 nowPos;
    private Vector3 endPos;

    private bool jump = false;
    private bool check = false;
    private float animationDuration = 15f;
    
    private void Start()
    {
        shake = GameObject.Find("Main Camera").GetComponent<CameraFollowing>();
        animator = GetComponentInChildren<Animator>();

        MainManager.Instance.timetime = 0f;

        StartCoroutine(Updater());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Respawn") 
        {
            check = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            animator.SetBool("Jump", false);
            jump = true;
        }
    }

    private IEnumerator CharMove(int i)
    {
        line += i;

        float time = 0f;
        while (time < 0.2f)
        {
            time += 0.02f;
            yield return wait_Seconds;
            transform.position = new Vector3(transform.position.x + time * i, transform.position.y, transform.position.z);
        }
    }

    private IEnumerator CharJump()
    {
        MainManager.Instance.playerJump = true;
        float time = 0f;
        
        while (time < 0.3f)
        {

            time += 0.02f;
            yield return wait_Seconds;
            transform.position = new Vector3(transform.position.x, transform.position.y + time, transform.position.z);
        }
        time = 0f;
        while (time < 0.2f)
        {

            time += 0.02f;
            yield return wait_Seconds;
        }
        time = 0f;
        while (time < 0.3f)
        {
            time += 0.02f;
            yield return wait_Seconds;
            transform.position = new Vector3(transform.position.x, transform.position.y - time, transform.position.z);
            MainManager.Instance.playerJump = false;
        }
    }

    private IEnumerator CharAttack()
    {
        MainManager.Instance.playerAttack = true;
        
        float time = 0f;

        MainManager.Instance.speed += 0.04f;

        while (time < 0.6f)
        {
            time += 0.02f;
            yield return wait_Seconds;

            if (time > 0.57f)
            {
                MainManager.Instance.speed = 0.04f;
                MainManager.Instance.playerAttack = false;
                animator.SetBool("Attack", false);
            }
        }
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.dontMov)
                yield return wait_Seconds;
            
            else
            {
                MainManager.Instance.timetime += Time.deltaTime;

                if (check)
                {
                    animator.SetBool("Run", true);
                }

                if (MainManager.Instance.timetime > animationDuration && check)
                {
                    if (Input.GetMouseButton(0))
                    {
                        nowPos = (Input.touchCount == 0) ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;

                        if (Input.GetMouseButtonDown(0))
                        {
                            startPos = nowPos;
                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        endPos = nowPos;

                        if (Mathf.Abs(endPos.y - startPos.y) < 150)
                        {
                            if (endPos.x > startPos.x && line != 1)
                                StartCoroutine(CharMove(1));

                            else if (endPos.x < startPos.x && line != -1)
                                StartCoroutine(CharMove(-1));
                        }
                        else
                        {
                            if (endPos.y > startPos.y && jump)
                            {
                                jump = false;

                                animator.SetBool("Jump", true);
                                StartCoroutine(CharJump());
                            }
                            else if (endPos.y < startPos.y && jump)
                            {
                                jump = false;
                                animator.SetBool("Attack", true);
                                StartCoroutine(CharAttack());
                            }
                        }
                    }
                }

                if (!MainManager.Instance.stageChange)
                {
                    animator.SetBool("Stage", false);
                }
                if (MainManager.Instance.playerHit)
                {
                    shake.ShakeForTime(0.2f);
                    animator.SetBool("Hit", true);
                }
                else if (!MainManager.Instance.playerHit)
                {
                    animator.SetBool("Hit", false);
                }

                yield return wait_Seconds;
            }
        }
    }

    /*
    점프
    
    업드리기

    공격
    칼 횡베기

    ㅁㄴㅇㅁㄴㅇㄹ
     
     */
}
