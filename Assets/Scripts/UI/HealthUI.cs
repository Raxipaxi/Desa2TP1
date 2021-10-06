using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
   }

    public void InitSlider(int inithealth)
    {
        _slider.value =  inithealth;
    }

    public void ModifyHealthbar(int damage)
    {
        _slider.value -= damage;
    }
}
