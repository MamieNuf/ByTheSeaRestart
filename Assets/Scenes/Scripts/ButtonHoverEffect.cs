using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverIcon; // L'icône à afficher en hover
    private BobSwingEffect bobSwingEffect; // Référence au script de balancement

    private void Start()
    {
        if (hoverIcon != null)
        {
            hoverIcon.SetActive(false); // Cache l'icône par défaut
            bobSwingEffect = hoverIcon.GetComponent<BobSwingEffect>(); // Récupère le script BobSwingEffect sur l'icône
        }
    }

    // Méthode appelée quand la souris entre sur le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverIcon != null)
        {
            hoverIcon.SetActive(true); // Affiche l'icône
            if (bobSwingEffect != null)
            {
                bobSwingEffect.StartSwinging(); // Lance l'animation de balancement
            }
        }
    }

    // Méthode appelée quand la souris quitte le bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverIcon != null)
        {
            hoverIcon.SetActive(false); // Cache l'icône
            if (bobSwingEffect != null)
            {
                bobSwingEffect.StopSwinging(); // Arrête l'animation de balancement
            }
        }
    }
}
