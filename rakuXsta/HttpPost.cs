﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

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
            return token;//Register型で返してる。obj.Tokenでトークンが取得、obj.Msgでメッセージが取得
        }

    }
    public class Register
    {
        public string Token { get; set; }
        public string Msg { get; set; }
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
            return token;//Login型で返してる。obj.Tokenでトークンが取得、obj.Msgでメッセージが取得
        }

    }
    public class Login
    {
        public string Token { get; set; }
        public string Msg { get; set; }
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
            return msg;//Login型で返してる。obj.msgでトークンが取得
        }

    }
    public class LoginConfirm
    {
        public string Msg { get; set; }
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

        public ObservableCollection<ItemIncludeImages> Exe()//実行メソッド
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
            //timeout例外処理！！！！！！！
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
            var cards = dataToParse.CardAry;
            ObservableCollection<ItemIncludeImages> cards_include_img = new ObservableCollection<ItemIncludeImages>();
            foreach (var i in cards)
            {
                cards_include_img.Add(new ItemIncludeImages(i.Name, i.Img, i.Info, i.Id, i.Point));
            }
            return cards_include_img ;
        }

    }
    public class ListDataToParse
    {
        public ObservableCollection<Item> CardAry { get; set; }

    }

    public class Item 
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public string Id { get; set; }
        public string Point { get; set; }
            
    }

    /*
     * oaiwfhuahviuwagfiuhawfiu
     */

    public class ItemIncludeImages
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public string Id { get; set; }
        public string Point { get; set; }
        private string image1;
        private string image2;
        private string image3;
        private string image4;
        private string image5;
        private string image6;
        private string image7;
        private string image8;
        private string image9;
        private string image10;
        public string Image1
        {
            get
            {
                return image1;
            }
            set
            {
                image1 = value;
            }
        }
        public string Image2
        {
            get
            {
                return image2;
            }
            set
            {
                image2 = value;
            }
        }
        public string Image3
        {
            get
            {
                return image3;
            }
            set
            {
                image3 = value;
            }
        }
        public string Image4
        {
            get
            {
                return image4;
            }
            set
            {
                image4 = value;
            }
        }
        public string Image5
        {
            get
            {
                return image5;
            }
            set
            {
                image5 = value;
            }
        }
        public string Image6
        {
            get
            {
                return image6;
            }
            set
            {
                image6 = value;
            }
        }
        public string Image7
        {
            get
            {
                return image7;
            }
            set
            {
                image7 = value;
            }
        }
        public string Image8
        {
            get
            {
                return image8;
            }
            set
            {
                image8 = value;
            }
        }
        public string Image9
        {
            get
            {
                return image9;
            }
            set
            {
                image9 = value;
            }
        }
        public string Image10
        {
            get
            {
                return image10;
            }
            set
            {
                image10 = value;
            }
        }

        public ItemIncludeImages(string Name, string Img, string Info, string Id, string Point)
        {
            ITokenInfo tokenInfo = DependencyService.Get<ITokenInfo>(DependencyFetchTarget.GlobalInstance);
            
            this.Name = Name;
            this.Img = Img;
            this.Info = Info;
            this.Id = Id;
            this.Point = Point;
            if (int.Parse(Point) == 0)
            {
                this.Image1 = "circle.png";
                this.Image2 = "circle.png";
                this.Image3 = "circle.png";
                this.Image4 = "circle.png";
                this.Image5 = "circle.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 1)
            {
                this.Image1 = "good.png";
                this.Image2 = "circle.png";
                this.Image3 = "circle.png";
                this.Image4 = "circle.png";
                this.Image5 = "circle.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 2)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "circle.png";
                this.Image4 = "circle.png";
                this.Image5 = "circle.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 3)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "circle.png";
                this.Image5 = "circle.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 4)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "circle.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 5)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "circle.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 6)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "good.png";
                this.Image7 = "circle.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 7)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "good.png";
                this.Image7 = "good.png";
                this.Image8 = "circle.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 8)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "good.png";
                this.Image7 = "good.png";
                this.Image8 = "good.png";
                this.Image9 = "circle.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) == 9)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "good.png";
                this.Image7 = "good.png";
                this.Image8 = "good.png";
                this.Image9 = "good.png";
                this.Image10 = "circle.png";
            }
            else if (int.Parse(Point) >= 10)
            {
                this.Image1 = "good.png";
                this.Image2 = "good.png";
                this.Image3 = "good.png";
                this.Image4 = "good.png";
                this.Image5 = "good.png";
                this.Image6 = "good.png";
                this.Image7 = "good.png";
                this.Image8 = "good.png";
                this.Image9 = "good.png";
                this.Image10 = "good.png";
            }
        }

    }

