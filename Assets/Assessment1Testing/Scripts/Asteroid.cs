using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
    public float maxStartSpeed = 5;

    public List<GameObject> onDeathPrefabs = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(Random.Range(-maxStartSpeed, maxStartSpeed), Random.Range(-maxStartSpeed, maxStartSpeed));
    }

    public void Die()
    {
        foreach(GameObject prefab in onDeathPrefabs)
        {
            GameObject deathObject = Instantiate(prefab);
            deathObject.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
    
}
