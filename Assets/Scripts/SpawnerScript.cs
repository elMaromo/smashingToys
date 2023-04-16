using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> monsters;
    public List<GameObject> firstRow;

    public float offsetY;
    public float spawnRatio;
    public float spawnIncrease;
    public float timeToIncreaseRatio;

    private float originalSpawnRatio;
    private float timer;
    private float ratioTimer;

    private void Awake()
    {
        originalSpawnRatio = spawnRatio;
        timer = spawnRatio;
        ratioTimer = timeToIncreaseRatio;
    }

    private void Update()
    {

        timer -= Time.deltaTime;
        ratioTimer -= Time.deltaTime;

        if (timer < 0)
        {
            CreateMonster();
            timer = spawnRatio;
        }

        if (ratioTimer < 0)
        {
            spawnRatio = spawnRatio * spawnIncrease;
            ratioTimer = timeToIncreaseRatio;
        }
    }

    private void CreateMonster()
    {
        int colSel = Random.Range(0, firstRow.Count);
        int monsSelec = Random.Range(0, monsters.Count);
        GameObject newMonster = Instantiate(monsters[monsSelec], transform.position, transform.rotation);
        MonsterJump( newMonster, firstRow[colSel] );
        MonsterScript mstrScript = newMonster.GetComponent<MonsterScript>();
        mstrScript.setMonster(spawnRatio, offsetY, firstRow[colSel].GetComponent<ButtonsScrip>() );
    }

    public void MonsterJump( GameObject monster, GameObject Cas )
    {
        Vector3 enPos = Cas.transform.position + Vector3.up * offsetY;
        monster.transform.DOJump(enPos, 1, 1, 0.3f).SetEase(Ease.OutQuad);
    }

}