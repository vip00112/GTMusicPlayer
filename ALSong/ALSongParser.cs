using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace GTMusicPlayer
{
    public class ALSongParser
    {
        #region Public Method
        /// <summary>
        /// 해당 title과 singer에 맞는 가사를 알송 서버에서 파싱
        /// </summary>
        /// <param name="title"></param>
        /// <param name="singer"></param>
        /// <returns></returns>
        public static List<Lyric> GetLyric(string title, string singer)
        {
            var header = GetHeader(title, singer);
            if (header == null) return null;

            string url = "http://lyrics.alsong.co.kr/alsongwebservice/service1.asmx";
            string param = string.Format(Properties.Resources.ALSongLyricByID, header.LyricID);
            byte[] paramData = Encoding.UTF8.GetBytes(param);

            try
            {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
                req.Headers.Add("SOAPAction", "ALSongWebServer/GetLyricByID2");
                req.ContentType = "application/soap+xml;charset=utf-8";
                req.UserAgent = "gSOAP/2.7";
                req.Method = "POST";
                req.ContentLength = paramData.Length;
                using (var reqStream = req.GetRequestStream())
                {
                    reqStream.Write(paramData, 0, paramData.Length);
                }
                using (var res = (HttpWebResponse) req.GetResponse())
                using (var resStream = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                {
                    string respone = resStream.ReadToEnd();
                    var doc = new XmlDocument();
                    doc.LoadXml(respone);

                    string json = JsonConvert.SerializeXmlNode(doc.ChildNodes[1].ChildNodes[0].ChildNodes[0]);
                    var wrapper = JsonConvert.DeserializeObject<ALSongWrapper>(json);

                    if (string.IsNullOrWhiteSpace(wrapper.ContentContainer.Content.Lyric)) return null;

                    var lyrics = Convert(wrapper.ContentContainer.Content.Lyric);
                    return lyrics.OrderBy(o => o.Time).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        #endregion

        #region Private Method
        private static ALSongLyricHeader GetHeader(string title, string singer)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;
            if (string.IsNullOrWhiteSpace(singer)) return null;

            string url = "http://lyrics.alsong.co.kr/alsongwebservice/service1.asmx";
            string param = string.Format(Properties.Resources.ALSongLyricList, title, singer);
            byte[] paramData = Encoding.UTF8.GetBytes(param);

            try
            {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
                req.Headers.Add("SOAPAction", "ALSongWebServer/GetResembleLyricList2");
                req.ContentType = "application/soap+xml;charset=utf-8";
                req.UserAgent = "gSOAP/2.7";
                req.Method = "POST";
                req.ContentLength = paramData.Length;
                using (var reqStream = req.GetRequestStream())
                {
                    reqStream.Write(paramData, 0, paramData.Length);
                }
                using (var res = (HttpWebResponse) req.GetResponse())
                using (var resStream = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                {
                    string respone = resStream.ReadToEnd();
                    var doc = new XmlDocument();
                    doc.LoadXml(respone);

                    string json = JsonConvert.SerializeXmlNode(doc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0]);
                    var container = JsonConvert.DeserializeObject<ALSongWrapper>(json);

                    if (container.HeaderContainer.Headers.Count == 0) return null;
                    return container.HeaderContainer.Headers[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        private static List<Lyric> Convert(string lyric)
        {
            if (string.IsNullOrWhiteSpace(lyric)) return null;

            var results = new List<Lyric>();
            string[] lines = lyric.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] datas = line.Substring(1).Split(']');
                if (datas.Length != 2) continue;
                if (string.IsNullOrWhiteSpace(datas[0])) continue;
                if (string.IsNullOrWhiteSpace(datas[1])) continue;
                if (datas[1].Length <= 1) continue;

                TimeSpan time;
                if (!TimeSpan.TryParseExact(datas[0], "mm\\:ss\\.ff", System.Globalization.CultureInfo.InvariantCulture, out time)) continue;

                var result = new Lyric()
                {
                    Time = time,
                    Text = datas[1],
                };
                results.Add(result);
            }
            return results;
        }
        #endregion
    }
}