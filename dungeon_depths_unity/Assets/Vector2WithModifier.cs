using UnityEditor;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Scripting;

namespace UnityEngine.InputSystem.Composites
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    [DisplayStringFormat("{modifier}+{vector2}")]
    public class Vector2WithOneModifier : InputBindingComposite<Vector2>
    {
        [InputControl(layout = "Button")] public int modifier;

        [InputControl(layout = "Vector2")] public int vector2;

        public override Vector2 ReadValue(ref InputBindingCompositeContext context)
        {
            if(context.ReadValueAsButton(modifier))
            {
                return context.ReadValue<Vector2, Vector2MagnitudeComparer>(vector2);
            }

            return default;
        }

        //public override Vector2 EvaluateMagnitude(ref InputBindingCompositeContext context)
        //{
        //    return ReadValue(ref context);
        //}
    }
}
