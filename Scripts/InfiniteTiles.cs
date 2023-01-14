using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTiles : MonoBehaviour
{
    public GameObject[] tileprefab;
    public Transform playertransform;
    public float spawnz =-5.03f;
    public float tilelength = 5.03f;
    public int amttilesonscreen = 3;
    public List<GameObject> activeTiles;
    public float safezone = 5f;
    private int lastprefabindex = 0;


   
    void Start()
    {
  
        //activeTiles = new List<GameObject>();
        for (int i = 0; i < amttilesonscreen;i++)
        {
            if (i < 3)
            { spawntile(0); }

            else
            { spawntile(); }
        }
    }

   
    void Update()
    {
        if (playertransform.position.z - safezone > (spawnz - amttilesonscreen * tilelength))
        {
            spawntile();
            DeleteTile();
        }

    }


    private void spawntile(int prefabindex=-1)
    {

        GameObject go;
        if (prefabindex == -1)
        { go = Instantiate(tileprefab[Randomprefabindex()]) as GameObject; }

        else
        { go = Instantiate(tileprefab[prefabindex]) as GameObject; }

        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnz;
        spawnz += tilelength;
        activeTiles.Add(go);
    }


    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int Randomprefabindex()
    {
        if (tileprefab.Length <= 1)
            return 0;

        int randomindex = lastprefabindex;
        while(randomindex==lastprefabindex)
        {
            randomindex = Random.Range(0, tileprefab.Length);
        }

        lastprefabindex = randomindex;
        return randomindex;

     }
}
