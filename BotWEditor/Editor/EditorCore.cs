using BotWEditor.Editor.Components;
using BotWEditor.Forms;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace BotWEditor.Editor
{
    class EditorCore
    {
        public MainEditorForm EditorForm;

        private List<EditorObject> _editorObjectList;

        private Camera _activeCamera;
        private Stopwatch _dtStopWatch;

        public EditorCore(MainEditorForm editorForm)
        {
            EditorForm = editorForm;

            _dtStopWatch = new Stopwatch();

            _editorObjectList = new List<EditorObject>();

            EditorObject cameraObj = new EditorObject("Main Camera");
            var camera = cameraObj.AddComponent<Camera>();
            camera.Rect = new Rect(1, 1, 0, 0);
            camera.ClearColor = Color.CornflowerBlue;
            _activeCamera = camera;

            cameraObj.AddComponent<FPSCameraMovement>();

            Add(cameraObj);
        }

        public void Add(EditorObject obj)
        {
            EditorForm.EditorObjectTreeView.Nodes.Add(obj.Name);
            EditorForm.ObjectPropertyGrid.SelectedObject = obj;
            _editorObjectList.Add(obj);
        }

        public void ProcessFrame()
        {
            Time.Internal_UpdateTime(_dtStopWatch.ElapsedMilliseconds / 1000f);
            _dtStopWatch.Restart();

            Input.Internal_UpdateInputState();

            //Actual render stuff
            GL.ClearColor(_activeCamera.ClearColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(0, 0);
            GL.Vertex2(1, 0);
            GL.Vertex2(0, 1);
            GL.End();

            foreach (var editorObject in _editorObjectList)
            {
                var renderable = editorObject.GetComponent<Renderable>();

                if (renderable != null)
                    renderable.Render(_activeCamera);
            }
        }
    }
}
