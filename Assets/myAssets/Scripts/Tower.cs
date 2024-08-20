using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : GameBehaviour
{
    public float fireDelay = 0.5f;
    public int dmg = 1;
    public float radius = 2;
    public GameObject radiusObj;
    public float rSpd = 1000f;
    private bool isSelected = true;
    private bool isFiring = false;

    private GameObject closeEnemy;

    private void LateUpdate()
    {
        closeEnemy = GetClosestEnemy();
        switch (_GM.gState)
        {
            case GameState.Attack:
                if (GetClosestEnemy() != null)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - closeEnemy.transform.position), Time.deltaTime * rSpd);
                    if (CheckRange(closeEnemy))
                    {
                        if (!isFiring)
                            StartCoroutine(Fire(closeEnemy));
                        //closeEnemy.GetComponent<Enemy>().TakeDamage(dmg);//this makes them die at the next Node? idk why
                    }
                }
                ToggleActive(true);
                
                return;
            case GameState.Build:
                
                return;
        }
        
    }

    bool CheckRange(GameObject _target)
    {
        if (_target == null) return false;

        if (Vector3.Distance(transform.position, _target.transform.position) < radius)
            return true;
        else return false;
    }

    float GetDistanceToEnemy(GameObject go)
    {
        if (go != null)
            return Vector3.Distance(this.gameObject.transform.position, go.transform.position);
        else return radius;
    }

    GameObject GetClosestEnemy()
    {
        float oldDist = radius;
        float newDist;
        foreach (GameObject g in _EM.ActiveEnemyList)
        {
            newDist = GetDistanceToEnemy(g);
            if (newDist < oldDist)
            {
                oldDist = newDist;
                return g;
            }
        }
        return null;
    }

    private void OnMouseDown()
    {
        if (canBuild)
            ToggleActive();
    }

    private void ToggleActive(bool off = false)
    {
        if (!off)
        {
            isSelected = !isSelected;
            radiusObj.SetActive(isSelected);
        }else
        {
            isSelected = false;
            radiusObj.SetActive(false);
        }
            
    }

    private IEnumerator Fire(GameObject _target)
    {
        Debug.Log("IN RANGE!");
        isFiring = true;
        _target.GetComponent<Enemy>().TakeDamage(dmg);
        this.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(fireDelay);//fireDelay
        GetComponent<Renderer>().material.color = Color.red;
        isFiring = false;
        yield return null;

        /*if (CheckRange(_target))
        {
            Debug.LogWarning("Still in range!");
            Fire(_target);
        }else
        {
            Debug.Log("not close enough!");
            GetComponent<Renderer>().material.color = Color.red;
            isFiring = false;
            yield return null;
        }*/
    }
    
}
