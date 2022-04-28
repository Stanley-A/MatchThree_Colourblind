using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

	public int width;
	public int height;

	public int boarderSize;

	public GameObject tilePrefab;
	public GameObject[] gamePiecePrefabs;


	Tile[,] m_allTiles;
	GamePiece[,] m_allGamePieces;

	void Start()
	{
		m_allTiles = new Tile[width, height];
		m_allGamePieces = new GamePiece[width,height];
		SetupTiles();
		SetupCamera();
	}

	void SetupTiles()
	{
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				GameObject tile = Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

				tile.name = "Tile (" + i + "," + j + ")";

				m_allTiles[i, j] = tile.GetComponent<Tile>();

				tile.transform.parent = transform;

				m_allTiles[i, j].Init(i, j, this);



			}
		}
	}

	void SetupCamera()
    {
		Camera.main.transform.position = new Vector3((float)(width -1) / 2f, (float) (height -1) / 2f, -10f);

		float aspectRatio = (float) Screen.width / (float) Screen.height;

		float vericalSize = (float)height / 2f + (float)boarderSize;

		float horizontalSize = ((float)width / 2f + (float)boarderSize) / aspectRatio;

		Camera.main.orthographicSize = (vericalSize > horizontalSize) ? vericalSize : horizontalSize;



    }


}
