using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public static MapDestroyer instance;

    public GameObject explodePrefab;

    //public int bombPower;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("Have more than one MapDestroyer in the editor");
        instance = this;
    }

    public Tilemap tilemap;

    public Tile[] walls;
    public Tile destructibleWall;
    public Tile[] ruins;

    public void Explode(Vector2 explodeWorldPosition, int bombPower)
    {
        Vector3Int originCell = tilemap.WorldToCell(explodeWorldPosition);

        ExplodeCell(originCell);

        void ExplodeFunc(Vector2 vectorVariable)
        {
            for (int i = 1; i < bombPower; i++)
            {
                if (!ExplodeCell(originCell + new Vector3Int(i * (int)vectorVariable.x, i * (int)vectorVariable.y, 0)))
                    break;
            }
        }

        Vector2[] variable = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
        for (int i = 0; i < 4; i++)
        {
            ExplodeFunc(variable[i]);
        }
    }

    private bool ExplodeCell (Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);

        for (int i = 0; i < walls.Length; i++)
        {
            if (tile == walls[i])
            {
                return false;
            }
        }

        if (tile == destructibleWall)
        {
            tilemap.SetTile(cell, ruins[Random.Range(0, 3)]);
        }

        Vector3 position = tilemap.GetCellCenterWorld(cell);
        Instantiate(explodePrefab, position, Quaternion.identity);
        return true;
    }
}


//public void Explode(Vector2 explodeWorldPosition)
//{
//    Vector3Int originCell = tilemap.WorldToCell(explodeWorldPosition);

//    ExplodeCell(originCell);

//    for (int i = 1; i < bombPower; i++)
//    {
//        //ExplodeCell(originCell + new Vector3Int(i, 0, 0));
//        if (!ExplodeCell(originCell + new Vector3Int(i, 0, 0)))
//            break;
//    }
//    for (int i = 1; i < bombPower; i++)
//    {
//        //ExplodeCell(originCell + new Vector3Int(-i, 0, 0));
//        if (!ExplodeCell(originCell + new Vector3Int(-i, 0, 0)))
//            break;
//    }
//    for (int i = 1; i < bombPower; i++)
//    {
//        //ExplodeCell(originCell + new Vector3Int(0, i, 0));
//        if (!ExplodeCell(originCell + new Vector3Int(0, i, 0)))
//            break;
//    }
//    for (int i = 1; i < bombPower; i++)
//    {
//        //ExplodeCell(originCell + new Vector3Int(0, -i, 0));
//        if (!ExplodeCell(originCell + new Vector3Int(0, -i, 0)))
//            break;
//    }
//}
