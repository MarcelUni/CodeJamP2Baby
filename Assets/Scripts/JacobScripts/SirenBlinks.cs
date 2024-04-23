using System.Collections;
using UnityEngine;

public class SirenBlinks : MonoBehaviour
{
    [SerializeField] private GameObject lightLeft;
    [SerializeField] private GameObject lightRight;
    [SerializeField] private float sirenLightSwitchSpeed = 0.35f;
    private void Start()
    {
        lightLeft.SetActive(false);
        lightRight.SetActive(false);
        StartCoroutine(Siren());
    }

    private IEnumerator Siren()
    {
        while (true) // Infinite loop to keep the siren blinking
        {
            yield return new WaitForSeconds(sirenLightSwitchSpeed);
            lightLeft.SetActive(true);
            lightRight.SetActive(true);
            yield return new WaitForSeconds(sirenLightSwitchSpeed);
            lightLeft.SetActive(false);
            lightRight.SetActive(false);
        }
    }
}
