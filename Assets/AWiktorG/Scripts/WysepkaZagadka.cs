using UnityEngine;

public class WysepkaZagadka : MonoBehaviour
{
    public GameObject przycisk;
    public GameObject[] wysepki;

    private bool isNearButton = false;

    public Color przyciskOdkrytyKolor = Color.green;
    public Color przyciskUkrytyKolor = Color.red;

    private void Start()
    {
        foreach (GameObject wysepka in wysepki)
        {
            wysepka.GetComponent<MeshRenderer>().enabled = false;
            //wysepka.GetComponent<Collider>().enabled = false;


        }
    }

    private void Update()
    {
        Debug.Log("Metoda Update() dzia³a");

        if (isNearButton)
        {
            Debug.Log("Gracz jest w pobli¿u przycisku");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Naciœniêto przycisk E");

                foreach (GameObject wysepka in wysepki)
                {
                    wysepka.GetComponent<MeshRenderer>().enabled = true;
                    //wysepka.GetComponent<Collider>().enabled = true;
                    // Ustaw kolor przycisku na odkryty kolor
                    przycisk.GetComponent<Renderer>().material.color = przyciskOdkrytyKolor;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter wywo³ane przez: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz w pobli¿u przycisku");
            isNearButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit wywo³ane przez: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        
            Debug.Log("Gracz opuœci³ obszar przycisku");

            isNearButton = false;
        foreach (GameObject wysepka in wysepki)
        {
            wysepka.GetComponent<MeshRenderer>().enabled = false;
            //wysepka.GetComponent<Collider>().enabled = false;
            // Ustaw kolor przycisku na ukryty kolor
            przycisk.GetComponent<Renderer>().material.color = przyciskUkrytyKolor;
        }
        
    }
}


