using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace shokuba_no_mondai_karuta
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 音声ファイルを再生
        /// </summary>
        /// <param name="command"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferSize"></param>
        /// <param name="hwndCallback"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int mciSendString(String command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        /// <summary>
        /// エイリアス
        /// </summary>
        private string _aliasName = "MyMediaFile";
        /// <summary>
        /// 再生中のファイルパス
        /// </summary>
        private string _musicFilePath= "";
        /// <summary>
        /// 再生時間（ミリ秒）
        /// </summary>
        private int _musicLength = 0;
        /// <summary>
        /// 再生位置（再生時間のうち、再生中の位置を示す）
        /// </summary>
        private int _musicPosition = 0;
        /// <summary>
        /// 再生モード（"not ready", "paused", "playing", "stopped", ""）
        /// </summary>
        private string _musicPlayMode = "";
        public Form1()
        {
            InitializeComponent();
            if (Directory.Exists(@"D:\Tools\職場の問題かるた_voice\voice"))
            {
                // 私の初期パス
                labelVoicePath.Text = @"D:\Tools\職場の問題かるた_voice\voice";
                setVoiceList(labelVoicePath.Text);

            }
            else
            {
                labelVoicePath.Text = "なし";
            }
            btnReplay.Enabled = false;
        }


        /// <summary>
        /// リセットボタンクリック時の動き
        /// リスト内の情報をクリアする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btonReset_Click(object sender, EventArgs e)
        {
            // リスト情報クリア
            listBoxVoice.Items.Clear();
            listBoxChoiceVoice.Items.Clear();

            // 初期状態のリストに戻す
            setVoiceList(labelVoicePath.Text);
            progressBarPlayTime.Value = 0;
            labelPlayTime.Text = "再生状況";
            btnReplay.Enabled = false;

        }

        /// <summary>
        /// 職場の問題かるたのVoiceセットのパス情報を登録するする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetVoice_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                //上部に表示する説明テキストを指定する
                fbd.Description = "フォルダを指定してください。";
                //ルートフォルダを指定する
                //デフォルトでDesktop
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                //最初に選択するフォルダを指定する
                //RootFolder以下にあるフォルダである必要がある
                fbd.SelectedPath = @"C:\";
                //ユーザーが新しいフォルダを作成できるようにする
                //デフォルトでTrue
                fbd.ShowNewFolderButton = true;

                //ダイアログを表示する
                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    //選択されたフォルダを表示する
                    labelVoicePath.Text =  fbd.SelectedPath;
                    setVoiceList(labelVoicePath.Text);
                }
            }
        }

        /// <summary>
        /// 指定のフォルダパス内含まれたmp3のファイルをすべてリストへ登録する。
        /// </summary>
        /// <param name="path"></param>
        private void setVoiceList(string path)
        {
            //"C:\test"以下のファイルをすべて取得する
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
            IEnumerable<System.IO.FileInfo> files =
                di.EnumerateFiles("*.mp3", System.IO.SearchOption.AllDirectories);

            //ファイルを列挙する
            foreach (System.IO.FileInfo f in files)
            {
                listBoxVoice.Items.Add(f.Name);
            }
            labelListBoxVoiceCount.Text = "再生リスト（ 個数: " + listBoxVoice.Items.Count + " ）";
            labelListBoxChoiceVoiceCount.Text = "再生済リスト（ 個数: " + listBoxChoiceVoice.Items.Count + " ）";
        }

        /// <summary>
        /// ランダムで音声データを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandomChoice_Click(object sender, EventArgs e)
        {
            int count = listBoxVoice.Items.Count;
            if (count ==0)
            {
                return; // データが空になったため、これ以上クリックできないようにする。
            }
            // Random クラスの新しいインスタンスを生成する
            Random r = new System.Random();
            // 0 以上 リスト最大値未満の乱数を取得する
            int randomChoiceIndex = r.Next(count);

            choiceListIndex(randomChoiceIndex);
        }

        /// <summary>
        /// 指定されたキー値の音声データを選択して、選択されたリストへ移行する。
        /// </summary>
        /// <param name="index"></param>
        private void choiceListIndex(int index)
        {
            // リストから指定のキー値のVoice情報を取得する。
            string voiceName = (string)listBoxVoice.Items[index];
            // 取得したキー値をリストから削除する
            listBoxVoice.Items.RemoveAt(index);
            // 選択されたリストに情報をうつす
            listBoxChoiceVoice.Items.Add(voiceName);

            labelListBoxVoiceCount.Text = "再生リスト（ 個数: " + listBoxVoice.Items.Count+ " ）";
            labelListBoxChoiceVoiceCount.Text = "再生済リスト（ 個数: " + listBoxChoiceVoice.Items.Count + " ）";

            play(Path.Combine(labelVoicePath.Text, voiceName));

        }



        /// <summary>
        /// 音声ファイルを再生する
        /// </summary>
        /// <param name="filePath">再生するファイルパス</param>
        private void play(string filePath)
        {
            _musicFilePath = filePath;
            openFileNamePanel(Path.GetFileName(filePath));
            StringBuilder buffer = new StringBuilder(255);
            _musicLength = 0;
            _musicPosition = 0;
            _musicPlayMode = "";
            
            // 注意：mciSendStringは、別スレッド（Task）内では呼び出せない。Single Thread Apartment でなければ動かない。
            // Single Thread Apartment にしなければ
            // MCIERR_CANNOT_LOAD_DRIVER(266)というエラーが変える。。
            // https://chitora.com/blog/?p=814
            //ファイルを開く
            string cmd1 = "open \"" + filePath + "\" type mpegvideo alias " + _aliasName;
            int err = mciSendString(cmd1, null, 0, IntPtr.Zero);
            if (err != 0)
            {
                return;
            }

            // 再生時間(ミリ秒)の取得
            string cmd2 = "status " + _aliasName + " length";
            mciSendString(cmd2, buffer, buffer.Capacity, IntPtr.Zero);
            _musicLength = int.Parse(buffer.ToString().Trim());
            System.Console.WriteLine("再生時間：" + _musicLength + "ミリ秒");
            progressBarPlayTime.Maximum = _musicLength;
            progressBarPlayTime.Minimum = 0;
            progressBarPlayTime.Value = 0;
            //再生する
            string cmd3 = "play " + _aliasName + " notify";
            System.Console.WriteLine("再生：" + filePath);
            mciSendString(cmd3, null, 0, this.Handle);

            Task.Run(() =>
            {
                try
                {
                    // 以下をどこで実行するべきか…。
                    System.Console.WriteLine("現在の再生状況を取得：" + filePath);
                    while ((_musicPosition < _musicLength) && (!"stopped".Equals(_musicPlayMode)))
                    {
                        this.Invoke(new DelegateUpdateStatus(this.updateStatus));
                        if ("".Equals(_musicPlayMode))
                        {
                            // 中断発生
                            break;
                        }
                        Task.Delay(500);    // 100ミリ秒遅延
                    }
                    this.Invoke((Action)(() =>
                    {
                        if ("".Equals(_musicPlayMode))
                        {
                            labelPlayTime.Text = "Mode： stopped, Time： " + _musicPosition + " / " + _musicLength + " ms";
                        }
                        else
                        {
                            progressBarPlayTime.Value = _musicLength;
                            labelPlayTime.Text = "Mode： stopped, Time： " + _musicLength + " / " + _musicLength + " ms";
                        }
                        closeFileNamePanel();
                    }));

                }
                catch (System.ObjectDisposedException ex)
                {
                    // '破棄されたオブジェクトにアクセスできません。
                    // フォームクローズ時に呼び出そうとして例外発生
                    // エラーであるが、特に影響はないため、無視。
                    System.Console.WriteLine(ex.ToString());    // エラーが出たらエラーメッセージをコンソールへ出力する
                }
            });

        }
        /// <summary>
        /// 再生状況をアップデートするメソッド用デリゲート宣言
        /// </summary>
        public delegate void DelegateUpdateStatus();

        /// <summary>
        /// 再生状況をアップデートする。
        /// </summary>
        private void updateStatus()
        {
            // 注意：mciSendStringは、別スレッド（Task）内では呼び出せない。Single Thread Apartment でなければ動かない。

            StringBuilder buffer = new StringBuilder(255);
            // 現在の再生状況を取得
            // ■再生状態("not ready", "paused", "playing", "stopped", ""のどれか)
            string cmd4 = "status " + _aliasName + " mode";
            buffer.Clear();
            mciSendString(cmd4, buffer, buffer.Capacity, IntPtr.Zero);
            _musicPlayMode = buffer.ToString().Trim();
            System.Console.WriteLine("再生状況：" + _musicPlayMode);
            string cmd5 = "status " + _aliasName + " position";
            buffer.Clear();
            mciSendString(cmd5, buffer, buffer.Capacity, IntPtr.Zero);
            string strMusicPosition = buffer.ToString().Trim();
            if (!"".Equals(strMusicPosition))
            {
                _musicPosition = int.Parse(strMusicPosition);
                progressBarPlayTime.Value = _musicPosition;
                System.Console.WriteLine("現在のポジション：" + _musicPosition + "ミリ秒");
            }
            labelPlayTime.Text = "Mode： " + _musicPlayMode + ", Time： " + _musicPosition + " / " + _musicLength + " ms";
        }

        private static int MM_MCINOTIFY = 0x3B9;
        private static int MCI_NOTIFY_SUCCESSFUL = 1;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY)
            {
                if ((int)m.WParam == MCI_NOTIFY_SUCCESSFUL)
                {
                    string cmd;
                    cmd = "stop " + _aliasName;
                    mciSendString(cmd, null, 0, IntPtr.Zero);
                    cmd = "close " + _aliasName;
                    mciSendString(cmd, null, 0, IntPtr.Zero);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 再生リストをダブルクリックで選択された場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxVoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxVoice.SelectedIndex >= 0)
            {
                // データが選択されている場合対応
                choiceListIndex(listBoxVoice.SelectedIndex);
            }
        }
        /// <summary>
        /// 再生済みリストをダブルクリックで選択された場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxChoiceVoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxChoiceVoice.SelectedIndex >= 0)
            {
                // データが選択されている場合対応
                string voiceName = (string)listBoxChoiceVoice.SelectedItem;
                play(Path.Combine(labelVoicePath.Text, voiceName));
            }
        }


        /// <summary>
        /// イベント発火系の機能を使用不可にして、現在再生中のファイル名を表示する
        /// </summary>
        /// <param name="filename">ファイル名</param>
        private void openFileNamePanel(string filename)
        {
            btnSetVoice.Enabled = false;
            buttonRandomChoice.Enabled = false;
            listBoxVoice.Enabled = false;
            listBoxChoiceVoice.Enabled = false;
            btonReset.Enabled = false;
            btnReplay.Enabled = false;


            // パネルをみえるように変更
            int sizeW = progressBarPlayTime.Size.Width;
            int sizeH = progressBarPlayTime.Location.Y - labelListBoxVoiceCount.Location.Y;
            int locX = labelListBoxVoiceCount.Location.X;
            int locY = labelListBoxVoiceCount.Location.Y;
            panelFileName.Size = new System.Drawing.Size(sizeW, sizeH);
            panelFileName.Location = new System.Drawing.Point(locX, locY);
            panelFileName.Visible = true;
            // ファイル名を定義
            labelNowFileName.Text = filename;
            labelNowFileName.Font = new System.Drawing.Font("ＭＳ ゴシック", 50);
            labelNowFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelNowFileName.Size = new System.Drawing.Size(sizeW, sizeH);
        }
        /// <summary>
        /// イベント発火系の機能を有効にする
        /// </summary>
        private void closeFileNamePanel()
        {

            // パネルをみえるように変更
            panelFileName.Visible = false;
            // ファイル名を定義
            labelNowFileName.Text = "";

            btnSetVoice.Enabled = true;
            buttonRandomChoice.Enabled = true;
            listBoxVoice.Enabled = true;
            listBoxChoiceVoice.Enabled = true;
            btonReset.Enabled = true;
            btnReplay.Enabled = true;

        }

        /// <summary>
        /// 再生中のファイルダブルクリックで再生中の状態を停止させる。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelNowFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string cmd = "stop " + _aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            cmd = "close " + _aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            //直前の再生ファイル名を再生
            play(_musicFilePath);
        }
    }
}
