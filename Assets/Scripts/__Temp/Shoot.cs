using UnityEngine;


namespace VarjoExample
{

    public class Shoot : MonoBehaviour
    {
        public float energyFactor;
        public GameObject projectilePrefab;
        public Transform projectileOrigin;


        bool buttonDown;
        float energy;
        public int a;
        public Quaternion controllerRotation;
        Controller controller;
        Rigidbody rb;
        GameObject projectile;

        void Start()
        {
            controller = GetComponent<Controller>();
        }

        void Update()
        {
            controllerRotation = controller.deviceRotation;

            if (controller.primary2DAxisClick)
            {
                if (!buttonDown)
                {
                    // Button is pressed, projectile is created
                    a = 1;
                    buttonDown = true;
                    projectile = Instantiate(projectilePrefab, projectileOrigin.transform.position, projectileOrigin.transform.rotation);
                    rb = projectile.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    projectile.transform.parent = projectileOrigin;
                }
                else
                {
                    // Button is held down, projectile gets energy
                    energy = energy + Time.deltaTime * energyFactor;
                }
            }
            else if (!controller.primary2DAxisClick && buttonDown)
            {
                // Button is released, projectile is released
                if (projectile && rb)
                {
                    a = 0;
                    rb.isKinematic = false;
                    projectile.transform.parent = null;
                    rb.AddForce(projectileOrigin.transform.forward * energy, ForceMode.Impulse);
                }
                buttonDown = false;
                energy = 0f;
            }

            
        }
    }
}