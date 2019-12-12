using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;


namespace rakuXsta
{
    /*
     *ユーザー登録
     */
    class HttpPostRegister
    {
        private string user_id;
        private string user_pass;
        public HttpPostRegister(string user_id, string user_pass)//コンストラクタ
        {
            this.user_id = user_id;
            this.user_pass = user_pass;
        }

        public Register Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["postUserId"] = HttpUtility.UrlEncode(user_id, enc);
            ht["postUserPass"] = HttpUtility.UrlEncode(user_pass, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/register");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = data.Length;
            //データをPOST送信するためのStreamを取得
            Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            //サーバーからの応答を受信するためのWebResponseを取得
            WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr = new StreamReader(resStream, enc);
            string output = sr.ReadToEnd();
            //閉じる
            sr.Close();
            //return output;

            var token = JsonConvert.DeserializeObject<Register>(output);
            return token;//Register型で返してる。token.tokenでトークンが取得、token.msgでメッセージが取得
        }

    }
    public class Register
    {
        public string token;
        public string msg;
    }

    /*
     * ログイン
     */
    class HttpPostLogin
    {
        private string user_id;
        private string user_pass;
        public HttpPostLogin(string user_id, string user_pass)//コンストラクタ
        {
            this.user_id = user_id;
            this.user_pass = user_pass;
        }

        public Login Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["postUserId"] = HttpUtility.UrlEncode(user_id, enc);
            ht["postUserPass"] = HttpUtility.UrlEncode(user_pass, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/authenticate");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = data.Length;
            //データをPOST送信するためのStreamを取得
            Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            //サーバーからの応答を受信するためのWebResponseを取得
            WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr = new StreamReader(resStream, enc);
            string output = sr.ReadToEnd();
            //閉じる
            sr.Close();
            //return output;

            var token = JsonConvert.DeserializeObject<Login>(output);
            return token;//Login型で返してる。token.tokenでトークンが取得、token.msgでメッセージが取得
        }

    }
    public class Login
    {
        public string token;
        public string msg;
    }

    /*
     * ログイン確認
     */
    class HttpPostLoginConfirm
    {
        private string token;
        public HttpPostLoginConfirm(string token)//コンストラクタ
        {
            this.token = token;
        }

        public LoginConfirm Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/test");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = data.Length;
            //データをPOST送信するためのStreamを取得
            Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            //サーバーからの応答を受信するためのWebResponseを取得
            WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr = new StreamReader(resStream, enc);
            string output = sr.ReadToEnd();
            //閉じる
            sr.Close();
            //return output;

            var msg = JsonConvert.DeserializeObject<LoginConfirm>(output);
            return msg;//Login型で返してる。msg.msgでトークンが取得
        }

    }
    public class LoginConfirm
    {
        public string msg;
    }

    /*
     * 所持カードリスト取得
     */
    class HttpPostGetCardsList
    {
        private string token;
        public HttpPostGetCardsList(string token)//コンストラクタ
        {
            this.token = token;
        }

        public List<Item> Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/list");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = data.Length;
            //データをPOST送信するためのStreamを取得
            Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            //サーバーからの応答を受信するためのWebResponseを取得
            WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr = new StreamReader(resStream, enc);
            string output = sr.ReadToEnd();
            //閉じる
            sr.Close();
            //return output;

            var dataToParse = JsonConvert.DeserializeObject<ListDataToParse>(output);
            var cards = dataToParse.cardAry;
            return cards;
        }

    }
    public class ListDataToParse
    {
        public List<Item> cardAry { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string img { get; set; }
        public string info { get; set; }
        public string fk_card_id { get; set; }
        public string point { get; set; }
    }

    /*
     * 作成カード取得
     */
     /*
    class HttpPostGetCreatedCardsList
    {
        private string token;
        public HttpPostGetCreatedCardsList(string token)//コンストラクタ
        {
            this.token = token;
        }

        public CreatedCardsList<CreateItem> Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/works");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = data.Length;
            //データをPOST送信するためのStreamを取得
            Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            //サーバーからの応答を受信するためのWebResponseを取得
            WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr = new StreamReader(resStream, enc);
            string output = sr.ReadToEnd();
            //閉じる
            sr.Close();
            //return output;

            var msg = JsonConvert.DeserializeObject<LoginConfirm>(output);
            return msg;//Login型で返してる。msg.msgでトークンが取得
        }

    }*/
}
