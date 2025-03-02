using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreventPlayerFall : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreCurrency;
    public static int scoreValue = 0;
    public static int currencyValue = 71;
    public static int CubeMultiplier = 0;
    public GameObject barrier;
    public GameObject barrier2;
    private Rigidbody rb;
    public ParticleSystem ps;
    public Transform particleSpawner;
    public AudioSource hitSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y <= -17)
        {
            transform.position = new Vector3(0, 17, 0);
            scoreValue++;
            currencyValue += 1 + CubeMultiplier;
        }

        score.text = $"Block Slides: {scoreValue}";
        scoreCurrency.text = $"Block Buckos: {currencyValue}";

        if (currencyValue >= 5)
        {
            barrier.SetActive(false);
        }

        if (currencyValue >= 75)
        {
            barrier2.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "g")
        {
            float impactForce = Mathf.Abs(other.relativeVelocity.y);
            if (impactForce > 6f)
            {
                Instantiate(ps, particleSpawner.position, Quaternion.identity);
                hitSound.Play();
            }
        }
    }
}
