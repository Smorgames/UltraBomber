using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject healthBarTarget;

    private void Start()
    {
        slider.maxValue = healthBarTarget.GetComponent<Boss>().maxBossHeaelth;
        slider.value = healthBarTarget.GetComponent<Boss>().maxBossHeaelth;
    }

    public void SetCurrentHealth()
    {
        slider.value = healthBarTarget.GetComponent<Boss>().currentBossHealth;
    }
}
