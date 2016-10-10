#pragma strict
function Start () {

}

function Update () {

}

var offset : Vector3;
var screenPoint : Vector3;
function OnMouseOver()
{
    if(Input.GetMouseButtonDown(0)) {
        Debug.Log("LEFT MOUSE PRESSED");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    if(Input.GetMouseButtonDown(1)){
        Debug.Log("RIGHT MOUSE PRESSED");
        Destroy(gameObject);
    }
}
function OnMouseDrag()
{
    var curScreenPoint : Vector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    var curPosition : Vector3 = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    transform.position = curPosition;

}