using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }
    private PortalController PortalController { get; set; }

    [SerializeField] private Portal[] linkedPortals;
    // Start is called before the first frame update
    void Start()
    {
        PortalController = FindObjectOfType<PortalController>();
        TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z); // Sets the offset when teleporting. 
    }

    public override void Interact()
    {
        PortalController.ActivatePortal(linkedPortals);
        playerAgent.ResetPath();
    
    }
}
