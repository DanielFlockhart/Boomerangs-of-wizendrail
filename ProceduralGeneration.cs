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
    void Update()
    {
        CullTiles();
    }
    void createTileMap()
    {
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
        // Code hidden due to its inefficiency


    }
    GameObject getShape(int indent)
    {
        // Code hidden due to its inefficiency

    }
    float posChangeY(int val)
    {
        // Code hidden due to its inefficiency
    }

    float posChangeX(int val)
    {
        // Code hidden due to its inefficiency
    }

}

