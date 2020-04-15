using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Vector2 mapSize;
    public Transform tilePrefab;

    [Range(0,1)]
    public float outlinePercent;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }
    
    
    
    public void GenerateMap()
    {
         string holdername = "GeneratedMap";
         if (transform.Find(holdername))
         {
             DestroyImmediate(transform.Find(holdername).gameObject);
         }
          Transform mapHolder = new GameObject(holdername).transform;
          mapHolder.parent = transform;

        for (int y = 0; y < mapSize.y; y++){
            for (int x = 0; x < mapSize.x; x++){

                Vector3 tilePosition = new Vector3(-mapSize.y / 2 + y + 0.5f, 0, -mapSize.x / 2 + x +0.5f);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(90, 0, 0)) as Transform;
                newTile.localScale = Vector3.one * (1-outlinePercent);
                newTile.parent = mapHolder;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
