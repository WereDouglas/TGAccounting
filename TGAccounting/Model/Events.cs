using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
    public class Events
    {
        private string id;
        private string details;
        private string starts;
        private string ends;
        private string users;
        private string file;
        private string created;
        private string fileid;
        private string status;
        private string userid;
        private string dated;
        private string notif;
        private string priority;
        private string sync;
        private string cal;
        private string contact;
        private string email;
        private string department;
        private string orgID;
        private string cost;
        private string no;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public string Starts
        {
            get
            {
                return starts;
            }

            set
            {
                starts = value;
            }
        }

        public string Ends
        {
            get
            {
                return ends;
            }

            set
            {
                ends = value;
            }
        }

        public string Users
        {
            get
            {
                return users;
            }

            set
            {
                users = value;
            }
        }

        public string File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }

        public string Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public string Fileid
        {
            get
            {
                return fileid;
            }

            set
            {
                fileid = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public string Dated
        {
            get
            {
                return dated;
            }

            set
            {
                dated = value;
            }
        }

        public string Notif
        {
            get
            {
                return notif;
            }

            set
            {
                notif = value;
            }
        }

        public string Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public string Sync
        {
            get
            {
                return sync;
            }

            set
            {
                sync = value;
            }
        }

        public string Cal
        {
            get
            {
                return cal;
            }

            set
            {
                cal = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public string OrgID
        {
            get
            {
                return orgID;
            }

            set
            {
                orgID = value;
            }
        }

        public string Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public Events() { }

        public Events(string id, string details, string starts, string ends, string users, string file, string created, string fileid, string status, string userid, string dated, string notif, string priority, string sync, string cal, string contact, string email, string department, string orgID, string cost, string no)
        {
            this.Id = id;
            this.Details = details;
            this.Starts = starts;
            this.Ends = ends;
            this.Users = users;
            this.File = file;
            this.Created = created;
            this.Fileid = fileid;
            this.Status = status;
            this.Userid = userid;
            this.Dated = dated;
            this.Notif = notif;
            this.Priority = priority;
            this.Sync = sync;
            this.Cal = cal;
            this.Contact = contact;
            this.Email = email;
            this.Department = department;
            this.OrgID = orgID;
            this.Cost = cost;
            this.No = no;
        }

        public static List<Events> List()
        {
            List<Events> events = new List<Events>();
            string SQL = "SELECT * FROM events";


            SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
            while (Reader.Read())
            {
                Events p = new Events(Reader["id"].ToString(), Reader["details"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Reader["users"].ToString(), Reader["file"].ToString(), Reader["created"].ToString(), Reader["fileid"].ToString(), Reader["status"].ToString(), Reader["userid"].ToString(), Reader["dated"].ToString(), Reader["notif"].ToString(), Reader["priority"].ToString(), Reader["sync"].ToString(), Reader["cal"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["department"].ToString(), Reader["orgid"].ToString(), Reader["cost"].ToString(), Reader["no"].ToString());
                events.Add(p);
            }
            Reader.Close();


            return events;

        }
    }
}