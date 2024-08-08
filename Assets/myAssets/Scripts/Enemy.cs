using NUnit.Framework;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpd = 10f;
    public float curSpd;
    public int maxHP = 10;
    public int curHP;
    public Vector3 nxtNode;
    private int curNode = 0;
    private float nodeDist = 0.2f;

    private GameObject _GM;

    public List<GameObject> tempNodeList;

    private void Start()
    {
        curSpd = 1;
    }

    // Move self toward target
    private void Update()
    {
        Move(curSpd, nxtNode);
    }

    private void Move(float _spd, Vector3 _node)
    {
        //transform.Translate(_node, _spd * Time.deltaTime);
        transform.Translate(_node.x * _spd, _node.y * _spd, _node.z * _spd);
    }

    public void NewNode(Vector3 _node)
    {
        nxtNode = _node;
    }

    public void SpecificNode(int _i)
    {
        NewNode(tempNodeList[_i].transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("NextNode"))
        {
            curNode += 1;
            SpecificNode(curNode);
        }
    }
}
