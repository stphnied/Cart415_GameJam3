using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouth : MonoBehaviour
{
    public Texture2D[] albedoTextures; // Set this in the Inspector with an array of textures
    public int currentIndex = 0; // Current index in the array

    void Start()
    {
        // Example: Call the SwitchAlbedoTexture function with the initial index
        // SwitchAlbedoTexture(currentIndex);
    }

    public void SwitchAlbedoTexture(int textureIndex)
    {
        // Ensure the GameObject has a Renderer component
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && albedoTextures != null && textureIndex >= 0 && textureIndex < albedoTextures.Length)
        {
            // Create a new material instance to avoid affecting other GameObjects using the same material
            Material newMaterial = new Material(renderer.sharedMaterial);

            // Assign the selected albedo texture to the material based on the index
            newMaterial.SetTexture("_MainTex", albedoTextures[textureIndex]);

            // Assign the modified material to the GameObject
            renderer.material = newMaterial;

            // Update the current index for the next texture switch
            currentIndex = textureIndex;
        }
        else
        {
            Debug.LogError("Renderer component not found on the GameObject, or invalid texture index.");
        }
    }

    // Example method to allow calling the SwitchAlbedoTexture function from elsewhere
    public void SwitchTextureExternally(int newTextureIndex)
    {
        // Call the SwitchAlbedoTexture function with the provided index
        SwitchAlbedoTexture(newTextureIndex);
    }
}
