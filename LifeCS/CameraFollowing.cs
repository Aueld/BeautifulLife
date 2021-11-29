using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public float ShakeAmount = 0.1f;

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVec;
    private Vector3 animationOffset;
    private Vector3 endPosition;

    private bool one = false;
    private bool one2 = false;
    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private float cameraRot = -30f;
    private float ShakeTime { get; set; }

    private void Start()
    {
        transform.position = new Vector3(0f, -0.74f, 3.4f);

        Time.timeScale = 1.5f;
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = new Vector3(0, 1.6f, -3.5f) - lookAt.position;
        animationOffset = new Vector3(0, 7, 7);
        
        StartCoroutine(Updater());
    }

    public void ShakeForTime(float time)
    {
        ShakeTime = time;
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            if (MainManager.Instance.stageChange)
            {
                StartCoroutine(StageMove());
                yield return StageMove();
            }
            else
            {

                if (ShakeTime > 0)
                {
                    ShakeTime -= 0.1f;
                    transform.position = Random.insideUnitSphere * ShakeAmount + endPosition;

                    //ShakeAmount -= 1 / (ShakeTime * 100);
                }
                else
                {
                    ShakeTime = 0.0f;

                    if (!one)
                    {
                        if (transition > 2.5f)
                        {
                            one = true;
                            transition = 0f;
                        }
                        else
                        {
                            transform.RotateAround(lookAt.position, lookAt.up, cameraRot * Time.deltaTime);
                            transition += Time.deltaTime * 1 / animationDuration;
                            if (transition > 0.5f)
                                cameraRot = 30f;
                        }
                    }
                    else
                    {
                        moveVec = lookAt.position + startOffset;

                        moveVec.x = 0f;
                        moveVec.y = Mathf.Clamp(moveVec.y, 0, 7);

                        if (transition > 1.0f)
                        {
                            transform.position = moveVec;
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(moveVec + animationOffset, moveVec, transition);
                            transition += Time.deltaTime * 2 / animationDuration;
                            transform.LookAt(lookAt.position + new Vector3(0, 0, 6));
                        }

                        transform.position = moveVec;
                        endPosition = transform.position;
                    }
                }

                one2 = false;

                if (MainManager.Instance.gameStop)
                    yield return new WaitForSeconds(0.01f);
                else
                    yield return MainManager.Instance.waitFrame;
            }
        }
    }

    private IEnumerator StageMove()
    {
        MainManager.Instance.dontClick = true;

        if (!one2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z + 0.5f);

            transition = 0f;
            while (transition < 2f)
            {
                transform.RotateAround(lookAt.position, lookAt.up, cameraRot * Time.deltaTime);

                transition += Time.deltaTime * 1 / animationDuration;
                yield return MainManager.Instance.waitFrame;
            }
            one2 = true;
            yield return new WaitForSeconds(5f);
            transition = 0f;
        }
        else if (one2)
        {
            moveVec = lookAt.position + startOffset;

            moveVec.x = 0f;
            moveVec.y = Mathf.Clamp(moveVec.y, 0, 7);

            if (transition > 1.0f)
            {
                transform.position = moveVec;
            }
            else
            {
                transform.position = Vector3.Lerp(moveVec + animationOffset, moveVec, transition);
                transition += Time.deltaTime * 2 / animationDuration;
                transform.LookAt(lookAt.position + new Vector3(0, 0, 6));
            }

            transform.position = moveVec;
            endPosition = transform.position;

            MainManager.Instance.dontClick = false;
        }
    }
}
