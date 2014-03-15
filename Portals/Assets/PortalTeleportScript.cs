using UnityEngine;
using System.Collections;

public class PortalTeleportScript : MonoBehaviour
{
	public GameObject exitPortal;

	public GameObject clone;

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.name == "Graphics" || coll.gameObject.name == "First Person Controller")
			return;

		Vector3 rotation = Quaternion.LookRotation(exitPortal.transform.forward).eulerAngles;
		rotation += coll.transform.localEulerAngles;
		Quaternion QRotaition = Quaternion.identity;
		QRotaition.eulerAngles = rotation;
		
		Vector3 position = this.transform.position - coll.transform.position;
		position = Vector3.Reflect(position, this.transform.forward);
		position = exitPortal.transform.TransformDirection(position);
		position += exitPortal.transform.position;
		
		clone = Instantiate(coll.gameObject, position, QRotaition) as GameObject;
		Destroy(clone.collider);
		Destroy(clone.rigidbody);
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.name == "Graphics" || coll.gameObject.name == "First Person Controller")
			return;

		if(clone == null)
			return;

		Vector3 rotation = Quaternion.LookRotation(exitPortal.transform.forward).eulerAngles;
		rotation += coll.transform.localEulerAngles;
		clone.transform.localEulerAngles = rotation;
		
		Vector3 position = this.transform.position - coll.transform.position;
		position = Vector3.Reflect(position, this.transform.forward);
		position = exitPortal.transform.TransformDirection(position);
		position += exitPortal.transform.position;
		clone.transform.position = position;
	}

	void OnTriggerExit(Collider coll)
	{
		if(coll.gameObject.name == "Graphics" || coll.gameObject.name == "First Person Controller")
			return;

		Destroy(clone);

		Vector3 rotation = Quaternion.LookRotation(exitPortal.transform.forward).eulerAngles;
		rotation += coll.transform.localEulerAngles;
		coll.transform.localEulerAngles = rotation;

		Vector3 position = this.transform.position - coll.transform.position;
		position = Vector3.Reflect(position, this.transform.forward);
		position = exitPortal.transform.TransformDirection(position);
		position += exitPortal.transform.position;
		coll.transform.position = position;

		Vector3 velocity = coll.rigidbody.velocity;
		velocity = Vector3.Reflect(velocity, this.transform.up);
		velocity = this.transform.InverseTransformDirection(velocity);
		velocity = exitPortal.transform.TransformDirection(velocity);
		coll.rigidbody.velocity = velocity;
	}
}
