using System.Collections;

using UnityEngine;
using System.Collections.Generic;


public class GamePiece : MonoBehaviour
{
    public int xIndex;
    public int yIndex;

    SpriteRenderer spriteRenderer;

    Board m_board;

    bool m_isMoving = false;

    public InterpType interpolation = InterpType.SmootherStep;


    //accesses the sprites colour
    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;

    }

    public void SetColor(Color newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    public enum InterpType
    {
        Liner,
        EaseOut,
        EaseIn,
        SmoothStep,
        SmootherStep
    }

    public MatchValue matchValue;

    public enum MatchValue
    {
        Yellow,
        Blue,
        Megenta,
        Indigo,
        Green,
        Teal,
        Red,
        Cyan,
        Wild

    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move((int)transform.position.x + 2, (int)transform.position.y, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move((int)transform.position.x - 2, (int)transform.position.y, 0.5f);
        }
        */
    }

    public void Init(Board board)
    {
       m_board = board;
    }

    public void SetCoord(int x, int y)
     {
          xIndex = x;
          yIndex = y;

     }

    public void Move(int destX, int destY, float timeToMove)
    {
        if (!m_isMoving)
        {
            StartCoroutine(MoveRoutine(new Vector3(destX, destY, 0), timeToMove));
        }
       
    }

    IEnumerator MoveRoutine(Vector3 destination, float timeToMove)
    {
        Vector3 startPosition = transform.position;

        bool reachedDestination = false;
        float elapsedTime = 0f;

        m_isMoving = true;


        while (!reachedDestination)
        {
            //do something useful here to move code to destination before breaking loop


            //if close enough to destination
            if (Vector3.Distance(transform.position, destination) < 0.01f)
            {
                reachedDestination = true;

                /*
                // round position to the final destination on int value.
                transform.position = destination;

                //SetCoord the xIndex and yIndex of Game Piece
                SetCoord((int)destination.x, (int)destination.y);
                */

                if (m_board !=null)
                {
                    m_board.PlaceGamePiece(this, (int)destination.x, (int)destination.y);
                }
                break;

            }

            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);

            switch (interpolation)
            {
                case InterpType.Liner:
                    break;

                case InterpType.EaseOut:
                    t = Mathf.Sin(t * Mathf.PI * 0.5f);
                    break;

                case InterpType.EaseIn:
                    t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
                    break;

                case InterpType.SmoothStep:
                    t = t * t;
                    break;

                case InterpType.SmootherStep:
                    t = t * t * t * (t * (t * 6 - 15) + 10);
                    break;

            }

            

            transform.position = Vector3.Lerp(startPosition, destination, t);


            //wait untill next frame
            yield return null;
        }

        m_isMoving = false;
    }




 
}

   