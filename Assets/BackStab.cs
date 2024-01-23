using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackStab : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
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
    

    private void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 direction = player.transform.position - transform.position;

        if(direction.magnitude < minDistForStart )
        {
            Debug.Log(gameObject + " Start Detection");
            if (Vector3.Dot(forward, direction.normalized) < -signAngle && Vector3.Dot(forward, player.transform.forward) > backStabAngle && direction.magnitude < backStabDis)
            {
                UpdateUI();
                back.SetActive(true);
                player.GetComponent<CharacterMovemebt>().CanBackStab(true);
            }
            else if (Vector3.Dot(forward, direction.normalized) > signAngle && direction.magnitude < signDist)
            {
                UpdateUI();
                warning.SetActive(true);
            }
            else if (direction.magnitude < backStabDis + .1f)
            {
                UpdateUI();
                player.GetComponent<CharacterMovemebt>().CanBackStab(false);
            }
            else
            {
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        back.SetActive(false);
        warning.SetActive(false);
    }
}
