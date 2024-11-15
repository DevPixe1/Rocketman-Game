using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public  float jumpforce;
    private bool engineIsOn;
    public Sprite Explosion;
    public GameObject DeadText;
    public GameObject RestartButton;

    public TextMeshProUGUI CoinAmount;
    private int coinCollected;

    public GameObject pauseMenuPanel;
    public GameObject pauseButton;

    private bool Paused;
    private bool Alive;

    [SerializeField] private SkinManager skinManager;

    [SerializeField]
    public GameObject fire;

    [SerializeField]
    private TextMeshProUGUI fuelMeter;
    public static int fuelAmount;
    private float burnTimer;

    void Start()
    {
        Alive = true;
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;

        coinCollected = PlayerPrefs.GetInt("coinCollected");
        engineIsOn = false;
        fire.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

        fuelAmount = 100;
        Time.timeScale = 0f;
    }
    void Update()
    {
        UpdateCoins();
        if (Alive == true)
        {
            fuelMeter.text = fuelAmount.ToString() + "%";
            PlayerPrefs.SetInt("coinCollected", coinCollected);
            if (Paused == false)
            {
                if (fuelAmount == 0)
                {
                    engineIsOn = false;
                    fire.SetActive(false);
                }
                //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && fuelAmount > 0)
                if (Input.GetMouseButtonDown(0) && fuelAmount > 0)
                {
                    fire.SetActive(true);
                    engineIsOn = true;
                    Time.timeScale = 1f;
                }
                //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                if (Input.GetMouseButtonUp(0))
                {
                    fire.SetActive(false);
                    engineIsOn = false;
                }
                bool burningFuel = Input.GetMouseButton(0) && fuelAmount > 0;
                if (burningFuel)
                {
                    burnTimer -= Time.deltaTime;
                    while (burnTimer <= 0)
                    {
                        fuelAmount -= 1;
                        burnTimer += 0.085f;
                    }
                }
            }

        }
    }
    private void FixedUpdate()
    {
        switch (engineIsOn)
        {
            case true:
                rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Force);
                break;
            case false:
                rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCollected += 1;
        }
        if (other.CompareTag("Building") || other.CompareTag("Object"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Explosion;
            Time.timeScale = 0f;
            DeadText.SetActive(true);
            RestartButton.SetActive(true);
            Alive = false;
        }
    }
    private void UpdateCoins()
    {
        CoinAmount.text = coinCollected.ToString();
        CoinAmount.text = Mathf.FloorToInt(coinCollected).ToString("D5");
    }
    public void Pause()
    {
        Paused = true;
        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Paused = false;
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
