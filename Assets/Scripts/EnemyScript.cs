using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public EnemyTrigger enemyTrigger;
    public float Speed = 4f;
    public float EnemyHealth = 0;

    public bool Dead;
    public bool IsHit = false;

    public float DeathForce;
    Rigidbody Rig;

    public AudioSource DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTrigger.PlayerPresence && !Dead)
        {
            Vector3 pos = Vector3.MoveTowards(Rig.position, Player.position, Speed * Time.deltaTime);
            Rig.MovePosition(pos);
            transform.LookAt(Player);
        }

        if (Vector3.Distance(Rig.position, Player.position) <= 2)
        {
            if (!IsHit && !Dead)
            {
                Debug.Log("Au");
                IsHit = true;
                if (FindObjectOfType<PlayerHealth>().PHealth > 0)
                {
                    FindObjectOfType<PlayerHealth>().Damage(1);
                    
                    Rig.AddForce((Rig.position - Player.position).normalized * 100);
                    IsHit = false;
                }
            }
        }

    }

    public void OnLightning()
    {
        EnemyHealth -= 5 * Time.deltaTime;
        if (EnemyHealth < 0 && !Dead)
        {
            EnemyDeath();
            Dead = true;
        }
    }

    public void EnemyDeath()
    {
        DeathSoundEffect();
        Rig.constraints = RigidbodyConstraints.None;
        Rig.AddForce(Camera.main.transform.forward * DeathForce);
    }

    void DeathSoundEffect()
    {
        DeathSound.Play();
    }
}
