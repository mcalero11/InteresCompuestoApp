
using Android.Widget;
using InteresCompuestoApp.Forms.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("IngEconomica")]
[assembly: ExportEffect(typeof(NumericEntryEffect), nameof(NumericEntryEffect))]
namespace InteresCompuestoApp.Forms.Droid.Effects
{
    public class NumericEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var editText = (EditText)Control;
            editText.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.NumberFlagSigned;

        }

        protected override void OnDetached()
        {
            
        }
    }
}