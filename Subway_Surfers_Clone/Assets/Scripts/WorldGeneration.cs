using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform Player; //Access to player game object
    [SerializeField] private Chunk[] Chunks; //Array of chunks 
    [SerializeField] private List<Chunk> SpawnedChunks = new List<Chunk>(); //List of spawned chunks currently visible on screen
    [SerializeField] private Chunk StartingChunk;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnedChunks.Add(StartingChunk); // Add starting chunk to list. This is the one without any obstacles and collectibles.
        while(SpawnedChunks.Count < 6) // Initialize world for the begining of the game
        {
            SpawnChunk();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(Chunks[0]); // Spawn new chunk
        newChunk.transform.position = SpawnedChunks[SpawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition; // Move new chunk to allign with end point of previous one.
        SpawnedChunks.Add(newChunk); // Add new chunk to list of chunks
    }
}
