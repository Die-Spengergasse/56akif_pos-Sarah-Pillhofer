using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01
{
    public abstract class Post
    {
        private int _rating;

        public string Title { get; } = string.Empty;
        public DateTime Created { get; }
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if ((value >= 1) && (value <= 5))
                {
                    _rating = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Range muss zwischen 1 und 5 liegen!");
                }
            }
        }
        public abstract string Html { get; }
        public SmartPhoneApp? SmartPhone { get; set; } = new SmartPhoneApp("");


        public Post(string title, DateTime created)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Titel war NULL!");
            }
            else
            {
                Title = title;
            }
            Created = created;
        }

        public Post(string title)
        {
            Title = title;
            Created = DateTime.Now; 
        }

        /*public override string ToString()
        {
            return base.ToString(Html);
        }*/
    }
}
