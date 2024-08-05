using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image healthValue;

    private void Start()
    {
        health.onHealthChange.AddListener(UpdateHP);
    }

    private void UpdateHP(int healthpoint, int maxhealth)
    {
        healthValue.fillAmount = (float)((float)healthpoint / (float)maxhealth);
    }
}
