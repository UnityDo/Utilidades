using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Magia))]
public class MagiaEditor : Editor
{
	public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
	{
		Magia magia = (Magia)target;
		if (magia.icono == null)
			return null;
		Texture2D tex2d = magia.icono.texture;

		// example.PreviewIcon must be a supported format: ARGB32, RGBA32, RGB24,
		// Alpha8 or one of float formats
		Texture2D tex = new Texture2D(width, height);
		EditorUtility.CopySerialized(tex2d, tex);

		return tex;
	}
}