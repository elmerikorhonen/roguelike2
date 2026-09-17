using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public BoardManager BoardManager;
    public PlayerController PlayerController;

    public TurnManager m_TurnManager;
    private int m_FoodAmount = 100;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TurnManager = new TurnManager();
        m_TurnManager.OnTick += OnTurnHappen;

        BoardManager.Init();

        PlayerController.Spawn(BoardManager, new Vector2Int(1, 1));
    }
    void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        Debug.Log("Current amount of food : " + m_FoodAmount);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
