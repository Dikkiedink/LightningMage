using System.Collections;
using UnityEngine;

public class BloomActivator : MonoBehaviour
{
    private Color initialColour;
    public Color glowColor;
    public GateOpen GO;

    public bool StopsGate = false;
    public bool StartElevator = false;


    public void OnLightning()
    {
        StopAllCoroutines();
        StartCoroutine(setEmission(10));
        if (!StartElevator)
        {
            if (StopsGate)
            {
                GO.StopByLightning();
            }
            else
            {
                GO.OpenByLightning();
            }
        }

        else
        {
            GO.MoveByLightning();
        }
    }

    private void Start()
    {
        initialColour = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    IEnumerator setEmission(float Amount)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", glowColor);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", initialColour);
    }

}
