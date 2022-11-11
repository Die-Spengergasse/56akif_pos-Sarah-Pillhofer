using Spg.PluePos._01;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01
{
    public class SmartPhoneApp : List<Post>
    {
        public string MySmartPhoneId { get; set; } = string.Empty;

        public SmartPhoneApp(string mySmartPhoneId)
        {
            MySmartPhoneId = mySmartPhoneId;
        }

        public new void Add(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException("Post war NULL!");
            }

            if (base.Contains(post))
            {
                throw new ArgumentException("Post ist bereits in dieser SmartPhoneApp!");
            }

            base.Add(post);

        }


        public string ProcessPosts()
        {
            string ergebnis = string.Empty;

            foreach (Post item in this)
            {
                ergebnis += item.Html;
            }

            return ergebnis;
        }

        public int CalcRating()
        {
            int ergebnis = 0;

            foreach (Post item in this)
            {
                ergebnis += item.Rating;
            }

            return ergebnis;
        }

        public Post this[Post "TextPost 6"]
        {
            get
            {
                if (!posts.Contains("TextPost 6"))
                {
                    return null;
                }
                else
                {
                    return posts["TextPost 6"]?.Html;
                }
            }
        }
            
    }
}
