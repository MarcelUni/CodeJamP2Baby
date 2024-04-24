using UnityEngine;

public class RandomMaterialAssigner : MonoBehaviour
{
    [SerializeField] private Material[] materials; // Array of materials to choose from

    private void Awake()
    {
        // Check if there are materials in the array
        if (materials != null && materials.Length > 0)
        {
            // Get a random index within the bounds of the materials array
            int randomIndex = Random.Range(0, materials.Length);

            // Get the renderer component of the object
            Renderer renderer = GetComponent<Renderer>();

            // Check if the renderer component exists
            if (renderer != null)
            {
                // Assign the randomly chosen material to the renderer
                renderer.material = materials[randomIndex];
            }
            else
            {
                Debug.LogWarning("Renderer component not found on object.");
            }
        }
        else
        {
            Debug.LogWarning("No materials assigned to the array.");
        }
    }
}
