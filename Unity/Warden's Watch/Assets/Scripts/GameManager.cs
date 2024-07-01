using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int points;
    public int startingPoints = 100;

    void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        points = startingPoints;
        UIManager.Instance.UpdatePointsUI(points);
    }

    public bool SpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            UIManager.Instance.UpdatePointsUI(points);
            return true;
        }
        return false;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UIManager.Instance.UpdatePointsUI(points);
    }
}
