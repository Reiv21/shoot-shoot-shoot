using TMPro;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    static int ironCoins = 0;
    static int goldCoins = 0;
    
    //public float damageBoost = 1;
    //public float attackSpeedBoost = 1;
    //public float maxAmmoBoost = 1;
    //public float recoilBoost = 1;
    //public float reloadSpeedBoost = 1;
    
    public static float healthRegenBoost = 1;
    public static float maxHealthBoost = 1;
    [SerializeField] Health healthScript;
    public static float speedBoost = 1;
    [SerializeField] PlayerCharacter characterScript;
    
    public static float earnIronCoinsBoost = 1;
    public static float earnGoldCoinsBoost = 1;
    
    [SerializeField] TMP_Text ironCoinsText;
    [SerializeField] TMP_Text goldCoinsText;
    void Start()
    {
        RefreshUpgrades();
        InvokeRepeating(nameof(RefreshText), 0 , 0.5f);
    }
    public static void AddIron(int amount)
    {
        ironCoins += (int) ( amount * earnIronCoinsBoost);
    }
    public static void AddGold(int amount)
    {
        goldCoins += (int) ( amount * earnGoldCoinsBoost);
    }
    
    public bool CanAfford(int iron, int gold )
    {
        return ironCoins >= iron && goldCoins >= gold;
    }

    void RefreshUpgrades()
    {
        healthScript.maxHealth += maxHealthBoost;
        healthScript.regenOfHealthPerSecound += healthRegenBoost;
        characterScript.speed += speedBoost;
    }

    void RefreshText()
    {
        ironCoinsText.text = "iron: " + ironCoins;
        goldCoinsText.text = "gold: " + goldCoins;
    }
}
