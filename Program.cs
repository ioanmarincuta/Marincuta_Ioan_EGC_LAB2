using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

public class Aplicatie3D : GameWindow
{
    Vector3[] coordonateCub;
    Color4[] culoriFețeCub;
    Vector3[] coordonateTriunghi;
    Color4[] culoriTriunghi;

    public Aplicatie3D() : base(800, 600, GraphicsMode.Default, "Cub si triunghi") { }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        CitesteCoordonateCubDinFisier("coordonate_cub.txt");
        CitesteCuloriFețeCubDinFisier("culori_cub.txt");
        CitesteCoordonateTriunghiDinFisier("coordonate_triunghi.txt");
        GenerareCuloriTriunghi();
        Console.WriteLine("Apasati Space pentru a afisa valorile RGB si a schimba culoarea triunghiului");
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        var state = Keyboard.GetState(); 
        

        if (state.IsKeyDown(Key.Space))
        {
            ModificareCuloareFațăCub(0, new Color4(0.0f, 0.0f, 0.0f, 1.0f));
            ModificareCuloriVertexTriunghi();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        ModificareCuloareFațăCub(0, new Color4(0.0f, 0.0f, 1.0f, 1.0f));
        DeseneazaCub();
        DeseneazaTriunghi();
        


        SwapBuffers();
    }

    private void CitesteCoordonateCubDinFisier(string numeFisier)
    {
        if (File.Exists(numeFisier))
        {
            string[] linii = File.ReadAllLines(numeFisier);
            coordonateCub = new Vector3[linii.Length];

            for (int i = 0; i < linii.Length; i++)
            {
                string[] coordonate = linii[i].Split(' ');
                if (coordonate.Length >= 3)
                {
                    if (float.TryParse(coordonate[0], out float x) && float.TryParse(coordonate[1], out float y) && float.TryParse(coordonate[2], out float z))
                    {
                        coordonateCub[i] = new Vector3(x, y, z);
                    }
                }
            }
        }
    }

    private void CitesteCuloriFețeCubDinFisier(string numeFisier)
    {
        if (File.Exists(numeFisier))
        {
            string[] linii = File.ReadAllLines(numeFisier);
            culoriFețeCub = new Color4[linii.Length];

            for (int i = 0; i < linii.Length; i++)
            {
                string[] culori = linii[i].Split(' ');
                if (culori.Length >= 4)
                {
                    if (float.TryParse(culori[0], out float r) && float.TryParse(culori[1], out float g) && float.TryParse(culori[2], out float b) && float.TryParse(culori[3], out float a))
                    {
                        culoriFețeCub[i] = new Color4(r, g, b, a);
                    }
                }
            }
        }
    }

    private void CitesteCoordonateTriunghiDinFisier(string numeFisier)
    {
        if (File.Exists(numeFisier))
        {
            string[] linii = File.ReadAllLines(numeFisier);
            coordonateTriunghi = new Vector3[linii.Length];

            for (int i = 0; i < linii.Length; i++)
            {
                string[] coordonate = linii[i].Split(' ');
                if (coordonate.Length >= 3)
                {
                    if (float.TryParse(coordonate[0], out float x) && float.TryParse(coordonate[1], out float y) && float.TryParse(coordonate[2], out float z))
                    {
                        coordonateTriunghi[i] = new Vector3(x, y, z);
                    }
                }
            }
        }
    }
    private void GenerareCuloriTriunghi()
    {
        if (coordonateTriunghi != null)
        {
            culoriTriunghi = new Color4[coordonateTriunghi.Length];

            
            for (int i = 0; i < coordonateTriunghi.Length; i++)
            {
                
                culoriTriunghi[i] = new Color4(
                    (float)new Random().NextDouble(),
                    (float)new Random().NextDouble(),
                    (float)new Random().NextDouble(),
                    1.0f);
            }
        }
    }
    private void ModificareCuloareFațăCub(int index, Color4 culoareNouă)
    {
        if (culoriFețeCub != null && index >= 0 && index < culoriFețeCub.Length)
        {
            culoriFețeCub[index] = culoareNouă;
        }
    }
    private void ModificareCuloriVertexTriunghi()
    {
        if (culoriTriunghi != null)
        {
            for (int i = 0; i < culoriTriunghi.Length; i++)
            {
                
                culoriTriunghi[i] = new Color4(
                    (float)new Random().NextDouble(),
                    (float)new Random().NextDouble(),
                    (float)new Random().NextDouble(),
                    1.0f);

                Console.WriteLine($"Vârf {i + 1}: R={culoriTriunghi[i].R}, G={culoriTriunghi[i].G}, B={culoriTriunghi[i].B}");
            }
        }
    }
    private void DeseneazaCub()
    {
        if (coordonateCub != null && culoriFețeCub != null && coordonateCub.Length == culoriFețeCub.Length)
        {
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < coordonateCub.Length; i++)
            {
                GL.Color4(culoriFețeCub[i]);
                GL.Vertex3(coordonateCub[i]);
            }
            GL.End();
        }
    }
    private void DeseneazaTriunghi()
    {
        if (coordonateTriunghi != null && culoriTriunghi != null && coordonateTriunghi.Length == culoriTriunghi.Length)
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < coordonateTriunghi.Length; i++)
            {
                GL.Color4(culoriTriunghi[i]);

                GL.Vertex3(coordonateTriunghi[i]);
            }
            GL.End();
        }
    }


    static void Main(string[] args)
    {
        using (var aplicatie = new Aplicatie3D())
        {
            aplicatie.Run(60.0);
        }
    }
}
