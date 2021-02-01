using UnityEngine;

[RequireComponent(typeof(WaterFloat))]
public class WaterBoard : MonoBehaviour
{

    //visible Properties
    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected Camera Camera;

    //internal Properties
    protected Vector3 CamVel;
    protected Vector2 user_vector;


    int discoveryStatus = 0;
    /*   Vector3 x1 = new Vector3(1.0f, 0.0f, 1.0f);  // right top
       Vector3 y1 = new Vector3(1.0f, 0.0f, -1.0f);  // right bottom
       Vector3 z1 = new Vector3(-1.0f, 0.0f, 1.0f);   // left top
       Vector3 w1 = new Vector3(-1.0f, 0.0f, -1.0f); // left bottom*/

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
        Camera = Camera.main;

        Wii.WakeUp();
        if (!Wii.GetIsAwake())
        {
            Wii.WakeUp();
        }
       
        Wii.StartSearch();
        discoveryStatus = Wii.GetDiscoveryStatus();
       
        if (discoveryStatus > 99)
        {
            Wii.AddVirtualRemote();
        }

    }
    public void Start()
    {
        /* Wii.StartSearch();
         Wii.GetDiscoveryStatus();
         int status = ;
         while (Wii.GetDiscoveryStatus() != 100)
         {
             if (Wii.IsActive(3))
             {

             }
         }*/

    }

    public void FixedUpdate()
    {


        // a -> Z-axis, b -> X-axis
        float x_axes = ((Wii.GetBalanceBoard(0).x + Wii.GetBalanceBoard(0).z) -   ////////////var x_axes yerine float yazdım
            (Wii.GetBalanceBoard(0).y + Wii.GetBalanceBoard(0).w));

        float z_axes = ((Wii.GetBalanceBoard(0).x + Wii.GetBalanceBoard(0).y) -
           (Wii.GetBalanceBoard(0).w + Wii.GetBalanceBoard(0).z));

        if (Wii.GetTotalWeight(0) > 0)
        {

            // Move translation along the object's z-axis

            Rigidbody.AddRelativeForce(x_axes/8, 0, z_axes/5);

         //   Debug.Log("x_axes: " + x_axes/8 + "\tz_axes: " + z_axes/5);
        }
    }
}
