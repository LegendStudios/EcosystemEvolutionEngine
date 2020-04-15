using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    private Vector3 GrowLoc;
    public GameObject PlantToGrow;

    public int Amount;
    public float Radius;
    public float GrowSpeed;
    public float Chance;

    // Start is called before the first frame update
    void Start()
    {

        // Rename the grass(clone) to grass
        this.name = "grass";

        //Depending on the grow speed, try to spread every ___ seconds
        InvokeRepeating("TrySpread", (100f - GrowSpeed) / 10f, (100f - GrowSpeed) / 10f);
    }

    void Update()
    {

    }

    public void TrySpread()
    {
        //Can plant still spread?
        if(Amount > 0)
        {
            //Will it spread (based on the set chance)
            if(Random.Range(0,100) < (Chance * 100))
            {
                Spread();
            }
            
        
        }
        //If the plant cant spread anymore, stop trying.
        if(Amount == 0)
        {
            CancelInvoke("TrySpread");
        }   
    }

    public void Spread()
    {
        //Pick a location
        GrowLoc.x = transform.position.x + (Random.Range(Radius * -10f,Radius * 10f) / 10f);
        GrowLoc.y = transform.position.y;
        GrowLoc.z = transform.position.z + (Random.Range(Radius * -10f, Radius * 10f) / 10f);

        //Only spread if the spread location is on the ground
        if (GrowLoc.x < 15 && GrowLoc.x > -15)
        {
            if (GrowLoc.z < 15 && GrowLoc.z > -15)
            {
                //Grow a new plant
                Instantiate(PlantToGrow, GrowLoc, transform.rotation);
                Amount = Amount - 1;
            }
        }
        
    }
}
