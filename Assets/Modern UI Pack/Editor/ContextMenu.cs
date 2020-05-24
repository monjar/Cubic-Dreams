using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Michsky.UI.ModernUIPack
{
    public class ContextMenu : Editor
    {
        static void CreateObject(string resourcePath)
        {
            GameObject clone = Instantiate(Resources.Load<GameObject>(resourcePath), Vector3.zero, Quaternion.identity) as GameObject;

            try
            {
                if (Selection.activeGameObject == null)
                {
                    var canvas = (Canvas)GameObject.FindObjectsOfType(typeof(Canvas))[0];
                    Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                    clone.transform.SetParent(canvas.transform, false);
                }

                else
                {
                    Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                    clone.transform.SetParent(Selection.activeGameObject.transform, false);
                }

                clone.name = clone.name.Replace("(Clone)", "").Trim();
            }

            catch
            {
                Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                CreateCanvas();
                var canvas = (Canvas)GameObject.FindObjectsOfType(typeof(Canvas))[0];
                clone.transform.SetParent(canvas.transform, false);
                clone.name = clone.name.Replace("(Clone)", "").Trim();
            }

            if (Application.isPlaying == false)
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        static void CreateButton(string resourcePath)
        {
            GameObject clone = Instantiate(Resources.Load<GameObject>(resourcePath), Vector3.zero, Quaternion.identity) as GameObject;

            try
            {
                if (Selection.activeGameObject == null)
                {
                    var canvas = (Canvas)GameObject.FindObjectsOfType(typeof(Canvas))[0];
                    Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                    clone.transform.SetParent(canvas.transform, false);
                }

                else
                {
                    Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                    clone.transform.SetParent(Selection.activeGameObject.transform, false);
                }

                clone.name = "Button";
            }

            catch
            {
                Undo.RegisterCreatedObjectUndo(clone, "Created an object");
                CreateCanvas();
                var canvas = (Canvas)GameObject.FindObjectsOfType(typeof(Canvas))[0];
                clone.transform.SetParent(canvas.transform, false);
                clone.name = "Button";
            }

            if (Application.isPlaying == false)
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        [UnityEditor.MenuItem("Tools/Modern UI Pack/Show UI Manager %#M")]
        static void ShowManager()
        {
            Selection.activeObject = Resources.Load("MUIP Manager");

            if (Selection.activeObject == null)
                Debug.Log("Can't find a file named 'MUIP Manager'. Make sure you have 'MUIP Manager' file in Resources folder.");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Canvas", false, -1)]
        static void CreateCanvas()
        {
            GameObject clone = Instantiate(Resources.Load<GameObject>("Other/Canvas"), Vector3.zero, Quaternion.identity) as GameObject;
            Undo.RegisterCreatedObjectUndo(clone, "Created an object");
            clone.name = clone.name.Replace("(Clone)", "").Trim();

            if (Application.isPlaying == false)
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Hamburger Menu", false, 0)]
        static void AIHTE()
        {
            CreateObject("Animated Icon/Hamburger Menu");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Heart Pop", false, 0)]
        static void AIHP()
        {
            CreateObject("Animated Icon/Heart Pop");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Load", false, 0)]
        static void AILOA()
        {
            CreateObject("Animated Icon/Load");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Lock", false, 0)]
        static void AIL()
        {
            CreateObject("Animated Icon/Lock");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Message Bubbles", false, 0)]
        static void AILMB()
        {
            CreateObject("Animated Icon/Message Bubbles");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/No to Yes", false, 0)]
        static void AINTY()
        {
            CreateObject("Animated Icon/No to Yes");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Notification Bell", false, 0)]
        static void AINTFB()
        {
            CreateObject("Animated Icon/Notification Bell");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Sand Clock", false, 0)]
        static void AISC()
        {
            CreateObject("Animated Icon/Sand Clock");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Slider", false, 0)]
        static void AISL()
        {
            CreateObject("Animated Icon/Slider");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Window", false, 0)]
        static void AIWI()
        {
            CreateObject("Animated Icon/Window");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Animated Icon/Yes to No", false, 0)]
        static void AIYTN()
        {
            CreateObject("Animated Icon/Yes to No");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Standard", false, 0)]
        static void BBST()
        {
            CreateButton("Button/Basic/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/White", false, 0)]
        static void BBWHI()
        {
            CreateButton("Button/Basic/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Gray", false, 0)]
        static void BBGR()
        {
            CreateButton("Button/Basic/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Blue", false, 0)]
        static void BBBL()
        {
            CreateButton("Button/Basic/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Brown", false, 0)]
        static void BBBRW()
        {
            CreateButton("Button/Basic/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Green", false, 0)]
        static void BBGRE()
        {
            CreateButton("Button/Basic/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Night", false, 0)]
        static void BBNI()
        {
            CreateButton("Button/Basic/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Orange", false, 0)]
        static void BBOR()
        {
            CreateButton("Button/Basic/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Pink", false, 0)]
        static void BBPIN()
        {
            CreateButton("Button/Basic/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Purple", false, 0)]
        static void BBPURP()
        {
            CreateButton("Button/Basic/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic/Red", false, 0)]
        static void BBRED()
        {
            CreateButton("Button/Basic/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/White", false, 0)]
        static void BGWHI()
        {
            CreateButton("Button/Basic - Gradient/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Gray", false, 0)]
        static void BGGR()
        {
            CreateButton("Button/Basic - Gradient/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Blue", false, 0)]
        static void BGBL()
        {
            CreateButton("Button/Basic - Gradient/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Brown", false, 0)]
        static void BGBRW()
        {
            CreateButton("Button/Basic - Gradient/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Green", false, 0)]
        static void BGGRE()
        {
            CreateButton("Button/Basic - Gradient/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Night", false, 0)]
        static void BGNI()
        {
            CreateButton("Button/Basic - Gradient/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Orange", false, 0)]
        static void BGOR()
        {
            CreateButton("Button/Basic - Gradient/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Pink", false, 0)]
        static void BGPIN()
        {
            CreateButton("Button/Basic - Gradient/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Purple", false, 0)]
        static void BGPURP()
        {
            CreateButton("Button/Basic - Gradient/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Gradient/Red", false, 0)]
        static void BGRED()
        {
            CreateButton("Button/Basic - Gradient/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Standard", false, 0)]
        static void BBOICS()
        {
            CreateButton("Button/Basic - Only Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/White", false, 0)]
        static void BBOICW()
        {
            CreateButton("Button/Basic - Only Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Gray", false, 0)]
        static void BBOICG()
        {
            CreateButton("Button/Basic - Only Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Blue", false, 0)]
        static void BBOICB()
        {
            CreateButton("Button/Basic - Only Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Brown", false, 0)]
        static void BBOICBR()
        {
            CreateButton("Button/Basic - Only Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Green", false, 0)]
        static void BBOICGR()
        {
            CreateButton("Button/Basic - Only Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Night", false, 0)]
        static void BBOICN()
        {
            CreateButton("Button/Basic - Only Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Orange", false, 0)]
        static void BBOICO()
        {
            CreateButton("Button/Basic - Only Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Pink", false, 0)]
        static void BBOICP()
        {
            CreateButton("Button/Basic - Only Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Purple", false, 0)]
        static void BBOICPU()
        {
            CreateButton("Button/Basic - Only Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Only Icon/Red", false, 0)]
        static void BBOICR()
        {
            CreateButton("Button/Basic - Only Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Standard", false, 0)]
        static void BBWICS()
        {
            CreateButton("Button/Basic - With Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/White", false, 0)]
        static void BBWICW()
        {
            CreateButton("Button/Basic - With Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Gray", false, 0)]
        static void BBWICG()
        {
            CreateButton("Button/Basic - With Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Blue", false, 0)]
        static void BBWICB()
        {
            CreateButton("Button/Basic - With Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Brown", false, 0)]
        static void BBWICBR()
        {
            CreateButton("Button/Basic - With Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Green", false, 0)]
        static void BBWICGR()
        {
            CreateButton("Button/Basic - With Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Night", false, 0)]
        static void BBWICN()
        {
            CreateButton("Button/Basic - With Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Orange", false, 0)]
        static void BBWICO()
        {
            CreateButton("Button/Basic - With Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Pink", false, 0)]
        static void BBWICP()
        {
            CreateButton("Button/Basic - With Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Purple", false, 0)]
        static void BBWICPU()
        {
            CreateButton("Button/Basic - With Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - With Icon/Red", false, 0)]
        static void BBWICR()
        {
            CreateButton("Button/Basic - With Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Standard", false, 0)]
        static void BOWHS()
        {
            CreateButton("Button/Basic - Outline/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/White", false, 0)]
        static void BOWHI()
        {
            CreateButton("Button/Basic - Outline/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Gray", false, 0)]
        static void BOGR()
        {
            CreateButton("Button/Basic - Outline/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Blue", false, 0)]
        static void BOBL()
        {
            CreateButton("Button/Basic - Outline/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Brown", false, 0)]
        static void BOBRW()
        {
            CreateButton("Button/Basic - Outline/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Green", false, 0)]
        static void BOGRE()
        {
            CreateButton("Button/Basic - Outline/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Night", false, 0)]
        static void BONI()
        {
            CreateButton("Button/Basic - Outline/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Orange", false, 0)]
        static void BOOR()
        {
            CreateButton("Button/Basic - Outline/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Pink", false, 0)]
        static void BOPIN()
        {
            CreateButton("Button/Basic Outline/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Purple", false, 0)]
        static void BOPURP()
        {
            CreateButton("Button/Basic - Outline/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline/Red", false, 0)]
        static void BORED()
        {
            CreateButton("Button/Basic - Outline/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/White", false, 0)]
        static void BOGWHI()
        {
            CreateButton("Button/Basic - Outline Gradient/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Gray", false, 0)]
        static void BOGBGR()
        {
            CreateButton("Button/Basic - Outline Gradient/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Blue", false, 0)]
        static void BOGBL()
        {
            CreateButton("Button/Basic - Outline Gradient/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Brown", false, 0)]
        static void BOGBRW()
        {
            CreateButton("Button/Basic - Outline Gradient/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Green", false, 0)]
        static void BOGGRE()
        {
            CreateButton("Button/Basic - Outline Gradient/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Night", false, 0)]
        static void BOGNI()
        {
            CreateButton("Button/Basic - Outline Gradient/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Orange", false, 0)]
        static void BOGOR()
        {
            CreateButton("Button/Basic - Outline Gradient/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Pink", false, 0)]
        static void BOGPIN()
        {
            CreateButton("Button/Basic - Outline Gradient/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Purple", false, 0)]
        static void BOGPURP()
        {
            CreateButton("Button/Basic - Outline Gradient/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Gradient/Red", false, 0)]
        static void BOGRED()
        {
            CreateButton("Button/Basic - Outline Gradient/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Standard", false, 0)]
        static void BOOIS()
        {
            CreateButton("Button/Basic - Outline Only Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/White", false, 0)]
        static void BOOIR()
        {
            CreateButton("Button/Basic - Outline Only Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Gray", false, 0)]
        static void BOOIG()
        {
            CreateButton("Button/Basic - Outline Only Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Blue", false, 0)]
        static void BOOIB()
        {
            CreateButton("Button/Basic - Outline Only Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Brown", false, 0)]
        static void BOOIBR()
        {
            CreateButton("Button/Basic - Outline Only Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Green", false, 0)]
        static void BOOIBG()
        {
            CreateButton("Button/Basic - Outline Only Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Night", false, 0)]
        static void BOOIBN()
        {
            CreateButton("Button/Basic - Outline Only Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Orange", false, 0)]
        static void BOOIBO()
        {
            CreateButton("Button/Basic - Outline Only Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Pink", false, 0)]
        static void BOOIBP()
        {
            CreateButton("Button/Basic - Outline Only Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Purple", false, 0)]
        static void BOOIBPU()
        {
            CreateButton("Button/Basic - Outline Only Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline Only Icon/Red", false, 0)]
        static void BOOIBRE()
        {
            CreateButton("Button/Basic - Outline Only Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Standard", false, 0)]
        static void BOWIBS()
        {
            CreateButton("Button/Basic - Outline With Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/White", false, 0)]
        static void BOWIBW()
        {
            CreateButton("Button/Basic - Outline With Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Gray", false, 0)]
        static void BOWIBG()
        {
            CreateButton("Button/Basic - Outline With Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Blue", false, 0)]
        static void BOWIBB()
        {
            CreateButton("Button/Basic - Outline With Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Brown", false, 0)]
        static void BOWIBBR()
        {
            CreateButton("Button/Basic - Outline With Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Green", false, 0)]
        static void BOWIBGR()
        {
            CreateButton("Button/Basic - Outline With Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Night", false, 0)]
        static void BOWIBN()
        {
            CreateButton("Button/Basic - Outline With Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Orange", false, 0)]
        static void BOWIBO()
        {
            CreateButton("Button/Basic - Outline With Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Pink", false, 0)]
        static void BOWIBP()
        {
            CreateButton("Button/Basic - Outline With Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Purple", false, 0)]
        static void BOWIBPU()
        {
            CreateButton("Button/Basic - Outline With Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Basic - Outline With Icon/Red", false, 0)]
        static void BOWIBRE()
        {
            CreateButton("Button/Basic - Outline With Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Standard", false, 0)]
        static void BROIS()
        {
            CreateButton("Button/Radial - Only Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/White", false, 0)]
        static void BROIW()
        {
            CreateButton("Button/Radial - Only Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Gray", false, 0)]
        static void BROIG()
        {
            CreateButton("Button/Radial - Only Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Blue", false, 0)]
        static void BROIB()
        {
            CreateButton("Button/Radial - Only Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Brown", false, 0)]
        static void BROIBR()
        {
            CreateButton("Button/Radial - Only Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Green", false, 0)]
        static void BROIGR()
        {
            CreateButton("Button/Radial - Only Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Night", false, 0)]
        static void BROIN()
        {
            CreateButton("Button/Radial - Only Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Orange", false, 0)]
        static void BROIO()
        {
            CreateButton("Button/Radial - Only Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Pink", false, 0)]
        static void BROIP()
        {
            CreateButton("Button/Radial - Only Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Purple", false, 0)]
        static void BROIPU()
        {
            CreateButton("Button/Radial - Only Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Only Icon/Red", false, 0)]
        static void BROIR()
        {
            CreateButton("Button/Radial - Only Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Standard", false, 0)]
        static void BROOIS()
        {
            CreateButton("Button/Radial - Outline Only Icon/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/White", false, 0)]
        static void BROOIW()
        {
            CreateButton("Button/Radial - Outline Only Icon/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Gray", false, 0)]
        static void BROOIG()
        {
            CreateButton("Button/Radial - Outline Only Icon/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Blue", false, 0)]
        static void BROOIB()
        {
            CreateButton("Button/Radial - Outline Only Icon/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Brown", false, 0)]
        static void BROOIBR()
        {
            CreateButton("Button/Radial - Outline Only Icon/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Green", false, 0)]
        static void BROOIGR()
        {
            CreateButton("Button/Radial - Outline Only Icon/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Night", false, 0)]
        static void BROOIN()
        {
            CreateButton("Button/Radial - Outline Only Icon/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Orange", false, 0)]
        static void BROOIO()
        {
            CreateButton("Button/Radial - Outline Only Icon/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Pink", false, 0)]
        static void BROOIP()
        {
            CreateButton("Button/Radial - Outline Only Icon/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Purple", false, 0)]
        static void BROOIPU()
        {
            CreateButton("Button/Radial - Outline Only Icon/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Radial - Outline Only Icon/Red", false, 0)]
        static void BROOIR()
        {
            CreateButton("Button/Radial - Outline Only Icon/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Standard", false, 0)]
        static void BRS()
        {
            CreateButton("Button/Rounded/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/White", false, 0)]
        static void BRW()
        {
            CreateButton("Button/Rounded/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Gray", false, 0)]
        static void BRG()
        {
            CreateButton("Button/Rounded/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Blue", false, 0)]
        static void BRB()
        {
            CreateButton("Button/Rounded/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Brown", false, 0)]
        static void BRBR()
        {
            CreateButton("Button/Rounded/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Green", false, 0)]
        static void BRGR()
        {
            CreateButton("Button/Rounded/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Night", false, 0)]
        static void BRN()
        {
            CreateButton("Button/Rounded/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Orange", false, 0)]
        static void BRO()
        {
            CreateButton("Button/Rounded/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Pink", false, 0)]
        static void BRP()
        {
            CreateButton("Button/Rounded/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Purple", false, 0)]
        static void BRPU()
        {
            CreateButton("Button/Rounded/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded/Red", false, 0)]
        static void BRR()
        {
            CreateButton("Button/Rounded/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/White", false, 0)]
        static void BRGW()
        {
            CreateButton("Button/Rounded - Gradient/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Gray", false, 0)]
        static void BRGG()
        {
            CreateButton("Button/Rounded - Gradient/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Blue", false, 0)]
        static void BRGB()
        {
            CreateButton("Button/Rounded - Gradient/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Brown", false, 0)]
        static void BRGBR()
        {
            CreateButton("Button/Rounded - Gradient/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Green", false, 0)]
        static void BRGGR()
        {
            CreateButton("Button/Rounded - Gradient/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Night", false, 0)]
        static void BRGN()
        {
            CreateButton("Button/Rounded - Gradient/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Orange", false, 0)]
        static void BRGO()
        {
            CreateButton("Button/Rounded - Gradient/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Pink", false, 0)]
        static void BRGP()
        {
            CreateButton("Button/Rounded - Gradient/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Purple", false, 0)]
        static void BRGPU()
        {
            CreateButton("Button/Rounded - Gradient/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Gradient/Red", false, 0)]
        static void BRGRE()
        {
            CreateButton("Button/Rounded - Gradient/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Standard", false, 0)]
        static void BROS()
        {
            CreateButton("Button/Rounded - Outline/Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/White", false, 0)]
        static void BROW()
        {
            CreateButton("Button/Rounded - Outline/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Gray", false, 0)]
        static void BROG()
        {
            CreateButton("Button/Rounded - Outline/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Blue", false, 0)]
        static void BROB()
        {
            CreateButton("Button/Rounded - Outline/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Brown", false, 0)]
        static void BROBR()
        {
            CreateButton("Button/Rounded - Outline/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Green", false, 0)]
        static void BROGR()
        {
            CreateButton("Button/Rounded - Outline/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Night", false, 0)]
        static void BRON()
        {
            CreateButton("Button/Rounded - Outline/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Orange", false, 0)]
        static void BROO()
        {
            CreateButton("Button/Rounded - Outline/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Pink", false, 0)]
        static void BROP()
        {
            CreateButton("Button/Rounded - Outline/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Purple", false, 0)]
        static void BROPU()
        {
            CreateButton("Button/Rounded - Outline/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline/Red", false, 0)]
        static void BRORE()
        {
            CreateButton("Button/Rounded - Outline/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/White", false, 0)]
        static void BROGW()
        {
            CreateButton("Button/Rounded - Outline Gradient/White");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Gray", false, 0)]
        static void BROGG()
        {
            CreateButton("Button/Rounded - Outline Gradient/Gray");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Blue", false, 0)]
        static void BROGB()
        {
            CreateButton("Button/Rounded - Outline Gradient/Blue");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Brown", false, 0)]
        static void BROGBR()
        {
            CreateButton("Button/Rounded - Outline Gradient/Brown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Green", false, 0)]
        static void BROGGR()
        {
            CreateButton("Button/Rounded - Outline Gradient/Green");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Night", false, 0)]
        static void BROGN()
        {
            CreateButton("Button/Rounded - Outline Gradient/Night");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Orange", false, 0)]
        static void BROGO()
        {
            CreateButton("Button/Rounded - Outline Gradient/Orange");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Pink", false, 0)]
        static void BROGP()
        {
            CreateButton("Button/Rounded - Outline Gradient/Pink");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Purple", false, 0)]
        static void BROGPU()
        {
            CreateButton("Button/Rounded - Outline Gradient/Purple");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Button/Rounded - Outline Gradient/Red", false, 0)]
        static void BROGRE()
        {
            CreateButton("Button/Rounded - Outline Gradient/Red");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Dropdown/Standard", false, 0)]
        static void DSD()
        {
            CreateObject("Dropdown/Dropdown");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Dropdown/Multi Select", false, 0)]
        static void DMSD()
        {
            CreateObject("Dropdown/Dropdown - Multi Select");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Horizontal Selector/Standard", false, 0)]
        static void HSS()
        {
            CreateObject("Horizontal Selector/Horizontal Selector");
        }

        // [UnityEditor.MenuItem("GameObject/Modern UI Pack/Hamburger Menu/Standard", false, 0)]
        static void HMST()
        {
            CreateObject("Hamburger Menu/Hamburger Menu");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Multi-Line", false, 0)]
        static void IFFML()
        {
            CreateObject("Input Field/Input Field - Multi-Line");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Fading (Left Aligned)", false, 0)]
        static void IFFLA()
        {
            CreateObject("Input Field/Input Field - Fading (Left)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Fading (Middle Aligned)", false, 0)]
        static void IFFMA()
        {
            CreateObject("Input Field/Input Field - Fading (Middle)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Fading (Right Aligned)", false, 0)]
        static void IFFRA()
        {
            CreateObject("Input Field/Input Field - Fading (Aligned)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Standard (Left Aligned)", false, 0)]
        static void IFSLA()
        {
            CreateObject("Input Field/Input Field - Standard (Left)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Standard (Middle Aligned)", false, 0)]
        static void IFSMA()
        {
            CreateObject("Input Field/Input Field - Standard (Middle)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Input Field/Standard (Right Aligned)", false, 0)]
        static void IFSRA()
        {
            CreateObject("Input Field/Input Field - Standard (Right)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/List View/Standard", false, 0)]
        static void LVS()
        {
            CreateObject("List View/List View");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Modal Window/Style 1/Standard", false, 0)]
        static void MWSS()
        {
            CreateObject("Modal Window/Style 1/MW - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Modal Window/Style 1/With Tabs", false, 0)]
        static void MWSWT()
        {
            CreateObject("Modal Window/Style 1/MW - With Tabs");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Modal Window/Style 2/Standard", false, 0)]
        static void MWSSS()
        {
            CreateObject("Modal Window/Style 2/MW - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Modal Window/Style 2/With Tabs", false, 0)]
        static void MWSSWT()
        {
            CreateObject("Modal Window/Style 2/MW - With Tabs");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Movable Window/Standard", false, 0)]
        static void MVWSSWT()
        {
            CreateObject("Movable Window/Movable Window");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Notification/Fading Notification", false, 0)]
        static void NSN()
        {
            CreateObject("Notification/Fading Notification");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Notification/Popup Notification", false, 0)]
        static void NSP()
        {
            CreateObject("Notification/Popup Notification");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Notification/Sliding Notification", false, 0)]
        static void NSS()
        {
            CreateObject("Notification/Sliding Notification");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Standard", false, 0)]
        static void PBS()
        {
            CreateObject("Progress Bar/PB - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Thin", false, 0)]
        static void PBRT()
        {
            CreateObject("Progress Bar/PB - Radial (Thin)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Light", false, 0)]
        static void PBRL()
        {
            CreateObject("Progress Bar/PB - Radial (Light)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Regular", false, 0)]
        static void PBRR()
        {
            CreateObject("Progress Bar/PB - Radial (Regular)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Bold", false, 0)]
        static void PBRB()
        {
            CreateObject("Progress Bar/PB - Radial (Bold)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Filled Horizontal", false, 0)]
        static void PBRFH()
        {
            CreateObject("Progress Bar/PB - Radial Filled Horizontal");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar/Radial Filled Vertical", false, 0)]
        static void PBRFV()
        {
            CreateObject("Progress Bar/PB - Radial Filled Vertical");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/Standard Fastly", false, 0)]
        static void PBLSF()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Standard Fastly");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/Standard Run", false, 0)]
        static void PBLSR()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Standard Run");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/Radial Material", false, 0)]
        static void PBLRM()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Radial Material");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/Radial Pie", false, 0)]
        static void PBLRP()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Radial Pie");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/Radial Run", false, 0)]
        static void PBLRR()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Radial Run");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Progress Bar (Loop)/PB Loop - Radial Trapez", false, 0)]
        static void PBLRT()
        {
            CreateObject("Progress Bar (Loop)/PB Loop - Radial Trapez");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Scrollbar/Standard", false, 0)]
        static void SCS()
        {
            CreateObject("Scrollbar/Scrollbar");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Standard/Standard", false, 0)]
        static void SLS()
        {
            CreateObject("Slider/Standard/Slider - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Standard/Standard (Popup)", false, 0)]
        static void SLSP()
        {
            CreateObject("Slider/Standard/Slider - Standard (Popup)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Standard/Standard (Value)", false, 0)]
        static void SLSV()
        {
            CreateObject("Slider/Standard/Slider - Standard (Value)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Gradient/Gradient", false, 0)]
        static void SLG()
        {
            CreateObject("Slider/Gradient/Slider - Gradient");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Gradient/Gradient (Popup)", false, 0)]
        static void SLGP()
        {
            CreateObject("Slider/Gradient/Slider - Gradient (Popup)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Gradient/Gradient (Value)", false, 0)]
        static void SLGV()
        {
            CreateObject("Slider/Gradient/Slider - Gradient (Value)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Outline/Outline", false, 0)]
        static void SLO()
        {
            CreateObject("Slider/Outline/Slider - Outline");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Outline/Outline (Popup)", false, 0)]
        static void SLOP()
        {
            CreateObject("Slider/Outline/Slider - Outline (Popup)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Outline/Outline (Value)", false, 0)]
        static void SLOV()
        {
            CreateObject("Slider/Outline/Slider - Outline (Value)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Radial/Radial", false, 0)]
        static void SLR()
        {
            CreateObject("Slider/Radial/Slider - Radial");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Radial/Radial (Gradient)", false, 0)]
        static void SLRG()
        {
            CreateObject("Slider/Radial/Slider - Radial (Gradient)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Range/Range", false, 0)]
        static void SLRA()
        {
            CreateObject("Slider/Range/Slider - Range");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Slider/Range/Range (Label)", false, 0)]
        static void SLRAL()
        {
            CreateObject("Slider/Range/Slider - Range (Label)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Switch/Standard", false, 0)]
        static void SWS()
        {
            CreateObject("Switch/Switch - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Switch/Material", false, 0)]
        static void SWM()
        {
            CreateObject("Switch/Switch - Material");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Toggle/Standard", false, 0)]
        static void TSTST()
        {
            CreateObject("Toggle/Toggle - Standard");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Toggle/Standard (Light)", false, 0)]
        static void TSTL()
        {
            CreateObject("Toggle/Toggle - Standard (Light)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Toggle/Standard (Regular)", false, 0)]
        static void TSTR()
        {
            CreateObject("Toggle/Toggle - Standard (Regular)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Toggle/Standard (Bold)", false, 0)]
        static void TSTB()
        {
            CreateObject("Toggle/Toggle - Standard (Bold)");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Toggle/Toggle Group Panel", false, 0)]
        static void TTGP()
        {
            CreateObject("Toggle/Toggle Group Panel");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Tooltip/Tooltip System", false, 0)]
        static void TTS()
        {
            CreateObject("Tooltip/Tooltip");
        }

        [UnityEditor.MenuItem("GameObject/Modern UI Pack/Window Manager", false, 0)]
        static void MWM()
        {
            CreateObject("Window Manager/Window Manager");
        }
    }
}
#endif