/*
 * 作成カード取得
 */

class HttpPostGetCreatedCardsList
    {
        private string token;
        public HttpPostGetCreatedCardsList(string token)//コンストラクタ
        {
            this.token = token;
        }

        public ObservableCollection<CreatedItems> Exe()//実行メソッド
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

            var dataToParse = JsonConvert.DeserializeObject<CreatedCardsListToParse>(output);
            var cards = dataToParse.CreatedCards;
            return cards;// .idでid、.nameでname、.imgでimg、.infoでinfo、.urlでurl
        }

    }
    public class CreatedCardsListToParse
    {
        public ObservableCollection<CreatedItems> CreatedCards { get; set; }
        public string Message { get; set; }
    }
    public class CreatedItems
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public string Url { get; set; }
    }

    /*
     * カード作成
     */
    class HttpPostCreateCard
    {
        private string card_name;
        private string card_info;
        private string token;
        private string card_img;
        public HttpPostCreateCard(string card_name, string card_info, string card_img, string token){
            this.card_name = card_name;
            this.card_info = card_info;
            this.token = token;
            this.card_img = card_img;
        }

        public CreateCardData Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["postCardName"] = HttpUtility.UrlEncode(card_name, enc);
            ht["postCardInfo"] = HttpUtility.UrlEncode(card_info, enc);
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            ht["postCardImg"] = HttpUtility.UrlEncode(card_img, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/create");
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
            var carddata = JsonConvert.DeserializeObject<CreateCardData>(output);

            return carddata;//obj.CardName等で取得
        }
    }
    public class CreateCardData
    {
        public string CardName { get; set; }
        public string CardImg { get; set; }
        public string CardInfo { get; set; }
        public string CardUrl { get; set; }
        public string CardId { get; set; }
    }

    /*
     * カード編集
     */
    class HttpPostEditCard
    {
        private string card_name;
        private string card_info;
        private string token;
        private string card_img;
        private string card_id;
        public HttpPostEditCard(string card_name, string card_info, string token, string card_img, string card_id)//コンストラクタ
        {
            this.card_name = card_name;
            this.card_info = card_info;
            this.token = token;
            this.card_img = card_img;
            this.card_id = card_id;
        }

        public EditCardData Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["postCardName"] = HttpUtility.UrlEncode(card_name, enc);
            ht["postCardInfo"] = HttpUtility.UrlEncode(card_info, enc);
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            ht["postCardImg"] = HttpUtility.UrlEncode(card_img, enc);
            ht["postCardId"] = HttpUtility.UrlEncode(card_id, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/edit");
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

            var carddata = JsonConvert.DeserializeObject<EditCardData>(output);

            return carddata;//obj.CardIdで取得
        }
    }
    public class EditCardData
    {
        public string CardId { get; set; }
    }

    class HttpPostAddPoint
    {
        private string url_num;
        private string token;
        public HttpPostAddPoint(string token, string QR_result)//コンストラクタ
        {
            this.token = token;
            this.url_num = QR_result;
        }

        public PointData Exe()//実行メソッド
        {
            //文字コード指定
            Encoding enc = Encoding.GetEncoding("UTF-8");
            //POSTする文字列の指定
            string param = "";
            Hashtable ht = new Hashtable();
            ht["token"] = HttpUtility.UrlEncode(token, enc);
            ht["postUrlNum"] = HttpUtility.UrlEncode(url_num, enc);
            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            //バイト型配列に変換
            byte[] data = Encoding.ASCII.GetBytes(param);
            //WebRequestの作成
            WebRequest req = WebRequest.Create("https://stamp-app-api.herokuapp.com/api/add");
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
            string output = sr.ReadToEnd();//表示方法変更する！！！！！！
            //閉じる
            sr.Close();
            //エラー発生(修正済み)

            var pointdata = JsonConvert.DeserializeObject<PointData>(output);
            return pointdata;//.Point等で取得

        }
    }
    class PointData
    {
        public string Point { get; set; }
        public string CardId { get; set; }
    }
}

