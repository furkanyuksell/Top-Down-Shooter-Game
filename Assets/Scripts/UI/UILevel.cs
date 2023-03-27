using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UILevel : MonoBehaviour
{
    [SerializeField] Image _fillableBar;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] Slider _healthSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayerHealth(int health)
    {
        _healthSlider.value = (health/100f);
    }
    void SetPlayerLevel(int level)
    {
        _levelText.SetText(level.ToString());
    }
    
    void SetPlayerExp(int exp)
    {
        _fillableBar.fillAmount = (exp / 100f);
    }

    private void OnEnable()
    {
        EventManagement.OnPlayerHealth  += SetPlayerHealth;
        EventManagement.OnPlayerLevel   += SetPlayerLevel;
        EventManagement.OnPlayerExp     += SetPlayerExp;
    }

    private void OnDisable()
    {
        EventManagement.OnPlayerHealth  -= SetPlayerHealth;
        EventManagement.OnPlayerLevel   -= SetPlayerLevel;
        EventManagement.OnPlayerExp     -= SetPlayerExp;
    }
}
