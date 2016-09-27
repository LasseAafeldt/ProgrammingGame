#pragma strict

var ray: Ray ;
var hit: RaycastHit;
var prefab: GameObject;
function Start () {
    prefab = GameObject.Find("CloneCube");
}

function Update () {

}

function OnMouseDown(){
    ray=Camera.main.ScreenPointToRay(Input.mousePosition);
    if(Physics.Raycast(ray,hit))
    {
        Debug.Log("Creating game object..");
        var obj : GameObject = Instantiate(prefab,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity);
    }
}