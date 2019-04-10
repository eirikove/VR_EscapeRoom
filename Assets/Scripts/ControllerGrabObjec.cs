
using UnityEngine;
using Valve.VR;

public class ControllerGrabObjec : MonoBehaviour
{
    int a;
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2
    private Light light;
    private SwitchScript lightSwitch;

    private Wires wireObj;
    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    
    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject  || !col.GetComponent<Collider>())
        {
            return;

        }
        // 2
        collidingObject = col.gameObject;
    }


    void Start()
    {
        light = GameObject.FindGameObjectWithTag("fLight").GetComponent<Light>();
        lightSwitch = GameObject.FindGameObjectWithTag("lightswitch").GetComponent<SwitchScript>();
    }


    // Update is called once per frame
    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        string objName = collidingObject.name;
        Debug.Log("Grabbed " + objName);
        if (objName == "red" || objName == "yellow" || objName == "green")
        {
            wireObj = collidingObject.GetComponent<Wires>();
            wireObj.incrementSolutions();
            if(wireObj.SolutionsFound == 3)
            {
                wireObj.winGame();
            }
        }

        if (objName == "blue")
        {
            wireObj = collidingObject.GetComponent<Wires>();
            wireObj.loseGame();
        }

        if(objName == "Flashlight")
        {
            light.enabled = true;
            lightSwitch.enableClue();
        }

        if(objName == "lightswitch")
        {
            lightSwitch.switchEffect();

        }

        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        Debug.Log("Released " + objectInHand.name);
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().useGravity = true;
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        // 4
        if (objectInHand.name == "Flashlight")
        {
            light = GameObject.FindGameObjectWithTag("fLight").GetComponent<Light>();
            light.enabled = false;
            lightSwitch.disableClue();
        }

        objectInHand = null;
        
    }


}
