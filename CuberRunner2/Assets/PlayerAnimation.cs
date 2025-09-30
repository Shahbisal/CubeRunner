using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    public GameObject cubeMesh;       // Reference to Cube
    public GameObject punithaModel;   // Reference to Punitha
    private Animator punithaAnimator;

    void Start()
    {
        punithaAnimator = punithaModel.GetComponent<Animator>();

        // Start with only Cube visible
        cubeMesh.SetActive(true);
        punithaModel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Switch from Cube to Punitha
            cubeMesh.SetActive(false);
            punithaModel.SetActive(true);

            // Play animation (replace "Run" with your animation state name)
            punithaAnimator.Play("Run");
        }
    }
}
