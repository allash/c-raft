using UnityEngine;
using System.Collections;
using ChunkRendering;

public class ChunkBehaviour : MonoBehaviour {
	
	public GameObject[] ChunkSliceObjects = new GameObject[16];
	public Chunk Parent;
	
	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < Chunk.NumSlices; ++i)
		{
			GameObject newObject = new GameObject();
			ChunkSliceObjects[i] = newObject;			
			MeshRenderer meshRenderer = newObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
			meshRenderer.material = new Material(Shader.Find("Diffuse"));
			meshRenderer.material.color = Parent.ChunkColor;
			newObject.AddComponent(typeof(MeshFilter));
			newObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (i * Chunk.SliceHeight), gameObject.transform.position.z);
			newObject.transform.parent = gameObject.transform;
		}
		
		ChunkRenderer.render(Parent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

