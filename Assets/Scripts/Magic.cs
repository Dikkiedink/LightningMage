using UnityEngine;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public Text magicText;
    public float lightningMagic = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        magicText.text = lightningMagic.ToString();
        lightningMagic = FindObjectOfType<Lightning>().magic;
    }
}
