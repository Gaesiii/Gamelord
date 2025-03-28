using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   public static UIController Instance;
   [SerializeField] private Slider playerHealthSlider;
   [SerializeField] private TMP_Text Healthtext;
   void Awake()
    {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
            } else{
                Instance = this;
            }
        
    }

    public void UpdatePlayerHealthSlider()
    {
        playerHealthSlider.maxValue = PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value = PlayerController.Instance.playerHealth;
        Healthtext.text =   playerHealthSlider.value + "/" + playerHealthSlider.maxValue;
    }
}
