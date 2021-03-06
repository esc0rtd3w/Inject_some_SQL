﻿using System;
using MySql.Data.MySqlClient;

namespace Inject_some_SQL.Database
{
    public class DataManager
    {
        private Configuration configuration = null;

        private String dbConnectionString;
        private MySqlConnection dbConnection;
        private String dbServer;
        private String dbUser;
        private String dbPassword;
        private String dbDataBase;
        private bool connected = false;

        /// <summary>
        /// Gibt an, ob die Verbindung zur Datenbank besteht
        /// </summary>
        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }


        // ~~~~~~~ KONSTRUKTOR ~~~~~~~
        public DataManager(Configuration conf)
        {
            this.configuration = conf;

            // Datenbank-Verbindungsdaten laden
            dbServer = conf.Database.Server;
            dbUser = conf.Database.Login;
            dbPassword = conf.Database.Password;
            dbDataBase = conf.Database.DataBase;
        }

        // -----------------------------------------------
        // Datenbankverbindung herstellen
        public void Connect()
        {
            connected = false;
            Connect(dbServer, dbUser, dbPassword, dbDataBase);
            this.connected = true;
        }

        // -----------------------------------------------
        // Datenbankverbindung herstellen
        private void Connect(String sServer, String sUid, String sPws, String sDataBase)
        {
            // Connectionstring zusammenbauen
            dbConnectionString = "Server=" + sServer + ";";
            dbConnectionString += "uid=" + sUid + ";";
            dbConnectionString += "pwd=" + sPws + ";";
            dbConnectionString += "database=" + sDataBase + ";";

            // Verbindung herstellen
            dbConnection = new MySqlConnection(dbConnectionString);
            dbConnection.Open();
        }
    }
}
