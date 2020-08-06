using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lightning : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float LightningSpeed = 100f;
    public float magic = 5f;
    public float magicRecharge = 5f; //hoe hoger hoe langzamer

    public float timer = 0f;
    public float timeToRecharge = 500f;

    public bool PlayingSound = false;

    public Camera fpsCam;
    public GameObject LightningBolt;
    public GameObject PlayerMovement;

    public AudioSource LightningStart;
    public AudioSource LightningLoop;

    private float lightningTime = 0f;

    //public AudioSource Laser;


    private void Update()
    {
        if (timer <= timeToRecharge)
        {
            timer += 1 * Time.deltaTime;
        }

        //Debug.Log(timer);

        if (Input.GetButton("Fire1") && magic >= 1 && PlayerMovement.GetComponent<NewPlayerMovement>().Dead == false)
        {
            timer = 0f;
            if (Time.time >= lightningTime)
            {
                lightningTime = Time.time + 1f / LightningSpeed;
                magic--;
            }
            LightningStrike();
        }
        else if (Time.time >= lightningTime && magic <= 49 && timer >= timeToRecharge)
        {
            lightningTime = Time.time + magicRecharge / LightningSpeed;
            magic++;
        }

        if (Input.GetButtonUp("Fire1") || magic <= 0)
        {
            PlayingSound = false;
            LightningLoop.Stop();
        }

    }

    void LightningStrike()
    {
        LightningBolt.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().Trigger();
        if (!PlayingSound)
        {
            LightningStartSoundEffect();
            LightningLoopSoundEffect();
            PlayingSound = true;
        }


        RaycastHit Hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out Hit, range))
        {
            Debug.Log(Hit.transform.name);
            Hit.transform.SendMessage("OnLightning", SendMessageOptions.DontRequireReceiver);

        }
    }

    void LightningStartSoundEffect()
    {
        LightningStart.Play();
    }

    void LightningLoopSoundEffect()
    {
        LightningLoop.Play();
    }

}