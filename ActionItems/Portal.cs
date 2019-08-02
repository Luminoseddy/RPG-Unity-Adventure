using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    [SerializeField] private Portal[] linkedPortals; /* Array of portals */

    public  Vector3          TeleportLocation { get; set; }
    private PortalController PortalController { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PortalController = FindObjectOfType<PortalController>();
        /* Position we teleport to */
        // TeleportLocation = transform.position + (Vector3.right * 2f);
        TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
       PortalController.ActivatePortal(linkedPortals);
       // playerAgent.ResetPath();
    }
}
