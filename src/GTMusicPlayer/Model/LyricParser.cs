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
    public class LyricParser
    {
        /// <summary>
        /// 해당 title과 singer에 해당하는 가사정보를 알송 서버에서 파싱
        /// </summary>
        /// <param name="title"></param>
        /// <param name="singer"></param>
        /// <returns></returns>
        public static List<ALSongLyricHeader> GetALSongLyricHeaders(string title, string singer, int max = 0)
        {
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(singer)) return null;

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

                    var headers = container.HeaderContainer.Headers;
                    headers = headers.OrderByDescending(o => o.LyricID).ToList();
                    if (max > 0)
                    {
                        if (max > headers.Count) max = headers.Count;
                        headers = headers.GetRange(0, max);
                    }
                    return headers;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        /// <summary>
        /// 해당 header에 맞는 가사를 알송 서버에서 파싱
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static List<Lyric> GetALSongLyrics(ALSongLyricHeader header)
        {
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

        /// <summary>
        /// String to Lyric List
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<Lyric> Convert(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return null;

            try
            {
                var results = new List<Lyric>();
                string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] datas = line.Substring(1).Split(']');
                    if (datas.Length != 2) continue;
                    if (string.IsNullOrWhiteSpace(datas[0])) continue;
                    if (string.IsNullOrWhiteSpace(datas[1])) continue;
                    if (datas[1].Length <= 1) continue;

                    TimeSpan time;
                    if (!TimeSpan.TryParseExact(datas[0], "mm\\:ss\\.ff", System.Globalization.CultureInfo.InvariantCulture, out time)) continue;

                    var lyric = new Lyric()
                    {
                        Time = time,
                        Text = datas[1],
                    };
                    results.Add(lyric);
                }
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        /// <summary>
        /// Lyric List to String
        /// </summary>
        /// <param name="lyrics"></param>
        /// <returns></returns>
        public static string Convert(List<Lyric> lyrics)
        {
            if (lyrics == null || lyrics.Count == 0) return null;

            try
            {
                var sb = new StringBuilder();
                foreach (var lyric in lyrics)
                {
                    string min = lyric.Time.ViewMinutes();
                    string sec = lyric.Time.ViewSeconds();
                    string ms = lyric.Time.ViewMilliseconds();
                    sb.AppendLine(string.Format("[{0}:{1}.{2}]{3}", min, sec, ms, lyric.Text));
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}