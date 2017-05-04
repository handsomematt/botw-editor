using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BotWWorldViewer.Graphics
{
    internal enum RenderLayer : byte
    {
        Base = 0,
        Alpha1 = 1,
        Alpha2 = 2
    }

    internal class TerrainShader : ShaderProgram3D
    {
        private Terrain myCurrentTerrain;

        private Vector3 myModelPos;
        private int myModelPosLoc;

        private Quaternion myModelRot;
        private int myModelRotLoc;

        private Color4 myColour;
        private int myColourLoc;

        private Color4 myFogColour;
        private int myFogColourLoc;
        private int myFogDensityLoc;

        private bool myAlphaMask;
        private int myAlphaMaskLoc;

        private bool myBackfaceCulling;

        public Vector3 ModelPos
        {
            get { return myModelPos; }
            set
            {
                myModelPos = value;
                GL.Uniform3(myModelPosLoc, value);
            }
        }
        public Quaternion ModelRot
        {
            get { return myModelRot; }
            set
            {
                myModelRot = value;
                GL.Uniform4(myModelRotLoc, value);
            }
        }
        public Color4 Colour
        {
            get { return myColour; }
            set
            {
                myColour = value;
                GL.Uniform4(myColourLoc, value);
            }
        }
        public Color4 FogColour
        {
            get { return myFogColour; }
            set
            {
                myFogColour = value;
                GL.Uniform3(myFogColourLoc, value.R, value.G, value.B);
            }
        }
        public bool AlphaMask
        {
            get { return myAlphaMask; }
            set
            {
                if (value != myAlphaMask)
                {
                    myAlphaMask = value;
                    GL.Uniform1(myAlphaMaskLoc, value ? 1 : 0);
                }
            }
        }

        public bool BackfaceCulling
        {
            get { return myBackfaceCulling; }
            set
            {
                if (myBackfaceCulling != value)
                {
                    myBackfaceCulling = value;
                    if (value)
                        GL.Enable(EnableCap.CullFace);
                    else
                        GL.Disable(EnableCap.CullFace);
                }
            }
        }

        public TerrainShader()
        {
            ShaderBuilder vert = new ShaderBuilder(ShaderType.VertexShader, false);
            vert.AddUniform(ShaderVarType.Mat4, "view_matrix");
            vert.AddUniform(ShaderVarType.Vec3, "model_pos");
            vert.AddUniform(ShaderVarType.Vec4, "model_rot");
            vert.AddUniform(ShaderVarType.Vec4, "colour");
            vert.AddUniform(ShaderVarType.Float, "fog_density");
            vert.AddAttribute(ShaderVarType.Vec3, "in_position");
            vert.AddAttribute(ShaderVarType.Vec2, "in_texcoord");
            vert.AddAttribute(ShaderVarType.Vec4, "in_colour");
            vert.AddVarying(ShaderVarType.Vec2, "var_texcoord");
            vert.AddVarying(ShaderVarType.Vec4, "var_colour");
            vert.AddVarying(ShaderVarType.Float, "var_fogfactor"); // vec4( qtransform( model_rot, in_position ) + model_pos, 1 );
            vert.Logic = @"
                vec3 qtransform( vec4 q, vec3 v )
                { 
	                return v + 2.0 * cross( cross( v, q.xyz ) + q.w * v, q.xyz );
	            }
                void main( void )
                {
                    gl_Position = view_matrix * vec4(in_position, 1.0); 
                    var_texcoord = in_texcoord;
                    var_colour = colour * in_colour;
                    var_colour = vec4(1.0, 1.0 - (1.0 / (in_position.y / 10.0)), 1.0 - (1.0 / (in_position.y / 10.0)), 1.0);
                    const float LOG2 = 1.442695;
                    float dist = length( gl_Position );
                    var_fogfactor = exp2( - fog_density * fog_density * dist * dist * LOG2 );
                    var_fogfactor = clamp( var_fogfactor, 0.0, 1.0 );
                }
            ";

            ShaderBuilder frag = new ShaderBuilder(ShaderType.FragmentShader, false);
            frag.AddUniform(ShaderVarType.Sampler2D, "tex_diffuse");
            frag.AddUniform(ShaderVarType.Sampler2D, "tex_mask");
            frag.AddUniform(ShaderVarType.Bool, "flag_mask");
            frag.AddUniform(ShaderVarType.Vec3, "fog_colour");
            frag.AddVarying(ShaderVarType.Vec2, "var_texcoord");
            frag.AddVarying(ShaderVarType.Vec4, "var_colour");
            frag.AddVarying(ShaderVarType.Float, "var_fogfactor");
            frag.Logic = @"
                void main( void )
                {
                    if( var_colour.a == 0.0 || var_fogfactor == 1.0 )
                        discard;
                    vec4 clr = texture2D( tex_diffuse, var_texcoord );
                    if( clr.a < 0.5 )
                        discard;
                    if( flag_mask && texture2D( tex_mask, var_texcoord ).a < 0.5 )
                        discard;
                    out_frag_colour = var_colour;
                }
            ";

            // out_frag_colour = vec4( clr.rgb * var_colour.rgb, clr.a * var_colour.a );

            VertexSource = vert.Generate(GL3);
            FragmentSource = frag.Generate(GL3);

            BeginMode = BeginMode.TriangleStrip;

            myColour = Color4.White;
            myAlphaMask = false;

            myBackfaceCulling = false;

            Create();
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            AddAttribute("in_position", 3);
            AddAttribute("in_texcoord", 2);
            AddAttribute("in_colour", 4);

            AddTexture("tex_diffuse", TextureUnit.Texture0);
            AddTexture("tex_mask", TextureUnit.Texture1);

            myModelPosLoc = GL.GetUniformLocation(Program, "model_pos");
            myModelRotLoc = GL.GetUniformLocation(Program, "model_rot");
            myColourLoc = GL.GetUniformLocation(Program, "colour");
            myFogColourLoc = GL.GetUniformLocation(Program, "fog_colour");
            myFogDensityLoc = GL.GetUniformLocation(Program, "fog_density");
            myAlphaMaskLoc = GL.GetUniformLocation(Program, "flag_mask");

            ModelPos = new Vector3();
            Colour = Color4.White;
            AlphaMask = false;
        }

        protected override void OnStartBatch()
        {
            base.OnStartBatch();

            if (Camera != null)
                GL.Uniform1(myFogDensityLoc, 2.0f / Camera.ViewDistance);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.PrimitiveRestart);

            GL.CullFace(CullFaceMode.Back);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PrimitiveRestartIndex(0xffff);

            myCurrentTerrain = null;
        }

        public void Render(Terrain terrain)
        {
            if (terrain != myCurrentTerrain)
            {
                if (myCurrentTerrain != null)
                    myCurrentTerrain.VertexBuffer.EndBatch(this);

                lock (terrain)
                    if (terrain.VertexBuffer == null)
                        terrain.SetupVertexBuffer();

                terrain.VertexBuffer.StartBatch(this);
                myCurrentTerrain = terrain;
            }

            terrain.Render(this);
        }

        protected override void OnEndBatch()
        {
            if (myCurrentTerrain != null)
                myCurrentTerrain.VertexBuffer.EndBatch(this);
            
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.PrimitiveRestart);
        }
    }
}
