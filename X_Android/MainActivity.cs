using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace X_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public EditText Edt_Input { get; set; }
        public Button Btn_Ok { get; set; }
        public Button Btn_Google { get; set; }
        public Button Btn_ShowPicture { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Edt_Input = FindViewById<EditText>(Resource.Id.activity_main_Edt_Input);
            Edt_Input.Click += ShowToast;
            //Btn_Ok = FindViewById<Button>(2131230778);
            Btn_Ok = FindViewById<Button>(Resource.Id.activity_main_Btn_Ok);

            Btn_Ok.Click += ShowToast;
            //Btn_Ok.Click += (sender, e) => Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();

            Btn_Google = FindViewById<Button>(Resource.Id.activity_main_Btn_Google);

            Intent impliziterIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://www.google.de"));
            Btn_Google.Click += (s, e) => StartActivity(impliziterIntent);

            Btn_ShowPicture = FindViewById<Button>(Resource.Id.activity_main_Btn_ShowPicture);
            Intent expliziterIntet = new Intent(this, typeof(ShowPictureActivity));
            Btn_ShowPicture.Click += (s,e) => StartActivity(expliziterIntet);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void ShowToast(object sender, EventArgs e)
        {
            Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();
        }
    }
}