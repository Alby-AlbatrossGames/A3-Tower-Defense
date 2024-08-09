using UnityEngine;

public class Tile : GameBehaviour
{
    private Renderer tileRenderer;

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if (!canBuild)
            return;
        tileRenderer.material.color = Color.blue;
    }
    private void OnMouseExit()
    {
        if (!canBuild)
            return;
        tileRenderer.material.color = Color.red;
    }
}
