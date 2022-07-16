using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ColorfulCube : MonoBehaviour {
  MeshRenderer _meshRenderer;

  void Start() {
    _meshRenderer = GetComponent<MeshRenderer>();
    StartCoroutine(ChangeColorOnce(Color.blue));
  }

  IEnumerator ChangeColorOnce(Color targetColor) {
    yield return new WaitForSeconds(seconds: 1f);

    _meshRenderer.material.SetColor("_Color", targetColor);
  }

  void Update() {

  }
}
