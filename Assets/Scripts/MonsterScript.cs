using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterScript : MonoBehaviour
{
    public float jumpHeight;
    public float timeJumping;

    private float timeToMove;
    private float offsetY;
    private ButtonsScrip currentCass;
    private ButtonsScrip nextCass;
    private float timer;
    [HideInInspector] public bool alive;

    private void Awake()
    {
        alive = true;
        timer = 200;
    }

    public void setMonster(float newTimer, float newOffsetY, ButtonsScrip newCass)
    {
        timeToMove = newTimer;
        offsetY = newOffsetY;
        currentCass = newCass;
        currentCass.monster = gameObject;
        currentCass.monsterHere = true;
        timer = timeToMove;
        choseNextCas();
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && alive )
        {
            currentCass.monster = null;
            currentCass.monsterHere = false;
            currentCass = nextCass;
            currentCass.monster = gameObject;
            currentCass.monsterHere = true;

            //transform.position = currentCass.transform.position;
            //transform.position += Vector3.up * offsetY;
            Jump();
            choseNextCas();
            timer = timeToMove;
        }
    }

    private void choseNextCas()
    {
        if (currentCass.nextButons.Count > 0)
        {
            int nextIndexCas = Random.Range(0, currentCass.nextButons.Count);
            nextCass = currentCass.nextButons[nextIndexCas];
            transform.LookAt(nextCass.transform.position + Vector3.up * offsetY);
        }

    }

    public void Jump()
    {
        Vector3 enPos = currentCass.transform.position + Vector3.up * offsetY;
        transform.DOJump(enPos, jumpHeight, 1, timeJumping).SetEase(Ease.OutQuad);
    }

}
