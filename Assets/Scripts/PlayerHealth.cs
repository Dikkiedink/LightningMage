using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text PHealthText;
    public float PHealth = 0f;
    public float InvincibleTimer;

    public AudioSource HitSound;

    // Update is called once per frame
    void Update()
    {
        PHealthText.text = PHealth.ToString();
        InvincibleTimer -= Time.deltaTime;

        if (PHealth <= 0f)
        {
            FindObjectOfType<NewPlayerMovement>().Dead = true;
        }
    }

    public void Damage(float damage)
    {
        if (InvincibleTimer <= 0)
        {
            HitSoundEffect();
            PHealth -= damage;
            InvincibleTimer = 1;
        }
    }

    void HitSoundEffect()
    {
        HitSound.Play();
    }
}