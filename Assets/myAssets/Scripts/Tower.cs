using System.Collections;
using UnityEngine;

public class Tower : GameBehaviour
{
    public int fireDelay;
    public int dmg = 1;
    public float radius = 1;
    public GameObject radiusObj;
    public float rSpd = 1000f;
    private bool isSelected = true;

    private GameObject closeEnemy;

    private void Start()
    {
        SetSize();
    }
    private void LateUpdate()
    {
        closeEnemy = GetClosestEnemy();
        switch (_GM.gState)
        {
            case GameState.Attack:
                if (GetClosestEnemy() != null)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - closeEnemy.transform.position), Time.deltaTime * rSpd);
                    if (Vector3.Distance(transform.position, closeEnemy.transform.position) < radius)
                    {
                        closeEnemy.GetComponent<Enemy>().TakeDamage(dmg);//this makes them die at the next Node? idk why
                    }
                }
                ToggleActive(true);
                
                return;
            case GameState.Build:
                
                return;
        }
        
    }

    float GetDistanceToEnemy(GameObject go)
    {
        return Vector3.Distance(this.gameObject.transform.position, go.transform.position);
    }

    GameObject GetClosestEnemy()
    {
        float oldDist = 999999f;
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

    private void SetSize()
    {
        radiusObj.transform.localScale = new Vector3(radiusObj.transform.localScale.x * radius, radiusObj.transform.localScale.y * radius, radiusObj.transform.localScale.z * radius);
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

    /*private IEnumerator Fire()
    {
        closeEnemy.GetComponent<Enemy>().TakeDamage(dmg);
        yield return new WaitForSeconds(fireDelay);
    }
    */
}
