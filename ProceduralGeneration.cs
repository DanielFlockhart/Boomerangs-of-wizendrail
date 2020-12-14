using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject Straight,StraightA,Left,Right,LeftUp,LeftDown,RightUp,RightDown;
    public GameObject Blocker;
    public Transform Player;
    public int loaded = 10;
    [SerializeField] int mapWidth = 1;
    [SerializeField] int mapHeight = 3;
    [SerializeField] float tileOffset = 1f;
    public GameManager manager;
    public List<GameObject> pieces;
    public List<int> types;
    float currX = 0;
    float currY = 0;
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<GameObject> { Straight, StraightA, Left, Right, LeftUp, LeftDown, RightUp, RightDown };
        types = new List<int> {};
        int prevP = 0;
        for (int x = 0; x < loaded; x++)
        {
            int piece = get_piece(prevP);
            types.Add(piece);
            prevP = piece;
            
        }
        createTileMap();
        
    }
    // Update is called once per frame
    void Update()
    {
        CullTiles();
    }
    void createTileMap()
    {
        //GameObject newTile = Instantiate(getShape(types[x]));
        
        for (int x = 0; x < loaded; x++)
        {
            createSegment(types[x]);
        }
    }

    void setTileInfo(GameObject GO) {
        GO.transform.parent = transform;
    }
    
    void CullTiles()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Board");
        float px = Player.transform.position.x;
        float py = Player.transform.position.y;
        
        float xGap = Mathf.Abs(Mathf.Abs(px) - Mathf.Abs(tiles[4].transform.position.x));
        float yGap = Mathf.Abs(Mathf.Abs(py) - Mathf.Abs(tiles[4].transform.position.y));
        if (xGap < 10 && yGap < 10)
        {
            Blocker.transform.position = tiles[0].transform.position;
            Destroy(tiles[0]);
            
            manager.loaded_chunks += 1;
            createTiles();
        }
        //if (Vector3.Distance(tiles[loaded-1].transform.position, Player.transform.position) < 5)
        //{
        //        Destroy(tiles[0]);
        //        manager.loaded_chunks += 1;
        //        createTiles();
        //}
    }
    void createSegment(int typenum)
    {
        //currX = Mathf.Floor(Player.transform.position.x / 10);
        //currY = Mathf.Floor(Player.transform.position.y / 10);
        GameObject TempGo = Instantiate(getShape(typenum));
        currX += posChangeX(typenum);
        currY += posChangeY(typenum);
        float xpos = currX;
        float ypos = currY;
        GetComponent<Populate>().PopulateSquare(xpos, ypos);
        TempGo.transform.position = new Vector3(xpos, ypos);
        TempGo.transform.parent = transform;
    }
    void createTiles()
    {
        int piece = get_piece(types[loaded-1]);
        types.Add(piece);
        types.RemoveAt(0);
        createSegment(types[loaded-1]);

    }
    int get_piece(int type)
    {
        // 0 = none
        // 1 = |
        // 2,3 = LEft right Turn
        // 4 = -
        // 9 = -
        // 5,6,7,8 = up down left right turn
        // 11,12 = 5,7 but reversed
        if (type == 0)
        {
            return 1;// 1 or 2
        } 
        else if(type == 1)
        {
            return Random.Range(1, 4);// 3 or 4
        }
        else if(type == 2 || type == 3)
        {
            if(type == 2)
            {
                return 4;
            } else
            {
                return 9;
            }
        }
        else if(type == 4 || type == 9)
        {
            if(type == 4)
            {
                return Random.Range(5, 7);
            } else
            {
                return Random.Range(7, 9);
            }
        }
        else if(type == 5 ||  type == 7)
        {
            return 1;
        }
        else if(type == 6 || type == 8)
        {
            return 10;
        }
        else if(type == 10)
        {
            return Random.Range(11, 13);
        }
        else if(type == 11 || type == 12)
        {
            if(type == 11)
            {
                return 9;
            } else
            {
                return 4;
            }
        }
        else
        {
            return 1;
        }
        


    }
    GameObject getShape(int indent)
    {
        if(indent == 1 || indent == 0 || indent == 10)
        {
            return Straight;
        }
        else if (indent == 2)
        {
            return Left;
        }
        else if (indent == 3)
        {
            return Right;
        }
        else if (indent == 4 || indent == 9)
        {
            return StraightA;
        }

        else if (indent == 5)
        {
            return LeftUp;
        }
        else if (indent == 6)
        {
            return LeftDown;
        }
        else if(indent == 10)
        {
            return Straight;
        }
        else if (indent == 7)
        {
            return RightUp;
        }
        else if(indent == 11)
        {
            return LeftUp;
        }
        else if (indent == 12)
        {
            return RightUp;
        }
        else if (indent == 8)
        {
            return RightDown;
        } else
        {
            return Straight;
        }

    }
    float posChangeY(int fuck)
    {
        if (fuck == 1 || fuck == 2 || fuck == 3)
        {
            return 10;
        }
        else if (fuck == 10 || fuck == 11 || fuck == 12)
        {
            return -10;
        }
        else
        {
            return 0;
        }
    }

    float posChangeX(int fuck)
    {
        if (fuck == 5 || fuck == 6 || fuck == 4)
        {
            return -10;
        }
        else if (fuck == 7 || fuck == 8 || fuck == 9)
        {
            return 10;
        }
        else
        {
            return 0;
        }
    }

}

