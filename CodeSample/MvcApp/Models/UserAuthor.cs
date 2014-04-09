using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcApp.Models
{
    public class UserAuthor
    {
        /// <summary>User系統編號</summary>
        [XmlAttribute]
        public string SystemUserId { get; set; }

        /// <summary>User角色編號</summary>
        [XmlAttribute]
        public string RoleId { get; set; }

        /// <summary>User可以使用的Menu</summary>
        [XmlArray("MenuList"), XmlArrayItem(typeof(string), ElementName = "Menu")]
        public List<string> MenuCodeList { get; set; }
    }
}