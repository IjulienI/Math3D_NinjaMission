using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackStab : MonoBehaviour
{
    [Header("References")]    
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject back;
    [Header("")]
    [Header("Settings")]
    [Header("BackStab")]
    [SerializeField] private float backStabDis;
    [SerializeField] private float backStabAngle;
    [Header("Vision")]
    [SerializeField] private float signDist;
    [SerializeField] private float signAngle;
    [Header("Optimisation")]
    [SerializeField] private float minDistForStart;

    private GameObject player;

    private void Start()
    {
        UpdateUI();
        player = CharacterMovemebt.instance.gameObject;
    }
    private void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 direction = player.transform.position - transform.position;

        if(direction.magnitude < minDistForStart )
        {
            UpdateUI();
            GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255, 255);

            if (Vector3.Dot(forward, direction.normalized) > signAngle && direction.magnitude < signDist)
            {
                CharacterMovemebt.instance.SetCanBackStab(false);
                warning.SetActive(true);
            }

            if (Vector3.Dot(forward, direction.normalized) < -signAngle && Vector3.Dot(forward, player.transform.forward) > backStabAngle && direction.magnitude < backStabDis)
            {                
                if (CharacterMovemebt.instance.GetCanBackstab())
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(gameObject);
                    }
                    back.SetActive(true);
                }
                CharacterMovemebt.instance.SetCanBackStab(true);
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 50);
        }
    }

    private void UpdateUI()
    {
        back.SetActive(false);
        warning.SetActive(false);
    }
}
