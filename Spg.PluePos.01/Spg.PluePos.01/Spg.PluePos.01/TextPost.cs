using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spg.PluePos._01
{
    public class TextPost : Post
    {
        public string? Content { get; set; }

        public int Length
        {
            get { return Content?.Length ?? 0; }
        }


        public override string Html
        {
            get
            {
                if (Content == null)
                {
                    throw new ArgumentNullException("Content war NULL!");
                }
                else
                {
                    return $"<h1>{Title}</h1><p>{Content}</p>";
                }
            }
        }

        public TextPost(string _title, string _content) : base(_title)
        {
            Content = _content;
        }

        public TextPost(string title) : base(title)
        {

        }

        public override string ToString()
        {
            return $"{Html}";
        }

    }
}
