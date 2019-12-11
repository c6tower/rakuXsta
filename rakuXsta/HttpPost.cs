﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace rakuXsta
{
    class HttpPostStart
    {
        private string token;
        public HttpPostStart(string token)//コンストラクタ
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
}
