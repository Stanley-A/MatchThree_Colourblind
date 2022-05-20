using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Normal,
    Obstacle
}

public class Tile : MonoBehaviour
{

    public int xIndex;
    public int yIndex;


    Board m_board;

    public TileType tileType = TileType.Normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void Init(int x, int y, Board board)
    {
        xIndex = x;
        yIndex = y;
        m_board = board;
    }

     private void OnMouseDown()
    {
        if(m_board != null)
        {
            //calls function from the board script
            m_board.ClickedTile(this);
        }
    }

    private void OnMouseEnter()
    {
        if (m_board != null)
        {
            m_board.DragToTile(this);
        }
    }

    private void OnMouseUp()
    {
        if (m_board != null)
        {
            m_board.ReleaseTile();
        }
    }

}
