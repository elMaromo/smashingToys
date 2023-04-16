using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonsScrip : MonoBehaviour
{
    public string letter;
    public Color HilightColor;
    public List<ButtonsScrip> nextButons;

    [HideInInspector] public bool activated;
    [HideInInspector] public bool isActivable = true;
    [HideInInspector] public bool monsterHere;
    [HideInInspector] public GameObject monster;

    private Material mat;
    private Color originalColor;
    

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        activated = false;
        originalColor = mat.color;
    }

    private void Update()
    {
        if( isActivable )
        {
            Scan();

            if(activated)
            {
                Atack();
            }
        }
    }

    private void Atack()
    {
        if(monsterHere)
        {
            monster.transform.DOScaleY(0.1f, 0.5f);
            monster.GetComponentInChildren<Renderer>().material.color = Color.red;
            monster.GetComponent<MonsterScript>().alive = false;
            Destroy(monster, 0.5f);
            monsterHere = false;
        }
    }

    private void Scan()
    {
        activated = false;
        if( Input.GetKeyDown(letter))
        {
            activated = true;
            mat.SetColor("_Color", HilightColor);
        }

        if( Input.GetKeyUp(letter))
        {
            mat.SetColor("_Color", originalColor);
        }
    }

}
