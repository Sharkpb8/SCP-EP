using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable_UI : MonoBehaviour
{
    public TextMeshProUGUI InteractText;
    Ray ray;
    RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.red);
        if (Physics.Raycast(ray, out hit, 5) && hit.collider.CompareTag("Interactable"))
        {
            enable(true);
        }
        else
        {
            enable(false);
        }
        
    }

    private void enable(bool enable){
        InteractText.gameObject.SetActive(enable);
    }
}
