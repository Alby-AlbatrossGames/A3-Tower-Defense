using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : GameBehaviour
{
    private Renderer tileRenderer;
    public Material defaultMat;
    public Material selectMat;
    public Material unavailMat;
    public List<GameObject> towerList;
    public GameObject placeText;
    private bool hasTower;

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
        placeText = GameObject.FindGameObjectWithTag("PlaceText");
        hasTower = false;
    }

    private void OnMouseEnter()
    {
        if (!canBuild || hasTower)
            return;

        tileRenderer.material = selectMat;

        placeText.SetActive(true);
    }
    private void OnMouseOver()
    {
        //placeText.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        placeText.transform.position = Input.mousePosition;

    }
    private void OnMouseExit()
    {
        if (!canBuild)
            return;
        tileRenderer.material = defaultMat;

        placeText.SetActive(false);
    }
    private void OnMouseUpAsButton()
    {
        if (!canBuild || hasTower) return;
        Instantiate(towerList[0], transform.position, transform.rotation);
        hasTower = true;
    }
}
