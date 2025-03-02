using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using TMPro;

public class UpgradeBuyer : MonoBehaviour
{
    public float distance;

    public int priceFor1;
    public int priceFor2;
    public int priceFor3;
    public int priceFor4;

    public PhysicMaterial cube;

    public TextMeshProUGUI price;
    public TextMeshProUGUI desc;

    public GameObject shopTPER;

    public Transform shoplo, homelo;

    public Transform player;


    private void Start()
    {
        cube.dynamicFriction = 1f;
        cube.staticFriction = 1f;
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if(hit.collider.name == "Upgrade 1")
            {
                price.gameObject.SetActive(true);
                price.text = $"Price: {priceFor1}";
                desc.text = "Increases block bucko gains by 1";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(PreventPlayerFall.currencyValue >= priceFor1)
                    {
                        PreventPlayerFall.currencyValue -= priceFor1;
                        PreventPlayerFall.CubeMultiplier += 1;
                        float newPrice = priceFor1 * 1.2f;
                        priceFor1 = (int)Mathf.Round(newPrice);
                    }
                }
            }
            else if (hit.collider.name == "Upgrade 2")
            {
                price.gameObject.SetActive(true);
                price.text = $"Price: {priceFor2}";
                desc.text = "Reduces block friction";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (PreventPlayerFall.currencyValue >= priceFor2)
                    {
                        PreventPlayerFall.currencyValue -= priceFor2;
                        cube.dynamicFriction /= 1.15f;
                        cube.staticFriction /= 1.15f;

                        float newPrice = priceFor2 * 1.2f;
                        priceFor2 = (int)Mathf.Round(newPrice);
                    }
                }

            }
            else if (hit.collider.name == "Upgrade 3")
            {
                price.gameObject.SetActive(true);
                price.text = $"Price: {priceFor4}";
                desc.text = "Increases Speed";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (PreventPlayerFall.currencyValue >= priceFor4)
                    {
                        PreventPlayerFall.currencyValue -= priceFor4;
                        FirstPersonController player = GetComponentInParent<FirstPersonController>();

                        player.sprintSpeed += 0.7f;
                        player.walkSpeed += 0.5f;

                        float newPrice = priceFor4 * 1.2f;
                        priceFor4 = (int)Mathf.Round(newPrice);
                    }
                }

            }
            else if (hit.collider.tag == "Tel Store")
            {
                price.gameObject.SetActive(true);
                price.text = $"Price: {priceFor3}";
                desc.text = "Activates teleporter, which allows fast travel from, and to, the shop.";

                if (Input.GetKeyDown(KeyCode.E) && PreventPlayerFall.currencyValue - priceFor3 >= 0)
                {
                   PreventPlayerFall.currencyValue -= priceFor3;
                   hit.collider.tag = "A STore";
                   shopTPER.SetActive(true);
                }

            }
            else if (hit.collider.tag == "A STore")
            {
                price.gameObject.SetActive(true);
                price.text = $"Teleporter";
                desc.text = "Go to shop? (E)";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Teleport to shop
                    player.position = shoplo.position;
                }

            }
            
            else if (hit.collider.tag == "A Home")
            {
                price.gameObject.SetActive(true);
                price.text = $"Teleporter";
                desc.text = "Go to main area? (E)";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Teleport to main area
                    player.position = homelo.position;
                }

            }
            else if (hit.collider.tag == "shopkeeper")
            {
                price.gameObject.SetActive(true);
                price.text = $"Shop Keeper";
                desc.text = "Talk (E)";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Teleport to shop
                    player.position = shoplo.position;
                }

            }
            else
            {
                price.gameObject.SetActive(false);
            }
    }
        else
        {
            price.gameObject.SetActive(false);

        }
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
    }
}
