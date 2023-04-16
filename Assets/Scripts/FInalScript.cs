using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FInalScript : MonoBehaviour
{
    private ButtonsScrip buttScr;
    public List<GameObject> clocks;
    private int health;
    private Vector3 originalClockScale;

    private void Awake()
    {
        health = clocks.Count;
        buttScr = GetComponent<ButtonsScrip>();
        buttScr.isActivable = false;
        originalClockScale = clocks[0].transform.localScale;
    }

    private void Update()
    {
        if(buttScr.monsterHere)
        {
            health--;
            if( health>=0 )
            {
                //clocks[health].transform.DOShakePosition( 1f, 0.5f );
                clocks[health].transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutQuad);
            }
            Destroy(buttScr.monster, 1f);
            buttScr.monster.transform.DOScale(Vector3.zero, 1f);
            buttScr.monsterHere = false;

            if( health == 0 )
            {
                ResetLife();
            }
        }
    }

    public void ResetLife()
    {
        for( int i = 0; i<clocks.Count; i++ )
        {
            clocks[i].transform.localScale = originalClockScale;
        }

        health = health = clocks.Count;
    }
}
