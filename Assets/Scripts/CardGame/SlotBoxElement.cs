using UnityEngine;
using UnityEngine.EventSystems;

namespace CardGame
{
    public class SlotBoxElement : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount > 0)
            {
                return;
            }
            
            Debug.Log("On Drop");
            GameObject draggedObject = eventData.pointerDrag;
            BoxElement boxElement = draggedObject.GetComponent<BoxElement>();
            boxElement.parentToReturnTo = transform;
        }
        // public void OnBeginDrag(PointerEventData eventData)
        // {
        //     Debug.Log("On Begin Drag");
        // }
        //
        // public void OnDrag(PointerEventData eventData)
        // {
        //     transform.position = eventData.position;
        //     Debug.Log("On Drag");
        // }
        //
        // public void OnEndDrag(PointerEventData eventData)
        // {
        //     Debug.Log("On End Drag");
        // }
    }
}