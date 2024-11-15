using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed Instance { get; private set; }

    public float initialGameSpeed = 1f;
    public float gameSpeedIncrease;
    public float maxGameSpeed;

    public float gameSpeed { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }
    private void Update()
    {
        if (gameSpeed < maxGameSpeed)
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
        }
        else
        {
            gameSpeed = maxGameSpeed;
        }
    }
}
