using UnityEngine;

public class Tile : GameBehaviour
{
    private Renderer tileRenderer;
    public Material defaultMat;
    public Material selectMat;
    public Material unavailMat;

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if (!canBuild)
            return;
        tileRenderer.material = selectMat;
    }
    private void OnMouseExit()
    {
        if (!canBuild)
            return;
        tileRenderer.material = defaultMat;
    }
}
