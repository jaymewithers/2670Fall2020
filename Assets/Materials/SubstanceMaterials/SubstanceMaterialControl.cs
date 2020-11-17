using UnityEngine;

public class SubstanceMaterialControl : MonoBehaviour
{
    public Substance.Game.Substance material;
    public Substance.Game.SubstanceGraph materialGraph;

    private void Start()
    {
        materialGraph.SetInputColor("blue", Color.blue);
    }
}