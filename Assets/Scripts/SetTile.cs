using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetTile : MonoBehaviour
{
    //public and private references
    public Tile tileToDispence;
    private TileDispencerListener tileListener;

    // Start is called before the first frame update
    void Start()
    {
        tileListener = Object.FindObjectOfType<TileDispencerListener>();
    }

    //When mouse clicks, dispence tile to the tiledispencerlistener
    void OnMouseDown()
    {
        tileListener.tileToPlace = tileToDispence;
    }
}
