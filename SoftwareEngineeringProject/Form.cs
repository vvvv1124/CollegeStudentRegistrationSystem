﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace SoftwareEngineeringProject
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            mysqlConnectionString = InitializeMySQLConnection("MySQLSettings.xml");
            //在此添加更多的其他初始化函数
        }

        private readonly string mysqlConnectionString;//保存MySQL连接信息的字符串

        public String MySQLConnectionString { get { return mysqlConnectionString; } }
        //使用MySqlConnection conn = new MySqlConnection(MySQLConnectionString);来创建数据库连接

        private string InitializeMySQLConnection(String SettingFilePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(SettingFilePath);
            XmlNode xmlNode = xml.SelectSingleNode("mysql");
            XmlNodeList settings = xmlNode.ChildNodes;
            String server = settings.Item(0).InnerText;
            String port = settings.Item(1).InnerText;
            String user = settings.Item(2).InnerText;
            String password = settings.Item(3).InnerText;
            String database = settings.Item(4).InnerText;
            return String.Format("server={0};port={1};user={2};password={3}; database={4};",
                server, port, user, password, database);
        }
    }
}
