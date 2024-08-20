using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    public float maxSpd = 5f;
    public float curSpd;
    public float maxHP = 10;
    public float curHP;
    public Vector3 nxtNode;
    private int curNode;
    private float nodeDist = 0.2f;

    public List<GameObject> tempNodeList;

    private void Start()
    {
        maxHP = (_WM.currentWave * Random.Range(0.25f, 1.75f));
        curHP = maxHP;
        curSpd = maxSpd;
        curNode = 0;
        transform.position = _EM.NodeList[curNode].position;
        nxtNode = _EM.NodeList[curNode+1].transform.position;
    }

    // Move self toward target
    private void Update()
    {
        Move(curSpd, nxtNode);
    }

    private void Move(float _spd, Vector3 _node)
    {
        if (Vector3.Distance(transform.position, _node) < nodeDist)
            NextNode();

        //move towards target position
        transform.position = Vector3.MoveTowards(transform.position, _node, curSpd * Time.deltaTime);
    }

    public void SpecificNode(int _i) => nxtNode = _EM.NodeList[_i].transform.position;//NewNode(_EM.NodeList[_i].transform.position);

    public void NextNode()
    {
        if (curNode == _EM.NodeList.Length-1)
        {
            _PLAYER.TakeDamage();
            Die();
            return;
        }

        curNode += 1;
        SpecificNode(curNode);
    }

    public void Die() => _EM.KillEnemy(gameObject);

    public void TakeDamage(int _dmg)
    {
        curHP -= _dmg;
        if (curHP <= 0)
            Die();
    }
}
