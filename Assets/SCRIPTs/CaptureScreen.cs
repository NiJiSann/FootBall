using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScreen : MonoBehaviour
{
  [SerializeField] private Camera camera;
  [SerializeField] private Image _targetImage;
  
  private int height = 1024;
  private int width = 1024;
  private int depth = 24;

  private Rect rect;
  private RenderTexture renderTexture;
  private Texture2D texture;
  private void Start()
  {
      rect = new Rect(0,0,width,height);
      renderTexture = new RenderTexture(width, height, depth);
      texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
  }

  private void Update()
  {
      _targetImage.sprite = Capture();
  }

  //method to render from camera
  public Sprite Capture() 
  {
      camera.targetTexture = renderTexture;
      camera.Render();
  
      RenderTexture currentRenderTexture = RenderTexture.active;
      RenderTexture.active = renderTexture;
      texture.ReadPixels(rect, 0, 0);
      texture.Apply();
  
      camera.targetTexture = null;
      RenderTexture.active = currentRenderTexture;
      Destroy(renderTexture);
  
      Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);
  
      return sprite;
  }
}
