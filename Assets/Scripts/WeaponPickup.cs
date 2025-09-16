using TMPro;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private string mensajePickup = "Has obtenido el arma";
    public GameObject haveWeaponText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();

            if (playerAttack != null)
            {
                playerAttack.hasWeapon = true;
                haveWeaponText.gameObject.SetActive(true);
                Debug.Log(mensajePickup);
            }

            Destroy(gameObject); // Destruye el objeto del arma
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (haveWeaponText.gameObject.activeSelf == true)
        {
            //desactiva texto
            haveWeaponText.gameObject.SetActive(false);
        }
    }




}