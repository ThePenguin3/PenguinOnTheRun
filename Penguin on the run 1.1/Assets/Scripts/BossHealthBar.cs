using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{   
    
    public Text bossName;
    Slider slider;
    
    private void Awake() 
    {
        slider = GetComponentInChildren<Slider>();
        bossName = GetComponentInChildren<Text>();
    }
    private void Start()
    {
        SetBossHealthBarInactive();
    }
    public void SetBossName(string name)
    {
        bossName.text = name;
    }
    
    public void SetBossHealthBarActive()
    {
        slider.gameObject.SetActive(true);
    }
    
    public void SetBossHealthBarInactive()
    {
        slider.gameObject.SetActive(false);
    }

    public void SetMaxBossHealth(float currentHealth, float maxHealth)
    {
        slider.gameObject.SetActive(currentHealth < maxHealth);
        slider.maxValue = maxHealth;
        
    }
    public void SetBossHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }

    


}
