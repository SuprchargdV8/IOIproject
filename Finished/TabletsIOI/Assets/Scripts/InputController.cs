using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Animation anime;
    private CameraMove cameraMove;
    private MoveTablets tabletMover;
    private bool drag;
    private float prevDrag;
    private float previousMove;
    private bool zoom;
    public void Start(){
        zoom = false;
        drag = false;
        anime = this.GetComponent<Animation>();
        cameraMove = GameObject.Find("Camera").GetComponent<CameraMove>();
        tabletMover = GameObject.Find("Tablets").GetComponent<MoveTablets>();
    }
    public void OnPointerDown(PointerEventData eventData){
        //empty
    }

    public void OnPointerUp(PointerEventData eventData){
        if(!drag){
            cameraMove.setZoom();
            zoom = cameraMove.zoom;
            if(zoom) anime.Play("Cube_RotateIn");
            else anime.Play("Cube_RotateOut");
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(!zoom){
            tabletMover.move(prevDrag - eventData.position[0]);
            prevDrag = eventData.position[0];
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        if(!zoom){
            drag = true;
            prevDrag = eventData.position[0];
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(!zoom){
            drag = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        
    }
}
