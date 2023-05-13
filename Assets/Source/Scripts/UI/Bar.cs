using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    private void OnValidate()
    {
        if (Slider == null)
        {
            Slider = GetComponent<Slider>();
        }
    }

    public void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
