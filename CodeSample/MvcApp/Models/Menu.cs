using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcApp.Models
{
    public class Menu
    {
        /// <summary>Menu編號</summary>
        [XmlAttribute]
        public string Code { get; set; }

        /// <summary>Menu名稱</summary>
        public string Name { get; set; }

        /// <summary>Menu對應的網址</summary>
        public string ActionUrl { get; set; }

        /// <summary>Menu對應網址的參數</summary>
        public string Params { get; set; }

        /// <summary>Menu排序</summary>
        public string SortOrder { get; set; }

        /// <summary>List of child Menus</summary>
        [XmlArray("MenuList"), XmlArrayItem(typeof(Menu), ElementName = "Menu")]
        public List<Menu> MenuList { get; set; }
    }
}