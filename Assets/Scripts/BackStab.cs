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
            if (Vector3.Dot(forward, direction.normalized) > signAngle && direction.magnitude < signDist)
            {
                RaycastHit hit;
                Physics.Raycast(transform.position, direction, out hit);      
                
                if (hit.collider.tag == "Player")
                {
                    CharacterMovemebt.instance.SetCanBackStab(false);
                    warning.SetActive(true);
                    Vector3 rayDirection = hit.collider.transform.position - transform.position;
                    Debug.DrawRay(transform.position, rayDirection, Color.yellow, 0.1f);
                }
            }

            if (Vector3.Dot(forward, direction.normalized) < -backStabAngle && Vector3.Dot(forward, player.transform.forward) > backStabAngle && direction.magnitude < backStabDis)
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
            print(gameObject + " : Activate");
        }
        else
        {
            print(gameObject + " : desactivate");
        }
    }

    private void UpdateUI()
    {
        back.SetActive(false);
        warning.SetActive(false);
    }
}
