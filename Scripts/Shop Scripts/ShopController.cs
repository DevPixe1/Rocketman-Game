using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Image selectedSkin;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private SkinManager skinManager;


    void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("coinCollected").ToString();
        selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }
}
