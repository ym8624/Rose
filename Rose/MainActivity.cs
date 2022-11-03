using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Rose
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SeekBar sbSlider;
        private ImageView ivRose;
        private Switch rSwitch;

        private int alpha;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            SetView();
        }

        private void SetView()
        {
            sbSlider = FindViewById<SeekBar>(Resource.Id.sbSlider);
            ivRose = FindViewById<ImageView>(Resource.Id.ivRose);
            rSwitch = FindViewById<Switch>(Resource.Id.rSwitch);

            sbSlider.ProgressChanged += SbVisibility_ProgressChanged;
            rSwitch.CheckedChange += SwchVisible_CheckedChange;
        }

        private void SwchVisible_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (rSwitch.Checked)
            {
                rSwitch.Text = "Hide picture";
                ivRose.Visibility = Android.Views.ViewStates.Visible;
            }

            else
            {
                rSwitch.Text = "Show picture";
                ivRose.Visibility = Android.Views.ViewStates.Invisible;
            }
        }

        private void SbVisibility_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            alpha = sbSlider.Progress;
            ivRose.Alpha = 1 - (float)alpha / 100;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}