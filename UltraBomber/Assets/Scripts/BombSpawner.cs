using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class BombSpawner : MonoBehaviour
{
    public Tilemap tilemap;

    public GameObject bombPrefab;
    public GameObject spawnPoint;

    private bool canSpawnBomb = true;

    public int bombAmount = 3;
    public TextMeshProUGUI bombAmountText;


    private void Start()
    {
        bombAmountText.text = "x " + bombAmount.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnBomb && bombAmount > 0)
        {
            bombAmount -= 1;
            bombAmountText.text = "x " + bombAmount.ToString();

            Vector3Int cellPosition = tilemap.WorldToCell(spawnPoint.transform.position);
            Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cellPosition);

            Instantiate(bombPrefab, cellCenterPosition, Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bomb" || collision.tag == "CanNotSpawnObject")
            canSpawnBomb = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bomb" || collision.tag == "CanNotSpawnObject")
            canSpawnBomb = true;
    }

    public void bombAmountIncrease()
    {
        bombAmount += 1;
        bombAmountText.text = "x " + bombAmount.ToString();
    }
}
