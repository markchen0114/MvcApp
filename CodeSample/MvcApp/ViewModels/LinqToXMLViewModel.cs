using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MvcApp.ViewModels
{
    public class LinqToXMLViewModel
    {
        public List<Menu> MenuList { get; set; }

        public List<UserAuthor> UserAuthorList { get; set; }

        public LinqToXMLViewModel()
        {
        }

        /// <summary>取得XML File of Menu的範例字串</summary>
        /// <returns>string</returns>
        public string GetSampleXMLOfMenu()
        {
            MenuList = new List<Menu>();
            for (int i = 0; i < 10; i++)
            {
                Menu menu = new Menu();
                menu.Code = ((char)((int)'A' + i)).ToString();
                menu.Name = "Menu" + i.ToString();
                menu.ActionUrl = "";
                menu.Params = "";
                menu.SortOrder = i.ToString();
                menu.MenuList = new List<Menu>();
                for (int j = 0; j < 20; j++)
                {
                    Menu childMenu = new Menu();
                    childMenu.Code = ((char)((int)'A' + i)).ToString() + j.ToString("000");
                    childMenu.Name = "Menu" + i.ToString() + "-" + j.ToString();
                    childMenu.ActionUrl = "/Menu" + i.ToString() + "/" + "Menu" + i.ToString() + "-" + j.ToString();
                    childMenu.Params = "";
                    childMenu.SortOrder = j.ToString();
                    menu.MenuList.Add(childMenu);
                }
                MenuList.Add(menu);
            }

            var serializerMenu = new XmlSerializer(MenuList.GetType());
            StringWriter sw = new StringWriter();
            serializerMenu.Serialize(sw, MenuList);
            return sw.ToString();
        }

        /// <summary>取得XML File of UserAuthor的範例字串</summary>
        /// <returns>string</returns>
        public string GetSampleXMLOfUserAuthor()
        {
            UserAuthorList = new List<UserAuthor>();
            for (int i = 0; i < 1000; i++)
            {
                UserAuthor user = new UserAuthor();
                user.SystemUserId = i.ToString();
                user.RoleId = "admin" + (i % 20).ToString();
                user.MenuCodeList = new List<string>();

                for (int j = 0; j < 5; j++)
                {
                    user.MenuCodeList.Add(((char)((int)'A' + j)).ToString());

                    for (int k = 0; k < 20; k++)
                        user.MenuCodeList.Add(((char)((int)'A' + j)).ToString() + k.ToString("000"));
                }
                UserAuthorList.Add(user);
            }

            var serializerUser = new XmlSerializer(UserAuthorList.GetType());
            StringWriter sw = new StringWriter();
            serializerUser.Serialize(sw, UserAuthorList);
            return sw.ToString();
        }

        /// <summary>Read XML From String (Only get one level for XML, don't implement recursive to extract whole XML)</summary>
        /// <param name="XML">String with XML Format</param>
        /// <param name="elementName">Element Name Condition</param>
        /// <param name="attributeName">Attribute Name Condition</param>
        /// <param name="attributeValue">Attribute Code Condition</param>
        /// <returns></returns>
        public string ReadXML(string XML, string elementName, string attributeName, string attributeValue)
        {
            //XDocument xd = XDocument.Load(fileName); //Read XML from file
            XDocument xd = XDocument.Parse(XML); //Read XML from string
            var q =
                from x in xd.Descendants(elementName)
                where string.IsNullOrEmpty(attributeValue) || (x.Attribute(attributeName) != null && x.Attribute(attributeName).Value == attributeValue)
                select x;
            string strHtml = "";
            foreach (var o in q.SelectMany(s => s.Elements())) //需要Recursive解出子項目, 此範例未處理
                strHtml += o.Name + ":" + o.Value + "<br>";
            return strHtml;
        }
    }
}