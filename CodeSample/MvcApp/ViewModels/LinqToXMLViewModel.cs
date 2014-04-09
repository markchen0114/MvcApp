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

        /// <summary>Search XML</summary>
        /// <param name="root">XML Root</param>
        /// <param name="elementName">Element Name Condition, case sensitive</param>
        /// <param name="attributeName">Attribute Name Condition, case sensitive</param>
        /// <param name="attributeValue">Attribute Code Condition, case sensitive</param>
        /// <returns></returns>
        public string SearchXML(XElement root, string elementName = "", string attributeName = "", string attributeValue = "")
        {
            var XMLElementList = root.Elements();
            #region 依條件篩選
            if (!string.IsNullOrEmpty(elementName))
            {
                XMLElementList = XMLElementList.Where(w => w.Name == elementName);
                if (XMLElementList.Count() == 0) //若Elements中無符合elemantName的資料, 則往Child找elementName
                    XMLElementList = root.Descendants(elementName);
            }
            if (!string.IsNullOrEmpty(attributeValue))
                XMLElementList = XMLElementList.Where(w => w.Attribute(attributeName) != null && w.Attribute(attributeName).Value == attributeValue);
            #endregion 依條件篩選

            string strHtml = "";
            foreach (var e in XMLElementList)
            {
                foreach (var a in e.Attributes()) //列出所有Attribute
                    strHtml += "<font color='blue'>[ATT:" + e.Name + "]" + a.Name + ":" + a.Value + "</font><br>";
                foreach (var echild in e.Elements()) //列出沒有子項目的Element
                {
                    if (echild.Elements().Count() == 0)
                        strHtml += echild.Name + ":" + echild.Value + "<br>";
                    else
                    {
                        strHtml += "<font color='red'>[Child-Begin]" + e.Name + ":" + e.FirstAttribute + "</font><br>";
                        strHtml += SearchXML(echild);
                        strHtml += "<font color='red'>[Child-End]" + e.Name + ":" + e.FirstAttribute + "</font><br>";
                    }
                }
            }
            return strHtml;
        }
    }
}