using UnityEngine;

public class Object : MonoBehaviour
{
    public int value;
    public GameObject dollarPickup;
    public GameObject bombPickup;
    private GameManager gameManager;
    private PlayerStatistic playerStatistic;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerStatistic = FindObjectOfType<PlayerStatistic>();
        if (value == 5000) GetComponent<Animator>().SetTrigger("Is5000");
    }

    private void Start()
    {
        Invoke(nameof(DestroyObjectAfterSeconds), 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        if (gameObject.name.Contains("Dollar")) PickupDollar(collision.transform.position);
        if (gameObject.name.Contains("Bomb")) PickupBomb(collision.transform.position, collision.gameObject);
    }

    private void PickupDollar(Vector2 position)
    {
        GameObject dollarObject = Instantiate(dollarPickup, position, Quaternion.identity);
        dollarObject.GetComponent<DollarCollision>().SetAmountText(value);
        playerStatistic.gameInstanceScore += value;
        Destroy(gameObject);
    }

    private void PickupBomb(Vector2 position, GameObject player)
    {
        FindObjectOfType<AudioController>().EnableFilter();
        Destroy(player);
        Destroy(GameObject.Find("Player"));
        Time.timeScale = 0.5f;
        Instantiate(bombPickup, position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void DestroyObjectAfterSeconds()
    {
        Destroy(gameObject);
    }
}
