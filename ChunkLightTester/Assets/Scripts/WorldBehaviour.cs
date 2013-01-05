using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ChunkRendering;

public class WorldBehaviour : MonoBehaviour {

	public Chunk[] ChunksMap = new Chunk[ushort.MaxValue];
	// Use this for initialization
	void Start () {
		
		for(int x = -12; x < 12; ++x)
		{
			for(int z = -12; z < 12; ++z)
			{
				ushort index = (ushort)((x + 127) << 8 | (z + 127));
				Chunk chunk = new Chunk(x,z, this, (z + x) % 2 == 0? Color.black : Color.gray);
				//print("X: " + x + "Z: " + z + " " + index);
				ChunksMap[index] = chunk;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public byte GetBlockType(int x, int y, int z)
	{	
		int chunkX = x >> 4;
		int chunkZ = z >> 4;
		
		Chunk chunk = ChunksMap[(chunkX + 127) << 8 | (chunkZ + 127)];
		if(chunk == null)
			return 0;
		
		ChunkSlice slice = chunk.Slices[y / Chunk.SliceHeight];
		return slice[x & 0xF, y & Chunk.SliceHeightLimit, z & 0xF];
	}
}
