// This script should be attached to a Camera object 
// in Unity which acts as a mirror camera behind a 
// mirror. Once a Plane object is specified as the 
// "mirrorPlane" and a "mainCamera" is set, the script
// computes the mirrored position of the "mainCamera" 
// and places the script's camera at that position.

@script ExecuteInEditMode()
#pragma strict

public var mirrorPlane : GameObject;
public var mainCamera : Camera;

private var cameraComponent : Camera;

function Update() {
   cameraComponent = GetComponent(Camera);
   if (null != mirrorPlane && null != mainCamera 
      && null != cameraComponent)
   {
   
      var positionInMirrorSpace : Vector3 = 
         mirrorPlane.transform.InverseTransformPoint(
         mainCamera.transform.position);
      positionInMirrorSpace.y = -positionInMirrorSpace.y;
      cameraComponent.transform.position = 
         mirrorPlane.transform.TransformPoint(
         positionInMirrorSpace);
   }
}