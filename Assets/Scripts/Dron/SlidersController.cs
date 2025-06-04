
using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    [SerializeField] private Slider sliderCount;
    [SerializeField] private SpawnDron spawnDron;

    private void Update()
    {
        RegulCount();
    }

    private void RegulCount()
    {
        for(int i = 0; i < sliderCount.value; i++)
        {
            spawnDron.dronsBlue[i].SetActive(true);
            spawnDron.dronsRed[i].SetActive(true);
        }

        for (int i = (int)sliderCount.value; i < sliderCount.maxValue; i++)
        {
            spawnDron.dronsBlue[i].SetActive(false);
            spawnDron.dronsRed[i].SetActive(false);
        }
    }
}
