using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;

using System.Reflection;
using System.Net.Http;
using System.IO;
using System.Text;
using Android.Content;
using AndroidX.Core.Content;
using System.Threading;
using Java.Lang;
using Thread = System.Threading.Thread;
using String = Java.Lang.String;
using AlertDialog = Android.App.AlertDialog;

namespace AutoInstall
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        #region"変数"
        private string mstrVersion = "";                    //Version
        private string documentDir = "";
        private string settingname1 = "";
        private string settingname2 = "";
        private string settingname3 = "";
        private string uri1 = "";
        private string uri2 = "";
        private string uri3 = "";
        
        //ProgressBar pb;
        //TextView tv;
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Ver.の表示
            TextView lblVersion = FindViewById<TextView>(Resource.Id.lblVersion);
            mstrVersion = "Ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = mstrVersion;

            //パスの取得  
            documentDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
           
            //各イベントの設定
            setEvent();


            //設定ファイルの読み出し
            var prefs = GetSharedPreferences("pref", FileCreationMode.Private);
            settingname1 = prefs.GetString("SetteingName1", "");
            settingname2 = prefs.GetString("SetteingName2", "");
            settingname3 = prefs.GetString("SetteingName3", "");
            uri1 = prefs.GetString("UrlName1", "");
            uri2 = prefs.GetString("UrlName2", "");
            uri3 = prefs.GetString("UrlName3", "");

            //ボタン名を設定ファイルから取得した名称に変更
            var btnSystem1 = FindViewById<Button>(Resource.Id.btnSystem1);
            btnSystem1.Text = settingname1;
            var btnSystem2 = FindViewById<Button>(Resource.Id.btnSystem2);
            btnSystem2.Text = settingname2;
            var btnSystem3 = FindViewById<Button>(Resource.Id.btnSystem3);
            btnSystem3.Text = settingname3;

            //ボタン名称が空白の場合、非表示にする
            if (btnSystem1.Text.Length == 0)
            {
                btnSystem1.Visibility = ViewStates.Invisible;
            }
            if (btnSystem2.Text.Length == 0)
            {
                btnSystem2.Visibility = ViewStates.Invisible;
            }
            if (btnSystem3.Text.Length == 0)
            {
                btnSystem3.Visibility = ViewStates.Invisible;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        #region"各イベントの設定"
        private void setEvent()
        {          
            //設定1ボタンクリック時の設定
            var btnSystem1 = FindViewById<Button>(Resource.Id.btnSystem1);
            btnSystem1.Click += new EventHandler(this.btnSystem1_Click);

            //設定2ボタンクリック時の設定
            var btnSystem2 = FindViewById<Button>(Resource.Id.btnSystem2);
            btnSystem2.Click += new EventHandler(this.btnSystem2_Click);

            ////設定3ボタンクリック時の設定
            var btnSystem3 = FindViewById<Button>(Resource.Id.btnSystem3);
            btnSystem3.Click += new EventHandler(this.btnSystem3_Click);

            //Settings Button
            var imgbtnSettings = FindViewById<ImageButton>(Resource.Id.settings_image);
            imgbtnSettings.Click += new EventHandler(this.imgbtnSettings_Click);

        }
        #endregion

        #region"設定1ボタンクリック時"
        private async void btnSystem1_Click(object sender, EventArgs e)
        {
            try
            { 
                //ダイアログプログレスバー呼出
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View progressDialogBox = layoutInflater.Inflate(Resource.Layout.Progressbar, null);
                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
                alertDialogBuilder.SetView(progressDialogBox);
                var progressBar1 = progressDialogBox.FindViewById<ProgressBar>(Resource.Id.progressBar1);
                //progressBar1.Max = 100;
                //progressBar1.Progress = 0;

                Dialog dialog = alertDialogBuilder.Create();
                dialog.Show();

                UpdatePB uptask = new UpdatePB(this, progressBar1, dialog);
                uptask.Execute(100);

                //Webページの内容を取得する
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.GetAsync(uri1);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //httpResponse.Content.ReadAsByteArrayAsync    データを読んて、AKPファイルを作成する
                    //string stream = await httpResponse.Content.ReadAsStringAsync();
                    var stream = await httpResponse.Content.ReadAsStreamAsync();

                    string FilePath = Path.Combine(documentDir, "app.apk");
                    ////  ファイルに書き込み
                    //File.WriteAllBytes(FilePath, Encoding.UTF8.GetBytes($"{stream}"));
                    using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        stream.CopyTo(fileStream);
                    }

                    //Resultの表示
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = $"ダウンロードしました。";

                    //プログレスバーダイアログを閉じる
                    dialog.Dismiss();

                    // 共有URIの取得
                    Java.IO.File file = new Java.IO.File(FilePath);
                    var uri2 = FileProvider.GetUriForFile(Android.App.Application.Context,
                                Android.App.Application.Context.PackageName + ".provider",
                                file);

                    // インストーラーの起動
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(uri2, "application/vnd.android.package-archive");
                    intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);
                    Android.App.Application.Context.StartActivity(intent);

                    //インストールに成功
                    lblResult.Text = "";
                }
                else
                {
                    //インストールに失敗
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = "インストールに失敗しました。";
                }
            }
            catch (System.Exception ex)
            {
                //　ダウンロードに失敗　
                //　ここでex.Messageを確認すると「Permission.denied」
                TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                lblResult.Text = "インストールに失敗しました。" + $"Error Message: {ex.Message}";
                return;
            }
        }
        #endregion

        #region"設定2ボタンクリック時"
        private async void btnSystem2_Click(object sender, EventArgs e)
        {
            try
            {
                //ダイアログプログレスバー呼出
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View progressDialogBox = layoutInflater.Inflate(Resource.Layout.Progressbar, null);
                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
                alertDialogBuilder.SetView(progressDialogBox);
                var progressBar1 = progressDialogBox.FindViewById<ProgressBar>(Resource.Id.progressBar1);
                //progressBar1.Max = 100;
                //progressBar1.Progress = 0;

                Dialog dialog = alertDialogBuilder.Create();
                dialog.Show();

                UpdatePB uptask = new UpdatePB(this, progressBar1, dialog);
                uptask.Execute(100);

                //Webページの内容を取得する
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.GetAsync(uri2);


                if (httpResponse.IsSuccessStatusCode)
                {
                    //httpResponse.Content.ReadAsByteArrayAsync    データを読んて、AKPファイルを作成する
                    var stream = await httpResponse.Content.ReadAsStreamAsync();

                   　string FilePath = Path.Combine(documentDir, "app.apk");
                    ////  ファイルに書き込み
                    using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        stream.CopyTo(fileStream);
                    }

                    //Resultの表示
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = $"ダウンロードしました。";

                    //プログレスバーダイアログを閉じる
                    dialog.Dismiss();


                    // 共有URIの取得
                    Java.IO.File file = new Java.IO.File(FilePath);
                    var uri2 = FileProvider.GetUriForFile(Android.App.Application.Context,
                                Android.App.Application.Context.PackageName + ".provider",
                                file);

                    // インストーラーの起動
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(uri2, "application/vnd.android.package-archive");
                    intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);
                    Android.App.Application.Context.StartActivity(intent);

                    //インストールに成功
                    lblResult.Text = "";
                }
                else
                {
                    //インストールに失敗
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = "インストールに失敗しました。";
                }
            }
            catch (System.Exception ex)
            {
                //　ダウンロードに失敗　
                //　ここでex.Messageを確認すると「Permission.denied」
                TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                lblResult.Text = "インストールに失敗しました。" + $"Error Message: {ex.Message}";
                return;
            }
        }
        #endregion

        #region"設定3ボタンクリック時"
        private async void btnSystem3_Click(object sender, EventArgs e)
        {
            try
            {
                //ダイアログプログレスバー呼出
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View progressDialogBox = layoutInflater.Inflate(Resource.Layout.Progressbar, null);
                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
                alertDialogBuilder.SetView(progressDialogBox);
                var progressBar1 = progressDialogBox.FindViewById<ProgressBar>(Resource.Id.progressBar1);
                //progressBar1.Max = 100;
                //progressBar1.Progress = 0;

                Dialog dialog = alertDialogBuilder.Create();
                dialog.Show();

                UpdatePB uptask = new UpdatePB(this, progressBar1, dialog);
                uptask.Execute(100);

                //Webページの内容を取得する
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.GetAsync(uri3);
                if (httpResponse.IsSuccessStatusCode)
                {
                    //httpResponse.Content.ReadAsByteArrayAsync    データを読んて、AKPファイルを作成する
                    var stream = await httpResponse.Content.ReadAsStreamAsync();

                   
                    string FilePath = Path.Combine(documentDir, "app.apk");
                    //  ファイルに書き込み       
                    using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        stream.CopyTo(fileStream);
                    }

                    //Resultの表示
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = $"ダウンロードしました。";

                    //プログレスバーダイアログを閉じる
                    dialog.Dismiss();


                    // 共有URIの取得
                    Java.IO.File file = new Java.IO.File(FilePath);
                    var uri2 = FileProvider.GetUriForFile(Android.App.Application.Context,
                                Android.App.Application.Context.PackageName + ".provider",
                                file);

                    // インストーラーの起動
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(uri2, "application/vnd.android.package-archive");
                    intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);
                    Android.App.Application.Context.StartActivity(intent);

                    //インストールに成功
                    lblResult.Text = "";
                }
                else
                {
                    //インストールに失敗
                    TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                    lblResult.Text = "インストールに失敗しました。";
                }
            }
            catch (System.Exception ex)
            {
                //　ダウンロードに失敗　
                //　ここでex.Messageを確認すると「Permission.denied」
                TextView lblResult = FindViewById<TextView>(Resource.Id.lblResult);
                lblResult.Text = "インストールに失敗しました。" + $"Error Message: {ex.Message}";
                return;
            }
        }
        #endregion

        #region"設定イメージクリック時"

        private void imgbtnSettings_Click(object sender, EventArgs e)
        {
            //設定画面へ
            var f = new Intent(this, typeof(Settings));
            StartActivity(f);

        }
        #endregion

        #region"プログレスバーを表示"

        public class UpdatePB : AsyncTask<int, int, string>
        {
            Activity mcontext; 
            ProgressBar mpb;
            Dialog mdi;
            public UpdatePB(Activity context, ProgressBar pb, Dialog di)
            {
                this.mcontext = context;
                this.mpb = pb;
                this.mdi = di;
            }
            protected override string RunInBackground(params int[] @params)
            {
              
                // TODO Auto-generated method stub
                for (int i = 1; i <= 4; i++)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(50000);
                    }
                    catch (InterruptedException e)
                    {
                        // TODO Auto-generated catch block
                        Android.Util.Log.Error("lv", e.Message);
                    }
                    mpb.IncrementProgressBy(25);
                    //進行状況の変化をユーザーに送信する
                    PublishProgress(i * 25);

                }
               
                return "finish"; 
            }
            // This is called each time you call publishProgress()
            protected override void OnProgressUpdate(params int[] values)
            {
                // 進捗
                Android.Util.Log.Error("lv==", values[0] + "");
            }
            // This is called when doInBackground() is finished
            protected override void OnPostExecute(string result)
            {
                // 終了
                mcontext.Title = result;
                //プログレスバーダイアログを閉じる
                mdi.Dismiss();
            }
        }
    }
    #endregion
}


