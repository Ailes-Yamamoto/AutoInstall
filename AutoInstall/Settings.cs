using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoInstall
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    class Settings : AppCompatActivity
    {
        #region"変数"
        private string mstrVersion = "";                    //Version
        //private string documentDir = "";
        //private string FilePath = "";
        private EditText edittext1;
        private EditText edittext2;
        private EditText edittext3;
        private EditText urltext1;
        private EditText urltext2;
        private EditText urltext3;
        #endregion

        #region"画面起動時"
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.settings);

            //Ver.の表示
            TextView lblVersion = FindViewById<TextView>(Resource.Id.lblVersion);
            mstrVersion = "Ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = mstrVersion;

            ////ファイルパスの取得  
            //documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

            ////ファイル存在確認
            //File file = new File(documentDir + "/Setting.txt");
            //if (file.exists())
            //{

            //}
            //else
            //{

            //}
            //    //設定ファイルパス取得
            //    FilePath = Path.Combine(documentDir, "Setting.txt");

            ////  ファイルから読み込み　【確認用】
            //byte[] SettingsData = File.ReadAllBytes(FilePath);

            //変数 = (キャスト)findViewById(使いたいウィジェットのid)
            edittext1 = (EditText)FindViewById<TextView>(Resource.Id.edittext1);
            edittext2 = (EditText)FindViewById<TextView>(Resource.Id.edittext2);
            edittext3 = (EditText)FindViewById<TextView>(Resource.Id.edittext3);
            urltext1 = (EditText)FindViewById<TextView>(Resource.Id.urltext1);
            urltext2 = (EditText)FindViewById<TextView>(Resource.Id.urltext2);
            urltext3 = (EditText)FindViewById<TextView>(Resource.Id.urltext3);

            //edittext1.Text = Encoding.UTF8.GetString(SettingsData);

            //各イベントの設定
            setEvent();

            //設定ファイルの読み出し
            var prefs = GetSharedPreferences("pref", FileCreationMode.Private);
            var SetteingName1 = prefs.GetString("SetteingName1", "");
            var SetteingName2 = prefs.GetString("SetteingName2", "");
            var SetteingName3 = prefs.GetString("SetteingName3", "");
            var UrlName1 = prefs.GetString("UrlName1", "");
            var UrlName2 = prefs.GetString("UrlName2", "");
            var UrlName3 = prefs.GetString("UrlName3", "");

            edittext1.Text = SetteingName1;
            edittext2.Text = SetteingName2;
            edittext3.Text = SetteingName3;
            urltext1.Text = UrlName1;
            urltext2.Text = UrlName2;
            urltext3.Text = UrlName3;

        }
        #endregion

        #region"各イベントの設定"
        private void setEvent()
        {
            //保存ボタンクリック時の設定
            var imgbtnEdit = FindViewById<ImageButton>(Resource.Id.edit_image);
            imgbtnEdit.Click += new EventHandler(this.imgbtnEdit_Click);

            //ダウンロードボタンクリック時の設定
            var imgbtnDownload = FindViewById<ImageButton>(Resource.Id.download_image);
            imgbtnDownload.Click += new EventHandler(this.imgbtnDownload_Click);
        }
        #endregion

        #region"編集イメージクリック時"
        private void imgbtnEdit_Click(object sender, EventArgs e)
        {

            string settingdata = edittext1.Text + "," + edittext2.Text + "," + edittext3.Text;

            var prefs = GetSharedPreferences("pref", FileCreationMode.Private);
            var editor = prefs.Edit();
            editor.PutString("SetteingName1", edittext1.Text);
            editor.PutString("SetteingName2", edittext2.Text);
            editor.PutString("SetteingName3", edittext3.Text);
            editor.PutString("UrlName1", urltext1.Text);
            editor.PutString("UrlName2", urltext2.Text);
            editor.PutString("UrlName3", urltext3.Text);
            editor.Commit();
        }
        #endregion

        #region"ダウンロードイメージクリック時"
        private void imgbtnDownload_Click(object sender, EventArgs e)
        {
            //設定画面へ
            var f = new Intent(this, typeof(MainActivity));
            StartActivity(f);
        }
        #endregion
    }
}